using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace lab2
{
    public partial class Form1 : Form
    {
        private SerialPort port1;
        private SerialPort port2;
        private String name;
        private Int32 priority;
        private Int32 requestedPrio;

        private Boolean connected = false;
        private Boolean wantToSend = false;
        //private Boolean canSend = false;
        private Boolean isMonitor = false;
        private Boolean received = false;
        private Boolean markerSended = false;
        private Boolean baseMarker = true;

        private Marker markerReceived;

        public Form1()
        {
            InitializeComponent();
            prioComboBox.SelectedIndex = 1;            
            TextBox.CheckForIllegalCrossThreadCalls = false;            
        }

        // коннект/дисконнект станции
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                if (nameTextBox.Text.Length != 6) 
                {
                    MessageBox.Show(this, "Mac should contain 6 bytes!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);                                                             
                    return;
                }
                if (!initPorts()) 
                {
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
                baseMarker = true;
                isMonitor = (Boolean) monitorCheckBox.Checked;
                name = nameTextBox.Text;
                //canSend = false;
                setMonitor(monitorCheckBox.Checked);
                priority = Int32.Parse((String)prioComboBox.SelectedItem);
                markerSended = false;
                wantToSend = false;
                connected = true;
            }
            else 
            {
                closePorts();
                port1TextBox.Enabled = true;
                port2TextBox.Enabled = true;
                prioComboBox.Enabled = true;
                nameTextBox.Enabled = true;
                monitorCheckBox.Enabled = true;
                connectButton.Text = "Connect";
                sendButton.Enabled = false;
                isMonitor = false;
                wantToSend = false;
                monitorLabel.Text = "";
                priority = 0;
                connected = false;
                receiveTextBox.Text = "Received data:";
            }
        }

        // коннект к портам
        private Boolean initPorts() 
        {
            try
            {
                port1 = new SerialPort(port1TextBox.Text, 9600, Parity.None, 8, StopBits.One);
                port1.Open();
                port1.DiscardInBuffer();
                port1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            }
            catch (Exception e)
            {               
                port1TextBox.Text = "Incorrect!";
                return false;
            }
            try
            {
                port2 = new SerialPort(port2TextBox.Text, 9600, Parity.None, 8, StopBits.One);
                port2.Open();
                port1.DiscardOutBuffer();
            }
            catch (Exception e)
            {
                port2TextBox.Text = "Incorrect!";
                port1.Close();
                return false;
            }
            return true;
        }

        // дисконнект от портов
        private void closePorts()
        {
            port1.Close();
            port2.Close();
        }

        // обработчик принятия данных по 1 порту
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] dataBytes = new byte[port1.BytesToRead];
            port1.Read(dataBytes, 0, port1.BytesToRead);

            Encoding enc = Encoding.GetEncoding(1251);
            String text = enc.GetString(dataBytes);
            analyze(text);            
        }

        private void analyze(String package)
        {
            if (package.Length == 3)
            {
                Marker mrk = new Marker(package);
                printMessage("<marker> (prio: " + mrk.getPriority()+ ")");
                analyzeMarker(package);
            }
            else 
            {
                analyzeFrame(package);
            }
        }

        private void analyzeMarker(String package)
        {
            Marker marker = new Marker(package);

            if (isMonitor)
            {
                if (marker.getPriority() == 7)
                {
                    if (wantToSend && marker.getReservedPriority() < priority)
                    {
                        // установить свой приоритет
                        marker.setReservedPriority(priority);
                    }
                    // может вставить проверочку на getReservedPriority() > 0 
                    requestedPrio = marker.getReservedPriority();
                    baseMarker = false;
                }
                else
                {
                    if (wantToSend && marker.getPriority() <= priority)
                    {
                        // захват маркера и отправка сообщения
                        markerReceived = marker;
                        //canSend = true;
                        Frame frame = new Frame(markerReceived, isMonitor, destTextBox.Text, name, sendTextBox.Text);
                        writeToPort(port2, frame.ToString());
                        wantToSend = /*canSend =*/ false;
                        wantToSendLabel.Text = "";
                        sendButton.Enabled = true;
                    }
                    baseMarker = true;
                }
                markerSended = false;
                sendMarkerButton.Enabled = true;
            }
            else
            {
                if (marker.getPriority() == 7)
                {
                    if (wantToSend && marker.getReservedPriority() < priority)
                    {
                        // установить свой приоритет
                        marker.setReservedPriority(priority);
                    }
                    // пересылка маркера дальше по кольцу 
                    writeToPort(port2, marker.ToString());
                }
                else
                {
                    if (wantToSend && marker.getPriority() <= priority)
                    {
                        // захват маркера и отправка сообщения
                        markerReceived = marker;
                        //canSend = true;
                        Frame frame = new Frame(markerReceived, isMonitor, destTextBox.Text, name, sendTextBox.Text);
                        writeToPort(port2, frame.ToString());
                        wantToSend = /*canSend =*/ false;
                        wantToSendLabel.Text = "";
                        sendButton.Enabled = true;
                    }
                    else
                    {
                        // пересылка маркера дальше по кольцу 
                        writeToPort(port2, package);
                    }
                }
            }
        }

        /*private void analyzeMarker(String package)
        {
            Marker marker = new Marker(package);

            if (isMonitor)
            {
                if (marker.getPriority() == 7)
                {
                    // может вставить проверочку на getReservedPriority() > 0 
                    requestedPrio = marker.getReservedPriority();
                    baseMarker = false;
                }
                else
                {
                    baseMarker = true;
                }
                markerSended = false;
                sendMarkerButton.Enabled = true;
            }
            else
            {
                if (marker.getPriority() == 7)
                {
                    if (wantToSend && marker.getReservedPriority() < priority)
                    {
                        // установить свой приоритет
                        marker.setReservedPriority(priority);
                    }
                    // пересылка маркера дальше по кольцу 
                    writeToPort(port2, marker.ToString());
                }
                else
                {
                    if (wantToSend && marker.getPriority() <= priority)
                    {
                        // захват маркера и отправка сообщения
                        markerReceived = marker;
                        canSend = true;
                        Frame frame = new Frame(markerReceived, isMonitor, destTextBox.Text, name, sendTextBox.Text);
                        writeToPort(port2, frame.ToString());
                        wantToSend = canSend = false;
                        wantToSendLabel.Text = "";
                        sendButton.Enabled = true;
                    }
                    else
                    {
                        // пересылка маркера дальше по кольцу 
                        writeToPort(port2, package);
                    }
                }
            }
        }
        */

        private void analyzeFrame(String package)
        {
            Frame frame = new Frame(package);

            if (isMonitor && !frame.isSendedByMonitor()) 
            {
                setMonitor(false);
            }
            if (name.Equals(frame.getDestAddr()))
            {
                // вывести и переслать дальше по кольцу
                printMessage(frame.getData());
                writeToPort(port2, package);
            }
            if (name.Equals(frame.getSourceAddr()))
            {
                // стать монитором и удалить из кольца
                setMonitor(true);
            }
            else 
            {
                // переслать дальше по кольцу
                writeToPort(port2, package);
            }
        }

        private void setMonitor(Boolean monitor) {
            isMonitor = monitor;
            sendMarkerButton.Enabled = monitor;
            if (monitor)
            {
                monitorLabel.Text = "Is Monitor";
            }
            else
            {
                monitorLabel.Text = "";
            }
        }

        // вывод в receiveBox
        private void printMessage(String message)
        {
            try
            {
                DateTime time = DateTime.UtcNow;
                receiveTextBox.Text += "\r\n" + time.ToLongTimeString() + ": " + message;
                receiveTextBox.SelectionStart = receiveTextBox.Text.Length - 1;
                receiveTextBox.ScrollToCaret();
            }
            catch (Exception exc) 
            {
                //ignore
            }
        }

        // обработчик запроса на отправку данных
        private void sendButton_Click(object sender, EventArgs e)
        {
            wantToSend = true;
            wantToSendLabel.Text = "Want to Send";
            sendButton.Enabled = false;
        }

        // циклическая посылалка маркера
        /*private void markerSending() 
        {
            while (connected)
            {
                if (!isMonitor || markerSended)
                {
                    Thread.Sleep(1000);
                }
                else
                {
                    Marker marker;
                    if (baseMarker)
                    {
                        marker = Marker.getBaseMarker();
                    }
                    else 
                    {
                        marker = new Marker(requestedPrio, false, true);
                    }
                    markerSended = true;
                    writeToPort(port2, marker.ToString());                    
                }
            }
        }*/

        // посылалка в порт
        private void writeToPort(SerialPort port, String data)
        {
            while (port.BytesToWrite != 0) 
            {
                Thread.Sleep(50);
            }
            port.RtsEnable = true;
            Encoding enc = Encoding.GetEncoding(1251);
            byte[] dataBytes = enc.GetBytes(data);
            port.Write(dataBytes, 0, dataBytes.Length);
            port.RtsEnable = false;
        }

        // закрытие формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected)
            {
                connected = false;
                closePorts();
            }
        }
        
        // послать маркер
        private void sendMarkerButton_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                sendMarkerButton.Enabled = false;
                if (!isMonitor || markerSended)
                {
                    Thread.Sleep(1000);
                }
                else
                {
                    Marker marker;
                    if (baseMarker)
                    {
                        marker = Marker.getBaseMarker();
                    }
                    else
                    {
                        marker = new Marker(requestedPrio, false, true);
                    }
                    markerSended = true;
                    writeToPort(port2, marker.ToString());
                }
            }
        }
    }
}
