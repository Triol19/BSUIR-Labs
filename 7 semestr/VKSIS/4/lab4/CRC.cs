using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    static class CRC
    {
        // Полином = 0x31 = (x^8 + x^5 + x^4 + 1) = 100110001 => CRC-8-Dallas/Maxim
        // Полином = 0xD5 = (x^8 + x^7 + x^6 + x^4 + x^2 + 1) = 100110001 => CRC-8
        public static byte getCRC8(IEnumerable<byte> data, byte polynomial = 0x31)
        {
            if (data == null || data.Count() == 0)
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
}
