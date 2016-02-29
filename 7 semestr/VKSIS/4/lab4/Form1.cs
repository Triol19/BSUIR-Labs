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

namespace lab4
{
    public partial class Form1 : Form
    {
        Machine machine;

        public Form1()
        {
            InitializeComponent();            
            LoadSpeedValues();
            LoadPackageLength();
            LoadMachineValues();
            //comboBox1.DataSource = System.IO.Ports.SerialPort.GetPortNames();
        }


        private void LoadSpeedValues()
        {
            int[] values = new int[] {110, 150, 300, 600, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200};
            comboBox_speed.DataSource = values;
            comboBox_speed.SelectedItem = 115200;
        }

        private void LoadPackageLength()
        {
            int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            comboBox_length.DataSource = values;
            comboBox_length.SelectedItem = 5;
        }

        private void LoadMachineValues()
        {
            string[] machines = new string[5];
            machines[0] = "1) COM6 & COM7";
            machines[1] = "2) COM8 & COM9";
            machines[2] = "3) COM10 & COM11";
            machines[3] = "4) COM12 & COM13";
            machines[4] = "5) COM14 & COM15";

            comboBox_machine.DataSource = machines;
        }

        // Приём данных
        private void data_Received(object sender, OnRecievedEventArgs e)
        {
            Encoding enc = Encoding.GetEncoding(1251);
            String message = enc.GetString(e.Data);

            if (textBox1.InvokeRequired)
                textBox1.Invoke(new Action<string>((s) => textBox1.AppendText(s)), message);
            else textBox1.AppendText(message);
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            string com1_name, com2_name;
            byte address;
            int speed = int.Parse(comboBox_speed.SelectedItem.ToString());
            switch(comboBox_machine.SelectedIndex)
            {
                case 0:
                    com1_name = "COM6";
                    com2_name = "COM7";
                    address = 1;
                    break;

                case 1:
                    com1_name = "COM8";
                    com2_name = "COM9";
                    address = 2;
                    break;

                case 2:
                    com1_name = "COM10";
                    com2_name = "COM11";
                    address = 3;
                    break;

                case 3:
                    com1_name = "COM12";
                    com2_name = "COM13";
                    address = 4;
                    break;

                case 4:
                    com1_name = "COM14";
                    com2_name = "COM15";
                    address = 5;
                    break;

                default:
                    com1_name = "";
                    com2_name = "";
                    address = 0;
                    break;
            }
            label_address.Text = "" + address;
            try
            {
                machine = new Machine(com1_name, com2_name, int.Parse(comboBox_length.SelectedItem.ToString()), address, speed, checkBox1.Checked, checkBox2.Checked);
                machine.OnReceived += new OnRecievedHandler(data_Received);
                machine.OnForwarding += new OnForwardingHandler(redirectInfo);

                initializeButton.Enabled = false;
                stopButton.Enabled = true;
                sendButton.Enabled = true;

                comboBox_machine.Enabled = false;
                comboBox_speed.Enabled = false;
                comboBox_length.Enabled = false;
                checkBox2.Enabled = false;
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
                Encoding enc = Encoding.GetEncoding(1251);
                byte[] data = enc.GetBytes(textBox1.Text);

                byte dest = byte.Parse(textBox_addr.Text);
                machine.sendMessage(data, dest);
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
            comboBox_machine.Enabled = true;
            comboBox_speed.Enabled = true;
            comboBox_length.Enabled = true;
            checkBox2.Enabled = true;
            machine.OnReceived -= new OnRecievedHandler(data_Received);

            if(machine != null)
                machine.close();
            machine = null;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox_info.Clear();
        }

        /*private void textBox_addr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }*/

        private void redirectInfo(object sender, string info)
        {
            string text = info + Environment.NewLine;
            if (textBox_info.InvokeRequired)
                textBox_info.Invoke(new Action<string>((s) => textBox_info.AppendText(s)), text);
            else textBox_info.AppendText(text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (machine != null)
            {
                if (checkBox1.Checked)
                {
                    textBox_info.Enabled = true;
                    textBox1.Enabled = true;

                    textBox_addr.Enabled = true;

                    sendButton.Enabled = true;
                    clearButton.Enabled = true;
                }
                else
                {
                    textBox_info.Enabled = false;
                    textBox1.Enabled = false;

                    textBox_addr.Enabled = false;

                    sendButton.Enabled = false;
                    clearButton.Enabled = false;
                }

                machine.setEnabled(checkBox1.Checked);
            }
            
        }
    }
}
