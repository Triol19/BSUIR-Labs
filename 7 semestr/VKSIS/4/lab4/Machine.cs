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


namespace lab4
{
    public delegate void OnForwardingHandler(object sender, string info);


    class Machine
    {
        private ComPort com1;
        private ComPort com2;

        bool enabled;

        private int dataSizeInPacket;

        private byte machineAddress;
        private bool falseCRC;

        public event OnRecievedHandler OnReceived;
        public event OnForwardingHandler OnForwarding;

        public Machine(string com1_name, string com2_name, int dataSizeInPacket, byte address, int speed, bool enabled, bool falseCRC)
        {
            com1 = new ComPort(com1_name, speed);
            com2 = new ComPort(com2_name, speed);

            this.enabled = enabled;

            this.machineAddress = address;
            this.dataSizeInPacket = dataSizeInPacket;
            this.falseCRC = falseCRC;

            com1.OnReceived += new OnRecievedHandler(receivedMessage);
            com2.OnReceived += new OnRecievedHandler(receivedMessage);
        }


        public void sendMessage(byte[] message, byte dest)
        {
            int selectFalseCRCPacket=99;
            List<byte> dataToSend = new List<byte>();

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
                    dataToSend.AddRange(LinkLayer.MakePacket(packet, true));
                }
                else dataToSend.AddRange(LinkLayer.MakePacket(packet));                
            }
            com2.serialPort_SendData(dataToSend.ToArray());
        }

        public void receivedMessage(object sender, OnRecievedEventArgs e)
        {
            byte[] packet = e.Data;

            if (packet[0] == machineAddress && enabled)
            {
                byte[] message = new byte[packet.Length - 2];
                Array.Copy(packet, 2, message, 0, packet.Length - 2);  // что и с какого места, куда и в какое место, сколько

                OnRecievedEventArgs arg = new OnRecievedEventArgs(message);
                OnReceived(sender, arg);
                /////////////
                AutoClosingMessageBox.Show("Notice hase been sended to " + packet[1], this.machineAddress.ToString(), 1000);
                packet[0] = Convert.ToByte('D');
                com2.serialPort_SendData(LinkLayer.MakePacket(packet));
            }
            else if (packet[1] == machineAddress && packet[0] == 'D')
            {
                OnForwarding(sender, "Packet was sucessfully send!");
            }
            else if(packet[1] == machineAddress)
            {
                OnForwarding(sender, "Packet from" + packet[1] + " to " + packet[0] + " has not been received!");
            }
            else
            {
                com2.serialPort_SendData(LinkLayer.MakePacket(packet));
                if (packet[0] != 'D')
                {
                    OnForwarding(sender, "Packet from " + packet[1] + " to " + packet[0] + " redirected");
                }
                else
                {
                    OnForwarding(sender, "Notice was redirected to " + packet[1]);
                }
            }
        }

        public void setEnabled(bool enabled)
        {
            this.enabled = enabled;
        }

        public void close()
        {
            if(com1 != null && com2 != null && com1.isConnected())
                com1.close();
                com2.close();
        }
    }
}
