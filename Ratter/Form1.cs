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
        EveComFramework.Security.Security Security = new EveComFramework.Security.Security();

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
