
/* SerialPortHandler.cs*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace SerialConfig
{
    public class SerialPortHandler
    {
        private SerialPort serialPort;
        private Dictionary<string, Action<string>> commandHandlers;

        // Constructor
        public SerialPortHandler(string portName)
        {
            serialPort = new SerialPort(portName)
            {
                BaudRate = 115200, // Set appropriate baud rate
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One
            };

            commandHandlers = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "PA_15:ON", data => Console.WriteLine("PA_15 is ON") },  // Fixed recursion issue
                { "PA_15:OFF", data => Console.WriteLine("PA_15 is OFF") }
            };
        }

        // Initialize Serial Port safely
        public void InitializeSerialPort()
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();  // Open the serial port safely
                }

                // Register for data received event
                serialPort.DataReceived += SerialPort_DataReceived;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening serial port: " + ex.Message);
            }
        }

        // Handle data received from the serial port
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedData = serialPort.ReadLine().Trim();  // Trim whitespace
                Console.WriteLine("Received: " + receivedData);

                // Check if there's a handler for the received command
                if (commandHandlers.ContainsKey(receivedData))
                {
                    commandHandlers[receivedData].Invoke(receivedData);
                }
                else
                {
                    Console.WriteLine("Unknown Command: " + receivedData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading data: " + ex.Message);
            }
        }

        // Send command to serial port
        public void SendCommand(string command)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    string formattedCommand = command + "\r\n";  // Ensure STM32 gets CR+LF
                    serialPort.Write(formattedCommand);
                    Console.WriteLine("Sent: " + formattedCommand);
                }
                else
                {
                    Console.WriteLine("Serial port is not open!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending command: " + ex.Message);
            }
        }
    }
}