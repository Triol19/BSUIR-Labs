using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    class Marker
    {
        public const Byte START_FLAG = 0x7E; //~ 
        public const Byte END_FLAG = 0x7F; //⌂

        private Byte ac;

        public Marker(Int32 prio, Boolean type, Boolean monitor)
        {
            ac = 0x00;
            ac = (byte)(ac | (prio << 5));
            ac = (byte)(ac | ((type == true ? 1 : 0) << 4));
            ac = (byte)(ac | ((monitor == true ? 1 : 0) << 3));
        }

        public Marker(String package)
        {
            if (package.Length == 3)
            {
                Encoding enc = Encoding.GetEncoding(1251);
                Byte[] array = enc.GetBytes(package);
                ac = array[1];
            }
        }

        public static Marker getBaseMarker()
        {
            return new Marker(7, false, true);
        }

        public override string ToString()
        {
            Encoding enc = Encoding.GetEncoding(1251);
            return enc.GetString(new Byte[] { START_FLAG, ac, END_FLAG });
        }

        public Boolean isSendedByMonitor()
        {
            if ((ac & 0x08) == 0x08)
            {
                return true;
            }
            return false;
        }

        public Int32 getPriority()
        {
            return (Int32)((ac & 0xE0) >> 5);
        }

        public Int32 getReservedPriority()
        {
            return (Int32)(ac & 0x07);
        }

        public void setReservedPriority(Int32 prio)
        {
            ac = (byte)(ac & 0xF8);
            ac = (byte)(ac | prio);
        }

        public byte getAc()
        {
            return ac;
        }
    }
}
