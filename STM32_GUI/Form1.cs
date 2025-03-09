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

            try
            {
                InitializeComponent();

                // Ensure serialPort1 is not null before opening
                if (serialPort1 != null && !serialPort1.IsOpen)
                {
                    serialPort1.Open(); // Open the serial port safely
                }

                // Initialize Serial Port
                serialPort1.DataReceived += serialPort1_DataReceived;

                // Initialize Command Handlers
                commandHandlers = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)
                {
                   // { "cmd:htr_1", data => UpdateIndicator(Color.Lime) },
                    //{ "cmd:htr_0", data => UpdateIndicator(Color.Red) },
                    //{ "TEMP", data => ParseAndUpdateTempHumidity(data) }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening serial port: " + ex.Message);
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string indata = serialPort1.ReadExisting().Trim();
                if (!string.IsNullOrEmpty(indata))
                {
                    serialBuffer.Append(indata);

                    // Ensure complete message processing (assuming newline `\n` as delimiter)
                    if (indata.Contains("\n"))
                    {
                        string fullMessage = serialBuffer.ToString().Trim();
                        serialBuffer.Clear(); // Clear buffer for next message

                        Console.WriteLine("Received Data: " + fullMessage);
                       // ProcessReceivedData(fullMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                BeginInvoke(new Action(() => MessageBox.Show($"Serial Read Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void SendCommand(string command)
        {
            if (serialPort1 != null && serialPort1.IsOpen)
            {
                try
                {
                    string formattedCommand = command + "\r\n";  // Ensure STM32 gets CR+LF
                    serialPort1.Write(formattedCommand);
                    Console.WriteLine("Sent: " + formattedCommand);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending command: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Serial port is not open!");
            }
        }

        private void m1Strat_Click(object sender, EventArgs e)
        {
           
            SendCommand("PA_15:ON"); // PinID:State
        }

        private void m1Stop_Click(object sender, EventArgs e)
        {
           
            SendCommand("PA_15:OFF"); // PinID:State
        }
        
    }
}
