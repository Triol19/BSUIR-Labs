using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;



using System.ComponentModel;
using System.Data;
using System.Drawing;



namespace lab2
{
    static class CRC
    {
        // Полином = 0x31 = (x^8 + x^5 + x^4 + 1) = 100110001 => CRC-8-Dallas/Maxim
        // Полином = 0xD5 = (x^8 + x^7 + x^6 + x^4 + x^2 + 1) = 100110001 => CRC-8
        public static byte getCRC8(byte[] data, byte polynomial = 0x31)
        {
            if (data == null || data.Length == 0)
                throw new Exception("No data for CRC8 function");

            byte crc = 0;

            foreach (byte b in data)
            {
                crc ^= b;
                for (int i = 0; i < 8; i++)
                    crc = (byte)((crc & 0x80) != 0 ? (crc << 1) ^ polynomial : crc << 1);
                    // 0x80 = 1000 0000; если старший бит == 1, тогда сдвиг на 1 влево + XOR, если 0, то просто сдвиг на 1 влево
                    //x<<1 == x*2
            }
            return crc;
        }

    }

    class Package
    {
        static public bool[] startFlag = new bool[] { false, true, true, true, true, true, true, false }; // 01111110(7Eh)
        static public bool[] stuffingFlag = new bool[] { false, true, true, true, true, true, true };     // 0111111
        static public bool insertBit = true;
        static public bool falseCRC = false;

        static public byte[] Packaging(byte[] data, int maxPacketLength, bool CRC) //разбивка на пакеты
        {
            List<byte> dataToSend = new List<byte>();
            int selectFalseCRCPacket=0;
            int counter = 0;
            if (CRC)
            {
                Random random = new Random();
                selectFalseCRCPacket = random.Next(0, data.Length / maxPacketLength); // creates a number between 0 and total count of packets
            }
            for (int i = 0; i < data.Length; i += maxPacketLength)
            {
                if (CRC && counter == selectFalseCRCPacket)
                    falseCRC = CRC;
                byte[] packet = MakePacket(data.Skip(i).Take(maxPacketLength).ToArray()); //сразу создаётся пакет из maxPacketLength элементов + 2*флаг
                dataToSend.AddRange(packet);
                counter++;
            }

            return dataToSend.ToArray();
        }


        static public byte[] MakePacket(byte[] data) // переделано для CRC
        {
            int index = 0; //index замещаемого бита для CRC
            //List<bool> bitData = Stuffing.BitStuffing(data, stuffingFlag, insertBit);
            ///////////////////////
            byte crc8 = CRC.getCRC8(data);
            List<byte> dataWithCrc = new List<byte>(data);
            dataWithCrc.Add(crc8);

            List<bool> bitData = Stuffing.BitStuffing(dataWithCrc.ToArray(), stuffingFlag, insertBit);
            ///////////////////////
            BitArray resultData = new BitArray(startFlag); // создаём массив из флагов старта
            resultData.Length += (bitData.Count + startFlag.Length);

            if (falseCRC)
            {
                Random rnd = new Random();
                index = rnd.Next(0, bitData.Count); // creates a number between 0 and bitData-1
            }

            for (int i = 0; i < bitData.Count; i++)
                if (falseCRC && index==i)
                {
                    resultData[i + startFlag.Length] = !bitData[i];
                    falseCRC = false;
                }
                else
                {
                    resultData[i + startFlag.Length] = bitData[i]; //замещаем элементы, только оставляем флаг в начале
                }

            for (int i = 0; i < startFlag.Length; i++)
                resultData[startFlag.Length + bitData.Count + i] = startFlag[i]; // ставим флаг в конце

            return BitOperations.BitArrayToByteArray(resultData);
        }

        static public byte[] Unpackaging(List<bool> data, int numberOfPacket) // переделано для CRC
        {
            /*BitArray bitData = new BitArray(data.Count);

            for (int i = 0; i < data.Count; i++)
                bitData[i] = data[i];


            return Stuffing.DeStuffing(bitData, stuffingFlag);*/

            byte[] packetData = Stuffing.DeStuffing(data, stuffingFlag);

            var crc = CRC.getCRC8(packetData);

            if (crc == 0)
            {
                AutoClosingMessageBox.Show("CRC in packet number " + numberOfPacket + "is OK!", "OK message", 1000);
                return packetData.Take(packetData.Length - Marshal.SizeOf(crc)).ToArray(); //Marshall ????
            }
            else
            {
                AutoClosingMessageBox.Show("CRC in packet number " + numberOfPacket +"is incorrect!", "ERROR message", 1000);
                return new byte[] { };
            }
        }
    }
    ///////// OPERATIONS WITH BITS
    static class BitOperations
    {

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }


