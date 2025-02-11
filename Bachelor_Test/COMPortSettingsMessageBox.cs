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
    // Class for design of the COM Port settings MessageBox
    public class COMPortSettingsMessageBox : Form
    {
        public string SlaveID { get; private set; }
        public string SelectedCOMPort { get; private set; }
        public int SelectedBaudRate { get; private set; }
        public int SelectedDataBits { get; private set; }
        public StopBits SelectedStopBits { get; private set; }
        public Parity SelectedParity { get; private set; }
        public string LocalIPAddress { get; private set; }

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
            // Set the title of the form
            this.Text = "Settings";

            // Create and configure the Label for Slave ID
            Label slaveIdLabel = new Label();
            slaveIdLabel.Text = "Slave ID:";
            slaveIdLabel.Location = new Point(10, 10);
            slaveIdLabel.AutoSize = true;

            // Create and configure the TextBox for Slave ID
            slaveIdTextBox = new TextBox();
            slaveIdTextBox.Location = new Point(90, 10);
            slaveIdTextBox.Width = 200;
            slaveIdTextBox.Text = "1"; // Default value

            // Create and configure the Label for COM Port
            Label comPortLabel = new Label();
            comPortLabel.Text = "COM Port:";
            comPortLabel.Location = new Point(10, 40);
            comPortLabel.AutoSize = true;

            // Create and configure the ComboBox for COM Port selection
            comPortComboBox = new ComboBox();
            comPortComboBox.Location = new Point(90, 40);
            comPortComboBox.Width = 200;
            comPortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comPortComboBox.Items.AddRange(SerialPort.GetPortNames());
            if (comPortComboBox.Items.Count > 0)
            {
                comPortComboBox.SelectedIndex = 0; // Default to the first available COM port
            }

            // Create and configure the Label for Baud Rate
            Label baudRateLabel = new Label();
            baudRateLabel.Text = "Baud Rate:";
            baudRateLabel.Location = new Point(10, 70);
            baudRateLabel.AutoSize = true;

            // Create and configure the ComboBox for Baud Rate selection
            baudRateComboBox = new ComboBox();
            baudRateComboBox.Location = new Point(90, 70);
            baudRateComboBox.Width = 200;
            baudRateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            baudRateComboBox.Items.AddRange(new object[] { "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" });
            baudRateComboBox.SelectedItem = "9600"; // Default value

            // Create and configure the Label for Data Bits
            Label dataBitsLabel = new Label();
            dataBitsLabel.Text = "Data Bits:";
            dataBitsLabel.Location = new Point(10, 100);
            dataBitsLabel.AutoSize = true;

            // Create and configure the ComboBox for Data Bits selection
            dataBitsComboBox = new ComboBox();
            dataBitsComboBox.Location = new Point(90, 100);
            dataBitsComboBox.Width = 200;
            dataBitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            dataBitsComboBox.Items.AddRange(new object[] { "7", "8" });
            dataBitsComboBox.SelectedItem = "8"; // Default value

            // Create and configure the Label for Stop Bits
            Label stopBitsLabel = new Label();
            stopBitsLabel.Text = "Stop Bits:";
            stopBitsLabel.Location = new Point(10, 130);
            stopBitsLabel.AutoSize = true;

            // Create and configure the ComboBox for Stop Bits selection
            stopBitsComboBox = new ComboBox();
            stopBitsComboBox.Location = new Point(90, 130);
            stopBitsComboBox.Width = 200;
            stopBitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stopBitsComboBox.Items.AddRange(new object[] { "1", "2" });
            stopBitsComboBox.SelectedItem = "1"; // Default value

            // Create and configure the Label for Parity
            Label parityLabel = new Label();
            parityLabel.Text = "Parity:";
            parityLabel.Location = new Point(10, 160);
            parityLabel.AutoSize = true;

            // Create and configure the ComboBox for Parity selection
            parityComboBox = new ComboBox();
            parityComboBox.Location = new Point(90, 160);
            parityComboBox.Width = 200;
            parityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            parityComboBox.Items.AddRange(Enum.GetNames(typeof(Parity)));
            parityComboBox.SelectedItem = "None"; // Default value

            // Create and configure the Label for IP Address
            Label ipAddressLabel = new Label();
            ipAddressLabel.Text = "Local IP Address:";
            ipAddressLabel.Location = new Point(10, 200);
            ipAddressLabel.AutoSize = true;

            // Create and configure the TextBox for IP Address
            ipAddressTextBox = new TextBox();
            ipAddressTextBox.Location = new Point(130, 200);
            ipAddressTextBox.Width = 160;
            ipAddressTextBox.ReadOnly = true;
            ipAddressTextBox.Text = GetLocalIPAddress(); // Default value

            // Create and configure the Label for IP Address
            Label newIpAddressLabel = new Label();
            newIpAddressLabel.Text = "Set New IP:";
            newIpAddressLabel.Location = new Point(10, 240);
            newIpAddressLabel.AutoSize = true;

            // Create and configure the TextBox for IP Address
            newIpAddressTextBox = new TextBox();
            newIpAddressTextBox.Location = new Point(100, 240);
            newIpAddressTextBox.Width = 160; 

            // Create and configure the Button
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Height = 30;
            okButton.Location = new Point(300, 200);
            okButton.Click += (sender, e) =>
            {
                // Set the properties with the selected values
                SlaveID = slaveIdTextBox.Text;
                SelectedCOMPort = comPortComboBox.SelectedItem.ToString();
                SelectedBaudRate = int.Parse(baudRateComboBox.SelectedItem.ToString());
                SelectedDataBits = int.Parse(dataBitsComboBox.SelectedItem.ToString());
                SelectedStopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBitsComboBox.SelectedItem.ToString());
                SelectedParity = (Parity)Enum.Parse(typeof(Parity), parityComboBox.SelectedItem.ToString());
                if(newIpAddressTextBox.Text == "")
                {
                    LocalIPAddress = ipAddressTextBox.Text;
                }
                else
                {
                    LocalIPAddress = newIpAddressTextBox.Text;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            Button cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Height = 30;
            cancelButton.Location = new Point(300, 250);
            cancelButton.Click += (sender, e) => this.Close();

            // Add controls to the form
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

            // Set the size of the form
            this.ClientSize = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

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
                //Do nothing
                
            }
            return "";
        }
    }
}