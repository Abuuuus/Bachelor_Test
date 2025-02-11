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
            listBoxSignals = new ListBox();
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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtHoldingValue
            // 
            txtHoldingValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHoldingValue.Location = new Point(709, 349);
            txtHoldingValue.Name = "txtHoldingValue";
            txtHoldingValue.Size = new Size(125, 27);
            txtHoldingValue.TabIndex = 5;
            txtHoldingValue.TextChanged += txtHoldingValue_TextChanged;
            // 
            // lbRawBus
            // 
            lbRawBus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRawBus.AutoSize = true;
            lbRawBus.Location = new Point(709, 327);
            lbRawBus.Name = "lbRawBus";
            lbRawBus.Size = new Size(74, 20);
            lbRawBus.TabIndex = 6;
            lbRawBus.Text = "Eng Value";
            // 
            // btnChangeHolding
            // 
            btnChangeHolding.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeHolding.Location = new Point(846, 340);
            btnChangeHolding.Name = "btnChangeHolding";
            btnChangeHolding.Size = new Size(138, 51);
            btnChangeHolding.TabIndex = 9;
            btnChangeHolding.Text = "Toggle";
            btnChangeHolding.UseVisualStyleBackColor = true;
            btnChangeHolding.Click += btnChangeHolding_Click;
            // 
            // lbTag
            // 
            lbTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTag.AutoSize = true;
            lbTag.Location = new Point(262, 48);
            lbTag.Name = "lbTag";
            lbTag.Size = new Size(32, 20);
            lbTag.TabIndex = 13;
            lbTag.Text = "Tag";
            // 
            // listBoxSignals
            // 
            listBoxSignals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxSignals.FormattingEnabled = true;
            listBoxSignals.Location = new Point(11, 83);
            listBoxSignals.Name = "listBoxSignals";
            listBoxSignals.Size = new Size(245, 564);
            listBoxSignals.TabIndex = 14;
            listBoxSignals.MouseDoubleClick += listBoxSignals_MouseDoubleClick;
            // 
            // txtTag
            // 
            txtTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTag.Location = new Point(262, 71);
            txtTag.Name = "txtTag";
            txtTag.ReadOnly = true;
            txtTag.Size = new Size(494, 27);
            txtTag.TabIndex = 15;
            // 
            // lbDescription
            // 
            lbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbDescription.AutoSize = true;
            lbDescription.Location = new Point(262, 101);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(85, 20);
            lbDescription.TabIndex = 16;
            lbDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDescription.Location = new Point(262, 125);
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(494, 27);
            txtDescription.TabIndex = 17;
            // 
            // lbAdress
            // 
            lbAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbAdress.AutoSize = true;
            lbAdress.Location = new Point(262, 173);
            lbAdress.Name = "lbAdress";
            lbAdress.Size = new Size(53, 20);
            lbAdress.TabIndex = 18;
            lbAdress.Text = "Adress";
            // 
            // txtAdress
            // 
            txtAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAdress.Location = new Point(262, 203);
            txtAdress.Name = "txtAdress";
            txtAdress.ReadOnly = true;
            txtAdress.Size = new Size(125, 27);
            txtAdress.TabIndex = 19;
            // 
            // lbEngLow
            // 
            lbEngLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngLow.AutoSize = true;
            lbEngLow.Location = new Point(458, 177);
            lbEngLow.Name = "lbEngLow";
            lbEngLow.Size = new Size(34, 20);
            lbEngLow.TabIndex = 20;
            lbEngLow.Text = "Min";
            // 
            // txtEngLow
            // 
            txtEngLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngLow.Location = new Point(458, 203);
            txtEngLow.Name = "txtEngLow";
            txtEngLow.ReadOnly = true;
            txtEngLow.Size = new Size(125, 27);
            txtEngLow.TabIndex = 21;
            // 
            // lbEngHigh
            // 
            lbEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngHigh.AutoSize = true;
            lbEngHigh.Location = new Point(603, 173);
            lbEngHigh.Name = "lbEngHigh";
            lbEngHigh.Size = new Size(37, 20);
            lbEngHigh.TabIndex = 22;
            lbEngHigh.Text = "Max";
            // 
            // txtEngHigh
            // 
            txtEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngHigh.Location = new Point(603, 203);
            txtEngHigh.Name = "txtEngHigh";
            txtEngHigh.ReadOnly = true;
            txtEngHigh.Size = new Size(125, 27);
            txtEngHigh.TabIndex = 23;
            // 
            // lbSerialLow
            // 
            lbSerialLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSerialLow.AutoSize = true;
            lbSerialLow.Location = new Point(458, 245);
            lbSerialLow.Name = "lbSerialLow";
            lbSerialLow.Size = new Size(61, 20);
            lbSerialLow.TabIndex = 24;
            lbSerialLow.Text = "Bus Min";
            // 
            // txtSerialLow
            // 
            txtSerialLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialLow.Location = new Point(458, 269);
            txtSerialLow.Name = "txtSerialLow";
            txtSerialLow.ReadOnly = true;
            txtSerialLow.Size = new Size(125, 27);
            txtSerialLow.TabIndex = 25;
            // 
            // lbSerialHigh
            // 
            lbSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSerialHigh.AutoSize = true;
            lbSerialHigh.Location = new Point(603, 245);
            lbSerialHigh.Name = "lbSerialHigh";
            lbSerialHigh.Size = new Size(64, 20);
            lbSerialHigh.TabIndex = 26;
            lbSerialHigh.Text = "Bus Max";
            // 
            // txtSerialHigh
            // 
            txtSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialHigh.Location = new Point(603, 269);
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
            lbEngUnit.Location = new Point(751, 173);
            lbEngUnit.Name = "lbEngUnit";
            lbEngUnit.Size = new Size(65, 20);
            lbEngUnit.TabIndex = 29;
            lbEngUnit.Text = "Eng Unit";
            // 
            // txtEngUnit
            // 
            txtEngUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngUnit.Location = new Point(751, 203);
            txtEngUnit.Name = "txtEngUnit";
            txtEngUnit.ReadOnly = true;
            txtEngUnit.Size = new Size(82, 27);
            txtEngUnit.TabIndex = 30;
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripFile, toolStripCommSettings });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1258, 30);
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
            // btnStartSimulator
            // 
            btnStartSimulator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartSimulator.Location = new Point(846, 59);
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
            btnStopSimulator.Location = new Point(846, 125);
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
            label2.Location = new Point(298, 327);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 36;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(277, 327);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 37;
            label3.Text = "Test Result :";
            // 
            // btnResultNotOK
            // 
            btnResultNotOK.BackColor = SystemColors.Control;
            btnResultNotOK.ForeColor = Color.Red;
            btnResultNotOK.Location = new Point(387, 362);
            btnResultNotOK.Name = "btnResultNotOK";
            btnResultNotOK.Size = new Size(94, 29);
            btnResultNotOK.TabIndex = 38;
            btnResultNotOK.Text = "X";
            btnResultNotOK.UseVisualStyleBackColor = false;
            btnResultNotOK.Click += btnResultNotOKClick;
            // 
            // btnResultOK
            // 
            btnResultOK.BackColor = SystemColors.Control;
            btnResultOK.ForeColor = Color.LawnGreen;
            btnResultOK.Location = new Point(277, 362);
            btnResultOK.Name = "btnResultOK";
            btnResultOK.Size = new Size(94, 29);
            btnResultOK.TabIndex = 39;
            btnResultOK.Text = "✔";
            btnResultOK.UseVisualStyleBackColor = false;
            btnResultOK.Click += btnResultOKClick;
            // txtRawBusValue
            // 
            txtRawBusValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRawBusValue.Location = new Point(568, 349);
            txtRawBusValue.Name = "txtRawBusValue";
            txtRawBusValue.ReadOnly = true;
            txtRawBusValue.Size = new Size(125, 27);
            txtRawBusValue.TabIndex = 36;
            // 
            // lbRawBusValue
            // 
            lbRawBusValue.AutoSize = true;
            lbRawBusValue.Location = new Point(568, 327);
            lbRawBusValue.Name = "lbRawBusValue";
            lbRawBusValue.Size = new Size(64, 20);
            lbRawBusValue.TabIndex = 37;
            lbRawBusValue.Text = "Raw Bus";
            // 
            // cbPlusRegister
            // 
            cbPlusRegister.AutoSize = true;
            cbPlusRegister.Location = new Point(262, 244);
            cbPlusRegister.Name = "cbPlusRegister";
            cbPlusRegister.Size = new Size(49, 24);
            cbPlusRegister.TabIndex = 38;
            cbPlusRegister.Text = "+1";
            cbPlusRegister.UseVisualStyleBackColor = true;
            // 
            // cbMinusRegister
            // 
            cbMinusRegister.AutoSize = true;
            cbMinusRegister.Location = new Point(326, 245);
            cbMinusRegister.Name = "cbMinusRegister";
            cbMinusRegister.Size = new Size(45, 24);
            cbMinusRegister.TabIndex = 39;
            cbMinusRegister.Text = "-1";
            cbMinusRegister.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 891);
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
            Controls.Add(listBoxSignals);
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
        private ListBox listBoxSignals;
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
    }
}
