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
        String connectionString = "192.168.0.102"; // CHANGE TO ACTUAL SERVER 
        String hostName = "test.mosquitto.org"; // CHANGE TO ACTUAL SERVER
        String topicName = "ArduinoControl"; // CHANGE TO ACTUAL TOPIC

        public delegate void SerialPortCallback(Control control, string text);
        public delegate void MQTTCallback(Control control, string text);

        public MainWindow()
        {           
            InitializeComponent();

            //port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            //port.Open();
            //port.DataReceived += SerialDataHandler;

            //HostIP = IPAddress.Parse(connectionString);
            clientSub = new MqttClient(hostName);
            //clientSub = new MqttClient(HostIP);
            clientSub.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(EventPublished);
        }

        #region  Command window

        private void StopButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] {0x00});
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] {0x01});
            //byte[] command = new byte[1];
            //command[0] = 1;          
            //port.Write(command,0,1);        
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] {0x02});        
        }       

        private void LeftButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] { 0x03 });
            // SendCommand(3);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            SendCommand(new byte[] { 0x04 });
            //SendCommand(4);           
        }

        private void SendCommand(byte[] commands)
        {
            //byte[] commands = new byte[1];
            //commands[0] = command;
            port.Write(commands, 0, 1);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.Up)
                SendCommand(new byte[] { 0x01 });
            else if (e.KeyCode == Keys.Down)
                SendCommand(new byte[] { 0x02 });
            else if (e.KeyCode == Keys.Left)
                SendCommand(new byte[] { 0x03 });
            else if (e.KeyCode == Keys.Right)
                SendCommand(new byte[] { 0x04 });
            else
                SendCommand(new byte[] { 0x00 });
            */
        }

        private void SetSerialText(Control control, String text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SerialPortCallback(SetSerialText), new object[] { control, text });  
            }
            else
            {
                control.Text = text;     
            }            
        }

        private void SerialDataHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();        

            SetSerialText(SerialResponseBox, indata);         
            Console.Write(indata);
        }


        #endregion


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
                SetMQTTText(ConnectionStatusBox, "*** Received Message");
                SetMQTTText(ConnectionStatusBox, "*** Topic: " + e.Topic);
                SetMQTTText(ConnectionStatusBox, "*** Message: " + Encoding.UTF8.GetString(e.Message));
                SetMQTTText(ConnectionStatusBox, "");
            }
            catch (InvalidCastException ex)
            {
            }
        }          


        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                clientSub.Connect(hostName + "_sub");
                SetMQTTText(ConnectionStatusBox, "* Client connected"); 
                clientSub.Subscribe(new string[] { topicName }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                SetMQTTText(ConnectionStatusBox, "** Subscribing to: " + topicName);
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
            }
            catch (InvalidCastException ex)
            {
            }
        }

        private void PublishButton_Click(object sender, EventArgs e)
        {
            try
            {
                clientSub.Publish(topicName, Encoding.UTF8.GetBytes(PayloadTextBox.Text), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                SetMQTTText(ConnectionStatusBox, "*** Publishing on: " + topicName);               
            }
            catch (InvalidCastException ex)
            {
            }
        }

     
    }
}
       

       
    
