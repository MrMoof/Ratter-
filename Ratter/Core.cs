﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveComFramework;
using EveComFramework.Core;
using EveComFramework.Move;
using EveComFramework.Cargo;
using EveComFramework.Security;
using EveComFramework.AutoModule;
using EveComFramework.DroneControl;
using EveComFramework.Targets;
using EveCom;



namespace Ratter
{

    #region Settings

    internal class RatterSettings : EveComFramework.Core.Settings
    {
        public int CargoThreshold = 90;
        public int WarpDistance = 0;
        public int SpeedTankRange = 20;
        public int TargetSlots = 1;
        public int AmmoQuantity = 90;
        public int AmmoTrigger = 10;
        public RatMode Mode = RatMode.Belt;
        public bool Squat = false;
        public bool SpeedTank = false;
        public bool KeepAtRange = false;
        public bool MovementTether = false;
        public bool CombatTether = false;
        public string CombatTetherPilot = "";
        public string DropoffBookmark = "";
        public string Ammo = "";
        public Settings.SerializableDictionary<string, bool> Anomalies = new Settings.SerializableDictionary<string, bool> 
        {
            {"Sanctum", true},
            {"Drone Horde", true},
            {"Haven", true},
            {"Drone Patrol", true},
            {"Forlorn Hub", true},
            {"Forlorn Drone Squad", true},
            {"Forsaken Hub", true},
            {"Forsaken Drone Squad", true},
            {"Hidden Hub", true},
            {"Hidden Drone Squad", true},
            {"Hub", true},
            {"Drone Squad", true},
            {"Port", true},
            {"Drone Herd", true},
            {"Forlorn Rally Point", true},
            {"Forlorn Drone Menagerie", true},
            {"Forsaken Rally Point", true},
            {"Forsaken Drone Menagerie", true},
            {"Hidden Rally Point", true},
            {"Hidden Drone Menagerie", true},
            {"Rally Point", true},
            {"Drone Menagerie", true},
            {"Yard", true},
            {"Drone Surveillance", true},
            {"Forlorn Den", true},
            {"Forlorn Drone Gathering", true},
            {"Forsaken Den", true},
            {"Forsaken Drone Gathering", true},
            {"Hidden Den", true},
            {"Hidden Drone Gathering", true},
            {"Den", true},
            {"Drone Gathering", true},
            {"Refuge", true},
            {"Drone Assembly", true},
            {"Burrow", true},
            {"Drone Collection", true},
            {"Forlorn Hideaway", true},
            {"Forlorn Drone Cluster", true},
            {"Forsaken Hideaway", true},
            {"Forsaken Drone Cluster", true},
            {"Hidden Hideaway", true},
            {"Hidden Drone Cluster", true},
            {"Hideaway", true},
            {"Drone Cluster", true}
        };
    }

    #endregion

    class UIData : State
    {
        #region Instantiation

