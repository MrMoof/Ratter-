namespace Ratter
{
    partial class RatterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RatterForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Anomalies = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.Mode = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.listConsole = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.WarpDistanceLabel = new System.Windows.Forms.Label();
            this.WarpDistance = new System.Windows.Forms.TrackBar();
            this.Tether = new System.Windows.Forms.CheckBox();
            this.TetherPilot = new System.Windows.Forms.TextBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CargoThresholdLabel = new System.Windows.Forms.Label();
            this.CargoThreshold = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DropoffBookmark = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.AmmoQuantityLabel = new System.Windows.Forms.Label();
            this.AmmoTriggerLabel = new System.Windows.Forms.Label();
            this.AmmoTrigger = new System.Windows.Forms.TrackBar();
            this.AmmoQuantity = new System.Windows.Forms.TrackBar();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.Ammo = new System.Windows.Forms.TextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.DroneControlConfig = new System.Windows.Forms.Button();
            this.AutoModuleConfig = new System.Windows.Forms.Button();
            this.SecurityConfig = new System.Windows.Forms.Button();
            this.Toggle = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarpDistance)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetSlots)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTankRange)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CargoThreshold)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmmoTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmmoQuantity)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(6, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(282, 249);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Anomalies);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(274, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Anomaly";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Anomalies
            // 
            this.Anomalies.AllowDrop = true;
            this.Anomalies.AutoArrange = false;
            this.Anomalies.CheckBoxes = true;
            this.Anomalies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.Anomalies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.Anomalies.Location = new System.Drawing.Point(6, 6);
            this.Anomalies.Name = "Anomalies";
            this.Anomalies.Size = new System.Drawing.Size(262, 211);
            this.Anomalies.TabIndex = 6;
            this.Anomalies.UseCompatibleStateImageBehavior = false;
            this.Anomalies.View = System.Windows.Forms.View.Details;
            this.Anomalies.VirtualListSize = 10;
            this.Anomalies.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Anomalies_ItemDrag);
            this.Anomalies.DragDrop += new System.Windows.Forms.DragEventHandler(this.Anomalies_DragDrop);
            this.Anomalies.DragEnter += new System.Windows.Forms.DragEventHandler(this.Anomalies_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 250;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(274, 223);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bookmark";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(274, 223);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Belt";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Mode
            // 
            this.Mode.FormattingEnabled = true;
            this.Mode.Location = new System.Drawing.Point(6, 20);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(282, 21);
            this.Mode.TabIndex = 0;
            this.Mode.SelectedIndexChanged += new System.EventHandler(this.Mode_SelectedIndexChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(12, 25);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(314, 360);
            this.tabControl2.TabIndex = 2;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.listConsole);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(306, 334);
            this.tabPage9.TabIndex = 5;
            this.tabPage9.Text = "Console";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // listConsole
            // 
            this.listConsole.BackColor = System.Drawing.Color.Black;
            this.listConsole.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listConsole.ForeColor = System.Drawing.Color.White;
            this.listConsole.FormattingEnabled = true;
            this.listConsole.Location = new System.Drawing.Point(6, 6);
            this.listConsole.Name = "listConsole";
            this.listConsole.Size = new System.Drawing.Size(294, 316);
            this.listConsole.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(306, 334);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Movement";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tabControl1);
            this.groupBox6.Location = new System.Drawing.Point(6, 53);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(294, 275);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Objective";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Mode);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 47);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mode";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(306, 334);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Combat";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.WarpDistanceLabel);
            this.groupBox7.Controls.Add(this.WarpDistance);
            this.groupBox7.Controls.Add(this.Tether);
            this.groupBox7.Controls.Add(this.TetherPilot);
            this.groupBox7.Location = new System.Drawing.Point(6, 212);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(294, 117);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Warp In";
            // 
            // WarpDistanceLabel
            // 
            this.WarpDistanceLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarpDistanceLabel.Location = new System.Drawing.Point(6, 43);
            this.WarpDistanceLabel.Name = "WarpDistanceLabel";
            this.WarpDistanceLabel.Size = new System.Drawing.Size(282, 19);
            this.WarpDistanceLabel.TabIndex = 3;
            this.WarpDistanceLabel.Text = "Warp to 0 km";
            this.WarpDistanceLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WarpDistance
            // 
            this.WarpDistance.BackColor = System.Drawing.SystemColors.Control;
            this.WarpDistance.Location = new System.Drawing.Point(6, 17);
            this.WarpDistance.Maximum = 100;
            this.WarpDistance.Name = "WarpDistance";
            this.WarpDistance.Size = new System.Drawing.Size(282, 45);
            this.WarpDistance.TabIndex = 2;
            this.WarpDistance.Tag = "Use this slider to indicate how close ComBot should warp to ratting locations";
            this.WarpDistance.TickStyle = System.Windows.Forms.TickStyle.None;
            this.WarpDistance.Scroll += new System.EventHandler(this.WarpDistance_Scroll);
            // 
            // Tether
            // 
            this.Tether.AutoSize = true;
            this.Tether.Location = new System.Drawing.Point(6, 65);
            this.Tether.Name = "Tether";
            this.Tether.Size = new System.Drawing.Size(134, 17);
            this.Tether.TabIndex = 4;
            this.Tether.Text = "Tether to fleet member";
            this.Tether.UseVisualStyleBackColor = true;
            // 
            // TetherPilot
            // 
            this.TetherPilot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TetherPilot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TetherPilot.Location = new System.Drawing.Point(6, 88);
            this.TetherPilot.Name = "TetherPilot";
            this.TetherPilot.Size = new System.Drawing.Size(282, 21);
            this.TetherPilot.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TargetSlotsLabel);
            this.groupBox5.Controls.Add(this.TargetSlots);
            this.groupBox5.Location = new System.Drawing.Point(6, 141);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(294, 67);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Targeting";
            // 
            // TargetSlotsLabel
            // 
            this.TargetSlotsLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetSlotsLabel.Location = new System.Drawing.Point(6, 46);
            this.TargetSlotsLabel.Name = "TargetSlotsLabel";
            this.TargetSlotsLabel.Size = new System.Drawing.Size(282, 19);
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
            this.TargetSlots.Size = new System.Drawing.Size(282, 45);
            this.TargetSlots.TabIndex = 5;
            this.TargetSlots.Tag = "Use this slider to indicate how close to orbit the nearest NPC";
            this.TargetSlots.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TargetSlots.Value = 1;
            this.TargetSlots.Scroll += new System.EventHandler(this.TargetSlots_Scroll);
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
            this.groupBox4.Size = new System.Drawing.Size(294, 134);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Combat Movement";
            // 
            // KeepAtRange
            // 
            this.KeepAtRange.AutoSize = true;
            this.KeepAtRange.Location = new System.Drawing.Point(81, 66);
            this.KeepAtRange.Name = "KeepAtRange";
            this.KeepAtRange.Size = new System.Drawing.Size(91, 17);
            this.KeepAtRange.TabIndex = 7;
            this.KeepAtRange.Text = "Keep at Range";
            this.KeepAtRange.UseVisualStyleBackColor = true;
            this.KeepAtRange.CheckedChanged += new System.EventHandler(this.KeepAtRange_CheckedChanged);
            // 
            // CombatTether
            // 
            this.CombatTether.AutoSize = true;
            this.CombatTether.Location = new System.Drawing.Point(6, 66);
            this.CombatTether.Name = "CombatTether";
            this.CombatTether.Size = new System.Drawing.Size(68, 17);
            this.CombatTether.TabIndex = 6;
            this.CombatTether.Text = "Tethered";
            this.CombatTether.UseVisualStyleBackColor = true;
            this.CombatTether.CheckedChanged += new System.EventHandler(this.CombatTether_CheckedChanged);
            // 
            // SpeedTankRangeLabel
            // 
            this.SpeedTankRangeLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedTankRangeLabel.Location = new System.Drawing.Point(6, 115);
            this.SpeedTankRangeLabel.Name = "SpeedTankRangeLabel";
            this.SpeedTankRangeLabel.Size = new System.Drawing.Size(282, 19);
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
            this.SpeedTankRange.Size = new System.Drawing.Size(282, 45);
            this.SpeedTankRange.TabIndex = 3;
            this.SpeedTankRange.Tag = "Use this slider to indicate how close to orbit the nearest NPC";
            this.SpeedTankRange.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SpeedTankRange.Value = 20;
            this.SpeedTankRange.Scroll += new System.EventHandler(this.SpeedTankRange_Scroll);
            // 
            // SpeedTank
            // 
            this.SpeedTank.AutoSize = true;
            this.SpeedTank.Location = new System.Drawing.Point(6, 43);
            this.SpeedTank.Name = "SpeedTank";
            this.SpeedTank.Size = new System.Drawing.Size(77, 17);
            this.SpeedTank.TabIndex = 2;
            this.SpeedTank.Tag = "With this option enabled, ComBot will orbit the nearest hostile NPC using the dis" +
                "tance below";
            this.SpeedTank.Text = "Speed Tank";
            this.SpeedTank.UseVisualStyleBackColor = true;
            this.SpeedTank.CheckedChanged += new System.EventHandler(this.SpeedTank_CheckedChanged);
            // 
            // Squat
            // 
            this.Squat.AutoSize = true;
            this.Squat.Location = new System.Drawing.Point(6, 20);
            this.Squat.Name = "Squat";
            this.Squat.Size = new System.Drawing.Size(116, 17);
            this.Squat.TabIndex = 0;
            this.Squat.Tag = "With this option enabled, ComBot will approach the first wreck it sees at a ratti" +
                "ng location and stop within 1km";
            this.Squat.Text = "Squat on first wreck";
            this.Squat.UseVisualStyleBackColor = true;
            this.Squat.CheckedChanged += new System.EventHandler(this.Squat_CheckedChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox1);
            this.tabPage6.Controls.Add(this.groupBox2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(306, 334);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Dropoff";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CargoThresholdLabel);
            this.groupBox1.Controls.Add(this.CargoThreshold);
            this.groupBox1.Location = new System.Drawing.Point(6, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 64);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Threshold";
            // 
            // CargoThresholdLabel
            // 
            this.CargoThresholdLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargoThresholdLabel.Location = new System.Drawing.Point(7, 46);
            this.CargoThresholdLabel.Name = "CargoThresholdLabel";
            this.CargoThresholdLabel.Size = new System.Drawing.Size(281, 19);
            this.CargoThresholdLabel.TabIndex = 4;
            this.CargoThresholdLabel.Text = "90%";
            this.CargoThresholdLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CargoThreshold
            // 
            this.CargoThreshold.BackColor = System.Drawing.SystemColors.Menu;
            this.CargoThreshold.Location = new System.Drawing.Point(7, 20);
            this.CargoThreshold.Maximum = 100;
            this.CargoThreshold.Name = "CargoThreshold";
            this.CargoThreshold.Size = new System.Drawing.Size(281, 45);
            this.CargoThreshold.TabIndex = 3;
            this.CargoThreshold.Tag = resources.GetString("CargoThreshold.Tag");
            this.CargoThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.CargoThreshold.Value = 90;
            this.CargoThreshold.Scroll += new System.EventHandler(this.CargoThreshold_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DropoffBookmark);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 47);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bookmark";
            // 
            // DropoffBookmark
            // 
            this.DropoffBookmark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DropoffBookmark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.DropoffBookmark.Location = new System.Drawing.Point(6, 20);
            this.DropoffBookmark.Name = "DropoffBookmark";
            this.DropoffBookmark.Size = new System.Drawing.Size(282, 21);
            this.DropoffBookmark.TabIndex = 1;
            this.DropoffBookmark.TextChanged += new System.EventHandler(this.DropoffBookmarkFilter_TextChanged);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox9);
            this.tabPage7.Controls.Add(this.groupBox8);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(306, 334);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Ammo";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.AmmoQuantityLabel);
            this.groupBox9.Controls.Add(this.AmmoTriggerLabel);
            this.groupBox9.Controls.Add(this.AmmoTrigger);
            this.groupBox9.Controls.Add(this.AmmoQuantity);
            this.groupBox9.Location = new System.Drawing.Point(7, 62);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(293, 111);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Threshold";
            // 
            // AmmoQuantityLabel
            // 
            this.AmmoQuantityLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmmoQuantityLabel.Location = new System.Drawing.Point(6, 46);
            this.AmmoQuantityLabel.Name = "AmmoQuantityLabel";
            this.AmmoQuantityLabel.Size = new System.Drawing.Size(281, 19);
            this.AmmoQuantityLabel.TabIndex = 4;
            this.AmmoQuantityLabel.Text = "Fill 90% of cargo hold with ammo";
            this.AmmoQuantityLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AmmoTriggerLabel
            // 
            this.AmmoTriggerLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmmoTriggerLabel.Location = new System.Drawing.Point(6, 94);
            this.AmmoTriggerLabel.Name = "AmmoTriggerLabel";
            this.AmmoTriggerLabel.Size = new System.Drawing.Size(281, 19);
            this.AmmoTriggerLabel.TabIndex = 6;
            this.AmmoTriggerLabel.Text = "Reload if less than 10% ammo in cargo hold";
            this.AmmoTriggerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AmmoTrigger
            // 
            this.AmmoTrigger.BackColor = System.Drawing.SystemColors.Menu;
            this.AmmoTrigger.Location = new System.Drawing.Point(6, 68);
            this.AmmoTrigger.Maximum = 100;
            this.AmmoTrigger.Name = "AmmoTrigger";
            this.AmmoTrigger.Size = new System.Drawing.Size(281, 45);
            this.AmmoTrigger.TabIndex = 5;
            this.AmmoTrigger.Tag = resources.GetString("AmmoTrigger.Tag");
            this.AmmoTrigger.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AmmoTrigger.Value = 10;
            this.AmmoTrigger.Scroll += new System.EventHandler(this.AmmoTrigger_Scroll);
            // 
            // AmmoQuantity
            // 
            this.AmmoQuantity.BackColor = System.Drawing.SystemColors.Menu;
            this.AmmoQuantity.Location = new System.Drawing.Point(6, 20);
            this.AmmoQuantity.Maximum = 100;
            this.AmmoQuantity.Name = "AmmoQuantity";
            this.AmmoQuantity.Size = new System.Drawing.Size(281, 45);
            this.AmmoQuantity.TabIndex = 3;
            this.AmmoQuantity.Tag = resources.GetString("AmmoQuantity.Tag");
            this.AmmoQuantity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AmmoQuantity.Value = 90;
            this.AmmoQuantity.Scroll += new System.EventHandler(this.AmmoQuantity_Scroll);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.Ammo);
            this.groupBox8.Location = new System.Drawing.Point(7, 7);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(293, 48);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Ammo";
            // 
            // Ammo
            // 
            this.Ammo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Ammo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Ammo.Location = new System.Drawing.Point(6, 20);
            this.Ammo.Name = "Ammo";
            this.Ammo.Size = new System.Drawing.Size(281, 21);
            this.Ammo.TabIndex = 0;
            this.Ammo.TextChanged += new System.EventHandler(this.AmmoFilter_TextChanged);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.DroneControlConfig);
            this.tabPage8.Controls.Add(this.AutoModuleConfig);
            this.tabPage8.Controls.Add(this.SecurityConfig);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(306, 334);
            this.tabPage8.TabIndex = 4;
            this.tabPage8.Text = "Modules";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // DroneControlConfig
            // 
            this.DroneControlConfig.Location = new System.Drawing.Point(6, 72);
            this.DroneControlConfig.Name = "DroneControlConfig";
            this.DroneControlConfig.Size = new System.Drawing.Size(294, 27);
            this.DroneControlConfig.TabIndex = 2;
            this.DroneControlConfig.Text = "DroneControl";
            this.DroneControlConfig.UseVisualStyleBackColor = true;
            this.DroneControlConfig.Click += new System.EventHandler(this.DroneControlConfig_Click);
            // 
            // AutoModuleConfig
            // 
            this.AutoModuleConfig.Location = new System.Drawing.Point(6, 39);
            this.AutoModuleConfig.Name = "AutoModuleConfig";
            this.AutoModuleConfig.Size = new System.Drawing.Size(294, 27);
            this.AutoModuleConfig.TabIndex = 1;
            this.AutoModuleConfig.Text = "AutoModule";
            this.AutoModuleConfig.UseVisualStyleBackColor = true;
            this.AutoModuleConfig.Click += new System.EventHandler(this.AutoModuleConfig_Click);
            // 
            // SecurityConfig
            // 
            this.SecurityConfig.Location = new System.Drawing.Point(6, 6);
            this.SecurityConfig.Name = "SecurityConfig";
            this.SecurityConfig.Size = new System.Drawing.Size(294, 27);
            this.SecurityConfig.TabIndex = 0;
            this.SecurityConfig.Text = "Security";
            this.SecurityConfig.UseVisualStyleBackColor = true;
            this.SecurityConfig.Click += new System.EventHandler(this.SecurityConfig_Click);
            // 
            // Toggle
            // 
            this.Toggle.AutoSize = true;
            this.Toggle.Location = new System.Drawing.Point(12, 5);
            this.Toggle.Name = "Toggle";
            this.Toggle.Size = new System.Drawing.Size(55, 17);
            this.Toggle.TabIndex = 3;
            this.Toggle.Text = "Active";
            this.Toggle.UseVisualStyleBackColor = true;
            this.Toggle.CheckedChanged += new System.EventHandler(this.Toggle_CheckedChanged);
            // 
            // RatterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 396);
            this.Controls.Add(this.Toggle);
            this.Controls.Add(this.tabControl2);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RatterForm";
            this.Text = "Ratter";
            this.Load += new System.EventHandler(this.Ratter_Load);
            this.Shown += new System.EventHandler(this.RatterForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarpDistance)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetSlots)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTankRange)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CargoThreshold)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmmoTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmmoQuantity)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
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
        private System.Windows.Forms.TextBox DropoffBookmark;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label AmmoTriggerLabel;
        private System.Windows.Forms.TrackBar AmmoTrigger;
        private System.Windows.Forms.Label AmmoQuantityLabel;
        private System.Windows.Forms.TrackBar AmmoQuantity;
        private System.Windows.Forms.TextBox Ammo;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button SecurityConfig;
        private System.Windows.Forms.Button AutoModuleConfig;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.ListBox listConsole;
        private System.Windows.Forms.Button DroneControlConfig;
        private System.Windows.Forms.CheckBox Toggle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListView Anomalies;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label WarpDistanceLabel;
        private System.Windows.Forms.TrackBar WarpDistance;
        private System.Windows.Forms.CheckBox Tether;
        private System.Windows.Forms.TextBox TetherPilot;
    }
}

