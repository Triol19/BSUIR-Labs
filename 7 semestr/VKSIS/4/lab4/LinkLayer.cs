using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;

namespace lab4
{
    class LinkLayer
    {
        static public bool[] startFlag = new bool[] { false, true, true, true, true, true, true, false }; // 01111110
        static public bool[] stuffingFlag = new bool[] { false, true, true, true, true, true, true };     // 0111111
        static public bool insertBit = true;

        //-----------------------------------------------------------------//

        static public byte[] MakePacket(byte[] data, bool falseCRC = false)  // разбивка на пакеты вида флаг-кому-от кого-данные-CRC-флаг
        {            
            List<byte> packetData = new List<byte>(data);
            byte crc8 = CRC.getCRC8(packetData);
            packetData.Add(crc8);

            int index = 99;

            if (falseCRC)
            {
                Random random = new Random();
                index = random.Next(0, data.Length); // creates a number between 0 and total count of packets
            }

            List<bool> bitData = Stuffing.BitStuffing(packetData.ToArray(), stuffingFlag, insertBit);

            BitArray resultData = new BitArray(startFlag); 
            resultData.Length += (bitData.Count + startFlag.Length);

            for (int i = 0; i < bitData.Count; i++)
            {
                if (i == index && falseCRC)
                {
                    resultData[i + startFlag.Length] = !bitData[i];
                }
                else
                {
                    resultData[i + startFlag.Length] = bitData[i];
                }
            }

            for (int i = 0; i < startFlag.Length; i++)            
                resultData[startFlag.Length + bitData.Count + i] = startFlag[i];            

            return BitOperations.BitArrayToByteArray(resultData);
        }

        static public byte[] Unpackaging(List<bool> data)
        {            
            byte[] packetData = Stuffing.DeStuffing(data, stuffingFlag);

            var crc = CRC.getCRC8(packetData);
            if (crc == 0)
                return packetData.Take(packetData.Length - Marshal.SizeOf(crc)).ToArray();
            else
            {
                AutoClosingMessageBox.Show("CRC in packet is incorrect!", "ERROR message", 2000);
                //return null;
                return new byte[] { };
            }
        } 
    }
}
