using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Net;

using System.Collections;
using System.Runtime.InteropServices;


namespace lab4
{
    public delegate void OnForwardingHandler(object sender, string info);


    class Machine
    {
        /// <summary>
        /// ////////////////////
        /// </summary>
        private ComPort com1;
        private ComPort com2;

        bool enabled, router;

        private int dataSizeInPacket;

        private byte machineAddress;
        private bool falseCRC;

        public event OnRecievedHandler OnReceived;
        public event OnForwardingHandler OnForwarding;
        public Socket recieveS;
        public Socket sendS;
        public int portTo, portFrom;
        TextBox tData, tInfo;
        public string ipFrom, ipTo;
        public byte[] prevByte = { 0xFF };


        public Machine(string com1_name, string com2_name, int dataSizeInPacket, byte address, int speed, bool enabled, bool falseCRC, int portFrom, int portTo, string ipFrom, string ipTo, TextBox tData, TextBox tInfo, bool isRouter)
        {
            //com1 = new ComPort(com1_name, speed);
            //com2 = new ComPort(com2_name, speed);
            this.sendS = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.recieveS = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.portFrom = portFrom;
            this.portTo = portTo;
            this.ipFrom = ipFrom;
            this.ipTo = ipTo;

            this.tData = tData;
            this.tInfo = tInfo;

            this.enabled = enabled;
            this.router = isRouter;

            this.machineAddress = address;
            this.dataSizeInPacket = dataSizeInPacket;
            this.falseCRC = falseCRC;


            ///////////////////////////////////////////
            IPAddress ipAddressFrom = IPAddress.Parse(ipFrom);
            int iPortNo = System.Convert.ToInt32(portFrom);
            IPEndPoint ipEnd = new IPEndPoint(ipAddressFrom, iPortNo);

            this.sendS.Bind(ipEnd);
            this.sendS.Listen(1);
            sendS.BeginAccept(new AsyncCallback(accept), null);

            ////////////////////////////////////

            //com1.OnReceived += new OnRecievedHandler(receivedMessage);
            //com2.OnReceived += new OnRecievedHandler(receivedMessage);
        }


        public void sendMessage(byte[] message, byte dest)
        {
            int selectFalseCRCPacket=99;
            List<byte> dataToSend = new List<byte>();

            //IPEndPoint ip = new IPEndPoint(IPAddress.Parse(this.ipTo), System.Convert.ToInt32(this.portTo));
            //this.recieveS.Connect(ip);

            if (this.falseCRC)
            {
                Random random = new Random();
                selectFalseCRCPacket = random.Next(0, message.Length / dataSizeInPacket); // creates a number between 0 and total count of packets
            }

            for (int i = 0; i < message.Length; i += dataSizeInPacket)
            {
                byte[] packetData = message.Skip(i).Take(dataSizeInPacket).ToArray();

                byte[] packet = new byte[packetData.Length + 2];
                packet[0] = dest;
                packet[1] = machineAddress;
                Array.Copy(packetData, 0, packet, 2, packetData.Length); // что и с какого места, куда и в какое место, сколько

                if (i == selectFalseCRCPacket && this.falseCRC)
                {
                    this.recieveS.Send(LinkLayer.MakePacket(packet, true)); //dataToSend.AddRange(LinkLayer.MakePacket(packet, true));
                }
                else this.recieveS.Send(LinkLayer.MakePacket(packet));//dataToSend.AddRange(LinkLayer.MakePacket(packet));                
            }
            //com2.serialPort_SendData(dataToSend.ToArray());
        }

        public void accept(IAsyncResult asyn)
        {
            Socket sock = this.sendS.EndAccept(asyn);
            // Let the worker Socket do the further processing for the 
            // just connected client
            begin(sock);

            // Since the main Socket is now free, it can go back and wait for
            // other clients who are attempting to connect
            this.sendS.BeginAccept(new AsyncCallback(accept), null);
        }
        public class SocketPacket
        {
            public Socket m_currentSocket;
            public byte[] dataBuffer;

