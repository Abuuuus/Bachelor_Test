using System.Net;
using System.Net.Sockets;
using System.IO.Ports;
using Modbus.Device;
using Modbus.Data;
using System.Data.OleDb;

namespace Bachelor_Test
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cts;
        private CancellationTokenSource cts2;
        private DataStore datastore = DataStoreFactory.CreateDefaultDataStore();
        private SerialPort serialport;
        private TcpListener tcpListener;
        private ModbusTcpSlave tcpSlave;
        private ModbusSlave rtuSlave;
        private List<string> tag = new List<string>();
        private List<string> description = new List<string>();
        private List<string> engUnit = new List<string>();
        private List<string> engRangeLow = new List<string>();
        private List<string> engRangeHigh = new List<string>();
        private List<string> serialAdress = new List<string>();
        private List<string> serialLineLow = new List<string>();
        private List<string> serialLineHigh = new List<string>();
        private List<string> serialLineName = new List<string>();
        

       

        private byte slaveID = 1; //Default slaveID 1
        private string comPort = ""; //Gets assigned in the GUI
        private int baudRate;
        private int dataBits;
        private Parity parity;
        private StopBits stopBits;
        private byte[] serverIpAdress = new byte[4];


        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnChangeHolding_Click(object sender, EventArgs e)
        {
            try
            {
                string registerAdressRaw = textHAddress.Text;
                string registerAdress;
                if (registerAdressRaw.Contains("."))
                {
                    registerAdress = registerAdressRaw.Substring(0, registerAdressRaw.IndexOf("."));
                }
                else registerAdress = registerAdressRaw;
                ushort startAddress = ushort.Parse(registerAdress);
                string addressValue = txtHoldingValue.Text;
                int adr = Convert.ToInt32(addressValue);
                bool BitAdress = addressValue.Contains(".");
                List <ushort> modbusValues = new List <ushort>();
                List <float> scaledValues = new List <float>();
                List<ushort> modbusValues = new List<ushort>();
                List<float> scaledValues = new List<float>();
                int sensorLow = int.Parse(txtEngLow.Text);
                int sensorHigh = int.Parse(txtEngHigh.Text);
                int serialLow = int.Parse(txtSerialLow.Text);
                int serialHigh = int.Parse(txtSerialHigh.Text);
                ushort uSendRawData = 0;
                int Scale;
                int rawData;
                int sendRawData;

                // Ensure the TCP Modbus Slave is initialized
                if (tcpSlave != null && tcpSlave.DataStore != null)  //HUSK Å FIKS ADRESSER SOM HAR BIT I SEG MANNEN (if nigga dotted) !!!! pluss hvis ikke bit adressen er 0 som min buss verdi (da fungerer ikke regnestykket fix plis). 
                if (tcpSlave != null && tcpSlave.DataStore != null)  //HUSK Å FIKS ADRESSER SOM HAR BIT I SEG MANNEN (if nigga dotted) 
                {
                    if (registerAdressRaw.Contains("."))
                    {
                        int dotAdress = int.Parse(registerAdressRaw.Substring(registerAdressRaw.IndexOf(".") + 1));
                        BittCounter bittCounter = new BittCounter(dotAdress, adr);
                        uSendRawData = bittCounter.BittMassage;
                    }
                    else if (adr < 0 && serialLow != 0)
                {

                    if (adr < 0)
                    {
                        Scale = serialLow / sensorLow;
                        rawData = Scale * adr;
                        sendRawData = rawData + 65536;
                        uSendRawData = (ushort)sendRawData;

                      

                    }
                    else if (adr == 0 && serialLow == 0)
                    {
                        
                        uSendRawData = 0;

                    }
                    else
                    {
                        Scale = serialHigh / sensorHigh;
                        rawData = Scale * adr;
                        uSendRawData = (ushort)rawData;

                    }

                    MessageBox.Show(Convert.ToString(uSendRawData));


                    tcpSlave.DataStore.HoldingRegisters[startAddress + 1] = uSendRawData;

                }
                else
                {
                    MessageBox.Show("The TCP slave or DataStore is not initialized correctly.", "Initialization Error");
                }

                if (rtuSlave != null && rtuSlave.DataStore != null)
                {

                    if (adr < 0)
                    {
                        Scale = serialLow / sensorLow;
                        rawData = Scale * adr;
                        sendRawData = rawData + 65536;
                        uSendRawData = (ushort)sendRawData;


                    }
                    else
                    {
                        Scale = serialHigh / sensorHigh;
                        rawData = Scale * adr;
                        uSendRawData = (ushort)rawData;

                    }

                    MessageBox.Show(Convert.ToString(uSendRawData));


                    rtuSlave.DataStore.HoldingRegisters[startAddress + 1] = uSendRawData;


                }

            }
            catch (FormatException)
            {
                MessageBox.Show("The address must be a valid integer.", "Input Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show("The address is too large or too small.", "Input Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Unexpected Error");
            }
        }


        private byte[] GetLocalIPAddress()
        {
            try
            {
                foreach (var networkInterface in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (networkInterface.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Ethernet &&
                        networkInterface.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up &&
                        !networkInterface.Description.Contains("Virtual") && // Exclude virtual networks
                        !networkInterface.Name.Contains("VMware") && // Exclude VMware networks
                        !networkInterface.Description.Contains("Hyper-V")) // Exclude Hyper-V networks
                    {
                        var ipProperties = networkInterface.GetIPProperties();
                        foreach (var ip in ipProperties.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                string ipAddress = ip.Address.ToString();
                                byte[] serverIP = new byte[4];

                                // Split the IP address into its components
                                string[] ipParts = ipAddress.Split('.');

                                // Convert each part to a byte and store it in the array
                                for (int i = 0; i < 4; i++)
                                {
                                    serverIP[i] = byte.Parse(ipParts[i]);
                                }

                                return serverIP;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No valid IPV4 addresses could be found: {ex}");
            }

            // Return null if no IP address is found
            return null;
        }


        private void connectToDatabase(string filepath)
        {
            string querystring = "SELECT Io_List.S_Serial_Line_Name, Io_List.S_Instrument_Tag, Io_List.S_Description, Io_List.S_Serial_Line_Address, Io_List.S_Eng_Units, Io_List.S_Eng_Range_Low, Io_List.S_Eng_Range_High, Io_List.S_Serial_Line_Range_Low, Io_List.S_Serial_Line_Range_High\r\nFROM Io_List\r\nWHERE (((Io_List.S_Serial_Line_Name) Is Not Null));";
            using OleDbConnection connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Persist Security Info=False;");
            using OleDbCommand command = new OleDbCommand(querystring, connection);

            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    serialLineName.Add(reader.GetString(0));
                    tag.Add(reader.GetString(1));
                    description.Add(reader.GetString(2));
                    serialAdress.Add(reader.GetString(3));
                    if (serialAdress.Last().Contains("."))
                    {
                        engUnit.Add("");
                        engRangeLow.Add("0");
                        engRangeHigh.Add("1");
                        serialLineLow.Add("0");
                        serialLineHigh.Add("1");
                    }
                    else
                    {
                        engUnit.Add(reader.GetString(4));
                        engRangeLow.Add(reader.GetString(5));
                        engRangeHigh.Add(reader.GetString(6));
                        serialLineLow.Add(reader.GetString(7));
                        serialLineHigh.Add(reader.GetString(8));
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("Error" + e.ToString());
                }


            }
            foreach (string s in serialLineName)
            {
                if (comboBoxSerialLine.Items.Contains(s))
                {
                    //Do nothing
                }
                else
                {
                    comboBoxSerialLine.Items.Add(s);
                }
            }

        }

        private void UpdateStatus(params object[] messages)
        {
            string message = string.Join(", ", messages);

            if (InvokeRequired)
            {
                Invoke(new Action(() => listBoxSignals.Items.Add(message)));
            }
            else
            {
                listBoxSignals.Items.Add(message);
            }
        }

        private void listBoxSignals_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string tagHighLighted = listBoxSignals.Text;
            int position = tag.IndexOf(tagHighLighted); // Assuming tagList is the list containing all tags
            if (position != -1)
            {
                txtAdress.Text = serialAdress[position];
                txtDescription.Text = description[position];
                txtEngHigh.Text = engRangeHigh[position];
                txtEngLow.Text = engRangeLow[position];
                txtSerialHigh.Text = serialLineHigh[position];
                txtSerialLow.Text = serialLineLow[position];
                txtTag.Text = tagHighLighted;
                txtEngUnit.Text = engUnit[position];
            }
            else
            {
                MessageBox.Show("Tag not found in the list.");
            }
        }

        private void comboBoxSerialLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxSignals.Items.Clear();
            string serialLineSelected = comboBoxSerialLine.Text;
            for (int i = 0; i < tag.Count; i++)
            {
                if (serialLineName[i] == serialLineSelected)
                {
                    listBoxSignals.Items.Add(tag[i]);
                }
            }
        }

        private void importIOListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialogDB.InitialDirectory = "C:\\Marine\\Projects";
            FileDialogDB.Filter = "Select Database(*.mdb)|*.mdb";
            string stringpath;
            if (FileDialogDB.ShowDialog() == DialogResult.OK)
            {
                stringpath = FileDialogDB.FileName;
                connectToDatabase(stringpath);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            COMPortSettingsMessageBox comSettings = new COMPortSettingsMessageBox();
            if (comSettings.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the selected values
                comPort = comSettings.SelectedCOMPort;
                slaveID = byte.Parse(comSettings.SlaveID);
                baudRate = comSettings.SelectedBaudRate;
                dataBits = comSettings.SelectedDataBits;
                stopBits = comSettings.SelectedStopBits;
                parity = comSettings.SelectedParity;
                string localIPAddress = comSettings.LocalIPAddress;
                // Split the IP address into its components
                string[] ipParts = localIPAddress.Split('.');

                // Convert each part to a byte and store it in the array
                for (int i = 0; i < 4; i++)
                {
                    serverIpAdress[i] = byte.Parse(ipParts[i]);
                }

            }
            
            if(tcpListener != null && rtuSlave != null)
            {
                StopSimulator();
                StartSimulator();
            }
        }

        private void btnStartSimulator_Click(object sender, EventArgs e)
        {
            StartSimulator();
           
        }

        private void btnStopSimulator_Click(object sender, EventArgs e)
        {
            StopSimulator();
        }

        private void StartSimulator()
        {
            //Starting TCP server
            if (serverIpAdress == null)
            {
                MessageBox.Show("Could not find the local IP adress, make sure network card is set up correctly");
            }
            else
            {
                IPAddress address = new IPAddress(serverIpAdress);
                int port = 502;

                // Initialize cancellation token source
                cts = new CancellationTokenSource();

                try
                {
                    // Start the TCP listener
                    tcpListener = new TcpListener(address, port);
                    tcpListener.Start();

                    // Create the Modbus TCP slave using the default listener
                    tcpSlave = ModbusTcpSlave.CreateTcp(slaveID, tcpListener);
                    tcpSlave.DataStore = datastore; // Assign the TCP DataStore

                    // Listen for incoming requests on a separate thread
                    Task.Run(() =>
                    {
                        try
                        {
                            tcpSlave.Listen();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    });

                    MessageBox.Show($"TCP server is running on {address}:{port}");
                }
                catch (SocketException ex)
                {
                    MessageBox.Show($"Socket error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            //Starting RTU slave

            if (comPort == "")
            {
                MessageBox.Show("You have not configured the COM port");
            }
            else
            {
                serialport = new SerialPort(comPort);
                serialport.BaudRate = baudRate;
                serialport.DataBits = dataBits;
                serialport.Parity = parity;
                serialport.StopBits = stopBits;
                serialport.Open();
                // Create the RTU slave
                rtuSlave = ModbusSerialSlave.CreateRtu(slaveID, serialport);

                rtuSlave.DataStore = datastore;

                cts2 = new CancellationTokenSource();
                // Run ListenAsync on a separate task
                Task.Run(async () =>
                {
                    try
                    {
                        rtuSlave.Listen();
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("Modbus listening stopped.");
                    }
                });

                MessageBox.Show("RTU slave started");
            }
        }

        private void StopSimulator()
        {
            //Stopping TCP server

            try
            {
                if (cts != null)
                {
                    // Cancel the listening task
                    cts.Cancel();
                }

                if (tcpSlave != null)
                {
                    // Properly dispose of the Modbus TCP Slave
                    tcpSlave.Dispose();
                    tcpSlave = null;
                }

                if (tcpListener != null)
                {
                    // Stop the TCP listener only after stopping the slave
                    tcpListener.Stop();
                    tcpListener = null;
                }

                MessageBox.Show("Server stopped.");
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Socket error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            // Stopping RTU slave
            try
            {
                if (cts2 != null)
                {
                    cts2.Cancel();
                }

                if (rtuSlave != null)
                {
                    rtuSlave.Dispose();
                    rtuSlave = null;
                }
                if (serialport  != null)
                {
                    serialport.Dispose();
                    serialport = null;
                }

                MessageBox.Show("RTU slave stopped");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping RTU slave: {ex.Message}");
            }
        }
    }
}
