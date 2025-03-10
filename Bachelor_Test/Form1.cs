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
        /// <summary>
        /// 
        /// </summary>
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
        private List<string> verifiedTest = new List<string>(); 
        private List<string> sLoopTypical = new List<string>();
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
        private static System.Windows.Forms.Timer watchdogTimer;
        private bool rtuRequestReceived = false;
        private bool tcpRequestReceived = false;
        private bool isAlarmDisplayed = false;
        private DateTime _lastCommunicationTime;
        private bool _isRestarting = false;
        private const int MaxRestartAttempts = 3;
        private int currentRestartAttempts = 0;
        private DateTime lastCommunicationTime;
        private bool isRestarting = false;
        private System.Windows.Forms.Timer restartTimer;
        private const int CommunicationTimeout = 5000; 
        private const int RestartDelay = 3000; 
        private bool tcpCommunicationChecked;
        private bool rtuCommunicationChecked;



        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            listViewSignals.DrawItem += listViewSignals_DrawItem;
            listViewSignals.DrawSubItem += listViewSignals_DrawSubItem;

        }

        private void btnToggleValue(object sender, EventArgs e)
        {
            try
            {
                // Parse and adjust the register address from the input
                string registerAddressRaw = txtAdress.Text;
                string registerAddressSplit;
                int dotAddress;
                double registerAddress;
                ushort currentValue;
                ushort tempCurrentValue;
                BittCounter bittCounter;

                // Checking if it is a dot address, if not exit the method
                if (registerAddressRaw.Contains("."))
                {
                    dotAddress = int.Parse(registerAddressRaw.Substring(registerAddressRaw.IndexOf(".") + 1));
                    registerAddressSplit = registerAddressRaw.Substring(0, registerAddressRaw.IndexOf("."));
                    registerAddress = double.Parse(registerAddressSplit) - 40000;
                }
                else return;

                // Adjust the register address based on checkbox selections
                if (cbPlusRegister.Checked && !cbMinusRegister.Checked)
                {
                    registerAddress += 1;
                }
                else if (cbMinusRegister.Checked && !cbPlusRegister.Checked)
                {
                    registerAddress -= 1;
                }

                // Check if the simulator has been started
                if (datastore?.HoldingRegisters == null)
                {
                    MessageBox.Show("The simulator has not been started, so you cannot change registers", "Error");
                    return;
                }

                // Get the current value of the register
                currentValue = tcpSlave.DataStore.HoldingRegisters[(ushort)registerAddress];

                // Ensure the register address is within the valid range
                if (registerAddress < 0 || registerAddress >= tcpSlave.DataStore.HoldingRegisters.Count)
                {
                    MessageBox.Show("Invalid register address.");
                    return;
                }

                // Create the bitmask for the specific bit to toggle
                ushort mask = (ushort)(1 << dotAddress);

                // Toggle the bit using XOR operation
                ushort newValue = (ushort)(currentValue ^ mask);

                // Update the holding register with the new value (after toggling the bit)
                tcpSlave.DataStore.HoldingRegisters[(ushort)registerAddress] = newValue;

            }
            catch (FormatException)
            {
                MessageBox.Show("The address must be a valid number.", "Input Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show("The address is out of range.", "Input Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error");
            }
        }





        private void connectToDatabase(string filepath) //Method for extracting selected IO list
        {
            //Clearing old IO list information in variables and GUI
            serialLineName.Clear();
            tag.Clear();
            description.Clear();
            serialAdress.Clear();
            verifiedTest.Clear();
            sLoopTypical.Clear();
            tagColors.Clear();
            engUnit.Clear();
            engRangeHigh.Clear();
            engRangeLow.Clear();
            serialLineHigh.Clear();
            serialLineLow.Clear();
            comboBoxSerialLine.Items.Clear();
            comboBoxSerialLine.Text = "";
            listViewSignals.Items.Clear();
            //Clearing the values in the holding register setting them all to 0
            for (int i = 1; i < datastore.HoldingRegisters.Count; i++)
            {
                datastore.HoldingRegisters[i] = (ushort)0;
            }
            //Setting query needed for extracting correct information
            string querystring = "SELECT Io_List.S_Serial_Line_Name, Io_List.S_Instrument_Tag, Io_List.S_Description, Io_List.S_Serial_Line_Address, Io_List.S_Eng_Units, Io_List.S_Eng_Range_Low, Io_List.S_Eng_Range_High, Io_List.S_Serial_Line_Range_Low, Io_List.S_Serial_Line_Range_High, Io_List.W_Citect_Test, Io_List.S_Loop_Typical\r\nFROM Io_List\r\nWHERE (((Io_List.S_Serial_Line_Name) Is Not Null))\r\nORDER BY Io_List.S_Instrument_Tag ASC;";
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
                    tag.Add(reader.IsDBNull(1) ? "" : reader.GetString(1));
                    description.Add(reader.IsDBNull(2) ? "" : reader.GetString(2));
                    serialAdress.Add(reader.IsDBNull(3) ? "" : reader.GetString(3));
                    verifiedTest.Add(reader.IsDBNull(9) ? "" : reader.GetString(9));
                    sLoopTypical.Add(reader.IsDBNull(10) ? "" : reader.GetString(10));
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
                        engUnit.Add(reader.IsDBNull(4) ? "" : reader.GetString(4));
                        engRangeLow.Add(reader.IsDBNull(5) ? "" : reader.GetString(5));
                        engRangeHigh.Add(reader.IsDBNull(6) ? "" : reader.GetString(6));
                        serialLineLow.Add(reader.IsDBNull(7) ? "" : reader.GetString(7));
                        serialLineHigh.Add(reader.IsDBNull(8) ? "" : reader.GetString(8));


                    }

                }

                catch (Exception e)
                {

                }

            }
            VerifyDataIntegrity(filepath);
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
        private bool hasShownMessage = false; // Prevent multiple message boxes

        private void VerifyDataIntegrity(string filepath)
        {
            if (hasShownMessage) return; // Skip if already shown
            hasShownMessage = true;

            string querystring = "SELECT S_Serial_Line_Name, S_Instrument_Tag, S_Description, S_Serial_Line_Address, " +
                                 "S_Eng_Units, S_Eng_Range_Low, S_Eng_Range_High, S_Serial_Line_Range_Low, " +
                                 "S_Serial_Line_Range_High, W_Citect_Test, S_Loop_Typical " +
                                 "FROM Io_List WHERE S_Serial_Line_Name IS NOT NULL ORDER BY S_Instrument_Tag ASC;";

            using (OleDbConnection connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Persist Security Info=False;"))
            using (OleDbCommand command = new OleDbCommand(querystring, connection))
            {
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    int index = 0;
                    List<string> mismatches = new List<string>();

                    while (reader.Read())
                    {
                        if (index >= serialLineName.Count) break;

                        // Read values from database (handling NULL values)
                        string dbSerialLineName = reader.IsDBNull(0) ? "" : reader.GetString(0).Trim();
                        string dbTag = reader.IsDBNull(1) ? "" : reader.GetString(1).Trim();
                        string dbDescription = reader.IsDBNull(2) ? "" : reader.GetString(2).Trim();
                        string dbSerialAddress = reader.IsDBNull(3) ? "" : reader.GetString(3).Trim();
                        string dbEngUnit = reader.IsDBNull(4) ? "" : reader.GetString(4).Trim();
                        string dbVerifiedTest = reader.IsDBNull(9) ? "" : reader.GetString(9).Trim();
                        string dbLoopTypical = reader.IsDBNull(10) ? "" : reader.GetString(10).Trim();

                        // Read values from lists
                        string listSerialLineName = serialLineName[index].Trim();
                        string listTag = tag[index].Trim();
                        string listDescription = description[index].Trim();
                        string listSerialAddress = serialAdress[index].Trim();
                        string listEngUnit = engUnit[index].Trim();
                        string listVerifiedTest = verifiedTest[index].Trim();
                        string listLoopTypical = sLoopTypical[index].Trim();

                        // Check for mismatches
                        if (dbSerialLineName != listSerialLineName ||
                            dbTag != listTag ||
                            dbDescription != listDescription ||
                            dbSerialAddress != listSerialAddress ||
                            dbEngUnit != listEngUnit ||
                            dbVerifiedTest != listVerifiedTest ||
                            dbLoopTypical != listLoopTypical)
                        {
                            mismatches.Add($"Row {index + 1} Mismatch:\n" +
                                           $"Expected [Tag: {dbTag}, Address: {dbSerialAddress}, Desc: {dbDescription}, " +
                                           $"Unit: {dbEngUnit}," +
                                           $"Test: {dbVerifiedTest}, Loop: {dbLoopTypical}]\n" +
                                           $"Found [Tag: {listTag}, Address: {listSerialAddress}, Desc: {listDescription}, " +
                                           $"Unit: {listEngUnit}," +
                                           $"Test: {listVerifiedTest}, Loop: {listLoopTypical}]\n");
                        }

                        index++;
                    }

                    // Check if row counts match
                    if (index < serialLineName.Count)
                    {
                        mismatches.Add($"Mismatch in row count: Database has {index} rows, but list has {serialLineName.Count} rows.");
                    }

                    // Display final result in a single message box
                    if (mismatches.Count > 0)
                    {
                        MessageBox.Show($"Data mismatches found:\n\n{string.Join("\n", mismatches)}",
                                        "Data Verification",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("All data matches the database!",
                                        "Data Verification",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
            }

            hasShownMessage = false; // Reset flag for future calls
        }






        //Depending on serial line selected, correct tags will be filled in the list
        private void comboBoxSerialLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewSignals.Items.Clear();
            string serialLineSelected = comboBoxSerialLine.Text;
            string textBuilder = "";
            for (int i = 0; i < tag.Count; i++)
            {
                if (serialLineName[i] == serialLineSelected)
                {
                    textBuilder = tag[i].ToString() + " " + sLoopTypical[i].ToString();

                    ListViewItem item = new ListViewItem(textBuilder);
                    item.BackColor = tagColors[i]; // Assign background color


                    listViewSignals.Items.Add(item);
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

        //When settings dialog is closed, fetch variables from class storing them
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
                    rtuCommunicationChecked = comSettings.rtuCommunication;
                    tcpCommunicationChecked = comSettings.tcpCommunication;
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
        }

        
        private void btnStartSimulator_Click(object sender, EventArgs e)
        {
            if (tcpCommunicationChecked)
            {
                StartTCPSimulator();
            }
            if (rtuCommunicationChecked)
            {
                StartRTUSimulator();
            }

        }

        private void btnStopSimulator_Click(object sender, EventArgs e)
        {
            StopSimulator();
        }

        //Starting the TCP side of simulator
        private void StartTCPSimulator()
        {
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
                    lastCommunicationTime = DateTime.Now;
                    tcpSlave.ModbusSlaveRequestReceived += OnTcpModbusSlaveRequestReceived;

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
        }
        
        //Starting RTU side of simulator
        private void StartRTUSimulator()
        {

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
                    lastCommunicationTime = DateTime.Now;
                    rtuSlave.ModbusSlaveRequestReceived += OnTcpModbusSlaveRequestReceived;

                    // Run Listen on a separate task
                    MessageBox.Show("RTU Communication starting, it might take some time before it is connected");
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
            if (tcpSlave == null && rtuSlave == null)
            {
                CheckboxConnected.Checked = false;
            }
        }

        //Inputting NOT OK in IO list for selected tag
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
                string filepath = stringPath;  //Use existing path
                if (string.IsNullOrEmpty(stringPath))
                {
                    MessageBox.Show("Cannot input any information when you have not selected a IO list");
                    return;
                }
                string updateQuery = "UPDATE Io_List SET W_Citect_Test = @newValue WHERE S_Serial_Line_Address = @serialLineAddress;";

                using (OleDbConnection connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Persist Security Info=False;"))
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@newValue", newValueOK);

                    cmd.Parameters.AddWithValue("@serialLineAddress", selectedSerialAddress);

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

        //Inputting OK in IO list for selected tag
        private void btnResultOKClick(object sender, EventArgs e)
        {
            string newValueOK = "OK";
            string selectedSerialAddress = txtAdress.Text;

            if (string.IsNullOrEmpty(selectedSerialAddress))
            {
                MessageBox.Show("No row selected");

            }
            else
            {
                string filepath = stringPath;  //Using existing path
                if (string.IsNullOrEmpty(stringPath))
                {
                    MessageBox.Show("Cannot input any information when you have not selected a IO list");
                    return;
                }
                string updateQuery = "UPDATE Io_List SET W_Citect_Test = @newValue WHERE S_Serial_Line_Address = @serialLineAddress;";

                using (OleDbConnection connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Persist Security Info=False;"))
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@newValue", newValueOK);

                    cmd.Parameters.AddWithValue("@serialLineAddress", selectedSerialAddress);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    //Create the green background color if signal is OK
                    ListViewItem selectedItem = listViewSignals.SelectedItems[0];
                    selectedItem.BackColor = Color.LimeGreen;
                    int index = serialAdress.IndexOf(selectedSerialAddress);
                    tagColors[index] = Color.LimeGreen;
                }


            }
            int currentIndex = listViewSignals.SelectedItems[0].Index;
            int nextIndex = currentIndex + 1;
            if (nextIndex < listViewSignals.Items.Count)
            {
                listViewSignals.Items[currentIndex].Selected = false;
                listViewSignals.Items[currentIndex].Focused = false;
                listViewSignals.Items[nextIndex].Selected = true;
                listViewSignals.Items[nextIndex].Focused = true;
                listViewSignals.EnsureVisible(nextIndex); //Scroll the list only if necessary
            }
            changeTagInformation();

        }

        //Updating the scaling when user inputs something
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

        //Opening user manual
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
            changeTagInformation();

        }

        private void InitializeWatchdog(int interval)
        {
            // Check if either RTU or TCP communication is active
            if (rtuSlave != null || tcpSlave != null)
            {
                // Subscribe to the ModbusSlaveRequestReceived event for both TCP and RTU slaves
                if (rtuSlave != null)
                {
                    rtuSlave.ModbusSlaveRequestReceived += OnRtuModbusSlaveRequestReceived;
                }
                if (tcpSlave != null)
                {
                    tcpSlave.ModbusSlaveRequestReceived += OnTcpModbusSlaveRequestReceived;
                }

                // Initialize the watchdog timer
                watchdogTimer = new System.Windows.Forms.Timer();
                watchdogTimer.Interval = interval;
                watchdogTimer.Tick += WatchdogTimer_Tick;
                watchdogTimer.Start();

                // Initialize the restart timer
                restartTimer = new System.Windows.Forms.Timer();
                restartTimer.Interval = RestartDelay;
                restartTimer.Tick += RestartTimer_Tick;

                // Set the initial last communication time to the current time
                lastCommunicationTime = DateTime.Now;
            }
            else
            {
                txtWatchdogAddress.ReadOnly = false;
                btnWatchdogStart.Text = "Start";
                MessageBox.Show("Cannot start the watchdog, communication channels have not been opened");
            }
        }


        private CancellationTokenSource cancelUncheckTokenSource;

        private void OnRtuModbusSlaveRequestReceived(object sender, ModbusSlaveRequestEventArgs e)
        {
            rtuRequestReceived = true;
            lastCommunicationTime = DateTime.Now;

            if (!IsHandleCreated || IsDisposed) return;

            try
            {
                Invoke(new Action(() =>
                {
                    if (!IsDisposed) CheckboxConnected.Checked = true;
                }));
            }
            catch (ObjectDisposedException) { }

            // Start delayed uncheck task
            StartDelayedUncheck();
        }

        private void OnTcpModbusSlaveRequestReceived(object sender, ModbusSlaveRequestEventArgs e)
        {
            tcpRequestReceived = true;
            lastCommunicationTime = DateTime.Now;

            if (!IsHandleCreated || IsDisposed) return;

            try
            {
                Invoke(new Action(() =>
                {
                    if (!IsDisposed) CheckboxConnected.Checked = true;
                }));
            }
            catch (ObjectDisposedException) { }

            // Start delayed uncheck task
            StartDelayedUncheck();
        }

        private void StartDelayedUncheck()
        {
            // Cancel any previous uncheck task
            cancelUncheckTokenSource?.Cancel();
            cancelUncheckTokenSource = new CancellationTokenSource();
            var token = cancelUncheckTokenSource.Token;

            Task.Delay(2000, token) // Wait 5 seconds
                .ContinueWith(t =>
                {
                    if (!t.IsCanceled)
                    {
                        TimeSpan timeSinceLastRequest = DateTime.Now - lastCommunicationTime;
                        if (timeSinceLastRequest.TotalSeconds >= 2)
                        {
                            if (!IsHandleCreated || IsDisposed) return;

                            try
                            {
                                Invoke(new Action(() =>
                                {
                                    if (!IsDisposed) CheckboxConnected.Checked = false;
                                }));
                            }
                            catch (ObjectDisposedException) { }
                        }
                    }
                }, TaskScheduler.Default);
        }





        private void WatchdogTimer_Tick(object sender, EventArgs e)
        {
            if (rtuRequestReceived || tcpRequestReceived)
            {
                ushort addressValue = ushort.Parse(txtWatchdogAddress.Text);
                // Both RTU and TCP requests have been received within the interval
                watchDog++;  // Increment the watchdog counter

                datastore.HoldingRegisters[addressValue] = (ushort)watchDog;

                // Update the watchdog value on the UI
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

                // Reset alarm flags and update communication time
                isAlarmDisplayed = false;
                lastCommunicationTime = DateTime.Now;  // Update communication time
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
                        isRestarting = true;
                        currentRestartAttempts++;
                        StopSimulator();

                        // Update the last communication time
                        lastCommunicationTime = DateTime.Now;  // Update time right before restarting

                        // Restart communication
                        if (rtuCommunicationChecked)
                        {
                            StartRTUSimulator();
                        }
                        if (tcpCommunicationChecked)
                        {
                            StartTCPSimulator();
                        }

                        restartTimer.Start();
                    }
                    else if (currentRestartAttempts >= MaxRestartAttempts && !isAlarmDisplayed)
                    {
                        isAlarmDisplayed = true;
                        MessageBox.Show("Alarm: No Modbus requests received after multiple restart attempts.");
                    }
                }
            }

            // Reset flags after processing
            rtuRequestReceived = false;
            tcpRequestReceived = false;
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
                ushort addressValue = ushort.Parse(txtWatchdogAddress.Text);

                if (btnWatchdogStart.Text == "Start")
                {
                    btnWatchdogStart.Text = "Stop";
                    txtWatchdogAddress.ReadOnly = true;

                    // Initialize the watchdog when starting
                    InitializeWatchdog(interval);
                }
                else if (btnWatchdogStart.Text == "Stop")
                {
                    // Stop the watchdog timer
                    if (watchdogTimer != null)
                    {
                        watchdogTimer.Stop();
                    }

                    // Unsubscribe from the ModbusSlaveRequestReceived events
                    if (rtuSlave != null)
                    {
                        rtuSlave.ModbusSlaveRequestReceived -= OnRtuModbusSlaveRequestReceived;
                    }

                    if (tcpSlave != null)
                    {
                        tcpSlave.ModbusSlaveRequestReceived -= OnTcpModbusSlaveRequestReceived;
                    }

                    // Reset the watchdog counter only if it's a hard stop (not when restarting communication)
                    watchDog = 0;
                    txtWatchDog.Text = watchDog.ToString();

                    // Reset button and UI state
                    btnWatchdogStart.Text = "Start";
                    txtWatchdogAddress.ReadOnly = false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("You must select a valid number for the interval and a address to link it");
            }
        }

        //Changing the value in the holding register when ENTER is pressed
        private void txtHoldingValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    string registerAddressRaw = txtAdress.Text;
                    string registerAddressSubstring;
                    double registerAddress = 0;

                    if (registerAddressRaw.Contains("."))
                    {
                        registerAddressSubstring = registerAddressRaw.Substring(0, registerAddressRaw.IndexOf("."));
                        registerAddress = double.Parse(registerAddressSubstring) - 40000; // Adjusting for the leading number
                    }
                    else
                    {
                        registerAddressSubstring = registerAddressRaw;
                        registerAddress = double.Parse(registerAddressRaw) - 40000; // Adjusting for the leading number
                    }

                    if (cbPlusRegister.Checked && !cbMinusRegister.Checked)
                    {
                        registerAddress += 1;
                    }
                    else if (cbMinusRegister.Checked && !cbPlusRegister.Checked)
                    {
                        registerAddress -= 1;
                    }

                    ushort startAddress = (ushort)registerAddress;
                    string addressValue = txtHoldingValue.Text;
                    int adrValue = Convert.ToInt32(addressValue);
                    bool BitAdress = addressValue.Contains(".");
                    int sensorLow = int.Parse(txtEngLow.Text);
                    int sensorHigh = int.Parse(txtEngHigh.Text);
                    int serialLow = int.Parse(txtSerialLow.Text);
                    int serialHigh = int.Parse(txtSerialHigh.Text);
                    ushort registerValue = 0;
                    ushort previousValue = 0;
                    int Scale;
                    int rawData;
                    int sendRawData;

                    if (tcpSlave != null || rtuSlave != null) // Ensures that either RTU or TCP slaves have been started
                    {
                        if (registerAddressRaw.Contains(".")) // If dotted, extracts the number after the dot
                        {
                            int dotAdress = int.Parse(registerAddressRaw.Substring(registerAddressRaw.IndexOf(".") + 1));
                            BittCounter bittCounter = new BittCounter(dotAdress, adrValue);
                            registerValue = bittCounter.bitValue;
                            previousValue = datastore.HoldingRegisters[startAddress];

                            // If adrValue is 1, set the bit high
                            if (adrValue == 1)
                            {
                                registerValue = (ushort)(previousValue | registerValue); // Set bit high
                            }
                            // If adrValue is 0, clear the bit
                            else if (adrValue == 0)
                            {
                                // Create a mask to clear the specific bit
                                ushort mask = (ushort)~(1 << dotAdress);  // Clears the specific bit based on dotAdress

                                // Apply the mask to clear the bit
                                registerValue = (ushort)(previousValue & mask);

                            }

                            datastore.HoldingRegisters[startAddress] = registerValue;
                            return;
                        }
                        else if (adrValue < 0 && serialLow != 0)
                        {
                            Scale = serialLow / sensorLow;
                            rawData = Scale * adrValue;
                            sendRawData = rawData + 65536;
                            registerValue = (ushort)sendRawData;
                        }
                        else if (adrValue == 0 && serialLow == 0)
                        {
                            registerValue = 0;
                        }
                        else
                        {
                            Scale = serialHigh / sensorHigh;
                            rawData = Scale * adrValue;
                            registerValue = (ushort)rawData;
                        }
                        datastore.HoldingRegisters[startAddress] = registerValue;
                    }

                    e.Handled = true;
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
        }





        private void listViewSignals_MouseClick(object sender, MouseEventArgs e)
        {
            changeTagInformation();
        }

        //Updating the information about the tag in the appropriate textboxes
        private void changeTagInformation()
        {
            if (listViewSignals.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewSignals.SelectedItems[0];
                string textHighlighted = selectedItem.Text; // Assuming the tag is in the first column
                string tagHighlighted = textHighlighted.Substring(0, textHighlighted.IndexOf(" "));

                int position = tag.IndexOf(tagHighlighted);
                if (position != -1)
                {
                    txtAdress.Text = serialAdress[position];
                    txtDescription.Text = description[position];
                    txtEngHigh.Text = engRangeHigh[position];
                    txtEngLow.Text = engRangeLow[position];
                    txtSerialHigh.Text = serialLineHigh[position];
                    txtSerialLow.Text = serialLineLow[position];
                    txtTag.Text = tagHighlighted;
                    txtEngUnit.Text = engUnit[position];
                }
                else
                {
                    MessageBox.Show("Tag not found in the list.");
                }
            }
            txtHoldingValue.Text = string.Empty;
        }

        //Functionality for pressing arrow up and arrow down to switch tag
        private void listViewSignals_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Trigger the same behavior as mouse click selection change
                changeTagInformation();
            }
        }

        private void listViewSignals_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTagInformation();
        }

        //Making the custom colors when selecting a tag in the listview
        private void listViewSignals_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Clear the area to prevent artifacts from previous selections
            e.Graphics.FillRectangle(new SolidBrush(listViewSignals.BackColor), e.Bounds);

            // If the item is selected, apply custom drawing
            if (e.Item.Selected)
            {
                // Draw the original background (green) for the selected item
                using (SolidBrush backgroundBrush = new SolidBrush(e.Item.BackColor))
                {
                    e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                }

                // Adjust the rectangle slightly to avoid overlapping with previous borders
                Rectangle borderRect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);

                // Draw a thicker selection border
                using (Pen highlightPen = new Pen(Color.DarkBlue, 6))
                {
                    e.Graphics.DrawRectangle(highlightPen, borderRect);
                }

                // Draw the text in black
                e.Graphics.DrawString(e.Item.Text, e.Item.Font, Brushes.Black, e.Bounds);
            }
            else
            {
                // Redraw normal background for unselected items
                using (SolidBrush backgroundBrush = new SolidBrush(e.Item.BackColor))
                {
                    e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                }

                e.Graphics.DrawString(e.Item.Text, e.Item.Font, new SolidBrush(e.Item.ForeColor), e.Bounds);
            }
        }


        private void listViewSignals_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Draw subitem text with original color, no change needed for subitems
            e.Graphics.DrawString(e.SubItem.Text, e.Item.Font, Brushes.Black, e.Bounds);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the Modbus listener tasks
            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
                cts = null;
            }

            if (cts2 != null)
            {
                cts2.Cancel();
                cts2.Dispose();
                cts2 = null;
            }

            // Stop TCP listener
            if (tcpListener != null)
            {
                tcpListener.Stop();
                tcpListener = null;
            }

            // Close and dispose SerialPort
            if (serialport != null && serialport.IsOpen)
            {
                serialport.Close();
                serialport.Dispose();
                serialport = null;
            }

            // Prevent any remaining event handlers from trying to update UI
            tcpRequestReceived = false;
            rtuRequestReceived = false;
        }





    }
}

