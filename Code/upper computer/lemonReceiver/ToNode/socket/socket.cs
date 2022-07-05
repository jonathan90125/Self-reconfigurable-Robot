using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thSensor.ToNode
{
	public class socket
	{
		public const byte TERMINATOR = 0xff;
        public const byte ESCAPE = 0xfe;
        public DataSR<byte[]> basr;
        public DataSR<sktPkg> spsr;


		private socketRecord sr;
		public socket()
		{
			sr = new socketRecord();
            basr = new DataSR<byte[]>(receiveFromCom);
			spsr = new DataSR<sktPkg>(sendSktToMe);
		}
		//发送支线
        object sendBuffer_lock = new object();
		byte[] sendBuffer = new byte[128];
		private void sendSktToMe(sktPkg pkg)
		{
			sr.addSktPkg(pkg);
            lock (sendBuffer_lock)
            {
                int point = 0;
                if (pkg.data.Length > 59)
                {
					throw new Exception("发送长度(" + pkg.data.Length + ")>59");
                }
                sendBuffer[point++] = ESCAPE;
				sendBuffer[point++] = ((byte)((pkg.data.Length)+4));
				sendBuffer[point++] = pkg.src_port;
				sendBuffer[point++] = pkg.dst_port;
				sendBuffer[point++] = support.Uint16LowByte(pkg.remote_addr);
				sendBuffer[point++] = support.Uint16HighByte(pkg.remote_addr);
				foreach (byte b in pkg.data)
                {
                    if (b >= ESCAPE)
                    {
                        sendBuffer[point++] = (ESCAPE);
                        sendBuffer[point++] = ((byte)(b - 2));
                    }
                    else
                    {
                        sendBuffer[point++] = (b);
                    }
                }
                sendBuffer[point++] = (TERMINATOR);
                byte[] sendb = new byte[point];
                for (int i = 0; i < point; i++)
                {
                    sendb[i] = sendBuffer[i];
                }
                basr.send(sendb);
            }
		}
		//接收支线
		private void receiveFromCom(byte[] data)
		{
			foreach (byte b in data)
			{
				receiveOneByte(b);
			}
		}
		private bool escaping = false;
		private void receiveOneByte(byte data)
		{
			if(data == TERMINATOR)
			{
				receiveTerm();
				escaping = false;
                return;
			}
			else if(data == ESCAPE)
			{
				escaping = true;
                return;
			}
			else
			{
				if (escaping == true)
				{
					escaping = false;
					if (data < 64)
					{
						receiveHead(data);
					}
					else
					{
						if ((data + 2) == ESCAPE)
						{
							receiveData(ESCAPE);
						}
                        else if ((data + 2) == TERMINATOR)
                        {
                            receiveData(TERMINATOR);
                        }
                        else
                        {
                            throw new Exception("在转义数据后面收到了" + data);
                        }
					}
				}
				else
				{
					receiveData(data);
				}
			}
		}
		private int length = 0;
		private int conter = 0;
		private byte[] receiveBuffer = null;
		private void receiveTerm()
		{
			if ((length == conter) && (length != 0) && (receiveBuffer != null))
            {
				sktPkg p0 = new sktPkg(receiveBuffer);
				spsr.send(p0);
				sr.addSktPkg(p0);
			}
            else
            {
                throw new Exception("收包被打断");
            }
			length = 0;
			conter = 0;
			receiveBuffer = null;
		}
		private void receiveData(byte d)
		{
            if ((receiveBuffer != null) && (conter < length))
            {
                receiveBuffer[conter] = d;
                conter++;
            }
            else
            {
                throw new Exception("收到无用的数据");
            }
		}
		private void receiveHead(byte d)
		{
			length = d;
			conter = 0;
			receiveBuffer = new byte[d];
            if(receiveBuffer == null)
            {
                throw new Exception("接收这么长的包失败:" + d);
            }

		}

	}
}