        static UIData _Instance;
        public static UIData Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UIData();
                }
                return _Instance;
            }
        }

        private UIData() : base()
        {
            QueueState(Update);
        }

        #endregion

        #region Variables

        public List<string> Bookmarks { get; set; }
        public List<string> FleetMembers { get; set; }
        public List<string> Cargo { get; set; }
        public string CharacterName { get; set; }

        #endregion

        #region States

        bool Update(object[] Params)
        {
            if (!Session.Safe || (!Session.InStation && !Session.InSpace)) return false;
            Bookmarks = Bookmark.All.Select(a => a.Title).ToList();
            FleetMembers = Fleet.Members.Select(a => a.Name).ToList();
            Cargo = MyShip.CargoBay.Items.Select(a => a.Type).ToList();
            CharacterName = Me.Name;
            return false;
        }

        #endregion
    }
    
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
            
            Rats.AddPriorityTargets();
            Rats.AddNPCs();
            Rats.AddTargetingMe();

            Rats.Ordering = new RatComparer();
            NonFleetPlayers.AddNonFleetPlayers();
            Wrecks.AddQuery(a => a.GroupID == Group.Wreck && a.HaveLootRights);
            DefaultFrequency = 500;
        }

        #endregion

        #region Variables

        public Logger Console = new Logger();
        public Move Move = Move.Instance;
        public Cargo Cargo = Cargo.Instance;

        public RatterSettings Config = new RatterSettings();
        public Security Security = Security.Instance;
        public AutoModule AutoModule = AutoModule.Instance;
        public DroneControl DroneControl = DroneControl.Instance;

        List<SystemScanResult> UsedAnomalies = new List<SystemScanResult>();
        Entity FirstWreck;
        Entity SpeedTank;
        EveComFramework.Targets.Targets Rats = new EveComFramework.Targets.Targets();
        EveComFramework.Targets.Targets NonFleetPlayers = new EveComFramework.Targets.Targets();
        EveComFramework.Targets.Targets Wrecks = new EveComFramework.Targets.Targets();
        Entity ActiveTarget;
        string CurrentAnomaly = "";
        Dictionary<Entity, DateTime> TargetCooldown = new Dictionary<Entity, DateTime>();

        #endregion

        #region Actions

        public void Start()
        {
            if (Idle)
            {
                AutoModule.Start();
                Security.Start();
                DroneControl.Start();
                QueueState(CheckCargoHold);
                Security.Alert += Alert;
            }

        }


        public void Stop()
        {
            AutoModule.Stop();
            Security.Stop();
            DroneControl.Stop();
            Security.Alert -= Alert;
            Clear();
        }

        void Alert(EveComFramework.Security.FleeTrigger Trigger)
        {
            Clear();
            Cargo.Clear();
            Move.Clear();
            Security.Flee();
            QueueState(SecurityWait, -1, Trigger);
        }

        #endregion

        #region States

        bool SecurityWait(object[] Params)
        {
            FleeTrigger Trigger = (FleeTrigger)Params[0];
            if (Security.CurState != null && Security.CurState.ToString() == "CheckSafe")
            {
                AutoModule.Start();
                Security.Start();
                DroneControl.Start();
                QueueState(CheckCargoHold);
                return true;
            }
            if (Security.CurState != null && Security.CurState.ToString() == "Blank")
            {
                return false;
            }
            if (!Security.Idle)
            {
                return false;
            }
            switch (Trigger)
            {
                case FleeTrigger.NegativeStanding:
                case FleeTrigger.NeutralStanding:
                case FleeTrigger.Pod:
                case FleeTrigger.Targeted:
                    Console.Log("Performing wait after flee");
                    Security.Reset();
                    break;
                case FleeTrigger.ArmorLow:
                case FleeTrigger.CapacitorLow:
                case FleeTrigger.ShieldLow:
                    Console.Log("Resetting from cap/armor/shield flee");
                    Security.Reset(1);
                    break;
            }
            return false;
        }

        #region Inventory

        public bool TemporaryIsPrimedCheck(InventoryContainer Cont)
        {
            try
            {
                double test = Cont.UsedCapacity;
            }
            catch
            {
                return false;
            }
            return true;
        }

        bool CheckCargoHold(object[] Params)
        {
            if (MyShip.CargoBay == null)
            {
                Console.Log("Opening inventory");
                Command.OpenInventory.Execute();
                return false;
            }

            if (!TemporaryIsPrimedCheck(MyShip.CargoBay))
            {
                Console.Log("Activating CargoBay");
                MyShip.CargoBay.MakeActive();
                return false;
            }

            
            if (MyShip.CargoBay.UsedCapacity > MyShip.CargoBay.MaxCapacity * (Config.CargoThreshold / 100) ||
                (Config.Ammo != "" && MyShip.CargoBay.Items.FirstOrDefault(a => a.Type == Config.Ammo) != null && MyShip.CargoBay.Items.FirstOrDefault(a => a.Type == Config.Ammo).Volume * MyShip.CargoBay.Items.FirstOrDefault(a => a.Type == Config.Ammo).Quantity / MyShip.CargoBay.MaxCapacity * 100 < Config.AmmoTrigger))
            {
                Console.Log("Dropoff required");
                QueueState(PrepareWarp);
                QueueState(Dropoff);
                QueueState(Traveling);
                QueueState(CheckCargoHold);
                return true;
            }

            QueueState(PrepareWarp);
            QueueState(GoToRattingSystem);
            QueueState(Traveling);
            QueueState(Reload);
            QueueState(VerifyRatLocation);
            QueueState(WaitForHostiles);
            QueueState(Rat);
            return true;
        }

        bool Dropoff(object[] Params)
        {
            Cargo.At(Bookmark.All.FirstOrDefault(a => a.Title == Config.DropoffBookmark), () => MyShip.CargoBay).Unload();
            if (Config.Ammo != "")
            {
                Cargo.At(Bookmark.All.FirstOrDefault(a => a.Title == Config.DropoffBookmark), () => Station.ItemHangar).Load(item => item.Type == Config.Ammo);
            }
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

        bool MoveToNewRatLocation(object[] Params)
        {
            // ToDo:  Different ways to get to a ratting location here

            if (!Session.InSpace)
            {
                Console.Log("Undocking");
                Command.CmdExitStation.Execute();
                InsertState(MoveToNewRatLocation);
                WaitFor(20, () => Session.InSpace);
                return true;
            }

            if (Config.MovementTether)
            {
                Fleet.Members.FirstOrDefault(a => a.Name == Config.CombatTetherPilot).WarpTo(Config.WarpDistance);
                InsertState(Traveling, 2000);
                InsertState(Reload);
                InsertState(PrepareWarp);
                return true;
            }

            if (Config.Mode == RatMode.Anomaly)
            {
                InsertState(Traveling, 2000);
                InsertState(WarpToAnom, 11000);
                InsertState(Reload);
                InsertState(PrepareWarp);
                InsertState(Analyze);

                return true;
            }

            return true;
        }

        bool Analyze(object[] Params)
        {
            if (Window.Scanner != null)
            {
                Console.Log("Scanning");
                Window.Scanner.Analyze();
                return true;
            }
            else
            {
                Console.Log("Opening scan window");
                ScannerWindow.Open();
                return false;
            }
        }

        bool WarpToAnom(object[] Params)
        {
            SystemScanResult result;

            if (Window.Scanner != null ||
                Window.Scanner.ScanResults != null)
            {
                foreach (string type in Config.Anomalies.Where(i => i.Value).Select(i => i.Key))
                {
                    result = Window.Scanner.ScanResults.FirstOrDefault(a => a.DungeonName.Contains(type) && !UsedAnomalies.Contains(a) && a.Certainty > .99);
                    if (result != null)
                    {
                        if (Session.InFleet && Fleet.Members.First(member => member.ID == Me.CharID).Role != FleetRole.SquadMember)
                        {
                            Console.Log("Warping fleet to {0} [{1}] ({2})", result.DungeonName, result.ID, Config.WarpDistance);
                            result.WarpFleetTo(Config.WarpDistance * 1000);
                        }
                        else
                        {
                            Console.Log("Warping to {0} [{1}] ({2})", result.DungeonName, result.ID, Config.WarpDistance);
                            result.WarpTo(Config.WarpDistance * 1000);
                        }
                        InsertState(CloseScanner);
                        return true;
                    }
                }
                UsedAnomalies.Clear();
            }

            InsertState(Traveling, 2000);
            InsertState(WarpToAnom, 12000);
            InsertState(PrepareWarp);
            InsertState(Analyze);
            return true;
        }

        bool CloseScanner(object[] Params)
        {
            if (Window.Scanner != null)
            {
                Console.Log("Closing scan window");
                Window.Scanner.Close();
            }
            return true;
        }



        bool VerifyRatLocation(object[] Params)
        {
            if (!Session.InSpace)
            {
                Console.Log("Undocking");
                Command.CmdExitStation.Execute();
                InsertState(VerifyRatLocation);
                WaitFor(20, () => Session.InSpace);
                return true;
            }
            if (NonFleetPlayers.TargetList.Count > 0)
            {
                Console.Log("Non fleet members on overview");
                InsertState(VerifyRatLocation);
                InsertState(MoveToNewRatLocation);
                return true;
            }
            if (Entity.All.Count(a => (a.GroupID == Group.Stargate || a.GroupID == Group.Station || a.GroupID == Group.ControlTower) && a.Distance < 250000) > 0 ||
                Entity.All.Count(a => a.Distance < 250000 && a.OwnerID != Session.CharID) == 0)
            {
                Console.Log("This isn't a ratting location");
                InsertState(VerifyRatLocation);
                InsertState(MoveToNewRatLocation);
                return true;
            }
            if (Rats.TargetList.FirstOrDefault() == null)
            {
                Console.Log("No rats here");
                InsertState(VerifyRatLocation);
                InsertState(MoveToNewRatLocation);
                return true;
            }

            return true;
        }

        #endregion

        #region Combat

        bool Reload(object[] Params)
        {
            if (!Session.InSpace)
            {
                return true;
            }
            Console.Log("Reloading ammo");
            Command.CmdReloadAmmo.Execute();
            return true;
        }

        bool WaitForHostiles(object[] Params)
        {
            Console.Log("Waiting 60 seconds for hostiles");
            int WaitLength = 60000;
            if (Params.Count() > 0) { WaitLength = (int)Params[0]; }
            bool SecondCycle = false;
            if (Params.Count() > 1) { SecondCycle = (bool)Params[1]; }

            if (Rats.TargetList.Count == 0)
            {
                if (SecondCycle)
                {
                    InsertState(WaitForHostiles);
                    InsertState(VerifyRatLocation);
                    InsertState(MoveToNewRatLocation);
                    InsertState(PrepareWarp);
                }
                else
                {
                    InsertState(WaitForHostiles, -1, WaitLength, true);
                    WaitFor(WaitLength / CurState.Frequency, () => Rats.TargetList.Count > 0);
                }
            }
            return true;
        }

        bool Rat(object[] Params)
        {

            if (!Session.InSpace)
            {
                QueueState(CheckCargoHold);
                return true;
            }

            if (MyShip.ToEntity.Mode == EntityMode.Warping)
            {
                FirstWreck = null;
                return false;
            }

            if (Rats.TargetList.Count == 0 && !DroneControl.Busy.IsBusy)
            {
                QueueState(RefreshBookmarks);
                QueueState(FinishedRatting);
                QueueState(CheckCargoHold);
                return true;
            }


            // Ammo and cargo full check


            #region Squat

            if (Config.Squat)
            {
                InnerSpaceAPI.InnerSpace.Echo("Squat");
                if (FirstWreck == null || !FirstWreck.Exists)
                {
                    InnerSpaceAPI.InnerSpace.Echo("New wreck");
                    FirstWreck = Entity.All.FirstOrDefault(a => a.GroupID == Group.Wreck);
                }
                else if (!Config.SpeedTank)
                {
                    InnerSpaceAPI.InnerSpace.Echo("Move: " + FirstWreck.Name);
                    Move.Approach(FirstWreck, Config.SpeedTankRange * 1000);
                }
            }

            #endregion

            #region SpeedTank

            if (Config.Squat && Config.SpeedTank && FirstWreck != null && FirstWreck.Exists)
            {
                Move.Orbit(FirstWreck, Config.SpeedTankRange * 1000);
            }
            else if (Config.SpeedTank && SpeedTank != null && SpeedTank.Exists)
            {
                if (!Config.CombatTether && ActiveTarget != null && SpeedTank != ActiveTarget)
                {
                    SpeedTank = ActiveTarget;
                }

                if (Config.KeepAtRange)
                {
                    Move.Approach(SpeedTank, Config.SpeedTankRange * 1000);
                }
                else
                {
                    Move.Orbit(SpeedTank, Config.SpeedTankRange * 1000);
                }
            }
            else
            {
                if (Config.CombatTether)
                {
                    InnerSpaceAPI.InnerSpace.Echo("Combattether");
                    SpeedTank = Entity.All.FirstOrDefault(a => a.Name == Config.CombatTetherPilot);
                }
                else if (ActiveTarget != null)
                {
                    SpeedTank = ActiveTarget;
                }
                else if (Rats.TargetList.Count() > 0)
                {
                    SpeedTank = Rats.TargetList.OrderBy(a => a.Distance).FirstOrDefault();
                }
            }

            #endregion

            #region LockManagement

            TargetCooldown = TargetCooldown.Where(a => a.Value >= DateTime.Now).ToDictionary(a => a.Key, a => a.Value);
            Rats.LockedAndLockingTargetList.ForEach(a => { TargetCooldown.AddOrUpdate(a, DateTime.Now.AddSeconds(2)); });
            Entity NewTarget = Rats.UnlockedTargetList.FirstOrDefault(a => !a.Exploded && !TargetCooldown.ContainsKey(a) && a.Distance < MyShip.MaxTargetRange);
            if (Rats.LockedAndLockingTargetList.Count < Config.TargetSlots &&
                NewTarget != null &&
                Entity.All.FirstOrDefault(a => a.IsJamming && a.IsTargetingMe) == null)
            {
                Console.Log("Locking {0}", NewTarget.Name);
                TargetCooldown.AddOrUpdate(NewTarget, DateTime.Now.AddSeconds(2));
                NewTarget.LockTarget();
                return false;
            }

            #endregion

            if (ActiveTarget != null && ActiveTarget.Exists && !ActiveTarget.Exploded)
            {
                if (ActiveTarget.LockedTarget)
                {
                    if (MyShip.Modules.Any(a => a.GroupID == Group.StasisWeb && !a.IsActive && !a.IsDeactivating && !a.IsReloading && a.MaxRange > ActiveTarget.Distance))
                    {
                        MyShip.Modules.Where(a => a.GroupID == Group.StasisWeb && !a.IsActive && !a.IsDeactivating && !a.IsReloading && a.MaxRange > ActiveTarget.Distance).ForEach(a => a.Activate(ActiveTarget));
                        return false;
                    }
                    if (MyShip.Modules.Any(a => a.GroupID == Group.TargetPainter && !a.IsActive && !a.IsDeactivating && !a.IsReloading && a.MaxRange > ActiveTarget.Distance))
                    {
                        MyShip.Modules.Where(a => a.GroupID == Group.TargetPainter && !a.IsActive && !a.IsDeactivating && !a.IsReloading && a.MaxRange > ActiveTarget.Distance).ForEach(a => a.Activate(ActiveTarget));
                        return false;
                    }
                    if (MyShip.Modules.Any(a => a.GroupID == Group.MissileLauncherHeavy && !a.IsActive && !a.IsDeactivating && !a.IsReloading))
                    {
                        MyShip.Modules.Where(a => a.GroupID == Group.MissileLauncherHeavy && !a.IsActive && !a.IsDeactivating && !a.IsReloading).ForEach(a => a.Activate(ActiveTarget));
                        return false;
                    }
                    if (MyShip.Modules.Any(a => a.GroupID == Group.MissileLauncherHeavyAssault && !a.IsActive && !a.IsDeactivating && !a.IsReloading))
                    {
                        MyShip.Modules.Where(a => a.GroupID == Group.MissileLauncherHeavyAssault && !a.IsActive && !a.IsDeactivating && !a.IsReloading).ForEach(a => a.Activate(ActiveTarget));
                        return false;
                    }
                    if (MyShip.Modules.Any(a => a.GroupID == Group.MissileLauncherCruise && !a.IsActive && !a.IsDeactivating && !a.IsReloading))
                    {
                        MyShip.Modules.Where(a => a.GroupID == Group.MissileLauncherCruise && !a.IsActive && !a.IsDeactivating && !a.IsReloading).ForEach(a => a.Activate(ActiveTarget));
                        return false;
                    }
                    if (MyShip.Modules.Any(a => a.GroupID == Group.MissileLauncherTorpedo && !a.IsActive && !a.IsDeactivating && !a.IsReloading))
                    {
                        MyShip.Modules.Where(a => a.GroupID == Group.MissileLauncherTorpedo && !a.IsActive && !a.IsDeactivating && !a.IsReloading).ForEach(a => a.Activate(ActiveTarget));
                        return false;
                    }
                    if (MyShip.Modules.Any(a => a.GroupID == Group.HybridWeapon && !a.IsActive && !a.IsDeactivating && !a.IsReloading && a.MaxRange > ActiveTarget.Distance))
                    {
                        MyShip.Modules.Where(a => a.GroupID == Group.HybridWeapon && !a.IsActive && !a.IsDeactivating && !a.IsReloading && a.MaxRange > ActiveTarget.Distance).ForEach(a => a.Activate(ActiveTarget));
                        return false;
                    }
                    if (MyShip.Modules.Any(a => a.GroupID == Group.EnergyWeapon && !a.IsActive && !a.IsDeactivating && !a.IsReloading && a.MaxRange > ActiveTarget.Distance))
                    {
                        MyShip.Modules.Where(a => a.GroupID == Group.EnergyWeapon && !a.IsActive && !a.IsDeactivating && !a.IsReloading && a.MaxRange > ActiveTarget.Distance).ForEach(a => a.Activate(ActiveTarget));
                        return false;
                    }
                }
            }
            else
            {
                ActiveTarget = null;
                if (Rats.LockedAndLockingTargetList.Count > 0)
                {
                    List<double> MaxRanges = MyShip.Modules.Where(a => a.GroupID == Group.HybridWeapon || a.GroupID == Group.EnergyWeapon).Select(a => a.MaxRange).ToList();
                    foreach (double i in MaxRanges)
                    {
                        ActiveTarget = Rats.LockedAndLockingTargetList.FirstOrDefault(a => a.Distance < i);
                        if (ActiveTarget != null)
                        {
                            return false;
                        }
                    }
                    ActiveTarget = Rats.LockedAndLockingTargetList.FirstOrDefault();
                }
            }


            return false;
        }

        bool RefreshBookmarks(object[] Params)
        {
            Bookmark.Refresh();
            return true;
        }
        bool FinishedRatting(object[] Params)
        {
            if (Wrecks.TargetList.Count > 0 &&
                NonFleetPlayers.TargetList.Count == 0 &&
                Rats.TargetList.Count == 0)
            {
            }
            QueueState(CheckCargoHold);
            return true;
        }

        #endregion

        #endregion

    }

    #region Utility classes

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

    #endregion

}
