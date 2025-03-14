using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;
using System.Net;

namespace Bachelor_Test
{
    // Class for design of the COM Port settings MessageBox. This class will create the "form" for changing settings on the COM port
    //and IP address and store it for use in the main form
    public class COMPortSettingsMessageBox : Form
    {
        //Variables that main program needs to fetch
        public string SlaveID { get; private set; }
        public string SelectedCOMPort { get; private set; }
        public int SelectedBaudRate { get; private set; }
        public int SelectedDataBits { get; private set; }
        public StopBits SelectedStopBits { get; private set; }
        public Parity SelectedParity { get; private set; }
        public string LocalIPAddress { get; private set; }
        public bool rtuCommunication { get; private set; }
        public bool tcpCommunication { get; private set; }

        private TextBox slaveIdTextBox;
        private ComboBox comPortComboBox;
        private ComboBox baudRateComboBox;
        private ComboBox dataBitsComboBox;
        private ComboBox stopBitsComboBox;
        private ComboBox parityComboBox;
        private TextBox ipAddressTextBox;
        private TextBox newIpAddressTextBox;

        public COMPortSettingsMessageBox()
        {
            // Custom form for the settings page configured here
            this.Text = "Settings";

            Label slaveIdLabel = new Label();
            slaveIdLabel.Text = "Slave ID:";
            slaveIdLabel.Location = new Point(10, 10);
            slaveIdLabel.AutoSize = true;

            slaveIdTextBox = new TextBox();
            slaveIdTextBox.Location = new Point(90, 10);
            slaveIdTextBox.Width = 200;
            slaveIdTextBox.Text = "1"; // Default value

            Label comPortLabel = new Label();
            comPortLabel.Text = "COM Port:";
            comPortLabel.Location = new Point(10, 40);
            comPortLabel.AutoSize = true;

            comPortComboBox = new ComboBox();
            comPortComboBox.Location = new Point(90, 40);
            comPortComboBox.Width = 200;
            comPortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comPortComboBox.Items.AddRange(SerialPort.GetPortNames());
            if (comPortComboBox.Items.Count > 0)
            {
                comPortComboBox.SelectedIndex = 0; // Default to the first available COM port
            }

            Label baudRateLabel = new Label();
            baudRateLabel.Text = "Baud Rate:";
            baudRateLabel.Location = new Point(10, 70);
            baudRateLabel.AutoSize = true;

            baudRateComboBox = new ComboBox();
            baudRateComboBox.Location = new Point(90, 70);
            baudRateComboBox.Width = 200;
            baudRateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            baudRateComboBox.Items.AddRange(new object[] { "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" });
            baudRateComboBox.SelectedItem = "9600"; // Default value

            Label dataBitsLabel = new Label();
            dataBitsLabel.Text = "Data Bits:";
            dataBitsLabel.Location = new Point(10, 100);
            dataBitsLabel.AutoSize = true;

            dataBitsComboBox = new ComboBox();
            dataBitsComboBox.Location = new Point(90, 100);
            dataBitsComboBox.Width = 200;
            dataBitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dataBitsComboBox.Items.AddRange(new object[] { "7", "8" });
            dataBitsComboBox.SelectedItem = "8"; // Default value

            Label stopBitsLabel = new Label();
            stopBitsLabel.Text = "Stop Bits:";
            stopBitsLabel.Location = new Point(10, 130);
            stopBitsLabel.AutoSize = true;

            stopBitsComboBox = new ComboBox();
            stopBitsComboBox.Location = new Point(90, 130);
            stopBitsComboBox.Width = 200;
            stopBitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stopBitsComboBox.Items.AddRange(new object[] { "1", "2" });
            stopBitsComboBox.SelectedItem = "1"; // Default value

            Label parityLabel = new Label();
            parityLabel.Text = "Parity:";
            parityLabel.Location = new Point(10, 160);
            parityLabel.AutoSize = true;

            parityComboBox = new ComboBox();
            parityComboBox.Location = new Point(90, 160);
            parityComboBox.Width = 200;
            parityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            parityComboBox.Items.AddRange(Enum.GetNames(typeof(Parity)));
            parityComboBox.SelectedItem = "None"; // Default value

            Label ipAddressLabel = new Label();
            ipAddressLabel.Text = "Local IP Address:";
            ipAddressLabel.Location = new Point(10, 200);
            ipAddressLabel.AutoSize = true;

            ipAddressTextBox = new TextBox();
            ipAddressTextBox.Location = new Point(130, 200);
            ipAddressTextBox.Width = 160;
            ipAddressTextBox.ReadOnly = true;
            ipAddressTextBox.Text = GetLocalIPAddress(); // Gets the localIPadress from the method

            Label newIpAddressLabel = new Label();
            newIpAddressLabel.Text = "Set New IP:";
            newIpAddressLabel.Location = new Point(10, 240);
            newIpAddressLabel.AutoSize = true;

            Label newIpAddressLabelOptional = new Label();
            stopBitsLabel.Text = "Optional if no local address found";
            stopBitsLabel.Location = new Point(30, 265);
            stopBitsLabel.AutoSize = true;

            newIpAddressTextBox = new TextBox();
            newIpAddressTextBox.Location = new Point(100, 240);
            newIpAddressTextBox.Width = 160;
            newIpAddressTextBox.PlaceholderText = "xxx.xxx.xxx.xxx"; //Placeholder to display the format of IP address

            CheckBox rtuCheck = new CheckBox();
            rtuCheck.Height = 30;
            rtuCheck.Width = 20;
            rtuCheck.Location = new Point(300, 20);

            Label rtuCheckLabel = new Label();
            rtuCheckLabel.Text = "RTU";
            rtuCheckLabel.Location = new Point(340, 20);
            rtuCheckLabel.AutoSize = true;

            CheckBox tcpCheck = new CheckBox();
            tcpCheck.Height = 30;
            tcpCheck.Width = 20;
            tcpCheck.Location = new Point(300, 60);

            Label tcpCheckLabel = new Label();
            tcpCheckLabel.Text = "TCP";
            tcpCheckLabel.Location = new Point(340, 60);
            tcpCheckLabel.AutoSize = true;

            //When OK is pressed, variables are stored in class. Main program can fetch these variables
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Height = 30;
            okButton.Location = new Point(300, 200);
            okButton.Click += (sender, e) =>
            {
                SlaveID = slaveIdTextBox.Text;
                SelectedCOMPort = comPortComboBox.SelectedItem.ToString();
                SelectedBaudRate = int.Parse(baudRateComboBox.SelectedItem.ToString());
                SelectedDataBits = int.Parse(dataBitsComboBox.SelectedItem.ToString());
                SelectedStopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBitsComboBox.SelectedItem.ToString());
                SelectedParity = (Parity)Enum.Parse(typeof(Parity), parityComboBox.SelectedItem.ToString());
                //If user has not manually entered a IP address then the IP address that is fetched of ETHERNET is selected. If user has
                //entered a IP address this will be used.
                if(newIpAddressTextBox.Text == "")
                {
                    LocalIPAddress = ipAddressTextBox.Text;
                }
                else
                {
                    LocalIPAddress = newIpAddressTextBox.Text;
                }
                if (rtuCheck.Checked)
                {
                    rtuCommunication = true;
                }
                if (tcpCheck.Checked)
                {
                    tcpCommunication = true;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            Button cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Height = 30;
            cancelButton.Location = new Point(300, 250);
            cancelButton.Click += (sender, e) => this.Close();

            //Adding all the controls to the form
            this.Controls.Add(slaveIdLabel);
            this.Controls.Add(slaveIdTextBox);
            this.Controls.Add(comPortLabel);
            this.Controls.Add(comPortComboBox);
            this.Controls.Add(baudRateLabel);
            this.Controls.Add(baudRateComboBox);
            this.Controls.Add(dataBitsLabel);
            this.Controls.Add(dataBitsComboBox);
            this.Controls.Add(stopBitsLabel);
            this.Controls.Add(stopBitsComboBox);
            this.Controls.Add(parityLabel);
            this.Controls.Add(parityComboBox);
            this.Controls.Add(ipAddressLabel);
            this.Controls.Add(ipAddressTextBox);
            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);
            this.Controls.Add(newIpAddressLabel);
            this.Controls.Add(newIpAddressTextBox);
            this.Controls.Add(rtuCheck);
            this.Controls.Add(tcpCheck);
            this.Controls.Add(rtuCheckLabel);
            this.Controls.Add(tcpCheckLabel);
            this.ClientSize = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        //The method will search for a ethernet IP address and exclude any wifi or Virtual Machine networks, if none is found it can be set manually
        private string GetLocalIPAddress()
        {
            try
            {
                foreach (var networkInterface in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (networkInterface.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Ethernet &&
                        networkInterface.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up &&
                        !networkInterface.Description.Contains("Virtual") && // Exclude virtual networks
                        !networkInterface.Name.Contains("VMware") && // Exclude VMware networks
                        !networkInterface.Description.Contains("Hyper-V")) // Exclude Hyper-V networks)
                    {
                        var ipProperties = networkInterface.GetIPProperties();
                        foreach (var ip in ipProperties.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                return ip.Address.ToString();
                            }
                        }
                    }
                }
            }
            catch
            {
                
            }
            return "";
        }
    }
}