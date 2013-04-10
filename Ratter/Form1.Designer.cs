namespace Ratter
{
    partial class Ratter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ratter));
            this.TetherPilot = new System.Windows.Forms.ComboBox();
            this.Tether = new System.Windows.Forms.CheckBox();
            this.WarpDistanceLabel = new System.Windows.Forms.Label();
            this.WarpDistance = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Anomalies = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.Mode = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TargetSlotsLabel = new System.Windows.Forms.Label();
            this.TargetSlots = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.KeepAtRange = new System.Windows.Forms.CheckBox();
            this.CombatTether = new System.Windows.Forms.CheckBox();
            this.SpeedTankRangeLabel = new System.Windows.Forms.Label();
            this.SpeedTankRange = new System.Windows.Forms.TrackBar();
            this.SpeedTank = new System.Windows.Forms.CheckBox();
            this.Squat = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.CargoThresholdLabel = new System.Windows.Forms.Label();
            this.CargoThreshold = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DropoffBookmarkFilter = new System.Windows.Forms.TextBox();
            this.DropoffBookmark = new System.Windows.Forms.ListBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.AmmoTriggerLabel = new System.Windows.Forms.Label();
            this.AmmoTrigger = new System.Windows.Forms.TrackBar();
            this.AmmoQuantityLabel = new System.Windows.Forms.Label();
            this.AmmoQuantity = new System.Windows.Forms.TrackBar();
            this.Ammo = new System.Windows.Forms.ListBox();
            this.AmmoFilter = new System.Windows.Forms.TextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.SecurityConfig = new System.Windows.Forms.Button();
            this.Toggle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WarpDistance)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetSlots)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTankRange)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CargoThreshold)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmmoTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmmoQuantity)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // TetherPilot
            // 
            this.TetherPilot.FormattingEnabled = true;
            this.TetherPilot.Location = new System.Drawing.Point(3, 246);
            this.TetherPilot.Name = "TetherPilot";
            this.TetherPilot.Size = new System.Drawing.Size(225, 21);
            this.TetherPilot.TabIndex = 5;
            // 
            // Tether
            // 
            this.Tether.AutoSize = true;
            this.Tether.Location = new System.Drawing.Point(3, 223);
            this.Tether.Name = "Tether";
            this.Tether.Size = new System.Drawing.Size(132, 17);
            this.Tether.TabIndex = 4;
            this.Tether.Text = "Tether to fleet member";
            this.Tether.UseVisualStyleBackColor = true;
            // 
            // WarpDistanceLabel
            // 
            this.WarpDistanceLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarpDistanceLabel.Location = new System.Drawing.Point(0, 198);
            this.WarpDistanceLabel.Name = "WarpDistanceLabel";
            this.WarpDistanceLabel.Size = new System.Drawing.Size(233, 19);
            this.WarpDistanceLabel.TabIndex = 3;
            this.WarpDistanceLabel.Text = "Warp to 0 km";
            this.WarpDistanceLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WarpDistance
            // 
            this.WarpDistance.BackColor = System.Drawing.SystemColors.Control;
            this.WarpDistance.Location = new System.Drawing.Point(3, 172);
            this.WarpDistance.Maximum = 100;
            this.WarpDistance.Name = "WarpDistance";
            this.WarpDistance.Size = new System.Drawing.Size(230, 45);
            this.WarpDistance.TabIndex = 2;
            this.WarpDistance.Tag = "Use this slider to indicate how close ComBot should warp to ratting locations";
            this.WarpDistance.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(3, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(233, 133);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.Anomalies);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(225, 107);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Anomaly";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(179, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 7;
            this.button3.Tag = "Move the selected Anomaly down in the priority list";
            this.button3.Text = "↓";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(179, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 6;
            this.button2.Tag = "Move the selected Anomaly up in the priority list";
            this.button2.Text = "↑";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Anomalies
            // 
            this.Anomalies.CheckOnClick = true;
            this.Anomalies.FormattingEnabled = true;
            this.Anomalies.Items.AddRange(new object[] {
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
            "Drone Cluster"});
            this.Anomalies.Location = new System.Drawing.Point(6, 6);
            this.Anomalies.Name = "Anomalies";
            this.Anomalies.Size = new System.Drawing.Size(167, 94);
            this.Anomalies.TabIndex = 5;
            this.Anomalies.Tag = "This list indicates which Anomalies will be run.  Use the buttons to the right to" +
                " sort the list.  Unchecked Anomalies will be ignored.";
            this.Anomalies.SelectedIndexChanged += new System.EventHandler(this.Anomalies_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(225, 107);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bookmark";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(225, 107);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Belt";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Mode
            // 
            this.Mode.FormattingEnabled = true;
            this.Mode.Location = new System.Drawing.Point(3, 6);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(233, 21);
            this.Mode.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Location = new System.Drawing.Point(12, 38);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(250, 303);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Controls.Add(this.TetherPilot);
            this.tabPage3.Controls.Add(this.Mode);
            this.tabPage3.Controls.Add(this.Tether);
            this.tabPage3.Controls.Add(this.WarpDistanceLabel);
            this.tabPage3.Controls.Add(this.WarpDistance);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(242, 277);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Movement";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(242, 277);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Combat";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TargetSlotsLabel);
            this.groupBox5.Controls.Add(this.TargetSlots);
            this.groupBox5.Location = new System.Drawing.Point(6, 146);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(230, 67);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Targeting";
            // 
            // TargetSlotsLabel
            // 
            this.TargetSlotsLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetSlotsLabel.Location = new System.Drawing.Point(6, 46);
            this.TargetSlotsLabel.Name = "TargetSlotsLabel";
            this.TargetSlotsLabel.Size = new System.Drawing.Size(218, 19);
            this.TargetSlotsLabel.TabIndex = 6;
            this.TargetSlotsLabel.Text = "Use 1 target for weapons";
            this.TargetSlotsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TargetSlots
            // 
            this.TargetSlots.BackColor = System.Drawing.SystemColors.Control;
            this.TargetSlots.Location = new System.Drawing.Point(6, 20);
            this.TargetSlots.Maximum = 15;
            this.TargetSlots.Name = "TargetSlots";
            this.TargetSlots.Size = new System.Drawing.Size(218, 45);
            this.TargetSlots.TabIndex = 5;
            this.TargetSlots.Tag = "Use this slider to indicate how close to orbit the nearest NPC";
            this.TargetSlots.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TargetSlots.Value = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.KeepAtRange);
            this.groupBox4.Controls.Add(this.CombatTether);
            this.groupBox4.Controls.Add(this.SpeedTankRangeLabel);
            this.groupBox4.Controls.Add(this.SpeedTankRange);
            this.groupBox4.Controls.Add(this.SpeedTank);
            this.groupBox4.Controls.Add(this.Squat);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 134);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Combat Movement";
            // 
            // KeepAtRange
            // 
            this.KeepAtRange.AutoSize = true;
            this.KeepAtRange.Location = new System.Drawing.Point(81, 66);
            this.KeepAtRange.Name = "KeepAtRange";
            this.KeepAtRange.Size = new System.Drawing.Size(98, 17);
            this.KeepAtRange.TabIndex = 7;
            this.KeepAtRange.Text = "Keep at Range";
            this.KeepAtRange.UseVisualStyleBackColor = true;
            // 
            // CombatTether
            // 
            this.CombatTether.AutoSize = true;
            this.CombatTether.Location = new System.Drawing.Point(6, 66);
            this.CombatTether.Name = "CombatTether";
            this.CombatTether.Size = new System.Drawing.Size(69, 17);
            this.CombatTether.TabIndex = 6;
            this.CombatTether.Text = "Tethered";
            this.CombatTether.UseVisualStyleBackColor = true;
            // 
            // SpeedTankRangeLabel
            // 
            this.SpeedTankRangeLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedTankRangeLabel.Location = new System.Drawing.Point(6, 115);
            this.SpeedTankRangeLabel.Name = "SpeedTankRangeLabel";
            this.SpeedTankRangeLabel.Size = new System.Drawing.Size(218, 19);
            this.SpeedTankRangeLabel.TabIndex = 4;
            this.SpeedTankRangeLabel.Text = "Speed tank at 1 km";
            this.SpeedTankRangeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SpeedTankRange
            // 
            this.SpeedTankRange.BackColor = System.Drawing.SystemColors.Control;
            this.SpeedTankRange.Location = new System.Drawing.Point(6, 89);
            this.SpeedTankRange.Maximum = 100;
            this.SpeedTankRange.Minimum = 1;
            this.SpeedTankRange.Name = "SpeedTankRange";
            this.SpeedTankRange.Size = new System.Drawing.Size(218, 45);
            this.SpeedTankRange.TabIndex = 3;
            this.SpeedTankRange.Tag = "Use this slider to indicate how close to orbit the nearest NPC";
            this.SpeedTankRange.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SpeedTankRange.Value = 20;
            // 
            // SpeedTank
            // 
            this.SpeedTank.AutoSize = true;
            this.SpeedTank.Location = new System.Drawing.Point(6, 43);
            this.SpeedTank.Name = "SpeedTank";
            this.SpeedTank.Size = new System.Drawing.Size(85, 17);
            this.SpeedTank.TabIndex = 2;
            this.SpeedTank.Tag = "With this option enabled, ComBot will orbit the nearest hostile NPC using the dis" +
                "tance below";
            this.SpeedTank.Text = "Speed Tank";
            this.SpeedTank.UseVisualStyleBackColor = true;
            // 
            // Squat
            // 
            this.Squat.AutoSize = true;
            this.Squat.Location = new System.Drawing.Point(6, 20);
            this.Squat.Name = "Squat";
            this.Squat.Size = new System.Drawing.Size(120, 17);
            this.Squat.TabIndex = 0;
            this.Squat.Tag = "With this option enabled, ComBot will approach the first wreck it sees at a ratti" +
                "ng location and stop within 1km";
            this.Squat.Text = "Squat on first wreck";
            this.Squat.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.CargoThresholdLabel);
            this.tabPage6.Controls.Add(this.CargoThreshold);
            this.tabPage6.Controls.Add(this.groupBox2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(242, 277);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Dropoff";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // CargoThresholdLabel
            // 
            this.CargoThresholdLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargoThresholdLabel.Location = new System.Drawing.Point(6, 252);
            this.CargoThresholdLabel.Name = "CargoThresholdLabel";
            this.CargoThresholdLabel.Size = new System.Drawing.Size(225, 19);
            this.CargoThresholdLabel.TabIndex = 4;
            this.CargoThresholdLabel.Text = "Dropoff when cargo exceeds 90%";
            this.CargoThresholdLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CargoThreshold
            // 
            this.CargoThreshold.BackColor = System.Drawing.SystemColors.Menu;
            this.CargoThreshold.Location = new System.Drawing.Point(6, 226);
            this.CargoThreshold.Maximum = 100;
            this.CargoThreshold.Name = "CargoThreshold";
            this.CargoThreshold.Size = new System.Drawing.Size(225, 45);
            this.CargoThreshold.TabIndex = 3;
            this.CargoThreshold.Tag = resources.GetString("CargoThreshold.Tag");
            this.CargoThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.CargoThreshold.Value = 90;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DropoffBookmarkFilter);
            this.groupBox2.Controls.Add(this.DropoffBookmark);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 207);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dropoff Bookmark";
            // 
            // DropoffBookmarkFilter
            // 
            this.DropoffBookmarkFilter.Location = new System.Drawing.Point(7, 20);
            this.DropoffBookmarkFilter.Name = "DropoffBookmarkFilter";
            this.DropoffBookmarkFilter.Size = new System.Drawing.Size(212, 20);
            this.DropoffBookmarkFilter.TabIndex = 1;
            // 
            // DropoffBookmark
            // 
            this.DropoffBookmark.FormattingEnabled = true;
            this.DropoffBookmark.Location = new System.Drawing.Point(9, 50);
            this.DropoffBookmark.Name = "DropoffBookmark";
            this.DropoffBookmark.Size = new System.Drawing.Size(210, 147);
            this.DropoffBookmark.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.AmmoTriggerLabel);
            this.tabPage7.Controls.Add(this.AmmoTrigger);
            this.tabPage7.Controls.Add(this.AmmoQuantityLabel);
            this.tabPage7.Controls.Add(this.AmmoQuantity);
            this.tabPage7.Controls.Add(this.Ammo);
            this.tabPage7.Controls.Add(this.AmmoFilter);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(242, 277);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Ammo";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // AmmoTriggerLabel
            // 
            this.AmmoTriggerLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmmoTriggerLabel.Location = new System.Drawing.Point(6, 220);
            this.AmmoTriggerLabel.Name = "AmmoTriggerLabel";
            this.AmmoTriggerLabel.Size = new System.Drawing.Size(230, 19);
            this.AmmoTriggerLabel.TabIndex = 6;
            this.AmmoTriggerLabel.Text = "Reload if less than 10% ammo in cargo hold";
            this.AmmoTriggerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AmmoTrigger
            // 
            this.AmmoTrigger.BackColor = System.Drawing.SystemColors.Menu;
            this.AmmoTrigger.Location = new System.Drawing.Point(6, 194);
            this.AmmoTrigger.Maximum = 100;
            this.AmmoTrigger.Name = "AmmoTrigger";
            this.AmmoTrigger.Size = new System.Drawing.Size(230, 45);
            this.AmmoTrigger.TabIndex = 5;
            this.AmmoTrigger.Tag = resources.GetString("AmmoTrigger.Tag");
            this.AmmoTrigger.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AmmoTrigger.Value = 10;
            // 
            // AmmoQuantityLabel
            // 
            this.AmmoQuantityLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmmoQuantityLabel.Location = new System.Drawing.Point(6, 172);
            this.AmmoQuantityLabel.Name = "AmmoQuantityLabel";
            this.AmmoQuantityLabel.Size = new System.Drawing.Size(230, 19);
            this.AmmoQuantityLabel.TabIndex = 4;
            this.AmmoQuantityLabel.Text = "Fill 90% of cargo hold with ammo";
            this.AmmoQuantityLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AmmoQuantity
            // 
            this.AmmoQuantity.BackColor = System.Drawing.SystemColors.Menu;
            this.AmmoQuantity.Location = new System.Drawing.Point(6, 146);
            this.AmmoQuantity.Maximum = 100;
            this.AmmoQuantity.Name = "AmmoQuantity";
            this.AmmoQuantity.Size = new System.Drawing.Size(230, 45);
            this.AmmoQuantity.TabIndex = 3;
            this.AmmoQuantity.Tag = resources.GetString("AmmoQuantity.Tag");
            this.AmmoQuantity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AmmoQuantity.Value = 90;
            // 
            // Ammo
            // 
            this.Ammo.FormattingEnabled = true;
            this.Ammo.Location = new System.Drawing.Point(6, 32);
            this.Ammo.Name = "Ammo";
            this.Ammo.Size = new System.Drawing.Size(230, 108);
            this.Ammo.TabIndex = 1;
            // 
            // AmmoFilter
            // 
            this.AmmoFilter.Location = new System.Drawing.Point(6, 6);
            this.AmmoFilter.Name = "AmmoFilter";
            this.AmmoFilter.Size = new System.Drawing.Size(230, 20);
            this.AmmoFilter.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.SecurityConfig);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(242, 277);
            this.tabPage8.TabIndex = 4;
            this.tabPage8.Text = "Config";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // SecurityConfig
            // 
            this.SecurityConfig.Location = new System.Drawing.Point(6, 6);
            this.SecurityConfig.Name = "SecurityConfig";
            this.SecurityConfig.Size = new System.Drawing.Size(230, 27);
            this.SecurityConfig.TabIndex = 0;
            this.SecurityConfig.Text = "Security";
            this.SecurityConfig.UseVisualStyleBackColor = true;
            this.SecurityConfig.Click += new System.EventHandler(this.SecurityConfig_Click);
            // 
            // Toggle
            // 
            this.Toggle.Location = new System.Drawing.Point(12, 4);
            this.Toggle.Name = "Toggle";
            this.Toggle.Size = new System.Drawing.Size(246, 28);
            this.Toggle.TabIndex = 3;
            this.Toggle.Text = "Start";
            this.Toggle.UseVisualStyleBackColor = true;
            this.Toggle.Click += new System.EventHandler(this.Toggle_Click);
            // 
            // Ratter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 353);
            this.Controls.Add(this.Toggle);
            this.Controls.Add(this.tabControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Ratter";
            this.Text = "Ratter";
            this.Load += new System.EventHandler(this.Ratter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WarpDistance)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetSlots)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTankRange)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CargoThreshold)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmmoTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmmoQuantity)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TetherPilot;
        private System.Windows.Forms.CheckBox Tether;
        private System.Windows.Forms.Label WarpDistanceLabel;
        private System.Windows.Forms.TrackBar WarpDistance;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox Anomalies;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox Mode;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label TargetSlotsLabel;
        private System.Windows.Forms.TrackBar TargetSlots;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox KeepAtRange;
        private System.Windows.Forms.CheckBox CombatTether;
        private System.Windows.Forms.Label SpeedTankRangeLabel;
        private System.Windows.Forms.TrackBar SpeedTankRange;
        private System.Windows.Forms.CheckBox SpeedTank;
        private System.Windows.Forms.CheckBox Squat;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label CargoThresholdLabel;
        private System.Windows.Forms.TrackBar CargoThreshold;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox DropoffBookmarkFilter;
        private System.Windows.Forms.ListBox DropoffBookmark;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label AmmoTriggerLabel;
        private System.Windows.Forms.TrackBar AmmoTrigger;
        private System.Windows.Forms.Label AmmoQuantityLabel;
        private System.Windows.Forms.TrackBar AmmoQuantity;
        private System.Windows.Forms.ListBox Ammo;
        private System.Windows.Forms.TextBox AmmoFilter;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button SecurityConfig;
        private System.Windows.Forms.Button Toggle;
    }
}

