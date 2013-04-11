using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveComFramework;
using EveCom;

namespace Ratter
{
    class Core : EveComFramework.Core.State
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
            Rats.Ordering = new EveComFramework.Targets.RatComparer();
            NonFleetPlayers.AddNonFleetPlayers();
            Wrecks.AddQuery(a => a.GroupID == Group.Wreck && a.HaveLootRights);
            DefaultFrequency = 500;
        }

        #endregion

        #region Variables

        RatterSettings Config = new RatterSettings();
        EveComFramework.Move.Move Move = EveComFramework.Move.Move.Instance;
        EveComFramework.Cargo.Cargo Cargo = EveComFramework.Cargo.Cargo.Instance;
        public EveComFramework.Security.Security Security = EveComFramework.Security.Security.Instance;
        public EveComFramework.AutoModule.AutoModule AutoModule = EveComFramework.AutoModule.AutoModule.Instance;

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
                Security.Log.Event += Logger;
                Security.Alert += Alert;
            }

        }

        public void Stop()
        {
            Clear();
        }

        void Logger(string Message)
        {

        }

        void Alert(EveComFramework.Security.FleeTrigger Trigger)
        {

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

            // Todo:  Ammo check


            if (MyShip.CargoBay.UsedCapacity > MyShip.CargoBay.MaxCapacity * (Config.CargoThreshold / 100))
            {
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
            // Todo:  Call Cargo to perform unload
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

            if (Config.MovementTether)
            {
                if (!Session.InSpace)
                {
                    Command.CmdExitStation.Execute();
                    InsertState(MoveToNewRatLocation);
                    WaitFor(20, () => Session.InSpace);
                    return true;
                }
                Fleet.Members.FirstOrDefault(a => a.Name.Contains(Config.CombatTetherPilot)).WarpTo(Config.WarpDistance);
                InsertState(Traveling, 2000);
                InsertState(Reload);
                InsertState(PrepareWarp);
                return true;
            }

            if (Config.Mode == RatMode.Anomaly)
            {
                if (!Session.InSpace)
                {
                    Command.CmdExitStation.Execute();
                    InsertState(MoveToNewRatLocation);
                    WaitFor(20, () => Session.InSpace);
                    return true;
                }
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
                Window.Scanner.Analyze();
                return true;
            }
            else
            {
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
                foreach (string type in Config.Anomalies)
                {
                    result = Window.Scanner.ScanResults.FirstOrDefault(a => a.DungeonName.Contains(type) && !UsedAnomalies.Contains(a) && a.Certainty > .99);
                    if (result != null)
                    {
                        if (Session.InFleet && Fleet.Members.First(member => member.ID == Me.CharID).Role != FleetRole.SquadMember)
                        {
                            result.WarpFleetTo(Config.WarpDistance * 1000);
                        }
                        else
                        {
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
                Window.Scanner.Close();
            }
            return true;
        }



        bool VerifyRatLocation(object[] Params)
        {
            if (!Session.InSpace)
            {
                Command.CmdExitStation.Execute();
                InsertState(VerifyRatLocation);
                WaitFor(20, () => Session.InSpace);
                return true;
            }
            if (NonFleetPlayers.TargetList.Count > 0)
            {
                InsertState(VerifyRatLocation);
                InsertState(MoveToNewRatLocation);
                return true;
            }
            if (Entity.All.Count(a => (a.GroupID == Group.Stargate || a.GroupID == Group.Station || a.GroupID == Group.ControlTower) && a.Distance < 250000) > 0 ||
                Entity.All.Count(a => a.Distance < 250000 && a.OwnerID != Session.CharID) == 0)
            {
                InsertState(VerifyRatLocation);
                InsertState(MoveToNewRatLocation);
                return true;
            }
            if (Rats.TargetList.FirstOrDefault() == null)
            {
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
            Command.CmdReloadAmmo.Execute();
            return true;
        }

        bool WaitForHostiles(object[] Params)
        {
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

            if (Rats.TargetList.Count == 0)
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
                if (FirstWreck == null || !FirstWreck.Exists)
                {
                    FirstWreck = Entity.All.FirstOrDefault(a => a.GroupID == Group.Wreck);
                }
                else if (!Config.SpeedTank)
                {
                    Move.Approach(FirstWreck, 1000);
                }
            }

            #endregion

            #region SpeedTank

            if (Config.Squat && FirstWreck != null && FirstWreck.Exists)
            {
                Move.Orbit(FirstWreck, Config.SpeedTankRange * 1000);
            }
            else if (Config.SpeedTank && SpeedTank != null && SpeedTank.Exists)
            {
                if (ActiveTarget != null && SpeedTank != ActiveTarget)
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
                TargetCooldown.AddOrUpdate(NewTarget, DateTime.Now.AddSeconds(2));
                NewTarget.LockTarget();
                return false;
            }

            #endregion

            if (ActiveTarget != null && ActiveTarget.Exists && !ActiveTarget.Exploded)
            {
                if (MyShip.Modules.Count(a => a.GroupID == Group.MissileLauncherHeavy && !a.IsActive && !a.IsDeactivating && !a.IsReloading) > 0)
                {
                    MyShip.Modules.Where(a => a.GroupID == Group.MissileLauncherHeavy && !a.IsActive && !a.IsDeactivating && !a.IsReloading).ForEach(a => a.Activate(ActiveTarget));
                    return false;
                }
                if (MyShip.Modules.Count(a => a.GroupID == Group.HybridWeapon && !a.IsActive && !a.IsDeactivating && !a.IsReloading) > 0)
                {
                    MyShip.Modules.FirstOrDefault(a => a.GroupID == Group.HybridWeapon && !a.IsActive && !a.IsDeactivating && !a.IsReloading).Activate(ActiveTarget);
                    return false;
                }
            }
            else
            {
                if (Rats.LockedTargetList.Count > 0)
                {
                    ActiveTarget = Rats.LockedTargetList.FirstOrDefault();
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
