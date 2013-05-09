using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EveCom;
using EveComFramework.Core;


namespace Ratter
{
    public partial class RatterForm : Form
    {
        Core Bot = Core.Instance;
        RatterSettings Config = Core.Instance.Config;
        UIData UI = UIData.Instance;
        Color CurrentBackColor = Color.Black;

        public RatterForm()
        {
            InitializeComponent();
            
            Core.Instance.Console.Event += Console;
            Core.Instance.DroneControl.Log.Event += Console;
            Core.Instance.Security.Log.Event += Console;
            Core.Instance.Move.Log.Event += Console;
            Core.Instance.Cargo.Log.Event += Console;
            Core.Instance.Config.Updated += LoadSettings;
        }

        private void LoadSettings()
        {
            foreach (RatMode m in Enum.GetValues(typeof(RatMode)))
            {
                Mode.Items.Add(m);
            }
            Mode.Text = Config.Mode.ToString();

            foreach (KeyValuePair<string, bool> i in Config.Anomalies)
            {
                ListViewItem temp = Anomalies.Items.Add(i.Key);
                temp.Checked = i.Value;
            }

            TetherPilot.Text = Config.CombatTetherPilot;

            WarpDistance.Value = Config.WarpDistance;
            SpeedTankRange.Value = Config.SpeedTankRange;
            TargetSlots.Value = Config.TargetSlots;
            LastPrimary.Checked = Config.LastPrimary;
            RandomMidPrimary.Checked = Config.RandomMidPrimary;
            FirstPrimary.Checked = Config.FirstPrimary;
            RandomPrimary.Checked = Config.RandomPrimary;
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
            lblCurrentProfile.Text = EveComFramework.Core.Config.Instance.DefaultProfile;
        }

        private void Ratter_Load(object sender, EventArgs e)
        {
            LoadSettings();
            listProfiles.DataSource = Directory.GetFiles(Config.ConfigDirectory).Select(Path.GetFileNameWithoutExtension).ToList();
            Anomalies.ItemChecked += Anomalies_ItemChecked;
        }

        private void Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Mode = (RatMode)Mode.SelectedItem;
            Config.Save();
        }

        private void Anomalies_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Config.Anomalies = Anomalies.CheckedItems.Cast<string>().ToList();
            //Config.Save();
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

        private void LastPrimary_CheckedChanged(object sender, EventArgs e)
        {
            Config.LastPrimary = LastPrimary.Checked;
            Config.Save();
        }

        private void RandomMidPrimary_CheckedChanged(object sender, EventArgs e)
        {
            Config.RandomMidPrimary = RandomMidPrimary.Checked;
            Config.Save();
        }

        private void FirstPrimary_CheckedChanged(object sender, EventArgs e)
        {
            Config.FirstPrimary = FirstPrimary.Checked;
            Config.Save();
        }

        private void RandomPrimary_CheckedChanged(object sender, EventArgs e)
        {
            Config.RandomPrimary = RandomPrimary.Checked;
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
            if (richConsole.InvokeRequired)
            {
                richConsole.BeginInvoke(new SetConsole(Console), Message);
            }
            else
            {
                richConsole.SelectionColor = Color.White;
                richConsole.SelectionBackColor = CurrentBackColor;
                if (CurrentBackColor == Color.Black)
                {
                    CurrentBackColor = Color.FromArgb(50,50,50);
                }
                else
                {
                    CurrentBackColor = Color.Black;
                }
                Queue<char> StringReader = new Queue<char>(Message);
                while (StringReader.Any())
                {
                    char a = StringReader.Dequeue();
                    if (a == '|')
                    {
                        char color = StringReader.Dequeue();
                        switch (color)
                        {
                            case 'w':
                                richConsole.SelectionColor = Color.White;
                                continue;
                            case 'r':
                                richConsole.SelectionColor = Color.Red;
                                continue;
                            case 'b':
                                richConsole.SelectionColor = Color.Blue;
                                continue;
                            case 'o':
                                richConsole.SelectionColor = Color.Orange;
                                continue;
                            case 'y':
                                richConsole.SelectionColor = Color.Yellow;
                                continue;
                            case 'g':
                                richConsole.SelectionColor = Color.Green;
                                continue;
                        }
                    }
                    richConsole.AppendText(a.ToString());
                }
                richConsole.AppendText(new string(' ', 400) + Environment.NewLine);
                richConsole.SelectionStart = richConsole.TextLength;
            }
        }

        private void DroneControlConfig_Click(object sender, EventArgs e)
        {
            Core.Instance.DroneControl.Configure();
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

        private void Anomalies_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Anomalies.DoDragDrop(Anomalies.SelectedItems, DragDropEffects.Move);
        }