            // Constructor that takes one argument. 
            public SocketPacket(int size)
            {
                dataBuffer = new byte[size+5]; //12
            }
        }
        public void begin(Socket s)
        {
            AsyncCallback pfnWorkerCallBack = new AsyncCallback(receivedMessage);
            SocketPacket theSocPkt = new SocketPacket (this.dataSizeInPacket);
            theSocPkt.m_currentSocket = s;
            s.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, pfnWorkerCallBack, theSocPkt);
        }
        public void receivedMessage(IAsyncResult asyn)
        {
            SocketPacket socketData = (SocketPacket)asyn.AsyncState;
            int iRx = socketData.m_currentSocket.EndReceive(asyn);

            byte[] packetData = {};
            ///////////////////////////////////////////////////////////////////

            bool isPacket = false;
            int flagCount = 0;
            List<bool> receiveData = new List<bool>();

            //byte[] data;
            //data[0] = prevByte;

            //data.InsertRange(1, b2);
            byte[] data = prevByte.Concat(socketData.dataBuffer).ToArray();
            for (int z = data.Length-1; ; z--)
            {
                if (data[z] == 0)
                {
                    Array.Resize<byte>(ref data, data.Length - 1);
                }
                else break;
            }
            //byte[] data = socketData.dataBuffer;
            //data[0] = prevByte;
            //port.Read(data, 1, data.Length - 1);

            BitArray source = new BitArray(data);

            int i = LinkLayer.startFlag.Length;
            while (i < source.Length)
            {
                if (!isPacket) // Поиск начала пакета
                {
                    while (i < source.Length)
                    {
                        if (BitOperations.test(LinkLayer.startFlag, source, i))
                        {
                            isPacket = true;
                            i++;
                            flagCount = 0;

                            break;
                        }
                        i++;
                    }
                }
                else // Поиск конца пакета
                {
                    while (i < source.Length)
                    {
                        if (flagCount < LinkLayer.startFlag.Length)
                        {
                            receiveData.Add(source[i]);
                            i++;

                            flagCount++;
                        }
                        else
                        {
                            if (BitOperations.test(LinkLayer.startFlag, source, i))
                            {
                                isPacket = false;
                                i++;

                                receiveData.RemoveRange(receiveData.Count - LinkLayer.startFlag.Length + 1, LinkLayer.startFlag.Length - 1);  // удаляем ране записанный (ошибочно?) флаг в интервале

                                packetData = LinkLayer.Unpackaging(receiveData, this.router);
                                if (packetData.Length != 0)
                                {
                                    //OnRecievedEventArgs arg = new OnRecievedEventArgs(packetData);
                                    //OnReceived(this, arg);
                                }
                                receiveData.Clear();
                                break;
                            }
                            else
                            {
                                receiveData.Add(source[i]);
                                i++;
                            }
                        }
                    }
                }
            }
            prevByte[0] = data[data.Length-2];



















            ////////////////////////////////////////////////////////////////////////


            byte[] packet = packetData;

            if (packet.Length == 0)
            {
                string crcEr = "Break transmit. CRC error!";
                if (tInfo.InvokeRequired)
                    tInfo.Invoke(new Action<string>((s) => tInfo.AppendText(s)), crcEr);
                else tInfo.AppendText(crcEr);
            }
            else if(packet[0] == machineAddress && enabled)
            {
                byte[] message = new byte[packet.Length - 2];
                Array.Copy(packet, 2, message, 0, packet.Length - 2);  // что и с какого места, куда и в какое место, сколько
                //OnRecievedEventArgs arg = new OnRecievedEventArgs(message);
                //OnReceived(sender, arg);
                /////////////
                Encoding enc = Encoding.GetEncoding(1251);
                String mes = enc.GetString(message);

                if (tData.InvokeRequired)
                    tData.Invoke(new Action<string>((s) => tData.AppendText(s)), mes);
                else tData.AppendText(mes);

                AutoClosingMessageBox.Show("Notice hase been sended to " + packet[1], this.machineAddress.ToString(), 1000);
                packet[0] = Convert.ToByte('D');
                this.recieveS.Send(LinkLayer.MakePacket(packet));
                //com2.serialPort_SendData(LinkLayer.MakePacket(packet));
            }
            else if (packet[1] == machineAddress && packet[0] == 'D')
            {
                //OnForwarding(sender, "Packet was sucessfully send!");
                string suc = "Packet was sucessfully send!";
                if (tInfo.InvokeRequired)
                    tInfo.Invoke(new Action<string>((s) => tInfo.AppendText(s)), suc);
                else tInfo.AppendText(suc);
            }
            else if(packet[1] == machineAddress)
            {
                //OnForwarding(sender, "Packet from" + packet[1] + " to " + packet[0] + " has not been received!");
                string hasnot = "Packet from" + packet[1] + " to " + packet[0] + " has not been received!";
                if (tInfo.InvokeRequired)
                    tInfo.Invoke(new Action<string>((s) => tInfo.AppendText(s)), hasnot);
                else tInfo.AppendText(hasnot);
            }
            else
            {
                if (packet[0] != 'D')
                {
                    string redir = "Packet from " + packet[1] + " to " + packet[0] + " redirected";
                    //OnForwarding(sender, "Packet from " + packet[1] + " to " + packet[0] + " redirected");
                    if (tInfo.InvokeRequired)
                        tInfo.Invoke(new Action<string>((s) => tInfo.AppendText(s)), redir);
                    else tInfo.AppendText(redir);
                }
                else
                {
                    string notice = "Notice was redirected to " + packet[1];
                    //OnForwarding(sender, "Notice was redirected to " + packet[1]);
                    if (tInfo.InvokeRequired)
                        tInfo.Invoke(new Action<string>((s) => tInfo.AppendText(s)), notice);
                    else tInfo.AppendText(notice);
                }
                this.recieveS.Send(LinkLayer.MakePacket(packet));
            }
            begin(socketData.m_currentSocket);
        }

        public void setEnabled(bool enabled)
        {
            this.enabled = enabled;
        }

        public void close()
        {
            //if(com1 != null && com2 != null && com1.isConnected())
                //com1.close();
                //com2.close();
        }
    }
}
