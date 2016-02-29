using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        ComPort port;


        public Form1()
        {
            InitializeComponent();            
            LoadSpeedValues();
            LoadPackageLength();
            comboBox1.DataSource = System.IO.Ports.SerialPort.GetPortNames();
        }


        private void LoadSpeedValues()
        {
            int[] values = new int[] {110, 150, 300, 600, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200};
            comboBox2.DataSource = values;
            comboBox2.SelectedItem = 2400;
        }

        private void LoadPackageLength()
        {
            int[] values = new int[] {1, 2, 3, 4, 5, 6, 7};
            comboBox3.DataSource = values;
            comboBox3.SelectedItem = 5;
        }

        // Приём данных
        private void port_Received(object sender, OnRecievedEventArgs e)
        {
            if (textBox1.InvokeRequired) 
                textBox1.Invoke(new Action<string>((s) => textBox1.AppendText(s)), e.Data);
            else textBox1.AppendText(e.Data);
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            try
            {
                port = new ComPort(comboBox1.SelectedItem.ToString(), int.Parse(comboBox2.SelectedItem.ToString()));
                port.OnRecived += new OnRecievedHandler(port_Received);

                stopButton.Enabled = true;
                sendButton.Enabled = true;

                initializeButton.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                Stuffing.bitstuffingCount = 0;
                port.serialPort_SendData(textBox1.Text, int.Parse(comboBox3.SelectedItem.ToString()));
                textBox2.Text = Stuffing.bitstuffingCount.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            sendButton.Enabled = false;
            initializeButton.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;

            if(port != null && port.isConnected())
                port.close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

    }
}