        private void Anomalies_DragEnter(object sender, DragEventArgs e)
        {
            int len = e.Data.GetFormats().Length - 1;
            int i;
            for (i = 0; i <= len; i++)
            {
                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    //The data from the drag source is moved to the target.	
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void Anomalies_DragDrop(object sender, DragEventArgs e)
        {
            //Return if the items are not selected in the ListView control.
            if (Anomalies.SelectedItems.Count == 0)
            {
                return;
            }
            //Returns the location of the mouse pointer in the ListView control.
            Point cp = Anomalies.PointToClient(new Point(e.X, e.Y));
            //Obtain the item that is located at the specified location of the mouse pointer.
            ListViewItem dragToItem = Anomalies.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            //Obtain the index of the item at the mouse pointer.
            int dragIndex = dragToItem.Index;
            ListViewItem[] sel = new ListViewItem[Anomalies.SelectedItems.Count];
            for (int i = 0; i <= Anomalies.SelectedItems.Count - 1; i++)
            {
                sel[i] = Anomalies.SelectedItems[i];
            }
            for (int i = 0; i < sel.GetLength(0); i++)
            {
                //Obtain the ListViewItem to be dragged to the target location.
                ListViewItem dragItem = sel[i];
                int itemIndex = dragIndex;
                if (itemIndex == dragItem.Index)
                {
                    return;
                }
                if (dragItem.Index < itemIndex)
                    itemIndex++;
                else
                    itemIndex = dragIndex + i;
                //Insert the item at the mouse pointer.
                ListViewItem insertItem = (ListViewItem)dragItem.Clone();
                Anomalies.Items.Insert(itemIndex, insertItem);
                //Removes the item from the initial location while 
                //the item is moved to the new location.
                Anomalies.Items.Remove(dragItem);
            }

            Settings.SerializableDictionary<string, bool> build = new Settings.SerializableDictionary<string, bool>();
            foreach (ListViewItem i in Anomalies.Items)
            {
                build.Add(i.Text, i.Checked);
            }
            Config.Anomalies = build;
            Config.Save();
        }

        private void Anomalies_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                Settings.SerializableDictionary<string, bool> build = new Settings.SerializableDictionary<string, bool>();
                foreach (ListViewItem i in Anomalies.Items)
                {
                    build.Add(i.Text, i.Checked);
                }
                Config.Anomalies = build;
                Config.Save();

            }
            catch {}
        }

        private void RatterForm_Shown(object sender, EventArgs e)
        {
            Anomalies.ItemChecked += Anomalies_ItemChecked;
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            if (textNewProfile.Text == "") return;
            string newprofile = textNewProfile.Text;
            EveComFramework.Core.Config.Instance.DefaultProfile = newprofile;
            Config.ProfilePath = newprofile;
            Core.Instance.Security.Config.ProfilePath = newprofile;
            Core.Instance.AutoModule.Config.ProfilePath = newprofile;
            Core.Instance.DroneControl.Config.ProfilePath = newprofile;
            lblCurrentProfile.Text = newprofile;
            Config.Save();
            Core.Instance.Security.Config.Save();
            Core.Instance.AutoModule.Config.Save();
            Core.Instance.DroneControl.Config.Save();
            listProfiles.DataSource = Directory.GetFiles(Config.ConfigDirectory).Select(Path.GetFileNameWithoutExtension).ToList();
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            if (File.Exists(Config.ConfigDirectory + listProfiles.SelectedItem.ToString() + ".xml"))
            {
                string newprofile = listProfiles.SelectedItem.ToString();
                EveComFramework.Core.Config.Instance.DefaultProfile = newprofile;
                Config.ProfilePath = newprofile;
                Core.Instance.Security.Config.ProfilePath = newprofile;
                Core.Instance.AutoModule.Config.ProfilePath = newprofile;
                Core.Instance.DroneControl.Config.ProfilePath = newprofile;
                lblCurrentProfile.Text = newprofile;
                Config.Load();
                Core.Instance.Security.Config.Load();
                Core.Instance.AutoModule.Config.Load();
                Core.Instance.DroneControl.Config.Load();
                LoadSettings();
            }
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (EveComFramework.Core.Config.Instance.DefaultProfile == listProfiles.SelectedItem.ToString())
            {
                MessageBox.Show("You cannot remove your current profile.");
                return;
            }
            File.Delete(Config.ConfigDirectory + listProfiles.SelectedItem.ToString() + ".xml");
            listProfiles.DataSource = Directory.GetFiles(Config.ConfigDirectory).Select(Path.GetFileNameWithoutExtension).ToList();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UI.CharacterName != null) this.Text = String.Format("Ratter: {0}", UI.CharacterName);
            if (UI.FleetMembers != null) TetherPilot.AutoCompleteCustomSource = new MyAutoCompleteStringCollection(UI.FleetMembers);
            if (UI.Bookmarks != null) DropoffBookmark.AutoCompleteCustomSource = new MyAutoCompleteStringCollection(UI.Bookmarks);
            if (UI.Cargo != null) Ammo.AutoCompleteCustomSource = new MyAutoCompleteStringCollection(UI.Cargo);
        }

        private void TetherPilot_TextChanged(object sender, EventArgs e)
        {
            Config.CombatTetherPilot = TetherPilot.Text;
            Config.Save();
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


    public class MyAutoCompleteStringCollection : AutoCompleteStringCollection
    {
        public MyAutoCompleteStringCollection(List<String> items)
        {
            this.AddRange(items.ToArray());
        }
    }
}
