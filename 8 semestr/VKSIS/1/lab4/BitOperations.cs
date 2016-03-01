using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
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

        public static bool test(bool[] mask, BitArray source, int pos)  // true = пакет определён
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
    }
}
