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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtHoldingValue
            // 
            txtHoldingValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHoldingValue.Location = new Point(568, 255);
            txtHoldingValue.Margin = new Padding(3, 2, 3, 2);
            txtHoldingValue.Name = "txtHoldingValue";
            txtHoldingValue.Size = new Size(110, 23);
            txtHoldingValue.TabIndex = 5;
            txtHoldingValue.TextChanged += txtHoldingValue_TextChanged;
            txtHoldingValue.KeyPress += txtHoldingValue_KeyPress;
            // 
            // lbRawBus
            // 
            lbRawBus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRawBus.AutoSize = true;
            lbRawBus.Location = new Point(568, 238);
            lbRawBus.Name = "lbRawBus";
            lbRawBus.Size = new Size(58, 15);
            lbRawBus.TabIndex = 6;
            lbRawBus.Text = "Eng Value";
            // 
            // btnChangeHolding
            // 
            btnChangeHolding.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeHolding.Location = new Point(695, 246);
            btnChangeHolding.Margin = new Padding(3, 2, 3, 2);
            btnChangeHolding.Name = "btnChangeHolding";
            btnChangeHolding.Size = new Size(121, 38);
            btnChangeHolding.TabIndex = 9;
            btnChangeHolding.Text = "Toggle";
            btnChangeHolding.UseVisualStyleBackColor = true;
            btnChangeHolding.Click += btnToggleValue;
            // 
            // lbTag
            // 
            lbTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTag.AutoSize = true;
            lbTag.Location = new Point(245, 36);
            lbTag.Name = "lbTag";
            lbTag.Size = new Size(26, 15);
            lbTag.TabIndex = 13;
            lbTag.Text = "Tag";
            // 
            // txtTag
            // 
            txtTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTag.Location = new Point(245, 53);
            txtTag.Margin = new Padding(3, 2, 3, 2);
            txtTag.Name = "txtTag";
            txtTag.ReadOnly = true;
            txtTag.Size = new Size(433, 23);
            txtTag.TabIndex = 15;
            // 
            // lbDescription
            // 
            lbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbDescription.AutoSize = true;
            lbDescription.Location = new Point(245, 76);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(67, 15);
            lbDescription.TabIndex = 16;
            lbDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDescription.Location = new Point(245, 94);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(433, 23);
            txtDescription.TabIndex = 17;
            // 
            // lbAdress
            // 
            lbAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbAdress.AutoSize = true;
            lbAdress.Location = new Point(245, 135);
            lbAdress.Name = "lbAdress";
            lbAdress.Size = new Size(42, 15);
            lbAdress.TabIndex = 18;
            lbAdress.Text = "Adress";
            // 
            // txtAdress
            // 
            txtAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAdress.Location = new Point(245, 152);
            txtAdress.Margin = new Padding(3, 2, 3, 2);
            txtAdress.Name = "txtAdress";
            txtAdress.ReadOnly = true;
            txtAdress.Size = new Size(110, 23);
            txtAdress.TabIndex = 19;
            // 
            // lbEngLow
            // 
            lbEngLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngLow.AutoSize = true;
            lbEngLow.Location = new Point(368, 135);
            lbEngLow.Name = "lbEngLow";
            lbEngLow.Size = new Size(28, 15);
            lbEngLow.TabIndex = 20;
            lbEngLow.Text = "Min";
            // 
            // txtEngLow
            // 
            txtEngLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngLow.Location = new Point(368, 152);
            txtEngLow.Margin = new Padding(3, 2, 3, 2);
            txtEngLow.Name = "txtEngLow";
            txtEngLow.ReadOnly = true;
            txtEngLow.Size = new Size(110, 23);
            txtEngLow.TabIndex = 21;
            // 
            // lbEngHigh
            // 
            lbEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngHigh.AutoSize = true;
            lbEngHigh.Location = new Point(483, 135);
            lbEngHigh.Name = "lbEngHigh";
            lbEngHigh.Size = new Size(29, 15);
            lbEngHigh.TabIndex = 22;
            lbEngHigh.Text = "Max";
            // 
            // txtEngHigh
            // 
            txtEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngHigh.Location = new Point(483, 152);
            txtEngHigh.Margin = new Padding(3, 2, 3, 2);
            txtEngHigh.Name = "txtEngHigh";
            txtEngHigh.ReadOnly = true;
            txtEngHigh.Size = new Size(110, 23);
            txtEngHigh.TabIndex = 23;
            // 
            // lbSerialLow
            // 
            lbSerialLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSerialLow.AutoSize = true;
            lbSerialLow.Location = new Point(433, 184);
            lbSerialLow.Name = "lbSerialLow";
            lbSerialLow.Size = new Size(50, 15);
            lbSerialLow.TabIndex = 24;
            lbSerialLow.Text = "Bus Min";
            // 
            // txtSerialLow
            // 
            txtSerialLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialLow.Location = new Point(433, 202);
            txtSerialLow.Margin = new Padding(3, 2, 3, 2);
            txtSerialLow.Name = "txtSerialLow";
            txtSerialLow.ReadOnly = true;
            txtSerialLow.Size = new Size(110, 23);
            txtSerialLow.TabIndex = 25;
            // 
            // lbSerialHigh
            // 
            lbSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSerialHigh.AutoSize = true;
            lbSerialHigh.Location = new Point(568, 184);
            lbSerialHigh.Name = "lbSerialHigh";
            lbSerialHigh.Size = new Size(51, 15);
            lbSerialHigh.TabIndex = 26;
            lbSerialHigh.Text = "Bus Max";
            // 
            // txtSerialHigh
            // 
            txtSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialHigh.Location = new Point(568, 202);
            txtSerialHigh.Margin = new Padding(3, 2, 3, 2);
            txtSerialHigh.Name = "txtSerialHigh";
            txtSerialHigh.ReadOnly = true;
            txtSerialHigh.Size = new Size(110, 23);
            txtSerialHigh.TabIndex = 27;
            // 
            // comboBoxSerialLine
            // 
            comboBoxSerialLine.FormattingEnabled = true;
            comboBoxSerialLine.Location = new Point(23, 34);
            comboBoxSerialLine.Margin = new Padding(3, 2, 3, 2);
            comboBoxSerialLine.Name = "comboBoxSerialLine";
            comboBoxSerialLine.Size = new Size(182, 23);
            comboBoxSerialLine.TabIndex = 28;
            comboBoxSerialLine.SelectedIndexChanged += comboBoxSerialLine_SelectedIndexChanged;
            // 
            // lbEngUnit
            // 
            lbEngUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngUnit.AutoSize = true;
            lbEngUnit.Location = new Point(606, 133);
            lbEngUnit.Name = "lbEngUnit";
            lbEngUnit.Size = new Size(52, 15);
            lbEngUnit.TabIndex = 29;
            lbEngUnit.Text = "Eng Unit";
            // 
            // txtEngUnit
            // 
            txtEngUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngUnit.Location = new Point(606, 152);
            txtEngUnit.Margin = new Padding(3, 2, 3, 2);
            txtEngUnit.Name = "txtEngUnit";
            txtEngUnit.ReadOnly = true;
            txtEngUnit.Size = new Size(72, 23);
            txtEngUnit.TabIndex = 30;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripFile, toolStripCommSettings, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(835, 24);
            menuStrip1.TabIndex = 33;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripFile
            // 
            toolStripFile.DropDownItems.AddRange(new ToolStripItem[] { importIOListToolStripMenuItem, exitToolStripMenuItem });
            toolStripFile.Name = "toolStripFile";
            toolStripFile.Size = new Size(37, 20);
            toolStripFile.Text = "File";
            // 
            // importIOListToolStripMenuItem
            // 
            importIOListToolStripMenuItem.Name = "importIOListToolStripMenuItem";
            importIOListToolStripMenuItem.Size = new Size(148, 22);
            importIOListToolStripMenuItem.Text = "Import IO-List";
            importIOListToolStripMenuItem.Click += importIOListToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(148, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripCommSettings
            // 
            toolStripCommSettings.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            toolStripCommSettings.Name = "toolStripCommSettings";
            toolStripCommSettings.Size = new Size(106, 20);
            toolStripCommSettings.Text = "Communication";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(116, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { userManualToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // userManualToolStripMenuItem
            // 
            userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            userManualToolStripMenuItem.Size = new Size(140, 22);
            userManualToolStripMenuItem.Text = "User manual";
            userManualToolStripMenuItem.Click += HelpUserManualClick;
            // 
            // btnStartSimulator
            // 
            btnStartSimulator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartSimulator.Location = new Point(703, 44);
            btnStartSimulator.Margin = new Padding(3, 2, 3, 2);
            btnStartSimulator.Name = "btnStartSimulator";
            btnStartSimulator.Size = new Size(122, 38);
            btnStartSimulator.TabIndex = 34;
            btnStartSimulator.Text = "Start Simulator";
            btnStartSimulator.UseVisualStyleBackColor = true;
            btnStartSimulator.Click += btnStartSimulator_Click;
            // 
            // btnStopSimulator
            // 
            btnStopSimulator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStopSimulator.Location = new Point(703, 94);
            btnStopSimulator.Margin = new Padding(3, 2, 3, 2);
            btnStopSimulator.Name = "btnStopSimulator";
            btnStopSimulator.Size = new Size(122, 38);
            btnStopSimulator.TabIndex = 35;
            btnStopSimulator.Text = "Stop Simulator";
            btnStopSimulator.UseVisualStyleBackColor = true;
            btnStopSimulator.Click += btnStopSimulator_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(-5, 245);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 36;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(240, 236);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 37;
            label3.Text = "Test Result :";
            // 
            // btnResultNotOK
            // 
            btnResultNotOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnResultNotOK.BackColor = SystemColors.Control;
            btnResultNotOK.ForeColor = Color.Red;
            btnResultNotOK.Location = new Point(327, 254);
            btnResultNotOK.Margin = new Padding(3, 2, 3, 2);
            btnResultNotOK.Name = "btnResultNotOK";
            btnResultNotOK.Size = new Size(82, 22);
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
            btnResultOK.Location = new Point(240, 254);
            btnResultOK.Margin = new Padding(3, 2, 3, 2);
            btnResultOK.Name = "btnResultOK";
            btnResultOK.Size = new Size(82, 22);
            btnResultOK.TabIndex = 39;
            btnResultOK.Text = "✔";
            btnResultOK.UseVisualStyleBackColor = false;
            btnResultOK.Click += btnResultOKClick;
            // 
            // txtRawBusValue
            // 
            txtRawBusValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRawBusValue.Location = new Point(433, 255);
            txtRawBusValue.Margin = new Padding(3, 2, 3, 2);
            txtRawBusValue.Name = "txtRawBusValue";
            txtRawBusValue.ReadOnly = true;
            txtRawBusValue.Size = new Size(110, 23);
            txtRawBusValue.TabIndex = 36;
            // 
            // lbRawBusValue
            // 
            lbRawBusValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRawBusValue.AutoSize = true;
            lbRawBusValue.Location = new Point(461, 238);
            lbRawBusValue.Name = "lbRawBusValue";
            lbRawBusValue.Size = new Size(51, 15);
            lbRawBusValue.TabIndex = 37;
            lbRawBusValue.Text = "Raw Bus";
            // 
            // cbPlusRegister
            // 
            cbPlusRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbPlusRegister.AutoSize = true;
            cbPlusRegister.Location = new Point(246, 184);
            cbPlusRegister.Margin = new Padding(3, 2, 3, 2);
            cbPlusRegister.Name = "cbPlusRegister";
            cbPlusRegister.Size = new Size(40, 19);
            cbPlusRegister.TabIndex = 38;
            cbPlusRegister.Text = "+1";
            cbPlusRegister.UseVisualStyleBackColor = true;
            // 
            // cbMinusRegister
            // 
            cbMinusRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbMinusRegister.AutoSize = true;
            cbMinusRegister.Location = new Point(317, 184);
            cbMinusRegister.Margin = new Padding(3, 2, 3, 2);
            cbMinusRegister.Name = "cbMinusRegister";
            cbMinusRegister.Size = new Size(37, 19);
            cbMinusRegister.TabIndex = 39;
            cbMinusRegister.Text = "-1";
            cbMinusRegister.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(253, 337);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 40;
            label1.Text = "WatchDog counter:";
            // 
            // txtWatchDog
            // 
            txtWatchDog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtWatchDog.Location = new Point(253, 362);
            txtWatchDog.Margin = new Padding(3, 2, 3, 2);
            txtWatchDog.Name = "txtWatchDog";
            txtWatchDog.ReadOnly = true;
            txtWatchDog.Size = new Size(110, 23);
            txtWatchDog.TabIndex = 41;
            // 
            // listViewSignals
            // 
            listViewSignals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewSignals.BackColor = Color.Silver;
            listViewSignals.Columns.AddRange(new ColumnHeader[] { columnHeaderTag });
            listViewSignals.Location = new Point(10, 59);
            listViewSignals.Margin = new Padding(3, 2, 3, 2);
            listViewSignals.Name = "listViewSignals";
            listViewSignals.Size = new Size(214, 368);
            listViewSignals.TabIndex = 40;
            listViewSignals.UseCompatibleStateImageBehavior = false;
            listViewSignals.View = View.Details;
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
            comboBoxWatchdogInterval.Location = new Point(382, 388);
            comboBoxWatchdogInterval.Margin = new Padding(3, 2, 3, 2);
            comboBoxWatchdogInterval.Name = "comboBoxWatchdogInterval";
            comboBoxWatchdogInterval.Size = new Size(95, 23);
            comboBoxWatchdogInterval.TabIndex = 42;
            // 
            // btnWatchdogStart
            // 
            btnWatchdogStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnWatchdogStart.Location = new Point(382, 360);
            btnWatchdogStart.Margin = new Padding(3, 2, 3, 2);
            btnWatchdogStart.Name = "btnWatchdogStart";
            btnWatchdogStart.Size = new Size(82, 22);
            btnWatchdogStart.TabIndex = 43;
            btnWatchdogStart.Text = "Start";
            btnWatchdogStart.UseVisualStyleBackColor = true;
            btnWatchdogStart.Click += btnWatchdogStart_Click;
            // 
            // lbWatchdogMs
            // 
            lbWatchdogMs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbWatchdogMs.AutoSize = true;
            lbWatchdogMs.Location = new Point(481, 391);
            lbWatchdogMs.Name = "lbWatchdogMs";
            lbWatchdogMs.Size = new Size(23, 15);
            lbWatchdogMs.TabIndex = 44;
            lbWatchdogMs.Text = "ms";
            // 
            // CheckboxConnected
            // 
            CheckboxConnected.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CheckboxConnected.AutoSize = true;
            CheckboxConnected.Enabled = false;
            CheckboxConnected.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CheckboxConnected.Location = new Point(706, 136);
            CheckboxConnected.Margin = new Padding(3, 2, 3, 2);
            CheckboxConnected.Name = "CheckboxConnected";
            CheckboxConnected.Size = new Size(99, 23);
            CheckboxConnected.TabIndex = 45;
            CheckboxConnected.Text = "Connected";
            CheckboxConnected.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(835, 430);
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
    }
}
