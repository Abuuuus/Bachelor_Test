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
            btnClearText = new Button();
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
            textHAddress = new TextBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            toolStripFile = new ToolStripMenuItem();
            importIOListToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripCommSettings = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            btnStartSimulator = new Button();
            btnStopSimulator = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtHoldingValue
            // 
            txtHoldingValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHoldingValue.Location = new Point(708, 350);
            txtHoldingValue.Name = "txtHoldingValue";
            txtHoldingValue.Size = new Size(125, 27);
            txtHoldingValue.TabIndex = 5;
            // 
            // lbRawBus
            // 
            lbRawBus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRawBus.AutoSize = true;
            lbRawBus.Location = new Point(708, 327);
            lbRawBus.Name = "lbRawBus";
            lbRawBus.Size = new Size(140, 20);
            lbRawBus.TabIndex = 6;
            lbRawBus.Text = "Type Eng Unit Value";
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
            // btnClearText
            // 
            btnClearText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearText.Location = new Point(846, 487);
            btnClearText.Name = "btnClearText";
            btnClearText.Size = new Size(137, 47);
            btnClearText.TabIndex = 10;
            btnClearText.Text = "Clear Text";
            btnClearText.UseVisualStyleBackColor = true;
            // 
            // FileDialogDB
            // 
            FileDialogDB.FileName = "FileDialogDB";
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
            txtDescription.Location = new Point(262, 126);
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(494, 27);
            txtDescription.TabIndex = 17;
            // 
            // lbAdress
            // 
            lbAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbAdress.AutoSize = true;
            lbAdress.Location = new Point(262, 174);
            lbAdress.Name = "lbAdress";
            lbAdress.Size = new Size(53, 20);
            lbAdress.TabIndex = 18;
            lbAdress.Text = "Adress";
            // 
            // txtAdress
            // 
            txtAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAdress.Location = new Point(262, 202);
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
            txtEngLow.Location = new Point(458, 202);
            txtEngLow.Name = "txtEngLow";
            txtEngLow.ReadOnly = true;
            txtEngLow.Size = new Size(125, 27);
            txtEngLow.TabIndex = 21;
            // 
            // lbEngHigh
            // 
            lbEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngHigh.AutoSize = true;
            lbEngHigh.Location = new Point(604, 174);
            lbEngHigh.Name = "lbEngHigh";
            lbEngHigh.Size = new Size(37, 20);
            lbEngHigh.TabIndex = 22;
            lbEngHigh.Text = "Max";
            // 
            // txtEngHigh
            // 
            txtEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngHigh.Location = new Point(604, 202);
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
            txtSerialLow.Location = new Point(458, 270);
            txtSerialLow.Name = "txtSerialLow";
            txtSerialLow.ReadOnly = true;
            txtSerialLow.Size = new Size(125, 27);
            txtSerialLow.TabIndex = 25;
            // 
            // lbSerialHigh
            // 
            lbSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSerialHigh.AutoSize = true;
            lbSerialHigh.Location = new Point(604, 245);
            lbSerialHigh.Name = "lbSerialHigh";
            lbSerialHigh.Size = new Size(64, 20);
            lbSerialHigh.TabIndex = 26;
            lbSerialHigh.Text = "Bus Max";
            // 
            // txtSerialHigh
            // 
            txtSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialHigh.Location = new Point(604, 270);
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
            lbEngUnit.AutoSize = true;
            lbEngUnit.Location = new Point(751, 174);
            lbEngUnit.Name = "lbEngUnit";
            lbEngUnit.Size = new Size(65, 20);
            lbEngUnit.TabIndex = 29;
            lbEngUnit.Text = "Eng Unit";
            // 
            // txtEngUnit
            // 
            txtEngUnit.Location = new Point(751, 202);
            txtEngUnit.Name = "txtEngUnit";
            txtEngUnit.ReadOnly = true;
            txtEngUnit.Size = new Size(82, 27);
            txtEngUnit.TabIndex = 30;
            // 
            // textHAddress
            // 
            textHAddress.Location = new Point(708, 420);
            textHAddress.Margin = new Padding(3, 4, 3, 4);
            textHAddress.Name = "textHAddress";
            textHAddress.Size = new Size(142, 27);
            textHAddress.TabIndex = 31;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(708, 396);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 32;
            label1.Text = "Type Address";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripFile, toolStripCommSettings, toolStripMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1258, 28);
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
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(156, 24);
            toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // btnStartSimulator
            // 
            btnStartSimulator.Location = new Point(846, 59);
            btnStartSimulator.Name = "btnStartSimulator";
            btnStartSimulator.Size = new Size(140, 50);
            btnStartSimulator.TabIndex = 34;
            btnStartSimulator.Text = "Start Simulator";
            btnStartSimulator.UseVisualStyleBackColor = true;
            btnStartSimulator.Click += btnStartSimulator_Click;
            // 
            // btnStopSimulator
            // 
            btnStopSimulator.Location = new Point(846, 126);
            btnStopSimulator.Name = "btnStopSimulator";
            btnStopSimulator.Size = new Size(140, 50);
            btnStopSimulator.TabIndex = 35;
            btnStopSimulator.Text = "Stop Simulator";
            btnStopSimulator.UseVisualStyleBackColor = true;
            btnStopSimulator.Click += btnStopSimulator_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 891);
            Controls.Add(btnStopSimulator);
            Controls.Add(btnStartSimulator);
            Controls.Add(label1);
            Controls.Add(textHAddress);
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
            Controls.Add(btnClearText);
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
        private Button btnClearText;
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
        private TextBox textHAddress;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripFile;
        private ToolStripMenuItem importIOListToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolStripCommSettings;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Button btnStartSimulator;
        private Button btnStopSimulator;
    }
}
