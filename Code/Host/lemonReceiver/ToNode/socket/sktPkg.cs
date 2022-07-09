using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thSensor.ToNode
{
    public class sktPkg
    {
        DateTime time;
        bool isPkgOut;
		public DateTime Time { get { return time; } }
		public bool IsPkgOut { get { return isPkgOut; } }
		public byte src_port;
		public byte dst_port;
		public UInt16 remote_addr;
		public byte[] data;
		public delegate void dTransSktPkg(sktPkg pkg);
        public sktPkg(byte[] d, byte sp, byte dp, UInt16 addr)
        {
            time = DateTime.Now;
            isPkgOut = true;
            data = d;
            src_port = sp;
            dst_port = dp;
            remote_addr = addr;
        }
        public sktPkg(byte[] d)
        {
			if (d.Length <= 4)
            {
                remote_addr = 0xffff;
                data = null;
                src_port = 0xff;
                dst_port = 0xff;
            }
            else
            {
                time = DateTime.Now;
                isPkgOut = false;
                data = new byte[d.Length - 4];
                Array.Copy(d, 4, data, 0, data.Length);
                src_port = d[0];
                dst_port = d[1];
                remote_addr = support.byteToUint16(d[2],d[3]);
            }
        }
        public string ToCsv()
        {
            string st;
            st = Time.ToString("HH:mm:ss.ff") + ",";

            if (isPkgOut)
            {
                st += "发出" + ",";
            }
            else
            {
                st += "收到" + ",";
            }
            st += "0x" + support.ByteToString(src_port) + ",";
            st += "0x" + support.ByteToString(dst_port) + ",";
            st += "0x" + support.ushorToString(remote_addr) + ",";
            st += data.Length + ",";
            st += "# "+support.ByteArrayToString(data);
            return st;
        }

    }
}
