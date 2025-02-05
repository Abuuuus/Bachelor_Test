using System;
using System.IO.Ports;
using Modbus.Device;
using Modbus.Data;

namespace Slave_test
{
    internal class Slave_Test
    {
        static void Main(string[] args)
        {
            string comPort = "COM1"; // The COM port to be used
            int baudRate = 9600;

            // Create the SerialPort object
            using (SerialPort slavePort = new SerialPort(comPort))
            {
                try
                {
                    // Set up port configuration
                    slavePort.BaudRate = baudRate;
                    slavePort.DataBits = 8;
                    slavePort.Parity = Parity.None;
                    slavePort.StopBits = StopBits.One;

                    // Attempt to open the COM port
                    slavePort.Open();

                    // Check if the port is opened successfully
                    if (slavePort.IsOpen)
                    {
                        Console.WriteLine($"COM port {comPort} opened successfully.");

                        // Set up Modbus RTU Slave
                        byte unitID = 1;
                        ModbusSlave slave = ModbusSerialSlave.CreateRtu(unitID, slavePort);

                        // Create and assign the data store
                        slave.DataStore = DataStoreFactory.CreateDefaultDataStore();
                        for (int i = 1; i < 11; i++) // Change 100 to your desired range
                        {
                            int value = i + 1;
                            slave.DataStore.HoldingRegisters[i] = (ushort)value; // Default value, you can change this if needed
                        }
                        // Attach handlers for logging requests and responses
                        slave.ModbusSlaveRequestReceived += OnModbusRequestReceived;

                        // Start listening for requests
                        Console.WriteLine("Listening for Modbus requests...");

                        // Listen for requests and process them
                        slave.Listen();
                    }
                    else
                    {
                        Console.WriteLine($"Failed to open COM port {comPort}.");
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Access to the COM port {comPort} is denied. Error: {ex.Message}");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"I/O error occurred while trying to open COM port {comPort}. Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        // Event handler for logging received Modbus requests
        private static void OnModbusRequestReceived(object sender, ModbusSlaveRequestEventArgs e)
        {
            Console.WriteLine($"Modbus Request Received: Function Code: {e.Message.FunctionCode}, " +
                $"Slave Address: {e.Message.SlaveAddress}, Data: {BitConverter.ToString(e.Message.MessageFrame)}");

            // Log the response as well
            Console.WriteLine($"Modbus Response Sent: Function Code: {e.Message.FunctionCode}, " +
                $"Slave Address: {e.Message.SlaveAddress}, Data: {BitConverter.ToString(e.Message.MessageFrame)}");
        }
    }
}