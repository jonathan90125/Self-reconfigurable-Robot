using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lemonReceiver.ToNode
{
    class pkgSocket
    {
        public byte srouce_port;
        public byte destina_port;
        public UInt16 remote_addr;
        public byte[] data;
        public pkgSocket(Pkg1501 p)
        {
            if(p.Data.Length<4)
            {
                throw new Exception("包的长度不能小于4");
            }
            srouce_port = p.Data[0];
            destina_port = p.Data[1];
            remote_addr = support.byteToUint16(p.Data[2], p.Data[3]);
            data = new byte[p.Data.Length - 4];
            for (int i = 4; i < p.Data.Length; i++)
            {
                data[i - 4] = p.Data[i];
            }
        }
        public pkgSocket(byte s, byte d, ushort r)
        {
            srouce_port = s;
            destina_port = d;
            remote_addr = r;
        }
        public Pkg1501 toPkg1501()
        {
            Pkg1501 rev = new Pkg1501();
            Queue<byte> temp = new Queue<byte>();
            temp.Enqueue(0);
            temp.Enqueue(srouce_port);
            temp.Enqueue(destina_port);
            temp.Enqueue((byte)remote_addr);
            temp.Enqueue((byte)(remote_addr>>8));
            if(data ==null)
            {
                throw new Exception("不能将没有数据的包转换为1501");
            }
                foreach(byte b in data)
                {
                    temp.Enqueue(b);
                }
            byte[] reba = temp.ToArray();
            reba[0] = (byte)(reba.Length-1);
            rev.receiveData(reba);
            return rev;
        }
    }
}
