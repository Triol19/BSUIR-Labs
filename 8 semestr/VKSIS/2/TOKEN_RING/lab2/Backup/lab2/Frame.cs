using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    class Frame
    {
        public const Byte START_FLAG = 0x7E; //~ 
        public const Byte END_FLAG = 0x7F; //⌂

        private Byte ac;
        private Byte fc;
        private String da;
        private String sa;
        private String data;
        private String crc;

        public Frame(Marker marker, Boolean isMonitor, String destAddr, String srcAddr, String data)
        {
            ac = (byte)(marker.getAc() | 0x10);
            if (!isMonitor)
            {
                ac = (byte)(ac & 0xF7);
            }
            fc = 0x00;
            da = destAddr;
            sa = srcAddr;
            this.data = data;
            crc = "0000";
        }

        public Frame(String package)
        {
            String str = package.Substring(1, 1);
            Encoding enc = Encoding.GetEncoding(1251);
            ac = enc.GetBytes(str)[0];
            da = package.Substring(3, 6);
            sa = package.Substring(9, 6);
            data = package.Substring(15, package.Length - 20); 
        }

        public override string ToString()
        {
            Encoding enc = Encoding.GetEncoding(1251);
            String prefix = enc.GetString(new Byte[] { START_FLAG, ac, fc });
            String postfix = enc.GetString(new Byte[] { END_FLAG });
            return prefix + da + sa + data + crc + postfix;
        }

        public String getData()
        {
            return data;
        }

        public String getSourceAddr()
        {
            return sa;
        }

        public String getDestAddr()
        {
            return da;
        }

        public Boolean isSendedByMonitor()
        {
            if ((ac & 0x08) == 0x08)
            {
                return true;
            }
            return false;
        }
    }
}
