using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lemonReceiver.ToNode
{
    class nodeSocket
    {
        public event Pkg1501.eTransfer socketSendTo1501;
        public Dictionary<byte, nodeSocketPort> table;
        public nodeSocket()
        {
            table = new Dictionary<byte, nodeSocketPort>();
        }

        public bool register(byte num,nodeSocketPort port)
        {
            if (table.ContainsKey(num))
            {
                return false;
            }
            else
            {
                table.Add(num, port);
                return true;
            }
        }
        public void receiveFromSla1501(Pkg1501 p)
        {
            pkgSocket np = new pkgSocket(p);
            if (table.ContainsKey(np.destina_port))
            {
                table[np.destina_port].recieveData(np);
            }
        }
        public void sendToFromSla1501(pkgSocket pskt)
        {
            Pkg1501 p1501 = pskt.toPkg1501();
            if (socketSendTo1501 != null)
            {
                socketSendTo1501.Invoke(p1501);
            }
        }
    }
}
