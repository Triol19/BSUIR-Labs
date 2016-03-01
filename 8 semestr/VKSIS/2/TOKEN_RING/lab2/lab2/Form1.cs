using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;

using System.Collections;
using System.Runtime.InteropServices;

namespace lab2
{
    public partial class Form1 : Form
    {
        Machine machine;

        public Form1()
        {
            InitializeComponent();
            prioComboBox.SelectedIndex = 1;            
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        // коннект/дисконнект станции
        private void connectButton_Click(object sender, EventArgs e)
        {
            machine = new Machine(
                    int.Parse(port1TextBox.Text),
                    int.Parse(port2TextBox.Text),
                    ipTo.Text,
                    destTextBox,
                    sendTextBox,
                    receiveTextBox,
                    wantToSendLabel,
                    monitorLabel,
                    sendMarkerButton,
                    sendButton
                    );

            if (!machine.connected)
            {
                if (nameTextBox.Text.Length != 6) 
                {
                    MessageBox.Show(this, "Mac should contain 6 bytes!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);                                                             
                    return;
                }
              
                port1TextBox.Enabled = false;
                port2TextBox.Enabled = false;
                prioComboBox.Enabled = false;
                nameTextBox.Enabled = false;
                monitorCheckBox.Enabled = false;
                connectButton.Text = "Disconnect";
                wantToSendLabel.Text = "";
                sendButton.Enabled = true;
                machine.baseMarker = true;
                machine.isMonitor = (Boolean) monitorCheckBox.Checked;
                machine.name = nameTextBox.Text;
                //canSend = false;
                machine.setMonitor(monitorCheckBox.Checked);
                machine.priority = Int32.Parse((String)prioComboBox.SelectedItem);
                machine.markerSended = false;
                machine.wantToSend = false;
                machine.connected = true;
            }
            else 
            {
                port1TextBox.Enabled = true;
                port2TextBox.Enabled = true;
                prioComboBox.Enabled = true;
                nameTextBox.Enabled = true;
                monitorCheckBox.Enabled = true;
                connectButton.Text = "Connect";
                sendButton.Enabled = false;
                machine.isMonitor = false;
                machine.wantToSend = false;
                monitorLabel.Text = "";
                machine.priority = 0;
                machine.connected = false;
                receiveTextBox.Text = "Received data:";
            }
            /*try
            {
                sendS = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                recieveS = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                portFrom = int.Parse(port1TextBox.Text);
                portTo = int.Parse(port2TextBox.Text);
            }
            catch (Exception)
            {
                port1TextBox.Text = "Incorrect!";
            }

            IPAddress ipAddressFrom = IPAddress.Parse("192.168.1.122");
            IPEndPoint ipEnd = new IPEndPoint(ipAddressFrom, portFrom); //IPAddress.Any

            sendS.Bind(ipEnd);
            sendS.Listen(1);
            sendS.BeginAccept(new AsyncCallback(accept), null);*/
        }

        // обработчик запроса на отправку данных
        private void sendButton_Click(object sender, EventArgs e)
        {
            machine.wantToSend = true;
            wantToSendLabel.Text = "Want to Send";
            sendButton.Enabled = false;

            // Если мы монитор - отправляем маркер
            if (machine.isMonitor)
            {
                machine.sendMarker();
            }
        }

        // послать маркер
        private void sendMarkerButton_Click(object sender, EventArgs e)
        {
            machine.sendMarker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (machine.connected)
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(machine.ipTo), System.Convert.ToInt32(machine.portTo));
                machine.recieveS.Connect(ip);
            }
        }
    }
}
