namespace Bachelor_Test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtHoldingValue = new TextBox();
            lbRawBus = new Label();
            btnChangeHolding = new Button();
            FileDialogDB = new OpenFileDialog();
            lbTag = new Label();
            txtTag = new TextBox();
            lbDescription = new Label();
            txtDescription = new TextBox();
            lbAdress = new Label();
            txtAdress = new TextBox();
            lbEngLow = new Label();
            txtEngLow = new TextBox();
            lbEngHigh = new Label();
            txtEngHigh = new TextBox();
            lbSerialLow = new Label();
            txtSerialLow = new TextBox();
            lbSerialHigh = new Label();
            txtSerialHigh = new TextBox();
            comboBoxSerialLine = new ComboBox();
            lbEngUnit = new Label();
            txtEngUnit = new TextBox();
            menuStrip1 = new MenuStrip();
            toolStripFile = new ToolStripMenuItem();
            importIOListToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripCommSettings = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            userManualToolStripMenuItem = new ToolStripMenuItem();
            btnStartSimulator = new Button();
            btnStopSimulator = new Button();
            label2 = new Label();
            label3 = new Label();
            btnResultNotOK = new Button();
            btnResultOK = new Button();
            txtRawBusValue = new TextBox();
            lbRawBusValue = new Label();
            cbPlusRegister = new CheckBox();
            cbMinusRegister = new CheckBox();
            label1 = new Label();
            txtWatchDog = new TextBox();
            listViewSignals = new ListView();
            columnHeaderTag = new ColumnHeader();
            comboBoxWatchdogInterval = new ComboBox();
            btnWatchdogStart = new Button();
            lbWatchdogMs = new Label();
            CheckboxConnected = new RoundCheckbox();
            txtWatchdogAddress = new TextBox();
            lbWatchdogAddress = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtHoldingValue
            // 
            txtHoldingValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHoldingValue.Location = new Point(649, 340);
            txtHoldingValue.Name = "txtHoldingValue";
            txtHoldingValue.Size = new Size(125, 27);
            txtHoldingValue.TabIndex = 5;
            txtHoldingValue.TextChanged += txtHoldingValue_TextChanged;
            txtHoldingValue.KeyPress += txtHoldingValue_KeyPress;
            // 
            // lbRawBus
            // 
            lbRawBus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRawBus.AutoSize = true;
            lbRawBus.Location = new Point(649, 317);
            lbRawBus.Name = "lbRawBus";
            lbRawBus.Size = new Size(74, 20);
            lbRawBus.TabIndex = 6;
            lbRawBus.Text = "Eng Value";
            // 
            // btnChangeHolding
            // 
            btnChangeHolding.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeHolding.Location = new Point(794, 328);
            btnChangeHolding.Name = "btnChangeHolding";
            btnChangeHolding.Size = new Size(138, 51);
            btnChangeHolding.TabIndex = 9;
            btnChangeHolding.Text = "Toggle";
            btnChangeHolding.UseVisualStyleBackColor = true;
            btnChangeHolding.Click += btnToggleValue;
            // 
            // lbTag
            // 
            lbTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTag.AutoSize = true;
            lbTag.Location = new Point(280, 48);
            lbTag.Name = "lbTag";
            lbTag.Size = new Size(32, 20);
            lbTag.TabIndex = 13;
            lbTag.Text = "Tag";
            // 
            // txtTag
            // 
            txtTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTag.Location = new Point(280, 71);
            txtTag.Name = "txtTag";
            txtTag.ReadOnly = true;
            txtTag.Size = new Size(494, 27);
            txtTag.TabIndex = 15;
            // 
            // lbDescription
            // 
            lbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbDescription.AutoSize = true;
            lbDescription.Location = new Point(280, 101);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(85, 20);
            lbDescription.TabIndex = 16;
            lbDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDescription.Location = new Point(280, 125);
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(494, 27);
            txtDescription.TabIndex = 17;
            // 
            // lbAdress
            // 
            lbAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbAdress.AutoSize = true;
            lbAdress.Location = new Point(280, 180);
            lbAdress.Name = "lbAdress";
            lbAdress.Size = new Size(53, 20);
            lbAdress.TabIndex = 18;
            lbAdress.Text = "Adress";
            // 
            // txtAdress
            // 
            txtAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAdress.Location = new Point(280, 203);
            txtAdress.Name = "txtAdress";
            txtAdress.ReadOnly = true;
            txtAdress.Size = new Size(125, 27);
            txtAdress.TabIndex = 19;
            // 
            // lbEngLow
            // 
            lbEngLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngLow.AutoSize = true;
            lbEngLow.Location = new Point(421, 180);
            lbEngLow.Name = "lbEngLow";
            lbEngLow.Size = new Size(34, 20);
            lbEngLow.TabIndex = 20;
            lbEngLow.Text = "Min";
            // 
            // txtEngLow
            // 
            txtEngLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngLow.Location = new Point(421, 203);
            txtEngLow.Name = "txtEngLow";
            txtEngLow.ReadOnly = true;
            txtEngLow.Size = new Size(125, 27);
            txtEngLow.TabIndex = 21;
            // 
            // lbEngHigh
            // 
            lbEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngHigh.AutoSize = true;
            lbEngHigh.Location = new Point(552, 180);
            lbEngHigh.Name = "lbEngHigh";
            lbEngHigh.Size = new Size(37, 20);
            lbEngHigh.TabIndex = 22;
            lbEngHigh.Text = "Max";
            // 
            // txtEngHigh
            // 
            txtEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngHigh.Location = new Point(552, 203);
            txtEngHigh.Name = "txtEngHigh";
            txtEngHigh.ReadOnly = true;
            txtEngHigh.Size = new Size(125, 27);
            txtEngHigh.TabIndex = 23;
            // 
            // lbSerialLow
            // 
            lbSerialLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSerialLow.AutoSize = true;
            lbSerialLow.Location = new Point(495, 245);
            lbSerialLow.Name = "lbSerialLow";
            lbSerialLow.Size = new Size(61, 20);
            lbSerialLow.TabIndex = 24;
            lbSerialLow.Text = "Bus Min";
            // 
            // txtSerialLow
            // 
            txtSerialLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialLow.Location = new Point(495, 269);
            txtSerialLow.Name = "txtSerialLow";
            txtSerialLow.ReadOnly = true;
            txtSerialLow.Size = new Size(125, 27);
            txtSerialLow.TabIndex = 25;
            // 
            // lbSerialHigh
            // 
            lbSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSerialHigh.AutoSize = true;
            lbSerialHigh.Location = new Point(649, 245);
            lbSerialHigh.Name = "lbSerialHigh";
            lbSerialHigh.Size = new Size(64, 20);
            lbSerialHigh.TabIndex = 26;
            lbSerialHigh.Text = "Bus Max";
            // 
            // txtSerialHigh
            // 
            txtSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialHigh.Location = new Point(649, 269);
            txtSerialHigh.Name = "txtSerialHigh";
            txtSerialHigh.ReadOnly = true;
            txtSerialHigh.Size = new Size(125, 27);
            txtSerialHigh.TabIndex = 27;
            // 
            // comboBoxSerialLine
            // 
            comboBoxSerialLine.FormattingEnabled = true;
            comboBoxSerialLine.Location = new Point(26, 45);
            comboBoxSerialLine.Name = "comboBoxSerialLine";
            comboBoxSerialLine.Size = new Size(207, 28);
            comboBoxSerialLine.TabIndex = 28;
            comboBoxSerialLine.SelectedIndexChanged += comboBoxSerialLine_SelectedIndexChanged;
            // 
            // lbEngUnit
            // 
            lbEngUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngUnit.AutoSize = true;
            lbEngUnit.Location = new Point(693, 177);
            lbEngUnit.Name = "lbEngUnit";
            lbEngUnit.Size = new Size(65, 20);
            lbEngUnit.TabIndex = 29;
            lbEngUnit.Text = "Eng Unit";
            // 
            // txtEngUnit
            // 
            txtEngUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngUnit.Location = new Point(693, 203);
            txtEngUnit.Name = "txtEngUnit";
            txtEngUnit.ReadOnly = true;
            txtEngUnit.Size = new Size(82, 27);
            txtEngUnit.TabIndex = 30;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripFile, toolStripCommSettings, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(954, 30);
            menuStrip1.TabIndex = 33;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripFile
            // 
            toolStripFile.DropDownItems.AddRange(new ToolStripItem[] { importIOListToolStripMenuItem, exitToolStripMenuItem });
            toolStripFile.Name = "toolStripFile";
            toolStripFile.Size = new Size(46, 24);
            toolStripFile.Text = "File";
            // 
            // importIOListToolStripMenuItem
            // 
            importIOListToolStripMenuItem.Name = "importIOListToolStripMenuItem";
            importIOListToolStripMenuItem.Size = new Size(184, 26);
            importIOListToolStripMenuItem.Text = "Import IO-List";
            importIOListToolStripMenuItem.Click += importIOListToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(184, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripCommSettings
            // 
            toolStripCommSettings.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            toolStripCommSettings.Name = "toolStripCommSettings";
            toolStripCommSettings.Size = new Size(128, 24);
            toolStripCommSettings.Text = "Communication";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(145, 26);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { userManualToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // userManualToolStripMenuItem
            // 
            userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            userManualToolStripMenuItem.Size = new Size(174, 26);
            userManualToolStripMenuItem.Text = "User manual";
            userManualToolStripMenuItem.Click += HelpUserManualClick;
            // 
            // btnStartSimulator
            // 
            btnStartSimulator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartSimulator.Location = new Point(803, 59);
            btnStartSimulator.Name = "btnStartSimulator";
            btnStartSimulator.Size = new Size(139, 51);
            btnStartSimulator.TabIndex = 34;
            btnStartSimulator.Text = "Start Simulator";
            btnStartSimulator.UseVisualStyleBackColor = true;
            btnStartSimulator.Click += btnStartSimulator_Click;
            // 
            // btnStopSimulator
            // 
            btnStopSimulator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStopSimulator.Location = new Point(803, 125);
            btnStopSimulator.Name = "btnStopSimulator";
            btnStopSimulator.Size = new Size(139, 51);
            btnStopSimulator.TabIndex = 35;
            btnStopSimulator.Text = "Stop Simulator";
            btnStopSimulator.UseVisualStyleBackColor = true;
            btnStopSimulator.Click += btnStopSimulator_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(-6, 327);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 36;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(274, 315);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 37;
            label3.Text = "Test Result :";
            // 
            // btnResultNotOK
            // 
            btnResultNotOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnResultNotOK.BackColor = SystemColors.Control;
            btnResultNotOK.ForeColor = Color.Red;
            btnResultNotOK.Location = new Point(374, 339);
            btnResultNotOK.Name = "btnResultNotOK";
            btnResultNotOK.Size = new Size(94, 29);
            btnResultNotOK.TabIndex = 38;
            btnResultNotOK.Text = "X";
            btnResultNotOK.UseVisualStyleBackColor = false;
            btnResultNotOK.Click += btnResultNotOKClick;
            // 
            // btnResultOK
            // 
            btnResultOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnResultOK.BackColor = SystemColors.Control;
            btnResultOK.ForeColor = Color.LawnGreen;
            btnResultOK.Location = new Point(274, 339);
            btnResultOK.Name = "btnResultOK";
            btnResultOK.Size = new Size(94, 29);
            btnResultOK.TabIndex = 39;
            btnResultOK.Text = "✔";
            btnResultOK.UseVisualStyleBackColor = false;
            btnResultOK.Click += btnResultOKClick;
            // 
            // txtRawBusValue
            // 
            txtRawBusValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRawBusValue.Location = new Point(495, 340);
            txtRawBusValue.Name = "txtRawBusValue";
            txtRawBusValue.ReadOnly = true;
            txtRawBusValue.Size = new Size(125, 27);
            txtRawBusValue.TabIndex = 36;
            // 
            // lbRawBusValue
            // 
            lbRawBusValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRawBusValue.AutoSize = true;
            lbRawBusValue.Location = new Point(527, 317);
            lbRawBusValue.Name = "lbRawBusValue";
            lbRawBusValue.Size = new Size(64, 20);
            lbRawBusValue.TabIndex = 37;
            lbRawBusValue.Text = "Raw Bus";
            // 
            // cbPlusRegister
            // 
            cbPlusRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbPlusRegister.AutoSize = true;
            cbPlusRegister.Location = new Point(278, 245);
            cbPlusRegister.Name = "cbPlusRegister";
            cbPlusRegister.Size = new Size(49, 24);
            cbPlusRegister.TabIndex = 38;
            cbPlusRegister.Text = "+1";
            cbPlusRegister.UseVisualStyleBackColor = true;
            // 
            // cbMinusRegister
            // 
            cbMinusRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbMinusRegister.AutoSize = true;
            cbMinusRegister.Location = new Point(359, 245);
            cbMinusRegister.Name = "cbMinusRegister";
            cbMinusRegister.Size = new Size(45, 24);
            cbMinusRegister.TabIndex = 39;
            cbMinusRegister.Text = "-1";
            cbMinusRegister.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(289, 449);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 40;
            label1.Text = "WatchDog counter:";
            // 
            // txtWatchDog
            // 
            txtWatchDog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtWatchDog.Location = new Point(489, 480);
            txtWatchDog.Name = "txtWatchDog";
            txtWatchDog.ReadOnly = true;
            txtWatchDog.Size = new Size(78, 27);
            txtWatchDog.TabIndex = 41;
            // 
            // listViewSignals
            // 
            listViewSignals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewSignals.BackColor = Color.Silver;
            listViewSignals.Columns.AddRange(new ColumnHeader[] { columnHeaderTag });
            listViewSignals.Location = new Point(11, 79);
            listViewSignals.Name = "listViewSignals";
            listViewSignals.OwnerDraw = true;
            listViewSignals.Size = new Size(244, 489);
            listViewSignals.TabIndex = 40;
            listViewSignals.UseCompatibleStateImageBehavior = false;
            listViewSignals.View = View.Details;
            listViewSignals.SelectedIndexChanged += listViewSignals_SelectedIndexChanged;
            listViewSignals.KeyDown += listViewSignals_KeyDown;
            listViewSignals.MouseClick += listViewSignals_MouseClick;
            listViewSignals.MouseDoubleClick += listViewSignals_MouseDoubleClick;
            // 
            // columnHeaderTag
            // 
            columnHeaderTag.Text = "Tag";
            columnHeaderTag.Width = 240;
            // 
            // comboBoxWatchdogInterval
            // 
            comboBoxWatchdogInterval.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxWatchdogInterval.FormattingEnabled = true;
            comboBoxWatchdogInterval.Items.AddRange(new object[] { "100", "200", "400", "600", "800", "1000" });
            comboBoxWatchdogInterval.Location = new Point(525, 520);
            comboBoxWatchdogInterval.Name = "comboBoxWatchdogInterval";
            comboBoxWatchdogInterval.Size = new Size(108, 28);
            comboBoxWatchdogInterval.TabIndex = 42;
            // 
            // btnWatchdogStart
            // 
            btnWatchdogStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnWatchdogStart.Location = new Point(573, 480);
            btnWatchdogStart.Name = "btnWatchdogStart";
            btnWatchdogStart.Size = new Size(94, 29);
            btnWatchdogStart.TabIndex = 43;
            btnWatchdogStart.Text = "Start";
            btnWatchdogStart.UseVisualStyleBackColor = true;
            btnWatchdogStart.Click += btnWatchdogStart_Click;
            // 
            // lbWatchdogMs
            // 
            lbWatchdogMs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbWatchdogMs.AutoSize = true;
            lbWatchdogMs.Location = new Point(639, 523);
            lbWatchdogMs.Name = "lbWatchdogMs";
            lbWatchdogMs.Size = new Size(28, 20);
            lbWatchdogMs.TabIndex = 44;
            lbWatchdogMs.Text = "ms";
            // 
            // CheckboxConnected
            // 
            CheckboxConnected.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckboxConnected.AutoSize = true;
            CheckboxConnected.Enabled = false;
            CheckboxConnected.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CheckboxConnected.Location = new Point(803, 181);
            CheckboxConnected.Name = "CheckboxConnected";
            CheckboxConnected.Size = new Size(117, 27);
            CheckboxConnected.TabIndex = 45;
            CheckboxConnected.Text = "Connected";
            CheckboxConnected.UseVisualStyleBackColor = true;
            // 
            // txtWatchdogAddress
            // 
            txtWatchdogAddress.Location = new Point(330, 480);
            txtWatchdogAddress.Name = "txtWatchdogAddress";
            txtWatchdogAddress.Size = new Size(125, 27);
            txtWatchdogAddress.TabIndex = 46;
            // 
            // lbWatchdogAddress
            // 
            lbWatchdogAddress.AutoSize = true;
            lbWatchdogAddress.Location = new Point(262, 484);
            lbWatchdogAddress.Name = "lbWatchdogAddress";
            lbWatchdogAddress.Size = new Size(65, 20);
            lbWatchdogAddress.TabIndex = 47;
            lbWatchdogAddress.Text = "Address:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 573);
            Controls.Add(lbWatchdogAddress);
            Controls.Add(txtWatchdogAddress);
            Controls.Add(CheckboxConnected);
            Controls.Add(lbWatchdogMs);
            Controls.Add(btnWatchdogStart);
            Controls.Add(comboBoxWatchdogInterval);
            Controls.Add(txtWatchDog);
            Controls.Add(label1);
            Controls.Add(listViewSignals);
            Controls.Add(btnResultOK);
            Controls.Add(btnResultNotOK);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbMinusRegister);
            Controls.Add(cbPlusRegister);
            Controls.Add(lbRawBusValue);
            Controls.Add(txtRawBusValue);
            Controls.Add(btnStopSimulator);
            Controls.Add(btnStartSimulator);
            Controls.Add(txtEngUnit);
            Controls.Add(lbEngUnit);
            Controls.Add(comboBoxSerialLine);
            Controls.Add(txtSerialHigh);
            Controls.Add(lbSerialHigh);
            Controls.Add(txtSerialLow);
            Controls.Add(lbSerialLow);
            Controls.Add(txtEngHigh);
            Controls.Add(lbEngHigh);
            Controls.Add(txtEngLow);
            Controls.Add(lbEngLow);
            Controls.Add(txtAdress);
            Controls.Add(lbAdress);
            Controls.Add(txtDescription);
            Controls.Add(lbDescription);
            Controls.Add(txtTag);
            Controls.Add(lbTag);
            Controls.Add(btnChangeHolding);
            Controls.Add(lbRawBus);
            Controls.Add(txtHoldingValue);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtHoldingValue;
        private Label lbRawBus;
        private Button btnChangeHolding;
        private OpenFileDialog FileDialogDB;
        private Label lbTag;
        private TextBox txtTag;
        private Label lbDescription;
        private TextBox txtDescription;
        private Label lbAdress;
        private TextBox txtAdress;
        private Label lbEngLow;
        private TextBox txtEngLow;
        private Label lbEngHigh;
        private TextBox txtEngHigh;
        private Label lbSerialLow;
        private TextBox txtSerialLow;
        private Label lbSerialHigh;
        private TextBox txtSerialHigh;
        private ComboBox comboBoxSerialLine;
        private Label lbEngUnit;
        private TextBox txtEngUnit;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripFile;
        private ToolStripMenuItem importIOListToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolStripCommSettings;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Button btnStartSimulator;
        private Button btnStopSimulator;
        private Label label2;
        private Label label3;
        private Button btnResultNotOK;
        private Button btnResultOK;
        private TextBox txtRawBusValue;
        private Label lbRawBusValue;
        private CheckBox cbPlusRegister;
        private CheckBox cbMinusRegister;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem userManualToolStripMenuItem;
        private Label label1;
        private TextBox txtWatchDog;
        private ListView listViewSignals;
        private ColumnHeader columnHeaderTag;
        private ComboBox comboBoxWatchdogInterval;
        private Button btnWatchdogStart;
        private Label lbWatchdogMs;
        private RoundCheckbox CheckboxConnected;
        private TextBox txtWatchdogAddress;
        private Label lbWatchdogAddress;
    }
}
