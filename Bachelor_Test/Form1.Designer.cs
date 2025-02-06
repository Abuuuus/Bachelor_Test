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
            textHAddress = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnStartServer
            // 
            btnStartServer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartServer.Location = new Point(741, 10);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(120, 52);
            btnStartServer.TabIndex = 1;
            btnStartServer.Text = "StartServer";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click_1;
            // 
            // btnStopServer
            // 
            btnStopServer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStopServer.Location = new Point(741, 76);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(120, 51);
            btnStopServer.TabIndex = 2;
            btnStopServer.Text = "StopServer";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click_1;
            // 
            // btnStartCOM
            // 
            btnStartCOM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartCOM.Location = new Point(741, 133);
            btnStartCOM.Margin = new Padding(3, 2, 3, 2);
            btnStartCOM.Name = "btnStartCOM";
            btnStartCOM.Size = new Size(120, 36);
            btnStartCOM.TabIndex = 3;
            btnStartCOM.Text = "StartCOM";
            btnStartCOM.UseVisualStyleBackColor = true;
            btnStartCOM.Click += btnStartCOM_Click;
            // 
            // btnStopCOM
            // 
            btnStopCOM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStopCOM.Location = new Point(741, 184);
            btnStopCOM.Margin = new Padding(3, 2, 3, 2);
            btnStopCOM.Name = "btnStopCOM";
            btnStopCOM.Size = new Size(120, 33);
            btnStopCOM.TabIndex = 4;
            btnStopCOM.Text = "StopCOM";
            btnStopCOM.UseVisualStyleBackColor = true;
            btnStopCOM.Click += btnStopCOM_Click;
            // 
            // txtHoldingValue
            // 
            txtHoldingValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHoldingValue.Location = new Point(620, 244);
            txtHoldingValue.Margin = new Padding(3, 2, 3, 2);
            txtHoldingValue.Name = "txtHoldingValue";
            txtHoldingValue.Size = new Size(110, 23);
            txtHoldingValue.TabIndex = 5;
            // 
            // lbRawBus
            // 
            lbRawBus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbRawBus.AutoSize = true;
            lbRawBus.Location = new Point(694, 303);
            lbRawBus.Name = "lbRawBus";
            lbRawBus.Size = new Size(140, 20);
            lbRawBus.TabIndex = 6;
            lbRawBus.Text = "Type Eng Unit Value";
            // 
            // btnChangeHolding
            // 
            btnChangeHolding.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeHolding.Location = new Point(741, 236);
            btnChangeHolding.Margin = new Padding(3, 2, 3, 2);
            btnChangeHolding.Name = "btnChangeHolding";
            btnChangeHolding.Size = new Size(121, 38);
            btnChangeHolding.TabIndex = 9;
            btnChangeHolding.Text = "Toggle";
            btnChangeHolding.UseVisualStyleBackColor = true;
            btnChangeHolding.Click += btnChangeHolding_Click;
            // 
            // btnClearText
            // 
            btnClearText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearText.Location = new Point(740, 365);
            btnClearText.Margin = new Padding(3, 2, 3, 2);
            btnClearText.Name = "btnClearText";
            btnClearText.Size = new Size(120, 35);
            btnClearText.TabIndex = 10;
            btnClearText.Text = "Clear Text";
            btnClearText.UseVisualStyleBackColor = true;
            // 
            // btnChooseDB
            // 
            btnChooseDB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChooseDB.Location = new Point(741, 405);
            btnChooseDB.Margin = new Padding(3, 2, 3, 2);
            btnChooseDB.Name = "btnChooseDB";
            btnChooseDB.Size = new Size(119, 34);
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
            lbTag.Location = new Point(230, 10);
            lbTag.Name = "lbTag";
            lbTag.Size = new Size(25, 15);
            lbTag.TabIndex = 13;
            lbTag.Text = "Tag";
            // 
            // listBoxSignals
            // 
            listBoxSignals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxSignals.FormattingEnabled = true;
            listBoxSignals.ItemHeight = 15;
            listBoxSignals.Location = new Point(10, 62);
            listBoxSignals.Margin = new Padding(3, 2, 3, 2);
            listBoxSignals.Name = "listBoxSignals";
            listBoxSignals.Size = new Size(215, 424);
            listBoxSignals.TabIndex = 14;
            listBoxSignals.MouseDoubleClick += listBoxSignals_MouseDoubleClick;
            // 
            // txtTag
            // 
            txtTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTag.Location = new Point(230, 27);
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
            lbDescription.Location = new Point(230, 57);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(67, 15);
            lbDescription.TabIndex = 16;
            lbDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDescription.Location = new Point(230, 76);
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
            lbAdress.Location = new Point(230, 112);
            lbAdress.Name = "lbAdress";
            lbAdress.Size = new Size(42, 15);
            lbAdress.TabIndex = 18;
            lbAdress.Text = "Adress";
            // 
            // txtAdress
            // 
            txtAdress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAdress.Location = new Point(230, 133);
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
            lbEngLow.Location = new Point(402, 114);
            lbEngLow.Name = "lbEngLow";
            lbEngLow.Size = new Size(28, 15);
            lbEngLow.TabIndex = 20;
            lbEngLow.Text = "Min";
            // 
            // txtEngLow
            // 
            txtEngLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngLow.Location = new Point(402, 133);
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
            lbEngHigh.Location = new Point(529, 112);
            lbEngHigh.Name = "lbEngHigh";
            lbEngHigh.Size = new Size(30, 15);
            lbEngHigh.TabIndex = 22;
            lbEngHigh.Text = "Max";
            // 
            // txtEngHigh
            // 
            txtEngHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEngHigh.Location = new Point(529, 133);
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
            lbSerialLow.Location = new Point(402, 165);
            lbSerialLow.Name = "lbSerialLow";
            lbSerialLow.Size = new Size(50, 15);
            lbSerialLow.TabIndex = 24;
            lbSerialLow.Text = "Bus Min";
            // 
            // txtSerialLow
            // 
            txtSerialLow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialLow.Location = new Point(402, 184);
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
            lbSerialHigh.Location = new Point(529, 165);
            lbSerialHigh.Name = "lbSerialHigh";
            lbSerialHigh.Size = new Size(52, 15);
            lbSerialHigh.TabIndex = 26;
            lbSerialHigh.Text = "Bus Max";
            // 
            // txtSerialHigh
            // 
            txtSerialHigh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSerialHigh.Location = new Point(529, 184);
            txtSerialHigh.Margin = new Padding(3, 2, 3, 2);
            txtSerialHigh.Name = "txtSerialHigh";
            txtSerialHigh.ReadOnly = true;
            txtSerialHigh.Size = new Size(110, 23);
            txtSerialHigh.TabIndex = 27;
            // 
            // comboBoxSerialLine
            // 
            comboBoxSerialLine.FormattingEnabled = true;
            comboBoxSerialLine.Location = new Point(24, 26);
            comboBoxSerialLine.Margin = new Padding(3, 2, 3, 2);
            comboBoxSerialLine.Name = "comboBoxSerialLine";
            comboBoxSerialLine.Size = new Size(182, 23);
            comboBoxSerialLine.TabIndex = 28;
            comboBoxSerialLine.SelectedIndexChanged += comboBoxSerialLine_SelectedIndexChanged;
            // 
            // lbEngUnit
            // 
            lbEngUnit.AutoSize = true;
            lbEngUnit.Location = new Point(658, 112);
            lbEngUnit.Name = "lbEngUnit";
            lbEngUnit.Size = new Size(52, 15);
            lbEngUnit.TabIndex = 29;
            lbEngUnit.Text = "Eng Unit";
            // 
            // txtEngUnit
            // 
            txtEngUnit.Location = new Point(658, 133);
            txtEngUnit.Margin = new Padding(3, 2, 3, 2);
            txtEngUnit.Name = "txtEngUnit";
            txtEngUnit.ReadOnly = true;
            txtEngUnit.Size = new Size(72, 23);
            txtEngUnit.TabIndex = 30;
            // 
            // textHAddress
            // 
            textHAddress.Location = new Point(709, 395);
            textHAddress.Name = "textHAddress";
            textHAddress.Size = new Size(125, 27);
            textHAddress.TabIndex = 31;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(694, 372);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 32;
            label1.Text = "Type Address";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 668);
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
            Controls.Add(btnChooseDB);
            Controls.Add(btnClearText);
            Controls.Add(btnChangeHolding);
            Controls.Add(lbRawBus);
            Controls.Add(txtHoldingValue);
            Controls.Add(btnStopCOM);
            Controls.Add(btnStartCOM);
            Controls.Add(btnStopServer);
            Controls.Add(btnStartServer);
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
        private TextBox textHAddress;
        private Label label1;
    }
}
