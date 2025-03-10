using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM32_GUI
{
    public partial class Form1 : Form
    {
        private StringBuilder serialBuffer = new StringBuilder();
        private Dictionary<string, Action<string>> commandHandlers;


        public Form1()
        {

            InitializeComponent();

            // Initialize Serial Port and ensure it's open
            InitializeSerialPort();

            // Initialize Command Handlers
            commandHandlers = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "PA_15:ON", data => SendCommand("PA_15:ON") },
            { "PA_15:OFF", data => SendCommand("PA_15:OFF") },
            // You can add more handlers for different commands
        };
        }


        /************************************************************************************************/
        private void Form1_Load(object sender, EventArgs e)
        {
            m1_ind.BackColor = Color.Red;  // Default to Red if the action is not SET or RESET
        }
        /************************************************************************************************/

        // Initialize Serial Port safely
        private void InitializeSerialPort()
        {
            try
            {
                if (serialPort1 == null)
                {
                    serialPort1 = new SerialPort("COM9");  // Replace with your correct COM port
                }

                // Ensure serialPort1 is not null before opening
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();  // Open the serial port safely
                }

                // Register for data received event
                serialPort1.DataReceived += SerialPort1_DataReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening serial port: " + ex.Message);
            }
        }

        /*******************************    SerialPort1_DataReceived    ******************************/

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedData = serialPort1.ReadLine().Trim();  // Read and trim the data
                Console.WriteLine("Received: " + receivedData);

                // Process the received data using switch-case
                ProcessReceivedData(receivedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading data: " + ex.Message);
            }
        }



        /**************************************** Process Received Data *********************************/

        private void ProcessReceivedData(string data)
        {
            try
            {
                // Expected format: : TEMP: T1=24.4, RH: H1=45.9, ind: O01:SET
                if (string.IsNullOrEmpty(data)) return;

                // Clean data by trimming and splitting by commas
                string cleanedData = data.TrimStart(':').Trim();
                string[] parts = cleanedData.Split(',');

                string temperatureData = null;
                string humidityData = null;
                string indData = null;

                // Loop through parts and separate TEMP, RH, and ind
                foreach (var part in parts)
                {
                    if (part.Contains("TEMP"))
                    {
                        temperatureData = part.Trim();
                    }
                    else if (part.Contains("RH"))
                    {
                        humidityData = part.Trim();
                    }
                    else if (part.Contains("ind"))
                    {
                        indData = part.Trim();
                    }
                }

                // Process TEMP data 
                if (!string.IsNullOrEmpty(temperatureData))
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        string[] tempParts = temperatureData.Split(':');
                        if (tempParts.Length == 2)
                        {
                            string[] tempChannels = tempParts[1].Trim().Split(',');
                            foreach (var temp in tempChannels)
                            {
                                string[] channelTemp = temp.Trim().Split('=');
                                if (channelTemp.Length == 2)
                                {
                                    string channel = channelTemp[0].Trim();  // T1, T2
                                    string temperature = channelTemp[1].Trim(); // 24.4

                                    if (string.IsNullOrEmpty(temperature))
                                    {
                                        Console.WriteLine($"Temperature value for {channel} is null or empty.");
                                    }
                                    else
                                    {
                                        UpdateTemperature(channel, temperature);
                                    }
                                }
                            }
                        }
                    }));
                }

                // Process RH data 
                if (!string.IsNullOrEmpty(humidityData))
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        string[] rhParts = humidityData.Split(':');
                        if (rhParts.Length == 2)
                        {
                            string[] rhChannels = rhParts[1].Trim().Split(',');
                            foreach (var rh in rhChannels)
                            {
                                string[] channelRh = rh.Trim().Split('=');
                                if (channelRh.Length == 2)
                                {
                                    string channel = channelRh[0].Trim();  // H1
                                    string humidity = channelRh[1].Trim(); // 45.9

                                    if (string.IsNullOrEmpty(humidity))
                                    {
                                        Console.WriteLine($"Humidity value for {channel} is null or empty.");
                                    }
                                    else
                                    {
                                        UpdateHumidity(channel, humidity);
                                    }
                                }
                            }
                        }
                    }));
                }

                // Process indicator data 
                if (!string.IsNullOrEmpty(indData))
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        string[] indParts = indData.Split(':');
                        if (indParts.Length < 3) return;  // Ensure we have the correct format

                        string key = indParts[0].Trim();  // Extract key (e.g., ind)
                        string value = indParts[1].Trim(); // Extract the status (e.g., O01)
                        string action = indParts[2].Trim(); // Extract the action (e.g., SET or RESET)

                        switch (key)
                        {
                            case "ind":
                                Console.WriteLine($"Action received: {action}");  // Debugging line to check if action is being received correctly.
                                switch (action)
                                {
                                    case "SET":
                                        m1_ind.BackColor = Color.Lime;  // Set background color to Lime
                                        break;

                                    case "RESET":
                                        m1_ind.BackColor = Color.Red;  // Set background color to Red
                                        break;

                                }
                                break;

                            default:
                                Console.WriteLine("Unknown Key: " + key);  // Debugging line for unknown keys
                                break;
                        }
                    }));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing data: " + ex.Message);
            }
        }


        /************************************************************************************************/



        private void UpdateTemperature(string channel, string temperature)
        {
            switch (channel)
            {
                case "T1":
                    chTemp.Text = temperature;
                    break;
                //case "T2":
                //    chTemp2.Text = temperature;
                //    break;
                // Add more cases if you have more channels (e.g., T3, T4)
                default:
                    Console.WriteLine("Unknown Temperature Channel: " + channel);
                    break;
            }
        }

        private void UpdateHumidity(string channel, string humidity)
        {
            switch (channel)
            {
                case "H1":
                    chHumidity.Text = humidity;
                    break;
                //case "H2":
                //    chHumidity2.Text = humidity;
                //    break;
                // Add more cases if you have more channels (e.g., H3, H4)
                default:
                    Console.WriteLine("Unknown Humidity Channel: " + channel);
                    break;
            }
        }

        /************************************************************************************************/



        // Send command to serial port
        private void SendCommand(string command)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    string formattedCommand = command + "\r\n";  // Ensure STM32 gets CR+LF
                    serialPort1.Write(formattedCommand);
                    Console.WriteLine("Sent: " + formattedCommand);
                }
                else
                {
                    MessageBox.Show("Serial port is not open!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending command: " + ex.Message);
            }
        }

        /************************************************************************************************/
        private void m1Strat_Click(object sender, EventArgs e)
        {
           
            SendCommand("PA_15:ON"); // PinID:State
        }

        private void m1Stop_Click(object sender, EventArgs e)
        {
           
            SendCommand("PA_15:OFF"); // PinID:State
        }

        private void m1_ind_TextChanged(object sender, EventArgs e){ }

        private void chTemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void chHumidity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
