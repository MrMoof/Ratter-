using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EveCom;

namespace Ratter
{
    public partial class RatterForm : Form
    {
        RatterSettings Config = new RatterSettings();

        Core Bot = Core.Instance;
        UIData UI = UIData.Instance;


        public RatterForm()
        {
            InitializeComponent();
            
            Core.Instance.Console.Event += Console;
            Core.Instance.DroneControl.Log.Event += Console;
        }


        private void Ratter_Load(object sender, EventArgs e)
        {
            foreach (RatMode m in Enum.GetValues(typeof(RatMode)))
            {
                Mode.Items.Add(m);
            }
            Mode.Text = Config.Mode.ToString();

            for (int i = 0; i <= (Anomalies.Items.Count - 1); i++)
            {
                if (Config.Anomalies.Contains(Anomalies.Items[i].ToString()))
                {
                    Anomalies.SetItemChecked(i, true);
                }
            }
            //using (new EVEFrameLock())
            //{
            //    if (Session.InFleet)
            //    {
            //        TetherPilot.DataSource = Fleet.Members.Where(a => a.ID != Me.CharID).Select(a => a.Name).ToList();
            //    }
            //    DropoffBookmark.DataSource = Bookmark.All.Select(a => a.Title).ToList();
            //    if (MyShip.CargoBay != null)
            //    {
            //        Ammo.DataSource = MyShip.CargoBay.Items.Select(a => a.Type).ToList();
            //    }
            //}
            TetherPilot.Text = Config.CombatTetherPilot;
            
            WarpDistance.Value = Config.WarpDistance;
            SpeedTankRange.Value = Config.SpeedTankRange;
            TargetSlots.Value = Config.TargetSlots;
            CargoThreshold.Value = Config.CargoThreshold;
            AmmoQuantity.Value = Config.AmmoQuantity;
            AmmoTrigger.Value = Config.AmmoTrigger;

            WarpDistanceLabel.Text = String.Format("Warp to {0} km", Config.WarpDistance);
            SpeedTankRangeLabel.Text = String.Format("Speed tank at {0} km", Config.SpeedTankRange);
            TargetSlotsLabel.Text = String.Format("Use {0} target for weapons", Config.TargetSlots);
            CargoThresholdLabel.Text = String.Format("{0}%", Config.CargoThreshold);
            AmmoQuantityLabel.Text = string.Format("Fill {0}% of the cargo hold with ammo", Config.AmmoQuantity);
            AmmoTriggerLabel.Text = String.Format("Reload if less than {0}% ammo in cargo hold", Config.AmmoTrigger);

            Tether.Checked = Config.MovementTether;
            Squat.Checked = Config.Squat;
            SpeedTank.Checked = Config.SpeedTank;
            CombatTether.Checked = Config.CombatTether;
            KeepAtRange.Checked = Config.KeepAtRange;

            DropoffBookmark.Text = Config.DropoffBookmark;
            Ammo.Text = Config.Ammo;
        }

        private void Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Mode = (RatMode)Mode.SelectedItem;
            Config.Save();
        }

