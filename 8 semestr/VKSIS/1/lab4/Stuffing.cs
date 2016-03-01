using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    static class Stuffing
    {
        private static bool test(bool[] mask, List<bool> source, int pos)  // проверка на необходимость вставки/удаления бита
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

        private static bool test(bool[] mask, BitArray source, int pos)  // проверка на необходимость вставки/удаления бита
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
                    result.Add(insertBit);  // записываем бит (сам бит-стаффинг)
             
                    for (int k = 0; k < mask.Length - 1; k++)
                    {
                        i++;
                        if (i >= bitSource.Length)  // если добавление перед последним битом данных
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


        public static byte[] DeStuffing(List<bool> source, bool[] mask)
        {
            List<bool> result = new List<bool>();

            int i = 0;
            while (i < source.Count)
            {
                result.Add(source[i]);
                if (test(mask, source, i))
                {
                    i++;
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
