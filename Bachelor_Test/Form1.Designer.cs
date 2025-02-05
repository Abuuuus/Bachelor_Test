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
            btnStartServer = new Button();
            btnStopServer = new Button();
            btnStartCOM = new Button();
            btnStopCOM = new Button();
            txtHoldingValue = new TextBox();
            lbRawBus = new Label();
            btnChangeHolding = new Button();
            btnClearText = new Button();
            btnChooseDB = new Button();
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
            SuspendLayout();
            // 
            // btnStartServer
            // 
            btnStartServer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartServer.Location = new Point(847, 13);
            btnStartServer.Margin = new Padding(3, 4, 3, 4);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(137, 69);
            btnStartServer.TabIndex = 1;
            btnStartServer.Text = "StartServer";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click_1;
            // 
            // btnStopServer
            // 
            btnStopServer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStopServer.Location = new Point(847, 102);
            btnStopServer.Margin = new Padding(3, 4, 3, 4);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(137, 68);
            btnStopServer.TabIndex = 2;
            btnStopServer.Text = "StopServer";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click_1;
            // 
            // btnStartCOM
            // 
            btnStartCOM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartCOM.Location = new Point(847, 177);
            btnStartCOM.Name = "btnStartCOM";
            btnStartCOM.Size = new Size(137, 48);
            btnStartCOM.TabIndex = 3;
            btnStartCOM.Text = "StartCOM";
            btnStartCOM.UseVisualStyleBackColor = true;
            btnStartCOM.Click += btnStartCOM_Click;
            // 
            // btnStopCOM
            // 
            btnStopCOM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStopCOM.Location = new Point(847, 246);
            btnStopCOM.Name = "btnStopCOM";
            btnStopCOM.Size = new Size(137, 44);
            btnStopCOM.TabIndex = 4;
            btnStopCOM.Text = "StopCOM";
            btnStopCOM.UseVisualStyleBackColor = true;
            btnStopCOM.Click += btnStopCOM_Click;
            // 
            // txtHoldingValue
            // 
            txtHoldingValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHoldingValue.Location = new Point(709, 326);
            txtHoldingValue.Name = "txtHoldingValue";
            txtHoldingValue.Size = new Size(125, 27);
            txtHoldingValue.TabIndex = 5;
            // 
            // lbRawBus
            // 
            lbRawBus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRawBus.AutoSize = true;
            lbRawBus.Location = new Point(709, 303);
            lbRawBus.Name = "lbRawBus";
            lbRawBus.Size = new Size(64, 20);
            lbRawBus.TabIndex = 6;
            lbRawBus.Text = "Raw Bus";
            // 
            // btnChangeHolding
            // 
            btnChangeHolding.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeHolding.Location = new Point(847, 314);
            btnChangeHolding.Name = "btnChangeHolding";
            btnChangeHolding.Size = new Size(138, 50);
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
            // btnChooseDB
            // 
            btnChooseDB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChooseDB.Location = new Point(847, 540);
            btnChooseDB.Name = "btnChooseDB";
            btnChooseDB.Size = new Size(136, 45);
            btnChooseDB.TabIndex = 12;
            btnChooseDB.Text = "Choose DB";
            btnChooseDB.UseVisualStyleBackColor = true;
            btnChooseDB.Click += btnChooseDB_Click;
            // 
            // FileDialogDB
            // 
            FileDialogDB.FileName = "FileDialogDB";
            // 
            // lbTag
            // 
            lbTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTag.AutoSize = true;
            lbTag.Location = new Point(263, 13);
            lbTag.Name = "lbTag";
            lbTag.Size = new Size(32, 20);
            lbTag.TabIndex = 13;
            lbTag.Text = "Tag";
            // 
            // listBoxSignals
            // 
            listBoxSignals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxSignals.FormattingEnabled = true;
            listBoxSignals.Location = new Point(12, 83);
            listBoxSignals.Name = "listBoxSignals";
            listBoxSignals.Size = new Size(245, 564);
            listBoxSignals.TabIndex = 14;
            listBoxSignals.MouseDoubleClick += listBoxSignals_MouseDoubleClick;
            // 
            // txtTag
            // 
            txtTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTag.Location = new Point(263, 36);
            txtTag.Name = "txtTag";
            txtTag.ReadOnly = true;
            txtTag.Size = new Size(494, 27);
            txtTag.TabIndex = 15;
            // 
            // lbDescription
            // 
            lbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbDescription.AutoSize = true;
            lbDescription.Location = new Point(263, 76);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(85, 20);
            lbDescription.TabIndex = 16;
            lbDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDescription.Location = new Point(263, 102);
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(494, 27);
            txtDescription.TabIndex = 17;
            // 
            // lbAdress
            // 
            lbAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbAdress.AutoSize = true;
            lbAdress.Location = new Point(263, 150);
            lbAdress.Name = "lbAdress";
            lbAdress.Size = new Size(53, 20);
            lbAdress.TabIndex = 18;
            lbAdress.Text = "Adress";
            // 
            // txtAdress
            // 
            txtAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAdress.Location = new Point(263, 177);
            txtAdress.Name = "txtAdress";
            txtAdress.ReadOnly = true;
            txtAdress.Size = new Size(125, 27);
            txtAdress.TabIndex = 19;
            // 
            // lbEngLow
            // 
            lbEngLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngLow.AutoSize = true;
            lbEngLow.Location = new Point(460, 152);
            lbEngLow.Name = "lbEngLow";
            lbEngLow.Size = new Size(34, 20);
            lbEngLow.TabIndex = 20;
            lbEngLow.Text = "Min";
            // 
            // txtEngLow
            // 
            txtEngLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngLow.Location = new Point(460, 177);
            txtEngLow.Name = "txtEngLow";
            txtEngLow.ReadOnly = true;
            txtEngLow.Size = new Size(125, 27);
            txtEngLow.TabIndex = 21;
            // 
            // lbEngHigh
            // 
            lbEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbEngHigh.AutoSize = true;
            lbEngHigh.Location = new Point(605, 150);
            lbEngHigh.Name = "lbEngHigh";
            lbEngHigh.Size = new Size(37, 20);
            lbEngHigh.TabIndex = 22;
            lbEngHigh.Text = "Max";
            // 
            // txtEngHigh
            // 
            txtEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngHigh.Location = new Point(605, 177);
            txtEngHigh.Name = "txtEngHigh";
            txtEngHigh.ReadOnly = true;
            txtEngHigh.Size = new Size(125, 27);
            txtEngHigh.TabIndex = 23;
            // 
            // lbSerialLow
            // 
            lbSerialLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSerialLow.AutoSize = true;
            lbSerialLow.Location = new Point(460, 220);
            lbSerialLow.Name = "lbSerialLow";
            lbSerialLow.Size = new Size(61, 20);
            lbSerialLow.TabIndex = 24;
            lbSerialLow.Text = "Bus Min";
            // 
            // txtSerialLow
            // 
            txtSerialLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialLow.Location = new Point(460, 246);
            txtSerialLow.Name = "txtSerialLow";
            txtSerialLow.ReadOnly = true;
            txtSerialLow.Size = new Size(125, 27);
            txtSerialLow.TabIndex = 25;
            // 
            // lbSerialHigh
            // 
            lbSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbSerialHigh.AutoSize = true;
            lbSerialHigh.Location = new Point(605, 220);
            lbSerialHigh.Name = "lbSerialHigh";
            lbSerialHigh.Size = new Size(64, 20);
            lbSerialHigh.TabIndex = 26;
            lbSerialHigh.Text = "Bus Max";
            // 
            // txtSerialHigh
            // 
            txtSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialHigh.Location = new Point(605, 246);
            txtSerialHigh.Name = "txtSerialHigh";
            txtSerialHigh.ReadOnly = true;
            txtSerialHigh.Size = new Size(125, 27);
            txtSerialHigh.TabIndex = 27;
            // 
            // comboBoxSerialLine
            // 
            comboBoxSerialLine.FormattingEnabled = true;
            comboBoxSerialLine.Location = new Point(27, 34);
            comboBoxSerialLine.Name = "comboBoxSerialLine";
            comboBoxSerialLine.Size = new Size(208, 28);
            comboBoxSerialLine.TabIndex = 28;
            comboBoxSerialLine.SelectedIndexChanged += comboBoxSerialLine_SelectedIndexChanged;
            // 
            // lbEngUnit
            // 
            lbEngUnit.AutoSize = true;
            lbEngUnit.Location = new Point(752, 150);
            lbEngUnit.Name = "lbEngUnit";
            lbEngUnit.Size = new Size(65, 20);
            lbEngUnit.TabIndex = 29;
            lbEngUnit.Text = "Eng Unit";
            // 
            // txtEngUnit
            // 
            txtEngUnit.Location = new Point(752, 177);
            txtEngUnit.Name = "txtEngUnit";
            txtEngUnit.ReadOnly = true;
            txtEngUnit.Size = new Size(82, 27);
            txtEngUnit.TabIndex = 30;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 668);
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
            Controls.Add(btnChooseDB);
            Controls.Add(btnClearText);
            Controls.Add(btnChangeHolding);
            Controls.Add(lbRawBus);
            Controls.Add(txtHoldingValue);
            Controls.Add(btnStopCOM);
            Controls.Add(btnStartCOM);
            Controls.Add(btnStopServer);
            Controls.Add(btnStartServer);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnStartServer;
        private Button btnStopServer;
        private Button btnStartCOM;
        private Button btnStopCOM;
        private TextBox txtHoldingValue;
        private Label lbRawBus;
        private Button btnChangeHolding;
        private Button btnClearText;
        private Button btnChooseDB;
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
    }
}
