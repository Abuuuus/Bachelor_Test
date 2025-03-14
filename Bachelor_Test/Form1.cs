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
        private DataStore datastore = DataStoreFactory.CreateDefaultDataStore(); //Shared holding register for TCP and RTU
        //Variables needed for the slaves
        private SerialPort serialport; 
        private TcpListener tcpListener;
        private ModbusTcpSlave tcpSlave;
        private ModbusSlave rtuSlave;
        //Necessary lists for storing values in IO-list
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
        //Variables to be fetched from the settings window for RTU configuration
        private int baudRate, dataBits;
        private Parity parity;
        private StopBits stopBits;
        private byte[] serverIpAdress = new byte[4];
        private string stringPath;
        private int watchDog = 0;
        private static System.Windows.Forms.Timer watchdogTimer;
        //Flags for modbus reqeusts
        private bool rtuRequestReceived = false;
        private bool tcpRequestReceived = false;
        private bool isAlarmDisplayed = false;
        private const int MaxRestartAttempts = 3;
        private int currentRestartAttempts = 0;
        //Variable to update last time modbus request was received and watchdog variables
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
            //This method toggles the bit value for specified signal, if it was high it toggles low, if low toggles high
            try
            {
                // Parse and adjust the register address from the input
                string registerAddressRaw = txtAdress.Text;
                //Variables for executing the method
                string registerAddressSplit;
                int dotAddress;
                double registerAddress;
                ushort currentValue;

                // Checking if it is a dot address, if not method does not get used and exits
                if (registerAddressRaw.Contains("."))
                {
                    dotAddress = int.Parse(registerAddressRaw.Substring(registerAddressRaw.IndexOf(".") + 1));
                    registerAddressSplit = registerAddressRaw.Substring(0, registerAddressRaw.IndexOf("."));

                    // Remove the first character and parse the rest as an integer
                    registerAddress = double.Parse(registerAddressSplit.Substring(1));
                }

                else return; //Exits method if it is not a dot address

                // Adjust the register address based on checkbox selections
                if (cbPlusRegister.Checked && !cbMinusRegister.Checked)
                {
                    registerAddress += 1;
                }
                else if (cbMinusRegister.Checked && !cbPlusRegister.Checked)
                {
                    registerAddress -= 1;
                }

                // Check if the simulator has been started and holding register initialized, if not then error message shows
                if (datastore?.HoldingRegisters == null)
                {
                    MessageBox.Show("The simulator has not been started, so you cannot change registers", "Error");
                    return;
                }

                // Get the current value of the register
                currentValue = tcpSlave.DataStore.HoldingRegisters[(ushort)registerAddress];

                // Ensure the register address is within the valid range. This will most likely never be an issue due to importation of IO list
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
            //Catched for various exceptions
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





        private void connectToDatabase(string filepath) 
        {
            //This method imports a IO list from a .mdb file in Access. User selects which file they want to import and all information
            //is saved locally within the program

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
            //Executed the read command
            connection.Open();
            using OleDbDataReader reader = command.ExecuteReader();
            //Puts the IO list into variables saves in the program
            while (reader.Read())
            {
                try
                {
                    //Ensures if the cell has no information the values saved within program are blank. This is to eliminate faults in
                    //in importing and values to not be shifted places
                    serialLineName.Add(reader.GetString(0));
                    tag.Add(reader.IsDBNull(1) ? "" : reader.GetString(1));
                    description.Add(reader.IsDBNull(2) ? "" : reader.GetString(2));
                    serialAdress.Add(reader.IsDBNull(3) ? "" : reader.GetString(3));
                    verifiedTest.Add(reader.IsDBNull(9) ? "" : reader.GetString(9));
                    sLoopTypical.Add(reader.IsDBNull(10) ? "" : reader.GetString(10));
                    //Adds colors based on Citech_test column. Ensures that previous tests where signals were verified will show up green
                    //and user will not have to verify again
                    if (verifiedTest.Last().ToString() == "OK")
                    {
                        tagColors.Add(Color.LimeGreen);
                    }

                    else if (verifiedTest.Last().ToString() == "Not OK")
                    {
                        tagColors.Add(Color.Red);
                    }
                    //If test has not been done on signal it puts the background color of the listview
                    else
                    {
                        tagColors.Add(Color.Silver);
                    }
                    //Manual override for dot addresses in IO list, these have no information on ranges, and should have 0 as low and 1 as high
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

                catch
                {
                    //Do nothing, making sure program does not crash
                }

            }
            VerifyDataIntegrity(filepath); //Method to check if the IO list imported successfully
            foreach (string s in serialLineName)
            {
                if (comboBoxSerialLine.Items.Contains(s))
                {
                    //Do nothing, serial line has already been added
                }
                else
                {
                    //Adds the serial line in the dropdown box
                    comboBoxSerialLine.Items.Add(s);
                }
            }

        }
        private bool hasShownMessage = false; // Prevent multiple message boxes

        private void VerifyDataIntegrity(string filepath)
        {
            //Temporary method for checking if IO list imported successfully
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






        private void comboBoxSerialLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This method will add all the tags to the listview for selected serial line
            listViewSignals.Items.Clear();
            string serialLineSelected = comboBoxSerialLine.Text;
            string textBuilder = "";
            for (int i = 0; i < tag.Count; i++)
            {
                if (serialLineName[i] == serialLineSelected)
                {
                    textBuilder = tag[i].ToString() + " " + sLoopTypical[i].ToString(); //Adds both the tag and the s_loop_typical to the listview

                    ListViewItem item = new ListViewItem(textBuilder);
                    item.BackColor = tagColors[i]; // Assign background color


                    listViewSignals.Items.Add(item);
                }
            }
        }

        
        private void importIOListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This method sets the filepath that is standard for the IO lists, and then runs the method filling the information into lists
            FileDialogDB.InitialDirectory = "C:\\Marine\\Projects"; //Standard path for where IO list are. Further project specification is selected by user
            FileDialogDB.Filter = "Select Database(*.mdb)|*.mdb"; //Filters to only show filetypes for access databases
            if (FileDialogDB.ShowDialog() == DialogResult.OK)
            {
                stringPath = FileDialogDB.FileName; //Saves the path for where the IO list is
                connectToDatabase(stringPath); //Runs the method that saves IO list information
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //Exits the program

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This method will save the configuration for the COM port and IP address that is selected nby the user. This information in stored in the
            //COMPortSettingsMessageBox class when the user presses OK in the configuration menu. All information is fetched from the class
            string localIPAddress;
            COMPortSettingsMessageBox comSettings = new COMPortSettingsMessageBox();
            if (comSettings.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Retrieve the selected values from the class and saves in main program
                    comPort = comSettings.SelectedCOMPort;
                    slaveID = byte.Parse(comSettings.SlaveID);
                    baudRate = comSettings.SelectedBaudRate;
                    dataBits = comSettings.SelectedDataBits;
                    stopBits = comSettings.SelectedStopBits;
                    parity = comSettings.SelectedParity;
                    localIPAddress = comSettings.LocalIPAddress;
                    rtuCommunicationChecked = comSettings.rtuCommunication;
                    tcpCommunicationChecked = comSettings.tcpCommunication;
                    // Split the IP address into its components due to configuration of the TCP slave
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
                        //Do nothing for now, put in messagebox with information that IP address could not be parsed if wanted
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
            //This method starts RTU and TCP connection based on what the user has entered in the settings menu
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
            //This method will stop the simulator when user presses stop simulator
            StopSimulator();
        }

        private void StartTCPSimulator()
        {
            //This method starts the TCP slave side of the simulator using IP address selected in the settings menu
            if (serverIpAdress == null)
            {
                MessageBox.Show("Could not find the local IP address, make sure network card is set up correctly");
            }
            else
            {
                IPAddress address = new IPAddress(serverIpAdress); //Starts the simulator on selected IP address
                int port = 502; //Standard port for slave

                // Initialize cancellation token source
                cts = new CancellationTokenSource();

                try
                {
                    // Start the TCP listener
                    tcpListener = new TcpListener(address, port);
                    tcpListener.Start();

                    // Create the Modbus TCP slave using the default listener
                    tcpSlave = ModbusTcpSlave.CreateTcp(slaveID, tcpListener);
                    tcpSlave.DataStore = datastore; // Assign the shared datastore to TCP slave
                    lastCommunicationTime = DateTime.Now; //Updates the lastcommunication time when it is started
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
                //Various catches for exceptions
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
        
        private void StartRTUSimulator()
        {
            //This method starts the RTU slave side of the simulator with the configuration selected in the settings menu

            // Starting RTU slave
            if (string.IsNullOrEmpty(comPort))
            {
                //Is the COM port has not been configured in the settings menu the slave will not be started
                MessageBox.Show("You have not configured the COM port");
            }
            else
            {
                try
                {
                    //Creating the serialport with the configurations selected
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
                    rtuSlave.DataStore = datastore; //Assigns the shared datastore

                    cts2 = new CancellationTokenSource();
                    lastCommunicationTime = DateTime.Now; //Updates the communication time for the watchdog
                    rtuSlave.ModbusSlaveRequestReceived += OnTcpModbusSlaveRequestReceived; //Subscribes the the method for communication requests received

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
            //This methods stops the TCP or RTU slave depending on which is active

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

        private void btnResultNotOKClick(object sender, EventArgs e)
        {
            //This method will input Not OK into the IO list that is loaded by user in the citech_test column
            string notOKString = "Not OK";
            string selectedSerialAddress = txtAdress.Text; //Fetches the serial address for selected tag

            if (string.IsNullOrEmpty(selectedSerialAddress))
            {
                //If no tag is selected then the messagebox will show
                MessageBox.Show("No row selected");

            }
            else
            {
                string filepath = stringPath;  //Use existing path of loaded IO list
                if (string.IsNullOrEmpty(stringPath))
                {
                    //If no IO list has been loaded it exits the method
                    MessageBox.Show("Cannot input any information when you have not selected a IO list");
                    return;
                }
                //Query for updating the IO list
                string updateQuery = "UPDATE Io_List SET W_Citect_Test = @newValue WHERE S_Serial_Line_Address = @serialLineAddress;";

                
                using (OleDbConnection connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Persist Security Info=False;"))
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection))
                {
                    //Put the not OK string into the same row as the selected serialaddress
                    cmd.Parameters.AddWithValue("@newValue", notOKString);

                    cmd.Parameters.AddWithValue("@serialLineAddress", selectedSerialAddress);

                    connection.Open();

                    //Create the red background color if signal is NOTOK
                    ListViewItem selectedItem = listViewSignals.SelectedItems[0];
                    selectedItem.BackColor = Color.Red;
                    int index = serialAdress.IndexOf(selectedSerialAddress);
                    tagColors[index] = Color.Red;

                }


            }
            //Scrolls to the next tag when the test has been deemed as not OK
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

        private void btnResultOKClick(object sender, EventArgs e)
        {
            //This method will input OK into the IO list that is loaded by user in the citech_test column
            string OKString = "OK";
            string selectedSerialAddress = txtAdress.Text; //Fetches the serial address for selected tag

            if (string.IsNullOrEmpty(selectedSerialAddress))
            {
                //If no IO list has been selected it exits the method
                MessageBox.Show("No row selected");

            }
            else
            {
                string filepath = stringPath;  //Using existing path
                if (string.IsNullOrEmpty(stringPath))
                {
                    //If no IO list has been loaded it exits the method
                    MessageBox.Show("Cannot input any information when you have not selected a IO list");
                    return;
                }
                //Query for updating the IO list
                string updateQuery = "UPDATE Io_List SET W_Citect_Test = @newValue WHERE S_Serial_Line_Address = @serialLineAddress;";

                using (OleDbConnection connection = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Persist Security Info=False;"))
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection))
                {
                    //Put the OK string into the same row as the selected serialaddress
                    cmd.Parameters.AddWithValue("@newValue", OKString);

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
            //Scrolls to the next tag when the test has been deemed as OK
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

        private void txtHoldingValue_TextChanged(object sender, EventArgs e)
        {
            //This method will update the user on the bus value for the eng value they have inputted for each time it is typed

            //Variables needed for the method
            int busScaleLow;
            int busScaleHigh;
            int engScaleLow;
            int engScaleHigh;
            int userValue;
            int rawBusValue;

            if (string.IsNullOrWhiteSpace(txtHoldingValue.Text))
            {
                //If there is nothing written or user deletes what is written the raw bus value text is cleard and method exits
                txtRawBusValue.Clear();
                return;
            }
            //Makes sure that the values are correctly parsed. This will most likely only fail if user inputs a character other than a number
            if (int.TryParse(txtSerialLow.Text, out busScaleLow) &&
                int.TryParse(txtEngLow.Text, out engScaleLow) &&
                int.TryParse(txtSerialHigh.Text, out busScaleHigh) &&
                int.TryParse(txtEngHigh.Text, out engScaleHigh) &&
                int.TryParse(txtHoldingValue.Text, out userValue))
            {
                //Using interpolation to scale the bus value based on the ranges provided from the tag
                rawBusValue = busScaleLow + ((userValue-engScaleLow)*(busScaleHigh-busScaleLow)/(engScaleHigh-engScaleLow));
                txtRawBusValue.Text = Convert.ToString(rawBusValue);
            }
        }

        private void HelpUserManualClick(object sender, EventArgs e)
        {
            //This method will open the user manual when it is pressed. User manual is located within the project
            string pdfPath = Path.Combine(Application.StartupPath, "FullstendigCV_Automasjonsingeniør.pdf");

            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("User manual not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void listViewSignals_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //This method will change the information about the tag for which one is selcted. When user selects a new tag information
            //is updated for the approprate textboxes.
            changeTagInformation();

        }

        private void InitializeWatchdog(int interval)
        {
            //This method will initialize the watchdog with parameters needed

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
                //If it cannot start then communication channels have not been opened. User has not started either RTU or TCP slave
                txtWatchdogAddress.ReadOnly = false;
                btnWatchdogStart.Text = "Start";
                MessageBox.Show("Cannot start the watchdog, communication channels have not been opened");
            }
        }


        private CancellationTokenSource cancelUncheckTokenSource;

        private void OnRtuModbusSlaveRequestReceived(object sender, ModbusSlaveRequestEventArgs e)
        {
            //This method keeps track of incoming requests for RTU communication and updates the time and the checkbox for connection
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
            //This method keeps track of incoming requests for TCP communication and updates the time and the checkbox for connection
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
            //This method will untick the connected checkbox if there has been no requests within 2 seconds
            // Cancel any previous uncheck task
            cancelUncheckTokenSource?.Cancel();
            cancelUncheckTokenSource = new CancellationTokenSource();
            var token = cancelUncheckTokenSource.Token;

            Task.Delay(2000, token) // Wait 2 seconds
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
            //This method will tick the watchdog value based on the interval chosen by the user

            if (rtuRequestReceived || tcpRequestReceived) //Checks if either RTU or TCP has received a request
            {
                ushort addressValue = ushort.Parse(txtWatchdogAddress.Text); //Fetches the address typed in for the watchdog
                // Both RTU and TCP requests have been received within the interval
                watchDog++;  // Increment the watchdog counter

                datastore.HoldingRegisters[addressValue] = (ushort)watchDog; //Stores the new value within the address for the watchdog

                // Update the watchdog value on the UI, needs to be invoked in the event that it is ran on another thread than the GUI
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
            else //If no request has been received within 5 seconds it will attempt to restart the simulator to estabilish communication again
                 //this will happen 3 times and if communication is not estabilished again the program will give a warning
            {
                // Check if the communication timeout has been exceeded
                if ((DateTime.Now - lastCommunicationTime).TotalMilliseconds > CommunicationTimeout) //If the time is more than 5 seconds it will enter the IF statement
                {
                    if (!isRestarting && currentRestartAttempts < MaxRestartAttempts) //Checks how many times it has tried restarting. If it exceeds 3 attempts than warning will be displayed
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
            //This method will start the watchdog counter with the configuration selected by user
            try
            {
                //Makes sure the interval is a number and not a character that cannot be parsed
                int interval = int.Parse(comboBoxWatchdogInterval.Text);
                ushort addressValue = ushort.Parse(txtWatchdogAddress.Text);

                //Changes the text to stop on the watchdog counter
                if (btnWatchdogStart.Text == "Start")
                {
                    btnWatchdogStart.Text = "Stop";
                    txtWatchdogAddress.ReadOnly = true;

                    // Initialize the watchdog when starting
                    InitializeWatchdog(interval);
                }
                //Changes the text to start on the watchdog counter
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

        private void txtHoldingValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //This method will update the value of the selected tags holding register when user presses ENTER in the textbox for the value
            if (e.KeyChar == (char)Keys.Enter) //Only happens when user presses ENTER
            {
                try
                {
                    string registerAddressRaw = txtAdress.Text; //Fetches the address
                    string registerAddressSubstring; //Substring for splitting the address from leading number
                    double registerAddress = 0;

                    //Checks if it is a dot address and saves the value after the dot and the address itself
                    if (registerAddressRaw.Contains("."))
                    {
                        registerAddressSubstring = registerAddressRaw.Substring(0, registerAddressRaw.IndexOf(".")); //Fetches the address before the dot as a string
                        registerAddress = double.Parse(registerAddressSubstring.Substring(1)); //Saves the address as a number
                    }
                    else
                    {
                        registerAddressSubstring = registerAddressRaw; //If not dotted than saves the address as a string
                        registerAddress = double.Parse(registerAddressSubstring.Substring(1)); //Saves the address as a number
                    }
                    //Adjusts for +- 1 of the actual address when checkboxes are pressed
                    if (cbPlusRegister.Checked && !cbMinusRegister.Checked)
                    {
                        registerAddress += 1;
                    }
                    else if (cbMinusRegister.Checked && !cbPlusRegister.Checked)
                    {
                        registerAddress -= 1;
                    }
                    //Variables needed for method, and information within the tag itself
                    ushort startAddress = (ushort)registerAddress;
                    string addressValue = txtHoldingValue.Text;
                    int userValue = Convert.ToInt32(addressValue);
                    bool BitAdress = addressValue.Contains(".");
                    int engScaleLow = int.Parse(txtEngLow.Text);
                    int engScaleHigh = int.Parse(txtEngHigh.Text);
                    int busScaleLow = int.Parse(txtSerialLow.Text);
                    int busScaleHigh = int.Parse(txtSerialHigh.Text);
                    ushort registerValue = 0;
                    ushort previousValue = 0;
                    //Interpolation for fetching the bus value, bus value gets saved not engine value
                    int rawBusValue = busScaleLow + ((userValue - engScaleLow) * (busScaleHigh - busScaleLow) / (engScaleHigh - engScaleLow));

                    if (tcpSlave != null || rtuSlave != null) // Ensures that either RTU or TCP slaves have been started
                    {
                        if (registerAddressRaw.Contains(".")) // If dotted, extracts the number after the dot
                        {
                            int dotAdress = int.Parse(registerAddressRaw.Substring(registerAddressRaw.IndexOf(".") + 1));
                            BittCounter bittCounter = new BittCounter(dotAdress, userValue); //Runs a instance of the bittcounter class which will calculate the int for the bit selected
                            registerValue = bittCounter.bitValue; //Saves the int value for selected bit
                            previousValue = datastore.HoldingRegisters[startAddress]; //Fetches the previous value of the address for the values of previous bits

                            // If user wants to set bit high, with 1 typed in the textbox
                            if (userValue == 1)
                            {
                                registerValue = (ushort)(previousValue | registerValue); // Set bit high
                            }
                            // If user wants to set bit low, with 0 typed in the textbox
                            else if (userValue == 0)
                            {
                                // Create a mask to clear the specific bit
                                ushort mask = (ushort)~(1 << dotAdress);  // Clears the specific bit based on dotAdress

                                // Apply the mask to clear the bit
                                registerValue = (ushort)(previousValue & mask);

                            }

                            datastore.HoldingRegisters[startAddress] = registerValue;
                        }
                        else if (rawBusValue < 0)
                        //If it is not a dotted address then we only need to check it the value is negative since negative values cannot be sent
                        //The max value is added to the negative value and sent as a positive number over modbus. Modbus converts this based on the protocol
                        {
                            //Adds the absolute maximum number of a short. Example -32760 will become 32776 when sent, but interperated
                            //as -32760 by the PLC
                            rawBusValue = rawBusValue + 65536; 
                            registerValue = (ushort)rawBusValue; 
                        }
                        else
                        {
                            //If not a negative number than the actual value is stored
                            registerValue = (ushort)(rawBusValue);
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
            //This method will change the information about the tag for which one is selcted. When user selects a new tag information
            //is updated for the approprate textboxes. Same as the mousedoubleclick
            changeTagInformation();
        }

        private void changeTagInformation()
        {
            //This method will assign the appropriate values for the tag that is selected which is all stored in the program.
            //Since it is a list and the IO list importation happens for each row then indexes can be used
            if (listViewSignals.SelectedItems.Count > 0) //Makes sure that a tag is selected
            {
                ListViewItem selectedItem = listViewSignals.SelectedItems[0]; 
                string textHighlighted = selectedItem.Text; //Fetches the tag information that is selected
                string tagHighlighted = textHighlighted.Substring(0, textHighlighted.IndexOf(" ")); //Filters out the S_loop_typical information

                int position = tag.IndexOf(tagHighlighted); //Finds the index of the selected tag and uses this index for all informatiom
                if (position != -1) //Makes sure the tag is actually found within the list
                {
                    //Fetches all information about the tag and assigns it to approprate textboxes
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
            txtHoldingValue.Text = string.Empty; //Empties the value that user has entered for a previous tag
        }

        private void listViewSignals_KeyDown(object sender, KeyEventArgs e)
        {
            //This method lets user use the arrow keys for scrolling tags within the listview
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Trigger the same behavior as mouse click selection change
                changeTagInformation();
            }
        }

        private void listViewSignals_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This method will change the information about the tag for which one is selcted. When user selects a new tag information
            //is updated for the approprate textboxes.
            changeTagInformation();
        }

        private void listViewSignals_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //This method will draw the custom color border for the tag that is selected. This is mainly only for visual representation
            //of which tag is selected as a default would hide the background color of the selected tag

            // Clear the area to prevent artifacts from previous selections
            e.Graphics.FillRectangle(new SolidBrush(listViewSignals.BackColor), e.Bounds);

            // If the item is selected, apply custom drawing
            if (e.Item.Selected)
            {
                // Draw the original background (green/red) for the selected item
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
            //This method will ensure that the slaves are stopped before form is closed.

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

