using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveComFramework;
using EveComFramework.Core;
using EveComFramework.Move;
using EveComFramework.Cargo;
using EveComFramework.Security;
using EveComFramework.AutoModule;
using EveComFramework.Targets;
using EveCom;
using LavishScriptAPI;


namespace Salvager
{
    #region Settings

    internal class Settings : Settings
    {
        public int CargoThreshold = 80;
        public int MinimumBookmarkAge = 4;
        public bool WarpToAnom = false;
        public bool BookmarkSalvage = true;
        public string BookmarkSubstring = "Salvage:";
        public string DropoffBookmark = "";
        public IList<string> AnomQueue;

    }

    #endregion

    class Core : State
    {
        #region Instantiation

        static Core _Instance;
        public static Core Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Core();
                }
                return _Instance;
            }
        }

        private Core() : base()
        {
            Rats = new Targets();
            Rats.AddPriorityTargets();
            Rats.AddNPCs();
            Rats.AddTargetingMe();
            NonFleetPlayers = new Targets();
            NonFleetPlayers.AddNonFleetPlayers();
            Loot = new Targets();
            Loot.AddQuery(a => (a.GroupID == Group.Wreck || a.GroupID == Group.CargoContainer) && a.HaveLootRights);
            UsedAnomalies = new List<SystemScanResult>();
            DefaultFrequency = 500;
            LavishScript.Commands.AddCommand("Salvager", SalvageCommand);
        }

        #endregion

        #region Variables

        public Settings Config = new Settings();
        public Logger Console = new Logger();
        Cargo Cargo = Cargo.Instance;
        Move Move = Move.Instance;
        Salvaging salvaging = Salvaging.Instance;
        List<SystemScanResult> UsedAnomalies;
        Targets Rats;
        Targets NonFleetPlayers;
        Targets Loot;
        string CurrentAnom;
        Dictionary<double, DateTime> GateCooldown = new Dictionary<double, DateTime>();
        List<Bookmark> Blacklist = new List<Bookmark>();
        Bookmark CurrentBookmark;

        #endregion

        #region Actions

        public override void Start()
        {
            if (Idle)
            {
                QueueState(CheckCargoHold);
                QueueState(GoToRattingSystem);
                QueueState(VerifySalvageLocation);
                QueueState(Salvage);
                Console.Log("Salvager started");
            }

        }

        public override void Stop()
        {
            Clear();
            Console.Log("Salvager stopped");
        }

        private int SalvageCommand(string[] args)
        {

            if (args.Length > 1)
            {
                Config.AnomQueue.Add(args[1]);
            }

            return 0;
        }

        private int RemoveBookmark(string[] args)
        {
            if (args.Length > 1)
            {
                using (new EVEFrameLock())
                {
                    Bookmark.All.Where(a => a.ID.ToString() == args[1] && a.CreatorID == Session.CharID).ForEach(a => { Console.Log("Removing bookmark {0}", a.Title); a.Delete(); });
                }
            }

            return 0;
        }

        #endregion

        #region States

        #region Inventory

        bool CheckCargoHold(object[] Params)
        {
            if (Window.PrimaryInvWindow == null)
            {
                Command.OpenInventory.Execute();
                return false;
            }

            try
            {
                if (MyShip.CargoBay.UsedCapacity > MyShip.CargoBay.MaxCapacity * (Config.CargoThreshold * .01))
                {
                    Console.Log("Unload trip required");
                    InsertState(CheckCargoHold);
                    InsertState(Traveling);
                    InsertState(Dropoff);
                    InsertState(PrepareWarp);
                }

            }
            catch
            {
                MyShip.CargoBay.MakeActive();
                return false;
            }


            return true;
        }

        bool Dropoff(object[] Params)
        {
            Cargo.At(Bookmark.All.FirstOrDefault(a => a.Title.Contains(Config.DropoffBookmark))).Unload();
            InsertState(WaitForBookmarks, 5000);
            InsertState(Traveling, 5000);
            return true;
        }

        #endregion

        #region Travel

        bool GoToRattingSystem(object[] Params)
        {
            return true;
        }

        bool PrepareWarp(object[] Params)
        {
            return true;
        }

        bool Traveling(object[] Params)
        {
            if (!Move.Idle || !Cargo.Idle || (Session.InSpace && MyShip.ToEntity.Mode == EntityMode.Warping))
            {
                return false;
            }
            return true;
        }

        bool MoveToNewSalvageLocation(object[] Params)
        {
            // ToDo:  Different ways to get to a salvage location here

            if (Config.BookmarkSalvage)
            {
                GateCooldown = GateCooldown.Where(a => a.Value > DateTime.Now).ToDictionary(a => a.Key, a => a.Value);

                Bookmark NukeBookmark = Bookmark.All.FirstOrDefault(a => a.Title.Contains("Salvage:") && a.Created.AddHours(2) < Session.Now);
                if (NukeBookmark != null)
                {
                    Console.Log("Removing expired bookmark");
                    NukeBookmark.Delete();
                    InsertState(MoveToNewSalvageLocation);
                    InsertState(Blank, 4000);
                    return true;
                }

                Bookmark AvailableBookmark = Bookmark.All.OrderBy(a => a.Created).FirstOrDefault(a => a.Title.Contains(Config.BookmarkSubstring) && !GateCooldown.ContainsKey(a.ID) && a.LocationID == Session.SolarSystemID && a.Created.AddMinutes(Config.MinimumBookmarkAge) < Session.Now);
                if (AvailableBookmark == null)
                {
                    AvailableBookmark = Bookmark.All.OrderBy(a => a.Created).FirstOrDefault(a => a.Title.Contains(Config.BookmarkSubstring) && !GateCooldown.ContainsKey(a.ID) && a.Created.AddMinutes(Config.MinimumBookmarkAge) < Session.Now);
                }

                if (AvailableBookmark != null)
                {
                    CurrentBookmark = AvailableBookmark;
                    Move.Bookmark(AvailableBookmark);
                    InsertState(Traveling, 5000);
                    return true;
                }
                else
                {
                    Cargo.At(Bookmark.All.FirstOrDefault(a => a.Title.Contains(Config.DropoffBookmark))).Unload();
                    InsertState(WaitForBookmarks, 5000);
                    InsertState(Traveling, 5000);
                    return true;
                }
            }

            if (Config.WarpToAnom)
            {
                if (Config.AnomQueue.Count == 0)
                {
                    // ToDo: Go to safe location here
                    return false;
                }

                if (!Session.InSpace)
                {
                    Console.Log("Undocking");
                    Command.CmdExitStation.Execute();
                    InsertState(MoveToNewSalvageLocation);
                    WaitFor(20, () => Session.InSpace);
                    return true;
                }
                InsertState(Traveling, 2000);
                InsertState(WarpToAnom);
                InsertState(PrepareWarp);
                InsertState(Analyze);
            }

            return true;
        }

        bool Analyze(object[] Params)
        {
            bool ForceScan = false;
            if (Params.Count() > 0) { ForceScan = (bool)Params[0]; }

            if (Window.Scanner != null &&
                (Window.Scanner.ScanResults.Count == 0 ||
                ForceScan))
            {
                if (Rats.TargetList.Count > 0)
                {
                    Console.Log("Rats on grid - warping to sun", "r");
                    Entity.All.FirstOrDefault(a => a.GroupID == Group.Sun).WarpTo();
                    InsertState(Analyze);
                    InsertState(Traveling, 2000, ForceScan);
                    return true;
                }

                Console.Log("Performing scan");
                Window.Scanner.Analyze();
                InsertState(Blank, 11000);
                return true;
            }
            else if (Window.Scanner == null)
            {
                Console.Log("Opening scanner");
                ScannerWindow.Open();
                return false;
            }
            return true;
        }

        bool Blank(object[] Params)
        {
            return true;
        }

        bool WarpToAnom(object[] Params)
        {
            SystemScanResult result;

            if (Window.Scanner != null ||
                Window.Scanner.ScanResults != null)
            {
                result = Window.Scanner.ScanResults.FirstOrDefault(a => Config.AnomQueue.Contains(a.ID) && a.Certainty > .99);
                if (result != null)
                {
                    Console.Log("Warping");
                    result.WarpTo();
                    CurrentAnom = result.ID;
                    InsertState(CloseScanner);
                    return true;
                }
            }

            Console.Log("No suitable anomalies found");
            InsertState(Traveling, 2000);
            InsertState(WarpToAnom);
            InsertState(PrepareWarp);
            InsertState(Analyze);
            return true;
        }

        bool CloseScanner(object[] Params)
        {
            if (Window.Scanner != null)
            {
                Console.Log("Closing scanner");
                Window.Scanner.Close();
            }
            return true;
        }



        bool VerifySalvageLocation(object[] Params)
        {
            if (!Session.InSpace)
            {
                InsertState(VerifySalvageLocation);
                InsertState(MoveToNewSalvageLocation);
                InsertState(RefreshBookmarks);
                return true;
            }
            if (Entity.All.FirstOrDefault(a => a.GroupID == Group.WarpGate) != null &&
                CurrentBookmark != null)
            {
                Console.Log("Acceleration gate found.");
                GateCooldown.AddOrUpdate(CurrentBookmark.ID, DateTime.Now.AddMinutes(5));
                InsertState(VerifySalvageLocation);
                InsertState(MoveToNewSalvageLocation);
                InsertState(RefreshBookmarks);
                return true;
            }
            if (Rats.TargetList.Count > 0)
            {
                Console.Log("There are rats on grid");
                InsertState(VerifySalvageLocation);
                InsertState(MoveToNewSalvageLocation);
                InsertState(RefreshBookmarks);
                return true;
            }
            if (NonFleetPlayers.TargetList.Count > 0)
            {
                Console.Log("There are \ar" + NonFleetPlayers.TargetList.Count + "\a-o other players on grid");
                InsertState(VerifySalvageLocation);
                InsertState(MoveToNewSalvageLocation);
                InsertState(RefreshBookmarks);
                return true;
            }
            if (Loot.TargetList.Count(a =>  salvaging.Looting.CanBlacklist.Contains(a)) == 0)
            {
                Console.Log("There is no salvage on grid");
                if (CurrentBookmark != null && CurrentBookmark.Distance < 150000)
                {
                    Blacklist.Add(CurrentBookmark);
                    Console.Log("Removing current bookmark");
                    Console.Log(" " + CurrentBookmark.Title, "-g");
                    CurrentBookmark.Delete();
                }
                InsertState(VerifySalvageLocation);
                InsertState(MoveToNewSalvageLocation);
                InsertState(RefreshBookmarks);
                if (CurrentBookmark != null)
                {
                    Console.Log("Waiting 30 seconds for corp mates bookmark deletion");
                    InsertState(Blank, 30000);
                }
                return true;
            }
            if (Entity.All.Count(a => (a.GroupID == Group.Stargate || a.GroupID == Group.Station || a.GroupID == Group.ControlTower) && a.Distance < 250000) > 0 ||
                Entity.All.Count(a => a.Distance < 250000 && a.OwnerID != Session.CharID) == 0)
            {
                Console.Log("This does not appear to be a salvage location");
                InsertState(VerifySalvageLocation);
                InsertState(MoveToNewSalvageLocation);
                InsertState(RefreshBookmarks);
                return true;
            }

            Console.Log("Verify successful");

            return true;
        }

        #endregion

        #region Salvaging

        bool Salvage(object[] Params)
        {

            if (!Session.InSpace)
            {
                QueueState(CheckCargoHold);
                return true;
            }

            if (MyShip.ToEntity.Mode == EntityMode.Warping)
            {
                return false;
            }

            if (Rats.TargetList.Count > 0)
            {
                QueueState(VerifySalvageLocation);
                return true;
            }

            if (Loot.TargetList.Count(a => !salvaging.Looting.CanBlacklist.Contains(a)) == 0)
            {
                QueueState(FinishedSalvaging);
                QueueState(RefreshBookmarks);
                QueueState(CheckCargoHold);
                QueueState(GoToRattingSystem);
                QueueState(VerifySalvageLocation);
                QueueState(Salvage);
                return true;
            }

            // cargo full check
            double LockRange = Math.Min(MyShip.Modules.Where(a => a.GroupID == Group.TractorBeam).Min(a => a.OptimalRange), MyShip.MaxTargetRange);
            try
            {
                Move.Approach(Loot.TargetList.FirstOrDefault(a => a.Distance > LockRange && !salvaging.Looting.CanBlacklist.Contains(a)), (int)LockRange);
            }
            catch
            {
                InnerSpaceAPI.InnerSpace.Echo("Approach failed");
            }

            return false;
        }

        bool RefreshBookmarks(object[] Params)
        {
            Bookmark.Refresh();

            return true;
        }

        bool WaitForBookmarks(object[] Params)
        {
            Bookmark.Refresh();

            if (Bookmark.All.OrderBy(a => a.Created).FirstOrDefault(a => a.Title.Contains("Salvage:") && !GateCooldown.ContainsKey(a.ID)) == null)
            {
                return false;
            }

            return true;
        }

        bool FinishedSalvaging(object[] Params)
        {
            Config.AnomQueue.Remove(CurrentAnom);
            CurrentAnom = "";

            try
            {
                InnerSpaceAPI.InnerSpace.Echo(CurrentBookmark.Title + " " + CurrentBookmark.Distance + " " + CurrentBookmark.LocationID);
            }
            catch
            {

            }
            if (CurrentBookmark != null && CurrentBookmark.Distance < 150000 && CurrentBookmark.LocationID == Session.SolarSystemID)
            {
                Blacklist.Add(CurrentBookmark);
                LavishScript.ExecuteCommand("relay \"all other\" -event ComBot_RemoveBookmark " + CurrentBookmark.ID);
                LavishScript.ExecuteCommand("echo relay \"all other\" ComBotRemoveBookmark " + CurrentBookmark.ID);
                CurrentBookmark.Delete();
            }
            return true;
        }

        #endregion

        #endregion
    }


    class Salvaging : State
    {
        #region Instantiation

        static Salvaging _Instance;
        public static Salvaging Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Salvaging();
                }
                return _Instance;
            }
        }

        private Salvaging() : base()
        {
            Loot = new Targets();
            Loot.AddQuery(a => (a.GroupID == Group.Wreck || a.GroupID == Group.CargoContainer) && a.HaveLootRights);
            Wrecks = new Targets();
            Wrecks.AddQuery(a => a.GroupID == Group.Wreck && a.HaveLootRights);
            Cans = new Targets();
            Cans.AddQuery(a => a.GroupID == Group.CargoContainer && a.HaveLootRights);
            DefaultFrequency = 500;
        }

        #endregion

        #region Variables

        Targets Loot;
        Targets Wrecks;
        Targets Cans;
        Dictionary<Entity, DateTime> TargetCooldown = new Dictionary<Entity, DateTime>();

        public LootingController Looting = LootingController.Instance;
        TractoringController Tractoring = TractoringController.Instance;
        SalvagingController Salvaging = SalvagingController.Instance;


        #endregion

        #region Actions

        public void Start()
        {
            if (Idle)
            {
                QueueState(Control);
            }

        }

        public void Stop()
        {
            Clear();
            Looting.Stop();
            Tractoring.Stop();
            Salvaging.Stop();
        }

        #endregion

        #region States

        bool Control(object[] Params)
        {

            if (!Session.InSpace || Loot.TargetList.Count == 0 || MyShip.ToEntity.Mode == EntityMode.Warping)
            {
                Looting.Stop();
                Tractoring.Stop();
                Salvaging.Stop();
                return false;
            }

            Looting.Start();
            if (MyShip.Modules.FirstOrDefault(a => a.GroupID == Group.TractorBeam) != null)
            {
                Tractoring.Start();
            }
            if (MyShip.Modules.FirstOrDefault(a => a.GroupID == Group.Salvager) != null)
            {
                Salvaging.Start();
            }

            if (!(Tractoring.Idle && Salvaging.Idle))
            {
                TargetCooldown = TargetCooldown.Where(a => a.Value >= DateTime.Now).ToDictionary(a => a.Key, a => a.Value);
                Loot.LockedAndLockingTargetList.ForEach(a => { TargetCooldown.AddOrUpdate(a, DateTime.Now.AddSeconds(2)); });

                double LockRange = Math.Min(MyShip.Modules.Where(a => a.GroupID == Group.TractorBeam).Min(a => a.OptimalRange), MyShip.MaxTargetRange);
                Entity NewTarget = Wrecks.UnlockedTargetList.FirstOrDefault(a => a.Exists && !TargetCooldown.ContainsKey(a) && a.Distance < LockRange) ?? Cans.UnlockedTargetList.FirstOrDefault(a => a.Exists && !TargetCooldown.ContainsKey(a) && !Looting.CanBlacklist.Contains(a) && a.Distance < LockRange);

                if (Entity.Targets.Count + Entity.Targeting.Count < Me.MaxTargetLocks &&
                    NewTarget != null)
                {
                    NewTarget.LockTarget();
                    TargetCooldown.AddOrUpdate(NewTarget, DateTime.Now.AddSeconds(2));
                    return false;
                }
            }

            return false;
        }



        #endregion
    }

    class SalvagingController : State
    {
        #region Instantiation

        static SalvagingController _Instance;
        public static SalvagingController Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SalvagingController();
                }
                return _Instance;
            }
        }

        private SalvagingController() : base()
        {
            Wrecks = new Targets();
            Wrecks.AddQuery(a => a.GroupID == Group.Wreck && a.HaveLootRights);
            DefaultFrequency = 1000;
        }

        #endregion

        Targets Wrecks;
        Dictionary<Module, DateTime> ModuleCooldown = new Dictionary<Module, DateTime>();

        #region Actions

        public void Start()
        {
            if (Idle)
            {
                QueueState(SalvageState);
            }

        }

        public void Stop()
        {
            Clear();
        }

        #endregion

        #region States

        bool SalvageState(object[] Params)
        {
            ModuleCooldown = ModuleCooldown.Where(a => a.Value >= DateTime.Now).ToDictionary(a => a.Key, a => a.Value);
            double SalvagerRange = MyShip.Modules.Where(a => a.GroupID == Group.Salvager).Min(a => a.OptimalRange);
            Module FreeSalvager = MyShip.Modules.FirstOrDefault(a => a.GroupID == Group.Salvager && !a.IsActive && !a.IsDeactivating && !ModuleCooldown.ContainsKey(a));

            foreach (Entity Target in Wrecks.LockedTargetList.Where(a => a.Exists))
            {
                if (FreeSalvager != null &&
                    Target.Distance < SalvagerRange &&
                    Target.ActiveModules.Count(a => a.GroupID == Group.Salvager) == 0)
                {
                    FreeSalvager.Activate(Target);
                    ModuleCooldown.AddOrUpdate(FreeSalvager, DateTime.Now.AddSeconds(2));
                    return false;
                }
            }

            return false;
        }

        #endregion

    }

    class TractoringController : State
    {
        #region Instantiation

        static TractoringController _Instance;
        public static TractoringController Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TractoringController();
                }
                return _Instance;
            }
        }

        private TractoringController() : base()
        {
            Loot = new Targets();
            Loot.AddQuery(a => (a.GroupID == Group.Wreck || a.GroupID == Group.CargoContainer) && a.HaveLootRights);
            Wrecks = new Targets();
            Wrecks.AddQuery(a => a.GroupID == Group.Wreck && a.HaveLootRights);
            Cans = new Targets();
            Cans.AddQuery(a => a.GroupID == Group.CargoContainer && a.HaveLootRights);
            DefaultFrequency = 1000;
        }

        #endregion

        Targets Loot;
        Targets Wrecks;
        Targets Cans;
        Dictionary<Module, DateTime> ModuleCooldown = new Dictionary<Module, DateTime>();

        #region Actions

        public void Start()
        {
            if (Idle)
            {
                QueueState(TractorState);
            }

        }

        public void Stop()
        {
            Clear();
        }

        #endregion

        #region States

        bool TractorState(object[] Params)
        {
            ModuleCooldown = ModuleCooldown.Where(a => a.Value >= DateTime.Now).ToDictionary(a => a.Key, a => a.Value);
            double TractorRange = MyShip.Modules.Where(a => a.GroupID == Group.TractorBeam).Min(a => a.OptimalRange);
            Module FreeTractor = MyShip.Modules.FirstOrDefault(a => a.GroupID == Group.TractorBeam && !a.IsActive && !a.IsDeactivating && !ModuleCooldown.ContainsKey(a));

            foreach (Entity Target in Loot.LockedTargetList.Where(a => a.Exists))
            {
                if (FreeTractor != null &&
                    Target.Distance >= 2500 &&
                    Target.ActiveModules.Count(a => a.GroupID == Group.TractorBeam) == 0)
                {
                    FreeTractor.Activate(Target);
                    ModuleCooldown.AddOrUpdate(FreeTractor, DateTime.Now.AddSeconds(1));
                    return false;
                }
                if (Target.Distance < 2500 &&
                    Target.ActiveModules.Count(a => a.GroupID == Group.TractorBeam && !a.IsDeactivating) > 0)
                {
                    Target.ActiveModules.FirstOrDefault(a => a.GroupID == Group.TractorBeam).Deactivate();
                    return false;
                }
            }

            return false;
        }

        #endregion

    }

    class LootingController : State
    {
        #region Instantiation

        static LootingController _Instance;
        public static LootingController Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LootingController();
                }
                return _Instance;
            }
        }

        private LootingController() : base()
        {
            Cans = new Targets();
            Cans.AddQuery(a => (a.GroupID == Group.Wreck || a.GroupID == Group.CargoContainer) && a.HaveLootRights && a.Distance < 2500 && !a.IsWreckEmpty);
            DefaultFrequency = 1000;
        }

        #endregion

        Targets Cans;
        public List<Entity> CanBlacklist = new List<Entity>();

        #region Actions

        public void Start()
        {
            if (Idle)
            {
                QueueState(LootState);
            }

        }

        public void Stop()
        {
            Clear();
        }

        #endregion

        #region States

        bool LootState(object[] Params)
        {
            bool StackCargo = false;
            if (Params.Count() > 0) { StackCargo = (bool)Params[0]; }

            if (Window.PrimaryInvWindow == null)
            {
                Command.OpenInventory.Execute();
                return false;
            }

            if (StackCargo)
            {
                MyShip.CargoBay.StackAll();
                InsertState(LootState);
                return true;
            }

            foreach (Entity Target in Cans.TargetList.Where(a => !CanBlacklist.Contains(a)))
            {
                InventoryContainer CanLoot = Target.CanCargo;
                if (CanLoot == null)
                {
                    Target.OpenCargo();
                    return false;
                }
                else
                {
                    if (CanLoot.Items.Count(a => a.IsContraband) > 0)
                    {
                        CanBlacklist.Add(Target);
                        Target.UnlockTarget();
                        return false;
                    }
                    CanLoot.Items.MoveTo(MyShip.CargoBay);
                    InsertState(LootState, -1, true);
                    return true;
                }
            }

            return false;
        }

        #endregion

    }






    static class DictionaryHelper
    {
        public static IDictionary<TKey, TValue> AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }

            return dictionary;
        }
    }
    public static class ForEachExtension
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> method)
        {
            foreach (T item in items)
            {
                method(item);
            }
        }
    }
}