        private void Anomalies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Anomalies = Anomalies.CheckedItems.Cast<string>().ToList();
            Config.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Anomalies.SelectedIndex > 0)
            {
                Anomalies.Items.Insert(Anomalies.SelectedIndex - 1, Anomalies.SelectedItem);
                Anomalies.SelectedIndex = (Anomalies.SelectedIndex - 2);
                Anomalies.Items.RemoveAt(Anomalies.SelectedIndex + 2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Anomalies.SelectedIndex != -1 && Anomalies.SelectedIndex < (Anomalies.Items.Count - 1))
            {
                int IndexToRemove = Anomalies.SelectedIndex;
                Anomalies.Items.Insert(Anomalies.SelectedIndex + 2, Anomalies.SelectedItem);
                Anomalies.SelectedIndex = (Anomalies.SelectedIndex + 2);
                Anomalies.Items.RemoveAt(IndexToRemove);
            }
        }

        private void WarpDistance_Scroll(object sender, EventArgs e)
        {
            Config.WarpDistance = WarpDistance.Value;
            WarpDistanceLabel.Text = String.Format("Warp to {0} km", Config.WarpDistance);
            Config.Save();
        }

        private void Tether_CheckedChanged(object sender, EventArgs e)
        {
            Config.MovementTether = Tether.Checked;
            Config.Save();
        }

        private void TetherPilot_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.CombatTetherPilot = TetherPilot.Text;
            Config.Save();
        }

        private void Squat_CheckedChanged(object sender, EventArgs e)
        {
            Config.Squat = Squat.Checked;
            Config.Save();
        }

        private void SpeedTank_CheckedChanged(object sender, EventArgs e)
        {
            Config.SpeedTank = SpeedTank.Checked;
            Config.Save();
        }

        private void CombatTether_CheckedChanged(object sender, EventArgs e)
        {
            Config.CombatTether = CombatTether.Checked;
            Config.Save();
        }

        private void KeepAtRange_CheckedChanged(object sender, EventArgs e)
        {
            Config.KeepAtRange = KeepAtRange.Checked;
            Config.Save();
        }

        private void SpeedTankRange_Scroll(object sender, EventArgs e)
        {
            Config.SpeedTankRange = SpeedTankRange.Value;
            SpeedTankRangeLabel.Text = String.Format("Speed tank at {0} km", Config.SpeedTankRange);
            Config.Save();
        }

        private void TargetSlots_Scroll(object sender, EventArgs e)
        {
            Config.TargetSlots = TargetSlots.Value;
            TargetSlotsLabel.Text = String.Format("Use {0} target for weapons", Config.TargetSlots);
            Config.Save();
        }

        private void CargoThreshold_Scroll(object sender, EventArgs e)
        {
            Config.CargoThreshold = CargoThreshold.Value;
            CargoThresholdLabel.Text = String.Format("{0}%", Config.CargoThreshold);
            Config.Save();
        }

        private void DropoffBookmarkFilter_TextChanged(object sender, EventArgs e)
        {
            Config.DropoffBookmark = DropoffBookmark.Text;
            //using (new EVEFrameLock())
            //{
            //    DropoffBookmark.DataSource = Bookmark.All.Where(a => a.Title.Contains(DropoffBookmarkFilter.Text)).Select(a => a.Title).ToList();
            //}
            Config.Save();
        }

        private void DropoffBookmark_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Config.DropoffBookmark = DropoffBookmark.SelectedItem.ToString();
            //Config.Save();
        }

        private void AmmoFilter_TextChanged(object sender, EventArgs e)
        {
            Config.Ammo = Ammo.Text;
            //using (new EVEFrameLock())
            //{
            //    Ammo.DataSource = MyShip.CargoBay.Items.Where(a => a.Type.Contains(AmmoFilter.Text)).Select(a => a.Type).ToList();
            //}
            Config.Save();
        }

        private void Ammo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Config.Ammo = Ammo.SelectedItem.ToString();
            //Config.Save();
        }

        private void AmmoQuantity_Scroll(object sender, EventArgs e)
        {
            Config.AmmoQuantity = AmmoQuantity.Value;
            AmmoQuantityLabel.Text = string.Format("Fill {0}% of the cargo hold with ammo", Config.AmmoQuantity);
            Config.Save();
        }

        private void AmmoTrigger_Scroll(object sender, EventArgs e)
        {
            Config.AmmoTrigger = AmmoTrigger.Value;
            AmmoTriggerLabel.Text = String.Format("Reload if less than {0}% ammo in cargo hold", Config.AmmoTrigger);
            Config.Save();
        }

        private void SecurityConfig_Click(object sender, EventArgs e)
        {
            Core.Instance.Security.Configure();
        }

        private void AutoModuleConfig_Click(object sender, EventArgs e)
        {
            Core.Instance.AutoModule.Configure();
        }

        delegate void SetConsole(string Message);

        void Console(string Message)
        {
            if (listConsole.InvokeRequired)
            {
                listConsole.BeginInvoke(new SetConsole(Console), Message);
            }
            else
            {
                listConsole.Items.Add(Message);
            }
        }

        private void DroneControlConfig_Click(object sender, EventArgs e)
        {
            Core.Instance.DroneControl.Configure();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (UI.FleetMembers.Any()) TetherPilot.AutoCompleteCustomSource = new MyAutoCompleteStringCollection(UI.FleetMembers);
            if (UI.Bookmarks.Any()) DropoffBookmark.AutoCompleteCustomSource = new MyAutoCompleteStringCollection(UI.Bookmarks);
            if (UI.Cargo.Any()) Ammo.AutoCompleteCustomSource = new MyAutoCompleteStringCollection(UI.Cargo);
        }

        private void Toggle_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle.Checked)
            {
                Bot.Start();
            }
            else
            {
                Bot.Stop();
            }
        }


    }

    #region Enums

    internal enum RatMode
    {
        Anomaly,
        Bookmark,
        Belt,
        Dumb
    }

    #endregion

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
        public List<string> Anomalies = new List<string> 
        {
            "Sanctum",
            "Drone Horde",
            "Haven",
            "Drone Patrol",
            "Forlorn Hub",
            "Forlorn Drone Squad",
            "Forsaken Hub",
            "Forsaken Drone Squad",
            "Hidden Hub",
            "Hidden Drone Squad",
            "Hub",
            "Drone Squad",
            "Port",
            "Drone Herd",
            "Forlorn Rally Point",
            "Forlorn Drone Menagerie",
            "Forsaken Rally Point",
            "Forsaken Drone Menagerie",
            "Hidden Rally Point",
            "Hidden Drone Menagerie",
            "Rally Point",
            "Drone Menagerie",
            "Yard",
            "Drone Surveillance",
            "Forlorn Den",
            "Forlorn Drone Gathering",
            "Forsaken Den",
            "Forsaken Drone Gathering",
            "Hidden Den",
            "Hidden Drone Gathering",
            "Den",
            "Drone Gathering",
            "Refuge",
            "Drone Assembly",
            "Burrow",
            "Drone Collection",
            "Forlorn Hideaway",
            "Forlorn Drone Cluster",
            "Forsaken Hideaway",
            "Forsaken Drone Cluster",
            "Hidden Hideaway",
            "Hidden Drone Cluster",
            "Hideaway",
            "Drone Cluster"
        };
    }

    #endregion

    public class MyAutoCompleteStringCollection : AutoCompleteStringCollection
    {
        public MyAutoCompleteStringCollection(List<String> items)
        {
            this.AddRange(items.ToArray());
        }
    }
}
