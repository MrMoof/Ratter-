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
    public partial class Ratter : Form
    {
        RatterSettings Config = new RatterSettings();
        EveComFramework.Security.Security Security = EveComFramework.Security.Security.Instance;

        Core Bot = Core.Instance;

        public Ratter()
        {
            InitializeComponent();
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
            using (new EVEFrameLock())
            {
                TetherPilot.DataSource = Fleet.Members.Where(a => a.ID != Me.CharID).Select(a => a.Name).ToList();
                DropoffBookmark.DataSource = Bookmark.All.Select(a => a.Title).ToList();
                Ammo.DataSource = MyShip.CargoBay.Items.Select(a => a.Type).ToList();
            }
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
            CargoThresholdLabel.Text = String.Format("Dropoff when cargo exceeds {0}%", Config.CargoThreshold);
            AmmoQuantityLabel.Text = string.Format("Fill {0}% of the cargo hold with ammo", Config.AmmoQuantity);
            AmmoTriggerLabel.Text = String.Format("Reload if less than {0}% ammo in cargo hold", Config.AmmoTrigger);

            Tether.Checked = Config.MovementTether;
            Squat.Checked = Config.Squat;
            SpeedTank.Checked = Config.SpeedTank;
            CombatTether.Checked = Config.CombatTether;
            KeepAtRange.Checked = Config.KeepAtRange;

            DropoffBookmark.SelectedItem = Config.DropoffBookmark;
            Ammo.SelectedItem = Config.Ammo;
        }

        private void SecurityConfig_Click(object sender, EventArgs e)
        {
            Security.Configure();
        }

        private void Toggle_Click(object sender, EventArgs e)
        {
            if (Bot.Idle)
            {
                Bot.Start();
            }
            else
            {
                Bot.Stop();
            }
        }

        private void Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Mode = (RatMode)Mode.SelectedItem;
        }

        private void Anomalies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Anomalies = Anomalies.CheckedItems.Cast<string>().ToList();
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
        }

        private void Tether_CheckedChanged(object sender, EventArgs e)
        {
            Config.MovementTether = Tether.Checked;
        }

        private void TetherPilot_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.CombatTetherPilot = TetherPilot.SelectedIndex.ToString();
        }

        private void Squat_CheckedChanged(object sender, EventArgs e)
        {
            Config.Squat = Squat.Checked;
        }

        private void SpeedTank_CheckedChanged(object sender, EventArgs e)
        {
            Config.SpeedTank = SpeedTank.Checked;
        }

        private void CombatTether_CheckedChanged(object sender, EventArgs e)
        {
            Config.CombatTether = CombatTether.Checked;
        }

        private void KeepAtRange_CheckedChanged(object sender, EventArgs e)
        {
            Config.KeepAtRange = KeepAtRange.Checked;
        }

        private void SpeedTankRange_Scroll(object sender, EventArgs e)
        {
            Config.SpeedTankRange = SpeedTankRange.Value;
            SpeedTankRangeLabel.Text = String.Format("Speed tank at {0} km", Config.SpeedTankRange);
        }

        private void TargetSlots_Scroll(object sender, EventArgs e)
        {
            Config.TargetSlots = TargetSlots.Value;
            TargetSlotsLabel.Text = String.Format("Use {0} target for weapons", Config.TargetSlots);
        }

        private void CargoThreshold_Scroll(object sender, EventArgs e)
        {
            Config.CargoThreshold = CargoThreshold.Value;
            CargoThresholdLabel.Text = String.Format("Dropoff when cargo exceeds {0}%", Config.CargoThreshold);
        }

        private void DropoffBookmarkFilter_TextChanged(object sender, EventArgs e)
        {
            using (new EVEFrameLock())
            {
                DropoffBookmark.DataSource = Bookmark.All.Where(a => a.Title.Contains(DropoffBookmarkFilter.Text)).Select(a => a.Title).ToList();
            }
        }

        private void DropoffBookmark_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.DropoffBookmark = DropoffBookmark.SelectedItem.ToString();
        }

        private void AmmoFilter_TextChanged(object sender, EventArgs e)
        {
            using (new EVEFrameLock())
            {
                Ammo.DataSource = MyShip.CargoBay.Items.Where(a => a.Type.Contains(AmmoFilter.Text)).Select(a => a.Type).ToList();
            }
        }

        private void Ammo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Ammo = Ammo.SelectedItem.ToString();
        }

        private void AmmoQuantity_Scroll(object sender, EventArgs e)
        {
            Config.AmmoQuantity = AmmoQuantity.Value;
            AmmoQuantityLabel.Text = string.Format("Fill {0}% of the cargo hold with ammo", Config.AmmoQuantity);
        }

        private void AmmoTrigger_Scroll(object sender, EventArgs e)
        {
            Config.AmmoTrigger = AmmoTrigger.Value;
            AmmoTriggerLabel.Text = String.Format("Reload if less than {0}% ammo in cargo hold", Config.AmmoTrigger);
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
        internal int CargoThreshold = 90;
        internal int WarpDistance = 0;
        internal int SpeedTankRange = 20;
        internal int TargetSlots = 1;
        internal int AmmoQuantity = 90;
        internal int AmmoTrigger = 10;
        internal RatMode Mode = RatMode.Belt;
        internal bool Squat = false;
        internal bool SpeedTank = false;
        internal bool KeepAtRange = false;
        internal bool MovementTether = false;
        internal bool CombatTether = false;
        internal string CombatTetherPilot = "";
        internal string DropoffBookmark = "";
        internal string Ammo = "";
        internal List<string> Anomalies = new List<string> 
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
}
