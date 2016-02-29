using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    class Package
    {
        static public bool[] startFlag = new bool[] { false, true, true, true, true, true, true, false }; // 01111110(7Eh)
        static public bool[] stuffingFlag = new bool[] { false, true, true, true, true, true, true };     // 0111111
        static public bool insertBit = true;

        static public byte[] Packaging(byte[] data, int maxPacketLength) //разбивка на пакеты
        {
            List<byte> dataToSend = new List<byte>();
            for (int i = 0; i < data.Length; i += maxPacketLength)
            {
                byte[] packet = MakePacket(data.Skip(i).Take(maxPacketLength).ToArray()); //сразу создаётся пакет из maxPacketLength элементов + 2*флаг
                dataToSend.AddRange(packet);
            }

            return dataToSend.ToArray();
        }


        static public byte[] MakePacket(byte[] data)
        {
            List<bool> bitData = Stuffing.BitStuffing(data, stuffingFlag, insertBit);

            BitArray resultData = new BitArray(startFlag); // создаём массив из флагов старта
            resultData.Length += (bitData.Count + startFlag.Length);

            for (int i = 0; i < bitData.Count; i++)
                resultData[i + startFlag.Length] = bitData[i]; //замещаем элементы, только оставляем флаг в начале

            for (int i = 0; i < startFlag.Length; i++)
                resultData[startFlag.Length + bitData.Count + i] = startFlag[i]; // ставим флаг в конце

            return BitOperations.BitArrayToByteArray(resultData);
        }

        static public byte[] Unpackaging(List<bool> data)
        {
            BitArray bitData = new BitArray(data.Count);

            for (int i = 0; i < data.Count; i++)
                bitData[i] = data[i];


            return Stuffing.DeStuffing(bitData, stuffingFlag);
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


        public static byte[] DeStuffing(BitArray source, bool[] mask)
        {
            BitArray bitSource = new BitArray(source);

            List<bool> result = new List<bool>();

            int i = 0;
            while (i < bitSource.Length)
            {
                result.Add(bitSource[i]);
                if (test(mask, bitSource, i))
                {
                    i++; //пропускаем этот бит, который был добавлен ранее
                    for (int k = 0; k < mask.Length - 1; k++)
                    {
                        i++;
                        if (i >= bitSource.Length)
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
            return BitOperations.BitListToByteArray(result);
        }

    }
}
