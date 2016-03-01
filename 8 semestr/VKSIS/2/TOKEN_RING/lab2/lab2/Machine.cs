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
    class Machine
    {
        //http://citforum.ru/nets/protocols2/2_05_03.shtml
        public Socket recieveS, sendS;
        public string ipTo;
        public int portTo, portFrom;
        public String name;
        public Int32 priority;
        public Int32 requestedPrio;

        public Boolean connected = false;
        public Boolean wantToSend = false;
        //private Boolean canSend = false;
        public Boolean isMonitor = false;
        public Boolean received = false;
        public Boolean markerSended = false;
        public Boolean baseMarker = true;

        public Marker markerReceived;
        TextBox destTextBox, sendTextBox, receiveTextBox;
        Label wantToSendLabel, monitorLabel;
        Button sendMarkerButton, sendButton;


        public Machine(int portFrom, int portTo, string ipTo, TextBox destTextBox, TextBox sendTextBox, TextBox receiveTextBox,
                        Label wantToSendLabel, Label monitorLabel, Button sendMarkerButton, Button sendButton)
        {
            sendS = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            recieveS = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            this.portFrom = portFrom;
            this.portTo = portTo;
            this.ipTo = ipTo;

            this.destTextBox = destTextBox;
            this.sendTextBox = sendTextBox;
            this.receiveTextBox = receiveTextBox;
            this.wantToSendLabel = wantToSendLabel;
            this.monitorLabel = monitorLabel;
            this.sendMarkerButton = sendMarkerButton;
            this.sendButton = sendButton;

            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, portFrom); //IPAddress.Any

            sendS.Bind(ipEnd);
            sendS.Listen(1);
            sendS.BeginAccept(new AsyncCallback(accept), null);
        }

        public void accept(IAsyncResult asyn)
        {
            Socket sock = sendS.EndAccept(asyn);
            // Let the worker Socket do the further processing for the just connected client
            begin(sock);

            // Since the main Socket is now free, it can go back and wait for
            // other clients who are attempting to connect
            sendS.BeginAccept(new AsyncCallback(accept), null);
        }

        public class SocketPacket
        {
            public Socket m_currentSocket;
            public byte[] dataBuffer;

            // Constructor that takes one argument. 
            public SocketPacket(int size)
            {
                dataBuffer = new byte[size]; //12
            }
        }

        public void begin(Socket s)
        {
            AsyncCallback pfnWorkerCallBack = new AsyncCallback(serialPort1_DataReceived);
            SocketPacket theSocPkt = new SocketPacket(50);
            theSocPkt.m_currentSocket = s;
            s.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, pfnWorkerCallBack, theSocPkt);
        }

        // обработчик принятия данных по 1 порту
        private void serialPort1_DataReceived(IAsyncResult asyn)
        {
            SocketPacket socketData = (SocketPacket)asyn.AsyncState;
            int iRx = socketData.m_currentSocket.EndReceive(asyn);
            byte[] dataBytes = socketData.dataBuffer.ToArray();
            for (int i = dataBytes.Length - 1; i > 0; i--)
            {
                if (dataBytes[i] != 0)
                {
                    Array.Resize(ref dataBytes, i + 1);
                    break;
                }
            }
            /////////////////////////////////////////
            //byte[] dataBytes = new byte[port1.BytesToRead];
            //port1.Read(dataBytes, 0, port1.BytesToRead);

            Encoding enc = Encoding.GetEncoding(1251);
            String text = enc.GetString(dataBytes);

            // Анализируем данные, маркер или фрейм
            analyze(text);
            begin(socketData.m_currentSocket);
        }

        private void analyze(String package)
        {
            if (package.Length == 3)
            {
                Marker mrk = new Marker(package);
                printMessage("<marker> (prio: " + mrk.getPriority() + ")");
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

            // Если мы монитор
            if (isMonitor)
            {
                // Если это служебные маркер с наивысшим 7 приоритетом
                if (marker.getPriority() == 7)
                {
                    // Если хотим что-то передать и зарезервированный приоритет в маркере меньше нашего, перехватываем и резервируем этот маркер для себя
                    if (wantToSend && marker.getReservedPriority() < priority)
                    {
                        // установить свой приоритет
                        marker.setReservedPriority(priority);
                    }
                    // может вставить проверочку на getReservedPriority() > 0 /////////////////////////////////////////////////
                    if (marker.getReservedPriority() > 0)
                    {
                        requestedPrio = marker.getReservedPriority();
                        baseMarker = false;
                    }
                }
                else
                {
                    // Если маркер от какой-то машины, захватываем и отправляем сообщение
                    if (wantToSend && marker.getPriority() <= priority)
                    {
                        // захват маркера и отправка сообщения
                        markerReceived = marker;
                        //canSend = true;
                        Frame frame = new Frame(markerReceived, isMonitor, destTextBox.Text, name, sendTextBox.Text);
                        //writeToPort(port2, frame.ToString());
                        recieveS.Send(Encoding.GetEncoding(1251).GetBytes(frame.ToString()));
                        wantToSend = /*canSend =*/ false;
                        wantToSendLabel.Text = "";
                        sendButton.Enabled = true;
                    }
                    baseMarker = true;
                }
                markerSended = false;

                // Send marker
                sendMarkerButton.Enabled = true;
                //sendMarkerButton_Click(null, null);
                //sendMarker();
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
                    //writeToPort(port2, marker.ToString());
                    recieveS.Send(Encoding.GetEncoding(1251).GetBytes(marker.ToString()));
                }
                else
                {
                    if (wantToSend && marker.getPriority() <= priority)
                    {
                        // захват маркера и отправка сообщения
                        markerReceived = marker;
                        //canSend = true;
                        Frame frame = new Frame(markerReceived, isMonitor, destTextBox.Text, name, sendTextBox.Text);
                        //writeToPort(port2, frame.ToString());
                        recieveS.Send(Encoding.GetEncoding(1251).GetBytes(frame.ToString()));
                        wantToSend = /*canSend =*/ false;
                        wantToSendLabel.Text = "";
                        sendButton.Enabled = true;
                    }
                    else
                    {
                        // пересылка маркера дальше по кольцу 
                        //writeToPort(port2, package);
                        recieveS.Send(Encoding.GetEncoding(1251).GetBytes(package.ToString()));
                    }
                }
            }
        }

        private void analyzeFrame(String package)
        {
            Frame frame = new Frame(package);

            if (isMonitor && !frame.isSendedByMonitor())
            {
                //Если монитор кадр, содержащий бит монитора в 1, 
                //то монитор знает, что этот кадр уже однажды обошел кольцо 
                //и не был обработан станциями. Он удаляется из кольца. 
                setMonitor(false);
            }
            // Если это пакет к нам, принимаем данные и пересылаем дальше (чтобы дошло до отправителя)
            if (name.Equals(frame.getDestAddr()))
            {
                // вывести и переслать дальше по кольцу
                printMessage(frame.getData());
                //writeToPort(port2, package);
                recieveS.Send(Encoding.GetEncoding(1251).GetBytes(package.ToString()));
            }
            // Если мы отправляли и к нам опять пришло - становимся монитором
            if (name.Equals(frame.getSourceAddr()))
            {
                // стать монитором и удалить из кольца
                setMonitor(true);
            }
            else
            {
                // переслать дальше по кольцу
                //writeToPort(port2, package);
                recieveS.Send(Encoding.GetEncoding(1251).GetBytes(package.ToString()));
            }
        }

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

        public void sendMarker()
        {
            if (connected)
            {
                sendMarkerButton.Enabled = false;
                if (false) //!isMonitor || markerSended
                {
                    Thread.Sleep(1000);
                }
                else
                {
                    // Создаём маркер и отправляем
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
                    //writeToPort(port2, marker.ToString());
                    byte[] dat = Encoding.GetEncoding(1251).GetBytes(marker.ToString());
                    recieveS.Send(dat);
                }
            }
        }

        public void setMonitor(Boolean monitor)
        {
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
    }
}
