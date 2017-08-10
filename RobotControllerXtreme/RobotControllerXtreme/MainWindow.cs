using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace RobotControllerXtreme
{
    public partial class MainWindow : Form
    {      
        SerialPort port;                

        public delegate void SerialPortStringConsumer(Control control, string text);

        public MainWindow()
        {           
            InitializeComponent();
            port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.DataReceived += SerialDataHandler;       
        }

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
        }

        private void SetSerialText(Control control, String text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SerialPortStringConsumer(SetSerialText), new object[] { control, text });  
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

       

       
    }
}
