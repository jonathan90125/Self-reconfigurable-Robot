using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lemonReceiver.ToNode
{
    class nodeSocketPort
    {
        private nodeSocket srouce;
        private byte portnum;

        public nodeSocketPort(nodeSocket s, byte num)
        {
            srouce = s;
            portnum = num;
            srouce.register(num,this);
        }
        public void sendData(byte[] data, UInt16 remote_addr, byte des_port)
        {
            pkgSocket p = new pkgSocket(portnum, des_port, remote_addr);
            srouce.sendToFromSla1501(p);
        }

        public virtual void recieveData(pkgSocket p)
        {
            throw new Exception("必须重写这个类的receiveData函数以接受收到包事件");
        }
    }
}
