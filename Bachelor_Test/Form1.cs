using System.Net;
using System.Net.Sockets;
using System.IO.Ports;
using Modbus.Device;
using Modbus.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Text;
using System.Timers;

namespace Bachelor_Test
{
    public partial class Form1 : Form
    {
        //Data types needed across the class
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
        private List<string> verifiedTest = new List<string>(); // Verifing if tag is OK or not OK under testing. 
        private List<Color> tagColors = new List<Color>(); //Storing the color based on IO list
        private byte slaveID = 1; //Default slaveID 1
        private string comPort = ""; //Gets assigned in the GUI
        private int baudRate, dataBits;
        private Parity parity;
        private StopBits stopBits;
        private byte[] serverIpAdress = new byte[4];
        private OleDbCommand cmd;
        private string stringPath;
        private bool comRtuOK = false;
        private bool comTcpOK = false;
        private int watchDog = 0;
        private static DateTime _lastRequestTime;
        private static System.Windows.Forms.Timer _watchdogTimer;
        private bool _rtuRequestReceived = false;
        private bool _tcpRequestReceived = false;
        private bool isAlarmDisplayed = false;
        private DateTime _lastCommunicationTime;
        private bool _isRestarting = false;
        private const int MaxRestartAttempts = 3;
        private int currentRestartAttempts = 0;
        private DateTime lastCommunicationTime;
        private bool isRestarting = false;
        private System.Windows.Forms.Timer restartTimer;
        private const int CommunicationTimeout = 5000; // 5 seconds
        private const int RestartDelay = 3000; // 3 seconds



        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        //Makes sure holding register value is changed when toggle is pressed
        private void btnChangeHolding_Click(object sender, EventArgs e)
        {
            try
            {
                string registerAdressRaw = txtAdress.Text;
                string registerAdressSubstring;
                double registerAdress = 0;

                if (registerAdressRaw.Contains("."))
                {
                    registerAdressSubstring = registerAdressRaw.Substring(0, registerAdressRaw.IndexOf("."));
                    registerAdress = double.Parse(registerAdressSubstring) - 40000; // Adjusting for the leading number
                }
                else
                {
                    registerAdressSubstring = registerAdressRaw;
                    registerAdress = double.Parse(registerAdressRaw) - 40000; // Adjusting for the leading number
                }

                if (cbPlusRegister.Checked && !cbMinusRegister.Checked)
                {
                    registerAdress += 1;
                }
                else if (cbMinusRegister.Checked && !cbPlusRegister.Checked)
                {
                    registerAdress -= 1;
                }

                ushort startAddress = (ushort)registerAdress;
                string addressValue = txtHoldingValue.Text;
                int adr = Convert.ToInt32(addressValue);
                bool BitAdress = addressValue.Contains(".");
                int sensorLow = int.Parse(txtEngLow.Text);
                int sensorHigh = int.Parse(txtEngHigh.Text);
                int serialLow = int.Parse(txtSerialLow.Text);
                int serialHigh = int.Parse(txtSerialHigh.Text);
                ushort uSendRawData = 0;
                int Scale;
                int rawData;
                int sendRawData;



                if (tcpSlave != null && tcpSlave.DataStore != null) //Ensures that the TCP server is initialized
                {
                    if (registerAdressRaw.Contains(".")) //If dotted extracts the number after the dot
                    {
                        int dotAdress = int.Parse(registerAdressRaw.Substring(registerAdressRaw.IndexOf(".") + 1));
                        BittCounter bittCounter = new BittCounter(dotAdress, adr);
                        uSendRawData = bittCounter.BittMassage;
                    }
                    else if (adr < 0 && serialLow != 0)
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

                    tcpSlave.DataStore.HoldingRegisters[startAddress] = uSendRawData;
                }


                if (rtuSlave != null && rtuSlave.DataStore != null)  // Ensure the RTU Modbus Slave is initialized
                {

                    if (registerAdressRaw.Contains("."))
                    {
                        int dotAdress = int.Parse(registerAdressRaw.Substring(registerAdressRaw.IndexOf(".") + 1));
                        BittCounter bittCounter = new BittCounter(dotAdress, adr);
                        uSendRawData = bittCounter.BittMassage;
                    }
                    else if (adr < 0) //Calculation if negative number is to be saved
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

                    rtuSlave.DataStore.HoldingRegisters[startAddress] = uSendRawData;
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



        private void connectToDatabase(string filepath) //Method for extracting selected IO list
        {
            string querystring = "SELECT Io_List.S_Serial_Line_Name, Io_List.S_Instrument_Tag, Io_List.S_Description, Io_List.S_Serial_Line_Address, Io_List.S_Eng_Units, Io_List.S_Eng_Range_Low, Io_List.S_Eng_Range_High, Io_List.S_Serial_Line_Range_Low, Io_List.S_Serial_Line_Range_High, Io_List.W_Citect_Test\r\nFROM Io_List\r\nWHERE (((Io_List.S_Serial_Line_Name) Is Not Null));";
            using OleDbConnection connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Persist Security Info=False;");
            using OleDbCommand command = new OleDbCommand(querystring, connection);
            string verrifiedQuerystring = "UPDATE Io_List SET W_Citect_Test = @newValue WHERE S_Serial_Line_Name IS NOT NULL;";

            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();
            cmd = new OleDbCommand(verrifiedQuerystring, connection);
            //Puts the IO list into variables saved in program 
            while (reader.Read())
            {
                try
                {
                    serialLineName.Add(reader.GetString(0));
                    tag.Add(reader.GetString(1));
                    description.Add(reader.GetString(2));
                    serialAdress.Add(reader.GetString(3));
                    verifiedTest.Add(reader.IsDBNull(9) ? "" : reader.GetString(9));
                    if (verifiedTest.Last().ToString() == "OK")
                    {
                        tagColors.Add(Color.LimeGreen);
                    }

                    else if (verifiedTest.Last().ToString() == "Not OK")
                    {
                        tagColors.Add(Color.Red);
                    }

                    else
                    {
                        tagColors.Add(Color.Silver);
                    }

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


        private void comboBoxSerialLine_SelectedIndexChanged(object sender, EventArgs e) //Puts every signal under specified serial line in the listview
        {
            listViewSignals.Items.Clear();
            string serialLineSelected = comboBoxSerialLine.Text;
            for (int i = 0; i < tag.Count; i++)
            {
                if (serialLineName[i] == serialLineSelected)
                {
                    listViewSignals.Items.Add(tag[i]).BackColor = tagColors[i];

                }
            }
        }

        private void importIOListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialogDB.InitialDirectory = "C:\\Marine\\Projects";
            FileDialogDB.Filter = "Select Database(*.mdb)|*.mdb";
            if (FileDialogDB.ShowDialog() == DialogResult.OK)
            {
                stringPath = FileDialogDB.FileName;
                connectToDatabase(stringPath);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localIPAddress;
            COMPortSettingsMessageBox comSettings = new COMPortSettingsMessageBox();
            if (comSettings.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Retrieve the selected values
                    comPort = comSettings.SelectedCOMPort;
                    slaveID = byte.Parse(comSettings.SlaveID);
                    baudRate = comSettings.SelectedBaudRate;
                    dataBits = comSettings.SelectedDataBits;
                    stopBits = comSettings.SelectedStopBits;
                    parity = comSettings.SelectedParity;
                    localIPAddress = comSettings.LocalIPAddress;
                    // Split the IP address into its components
                    string[] ipParts = localIPAddress.Split('.');
                    try
                    {
                        // Convert each part to a byte and store it in the array
                        for (int i = 0; i < 4; i++)
                        {
                            serverIpAdress[i] = byte.Parse(ipParts[i]);
                        }
                    }
                    catch
                    {
                        //Do nothing
                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong with the settings, try again");
                }

            }

            if (tcpListener != null && rtuSlave != null)
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
            // Starting TCP server
            if (serverIpAdress == null)
            {
                MessageBox.Show("Could not find the local IP address, make sure network card is set up correctly");
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
                            MessageBox.Show($"TCP Error: {ex.Message}");
                        }
                    });

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

            // Starting RTU slave
            if (string.IsNullOrEmpty(comPort))
            {
                MessageBox.Show("You have not configured the COM port");
            }
            else
            {
                try
                {
                    serialport = new SerialPort(comPort)
                    {
                        BaudRate = baudRate,
                        DataBits = dataBits,
                        Parity = parity,
                        StopBits = stopBits
                    };
                    serialport.Open();

                    // Create the RTU slave
                    rtuSlave = ModbusSerialSlave.CreateRtu(slaveID, serialport);
                    rtuSlave.DataStore = datastore;

                    cts2 = new CancellationTokenSource();

                    // Run Listen on a separate task
                    Task.Run(() =>
                    {
                        try
                        {
                            rtuSlave.Listen();
                        }
                        catch (OperationCanceledException)
                        {
                            Console.WriteLine("Modbus listening stopped.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"RTU Error: {ex.Message}");
                        }
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                if (rtuSlave != null && tcpSlave != null)
                {
                    CheckboxConnected.Checked = true;
                }
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
                if (serialport != null)
                {
                    serialport.Dispose();
                    serialport = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping RTU slave: {ex.Message}");
            }
            if(tcpSlave == null && rtuSlave == null)
            {
                CheckboxConnected.Checked = false;
            }
        }

        private void btnResultNotOKClick(object sender, EventArgs e)
        {
            string newValueOK = "Not OK";
            string selectedSerialAddress = txtAdress.Text;

            if (string.IsNullOrEmpty(selectedSerialAddress))
            {
                MessageBox.Show("No row selected");

            }
            else
            {
                string filepath = stringPath;  // Hent filbanen valgt av brukeren
                if (string.IsNullOrEmpty(stringPath))
                {
                    MessageBox.Show("Filbane er ikke satt! Velg en database først.");
                    return;
                }
                string updateQuery = "UPDATE Io_List SET W_Citect_Test = @newValue WHERE S_Serial_Line_Address = @serialLineAddress;";

                using (OleDbConnection connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Persist Security Info=False;"))
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection))
                {
                    // Legg til parameteren for den nye verdien
                    cmd.Parameters.AddWithValue("@newValue", newValueOK);

                    // Legg til parameteren for den valgte raden
                    cmd.Parameters.AddWithValue("@serialLineAddress", selectedSerialAddress);

                    // �pne forbindelsen og kj�r sp�rringen
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    //Create the red background color if signal is NOTOK
                    ListViewItem selectedItem = listViewSignals.SelectedItems[0];
                    selectedItem.BackColor = Color.Red;
                    int index = serialAdress.IndexOf(selectedSerialAddress);
                    tagColors[index] = Color.Red;

                }


            }
        }

        private void btnResultOKClick(object sender, EventArgs e)
        {
            string newValueOK = "OK";
            string selectedSerialAddress = txtAdress.Text;

            if (string.IsNullOrEmpty(selectedSerialAddress))
            {
                MessageBox.Show("Ingen rad valgt!");

            }
            else
            {
                string filepath = stringPath;  // Hent filbanen valgt av brukeren
                if (string.IsNullOrEmpty(stringPath))
                {
                    MessageBox.Show("Filbane er ikke satt! Velg en database først.");
                    return;
                }
                string updateQuery = "UPDATE Io_List SET W_Citect_Test = @newValue WHERE S_Serial_Line_Address = @serialLineAddress;";

                using (OleDbConnection connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Persist Security Info=False;"))
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection))
                {
                    // Legg til parameteren for den nye verdien
                    cmd.Parameters.AddWithValue("@newValue", newValueOK);

                    // Legg til parameteren for den valgte raden
                    cmd.Parameters.AddWithValue("@serialLineAddress", selectedSerialAddress);

                    // �pne forbindelsen og kj�r sp�rringen
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    //Create the green background color if signal is OK
                    ListViewItem selectedItem = listViewSignals.SelectedItems[0];
                    selectedItem.BackColor = Color.LimeGreen;
                    int index = serialAdress.IndexOf(selectedSerialAddress);
                    tagColors[index] = Color.LimeGreen;
                }


            }
        }


        private void txtHoldingValue_TextChanged(object sender, EventArgs e)
        {
            int busScaleLow;
            int busScaleHigh;
            int engScaleLow;
            int engScaleHigh;
            int scalingLow = 0;
            int scalingHigh = 0;
            int rawBusValue;

            if (string.IsNullOrWhiteSpace(txtHoldingValue.Text))
            {
                txtRawBusValue.Clear();
                return;
            }

            if (int.TryParse(txtSerialLow.Text, out busScaleLow) &&
                int.TryParse(txtEngLow.Text, out engScaleLow) &&
                int.TryParse(txtSerialHigh.Text, out busScaleHigh) &&
                int.TryParse(txtEngHigh.Text, out engScaleHigh) &&
                int.TryParse(txtHoldingValue.Text, out rawBusValue))
            {
                if (engScaleHigh != 0)
                {
                    scalingHigh = busScaleHigh / engScaleHigh;
                    rawBusValue *= scalingHigh;
                    txtRawBusValue.Text = Convert.ToString(rawBusValue);
                }
                else if (engScaleLow != 0)
                {
                    scalingLow = busScaleLow / engScaleLow;
                    rawBusValue *= scalingLow;
                    txtRawBusValue.Text = Convert.ToString(rawBusValue);
                }
            }
        }

        private void HelpUserManualClick(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "FullstendigCV_Automasjonsingeniør.pdf");

            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Brukermanualen ble ikke funnet!", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void listViewSignals_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewSignals.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewSignals.SelectedItems[0];
                string tagHighLighted = selectedItem.Text; // Assuming the tag is in the first column

                int position = tag.IndexOf(tagHighLighted);
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

        }

        private void InitializeWatchdog(int interval)
        {
            if(rtuSlave != null && tcpSlave != null)
            {
                // Subscribe to the ModbusSlaveRequestReceived event for both TCP and RTU slaves
                rtuSlave.ModbusSlaveRequestReceived += OnRtuModbusSlaveRequestReceived;
                tcpSlave.ModbusSlaveRequestReceived += OnTcpModbusSlaveRequestReceived;
                // Initialize the watchdog timer
                _watchdogTimer = new System.Windows.Forms.Timer();
                _watchdogTimer.Interval = interval;
                _watchdogTimer.Tick += WatchdogTimer_Tick;
                _watchdogTimer.Start();

                // Initialize the restart timer
                restartTimer = new System.Windows.Forms.Timer();
                restartTimer.Interval = RestartDelay;
                restartTimer.Tick += RestartTimer_Tick;

                // Set the initial last communication time to the current time
                lastCommunicationTime = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Cannot start the watchdog, communication channels have not been opened");
            }

        }

        private void OnRtuModbusSlaveRequestReceived(object sender, ModbusSlaveRequestEventArgs e)
        {
            _rtuRequestReceived = true;
        }

        private void OnTcpModbusSlaveRequestReceived(object sender, ModbusSlaveRequestEventArgs e)
        {
            _tcpRequestReceived = true;
        }

        private void WatchdogTimer_Tick(object sender, EventArgs e)
        {
            if (_rtuRequestReceived && _tcpRequestReceived)
            {
                // Both RTU and TCP requests have been received within the interval
                watchDog++;

                if (txtWatchDog.InvokeRequired)
                {
                    txtWatchDog.Invoke(new Action(() =>
                    {
                        txtWatchDog.Text = watchDog.ToString();
                    }));
                }
                else
                {
                    txtWatchDog.Text = watchDog.ToString();
                }

                // Reset the alarm flag and update the last communication time
                isAlarmDisplayed = false;
                lastCommunicationTime = DateTime.Now;
                isRestarting = false;
                currentRestartAttempts = 0;
                restartTimer.Stop();
            }
            else
            {
                // Check if the communication timeout has been exceeded
                if ((DateTime.Now - lastCommunicationTime).TotalMilliseconds > CommunicationTimeout)
                {
                    if (!isRestarting && currentRestartAttempts < MaxRestartAttempts)
                    {
                        // Start the restart process
                        isRestarting = true;
                        currentRestartAttempts++;
                        StopSimulator();
                        StartSimulator();
                        restartTimer.Start();
                    }
                    else if (currentRestartAttempts >= MaxRestartAttempts && !isAlarmDisplayed)
                    {
                        // Display alarm message after maximum restart attempts
                        isAlarmDisplayed = true;
                        MessageBox.Show("Alarm: No Modbus requests received after multiple restart attempts.");
                    }
                }
            }

            _rtuRequestReceived = false;
            _tcpRequestReceived = false;
        }

        private void RestartTimer_Tick(object sender, EventArgs e)
        {
            if (isRestarting)
            {
                isRestarting = false;
                restartTimer.Stop();
            }
        }


        private void btnWatchdogStart_Click(object sender, EventArgs e)
        {
            try
            {
                int interval = int.Parse(comboBoxWatchdogInterval.Text);
                if (btnWatchdogStart.Text == "Start")
                {
                    InitializeWatchdog(interval);
                    btnWatchdogStart.Text = "Stop";
                }
                else if (btnWatchdogStart.Text == "Stop")
                {
                    // Check if the watchdog timer is initialized before stopping it
                    if (_watchdogTimer != null)
                    {
                        _watchdogTimer.Stop();
                    }

                    // Unsubscribe from the ModbusSlaveRequestReceived events if rtuSlave and tcpSlave are initialized
                    if (rtuSlave != null)
                    {
                        rtuSlave.ModbusSlaveRequestReceived -= OnRtuModbusSlaveRequestReceived;
                    }

                    if (tcpSlave != null)
                    {
                        tcpSlave.ModbusSlaveRequestReceived -= OnTcpModbusSlaveRequestReceived;
                    }

                    // Reset the watchdog counter and update the TextBox
                    watchDog = 0;
                    txtWatchDog.Text = watchDog.ToString();

                    // Reset the button text to "Start"
                    btnWatchdogStart.Text = "Start";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("You must select a valid number for the interval");
            }
        }
    }
}

