using System;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace RobotControllerXtreme
{
    public partial class MainWindow : Form
    {      
        SerialPort port;
        MqttClient clientSub;

        // POSSIBLE SERVERS:
        // "broker.hivemq.com";
        // "iot.eclipse.org"

        String hostName = "iot.eclipse.org";       // CHANGE TO ACTUAL SERVER
        String topicName = "ArduinoControl";       // CHANGE TO ACTUAL TOPIC

        JSONDataHolder holder;
        String rawGPSData;
        String lastValidGPS = "";

        public delegate void SerialPortCallback(Control control, string text);
        public delegate void MQTTCallback(Control control, string text);

        public MainWindow()
        {
            InitializeComponent();
            holder = new JSONDataHolder();           
        }


        public static string GetComPort()
            {
                string portName = "";

                for (int i = 1; i <= 20; i++)
                {
                    try
                    {
                        using (SerialPort port = new SerialPort(string.Format("COM{0}", i)))
                        {
                            // Try to Open the port
                            port.Open();

                            // Ensure that you're communicating with the correct device (Some logic to test that it's your device)
                            portName = string.Format("COM{0}", i);

                            // Close the port
                            port.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                return portName;
            }

        public bool ConnectToCOMPort()
        {
            bool success = true;
            string comPort = GetComPort();
            if (comPort != "")
            {
                port = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.DataReceived += SerialDataHandler;
                MessageBox.Show("Connected to serial " + comPort);
                LeftButton.Enabled = true;
                StopButton.Enabled = true;
                RightButton.Enabled = true;
                ForwardButton.Enabled = true;
                BackButton.Enabled = true;
                
            }

            else
            {
                MessageBox.Show("Not connected to serial port");
                success = false;
            }
            return success;
        } 


        #region  Serial command window

        private void SerialConnectButton_Click(object sender, EventArgs e)
        {
            if (ConnectToCOMPort())
            {
                SerialConnectButton.Enabled = false;
                SerialCommunicationBox.Enabled = true;
            }
        }


        private void StopButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] {0x00});
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] {0x01});                 
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] {0x02});        
        }       

        private void LeftButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] { 0x03 });       
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] { 0x04 });
             
        }


        private void SendCommand(byte[] commands)
        {
            if (port != null)
                port.Write(commands, 0, 1);
        }
    

        private void SetSerialText(Control control, String text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SerialPortCallback(SetSerialText), new object[] { control, text });  
            }
            else
            {                                           
                ((ListBox)control).Items.Add(text);
            }            
        }

        private void SerialDataHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();

            rawGPSData += indata;

            // if string contains start and end of JSON
            if (rawGPSData.Contains("{") && rawGPSData.Contains("}"))
                if (rawGPSData.IndexOf("{") < rawGPSData.IndexOf("}"))
                {
                    rawGPSData = rawGPSData.Substring(rawGPSData.IndexOf('{'), rawGPSData.IndexOf('}') - rawGPSData.IndexOf('{') + 1); // !?
                    lastValidGPS = rawGPSData;
                    rawGPSData = "";
                }
                else
                    rawGPSData = ""; 
            
            if (indata != Environment.NewLine.ToString() && indata != "\r" && indata != "\n")          
                SetSerialText(SerialCommunicationBox, indata);               
            
        }

        #endregion


        #region MQTT window

        private void SetMQTTText(Control control, String text)
        {            
            if (control.InvokeRequired)
            {
                control.Invoke(new MQTTCallback(SetMQTTText), new object[] { control, text});                
            }
            else
            {                              
                ((ListBox)control).Items.Add(text);
            }
        }

        private void EventPublished(Object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                String message = Encoding.UTF8.GetString(e.Message);

                if (message == "5")
                    if (lastValidGPS != "")
                        clientSub.Publish(topicName, Encoding.UTF8.GetBytes(lastValidGPS), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

                if (message.Length == 1)
                {
                    byte command = Convert.ToByte(((message.Trim().ToCharArray())[0] - 48)); // clusterfuck lol    
                    SendCommand(new byte[] { command });
                }

                SetMQTTText(ConnectionStatusBox, "*** Received Message");
                SetMQTTText(ConnectionStatusBox, "*** Topic: " + e.Topic);
                SetMQTTText(ConnectionStatusBox, "*** Message: " + message);
                SetMQTTText(ConnectionStatusBox, "");
            }
            catch (InvalidCastException ex)
            {
            }
        }          

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            clientSub = new MqttClient(hostName);
            clientSub.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(EventPublished);

            try
            {
                clientSub.Connect(hostName + "_sub");
                SetMQTTText(ConnectionStatusBox, "* Client connected"); 
                clientSub.Subscribe(new string[] { topicName }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                SetMQTTText(ConnectionStatusBox, "** Subscribing to: " + topicName);

                ConnectButton.Enabled = false;
                PublishButton.Enabled = true;
                DisconnectButon.Enabled = true;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Failed to connect!");
            }
        }

        private void DisconnectButon_Click(object sender, EventArgs e)
        {
            try
            {
                clientSub.Disconnect();
                SetMQTTText(ConnectionStatusBox, "* Client disconnected");

                ConnectButton.Enabled = true;
                PublishButton.Enabled = false;
                DisconnectButon.Enabled = false;
            }
            catch (InvalidCastException ex)
            {
            }
        }

        private void PublishButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PayloadTextBox.Text != "")
                {
                    clientSub.Publish(topicName, Encoding.UTF8.GetBytes(PayloadTextBox.Text), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                    PayloadTextBox.Text = "";
                    SetMQTTText(ConnectionStatusBox, "*** Publishing on: " + topicName);
                }

                //holder.JSONSerializeData("100", "-15", "5", "200", "45.02", "46.03");        
                //clientSub.Publish(topicName, Encoding.UTF8.GetBytes(holder.JSONString), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);    

                if (lastValidGPS != "")
                    clientSub.Publish(topicName, Encoding.UTF8.GetBytes(lastValidGPS), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

                              
            }
            catch (InvalidCastException ex)
            {
            }
        }

        #endregion

    }
}
       

       
    