        public static byte[] BitListToByteArray(List<bool> bits)
        {
            BitArray bitArray = new BitArray(bits.Count);
            for (int i = 0; i < bits.Count; i++)
                bitArray[i] = bits[i];

            byte[] ret = new byte[(bitArray.Length - 1) / 8 + 1];
            bitArray.CopyTo(ret, 0);
            return ret;
        }


        /*public static bool Contain(BitArray bits, BitArray mask)
        {
            if (mask.Length > bits.Length)
                return false;

            for (int i = 0; i <= bits.Length - mask.Length; i++)
            {
                for (int j = 0; j < mask.Length; j++)
                {
                    if (bits[i + j] != mask[j])
                        break;
                    else if (j == mask.Length - 1)
                        return true;
                }
            }
            return false;
        }*/


        public static bool test(bool[] mask, BitArray source, int pos) //true = пакет определён
        {
            if (pos < mask.Length - 1)
                return false;

            for (int i = mask.Length - 1; i >= 0; i--)
            {
                if (mask[i] != source[pos])
                    return false;
                pos--;
            }

            return true;
        }

        /*public static int getIndex(BitArray bits, BitArray mask)
        {
            if (mask.Length > bits.Length)
                return -1;

            for (int i = 0; i <= bits.Length - mask.Length; i++)
            {
                for (int j = 0; j < mask.Length; j++)
                {
                    if (bits[i + j] != mask[j])
                        break;
                    else if (j == mask.Length - 1)
                        return i;
                }
            }
            return -1;
        }

        public static int getIndexEnd(BitArray bits, BitArray mask)
        {
            if (mask.Length > bits.Length)
                return -1;

            for (int i = bits.Length - 1; i >= mask.Length - 1; i--)
            {
                for (int j = mask.Length - 1; j >= 0; j--)
                {
                    if (bits[i - j] != mask[j])
                        break;
                    else if (j == 0)
                        return i;
                }
            }
            return -1;
        }*/
    }
    ////////////////Stuffing/Destuffing
    static class Stuffing
    {
        static public int bitstuffingCount=0;

        private static bool test(bool[] mask, BitArray source, int pos) //проверка на необходимость вставки/удаления бита
        {
            int position = pos - mask.Length + 1;

            if (position < 0) return false;

            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] != source[position + i])
                    return false;
            }

            return true;

        }

        private static bool test(bool[] mask, List<bool> source, int pos) //добавлено для CRC
        {
            int position = pos - mask.Length + 1;

            if (position < 0) return false;

            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] != source[position + i])
                    return false;
            }

            return true;
        }

        public static List<bool> BitStuffing(byte[] source, bool[] mask, bool insertBit)
        {
            BitArray bitSource = new BitArray(source);

            List<bool> result = new List<bool>();

            int i = 0;
            while (i < bitSource.Length)
            {
                result.Add(bitSource[i]);
                if (test(mask, bitSource, i))
                {
                    result.Add(insertBit);// записываем бит (сам бит-стаффинг)
                    bitstuffingCount++;
                    for (int k = 0; k < mask.Length - 1; k++)
                    {
                        i++;
                        if (i >= bitSource.Length) //если добавление перед последним битом данных
                            break;

                        result.Add(bitSource[i]);
                    }
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return result;
        }


        public static byte[] DeStuffing(/*BitArray source,*/List<bool> source, bool[] mask) //переделано для CRC
        {
            //BitArray bitSource = new BitArray(source);

            List<bool> result = new List<bool>();

            int i = 0;
            while (i < source.Count)
            {
                result.Add(source[i]);
                if (test(mask, source, i))
                {
                    i++; //пропускаем этот бит, который был добавлен ранее
                    for (int k = 0; k < mask.Length - 1; k++)
                    {
                        i++;
                        if (i >= source.Count)
                            break;

                        result.Add(source[i]);
                    }
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return BitOperations.BitListToByteArray(result);
        }
    }
}
