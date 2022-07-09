using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace thSensor.ToNode
{
    public partial class ComPortControl : UserControl
    {
        private SerialPort mainSP;
        private System.Windows.Forms.Timer mainT;
        public DataSR<byte[]> sr;
        public byte[] writeBuffer;
        public int writePoint;
        public event EventHandler ePortClose;
        public ComPortControl()
        {
            InitializeComponent();
            comSelectCB.Click += new EventHandler(comSelectCB_Click);
            comStateClose();
            sr = new DataSR<byte[]>(writeToCom);
            writePoint = 0;
            writeBuffer = new byte[4096];
        }
        private void comStateOpen()
        {
            comSelectCB.BackColor = Color.LightGreen;
        }
        private void comStateClose()
        {
            comSelectCB.BackColor = Color.LightPink;
        }
        void comSelectCB_Click(object sender, EventArgs e)
        {
            getUartTable();
        }
        private void mainCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            openPort();
        }
        //one port operate   
        private object locker = new object();

        private string[] comNumTable;
        private int testComNumConter;
        public bool getUartTable()
        {
            try
            {
                comSelectCB.Items.Clear();
                comNumTable =  System.IO.Ports.SerialPort.GetPortNames();
                if (comNumTable.Length != 0)
                {
                    foreach (string s in comNumTable)
                    {
                        comSelectCB.Items.Insert(comSelectCB.Items.Count, s);
                    }
                    testComNumConter = 0;
                    comSelectCB.Text = comNumTable[testComNumConter];
                    testComNumConter++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                CMDSpeed.Text = "串口表获取发生错误";
                return false;
            }
        }
        delegate bool nextComPortCB();
        public bool nextComPort()
        {
            if (testComNumConter < comNumTable.Length)
            {
                if (this.comSelectCB.InvokeRequired)
                {
                    nextComPortCB d = new nextComPortCB(nextComPort);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    comSelectCB.Text = comNumTable[testComNumConter];
                    testComNumConter++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void openPort()
        {
			if (mainSP != null)
			{
				try { closePort(); }
				catch { }
			}
            mainSP = new SerialPort(comSelectCB.Text, 115200);
            try
            {
                mainSP.Open();
            }
            catch (Exception ex)
            {
                CMDSpeed.Text = "打开串口失败:" + ex.Message; 
                comStateClose();
            }
            if (mainSP.IsOpen == true)
            {
                comStateOpen();
                mainT = new System.Windows.Forms.Timer();
                mainT.Interval = 100;
                mainT.Tick += new EventHandler(loopReadFromCom);
                mainT.Start();
            }
            else
            {
                comStateClose();
            }
        }
        int  uartBuzzy = 0;
        int recvNum = 0, sendNum = 0;
        int updataNumpear10 = 1;
        void loopReadFromCom(object sender, EventArgs e)
        {
            if (updataNumpear10 == 10)
            {
                updataNumpear10 = 1;
                CMDSpeed.Text = "收发速度 " + recvNum + "B/" + sendNum + "B";
                double temp;
                temp = (100 * recvNum / 11520.0);
                if (temp >= 100) {temp = 100;}
                recvPB.Value = (int)temp;
                recvNum = 0; 
                temp = (100 * sendNum / 11520.0);
                if (temp >= 100) { temp = 100; }
                sendPB.Value = (int)temp;
                sendNum = 0;

            }
            else
            {
                updataNumpear10++;
            }

            if (uartBuzzy == 0)
            {
                uartBuzzy++;
                try
                {
                    lock (locker)
                    {
                        int dataLength = mainSP.BytesToRead;
                        if (dataLength != 0)
                        {
                            byte[] data = new byte[dataLength];
                            mainSP.Read(data, 0, dataLength);
                            sr.send(data);
                            recvNum += dataLength;
                          //  Program.postInfo(System.DateTime.Now.ToLongTimeString() + "收到"+support.ByteArrayToString(data) + "\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    CMDSpeed.Text = "读取异常重启:" + ex.Message;
                    closePort();
                    openPort();
                }
                try
                {
                    lock (locker)
                    {
                        if (writePoint != 0)
                        {
                            mainSP.Write(writeBuffer, 0, writePoint);
                            sendNum += writePoint;
                            writePoint = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CMDSpeed.Text = ("写入异常重启:" + ex.Message);
                    closePort();
                    openPort();
                }
                uartBuzzy=0;
            }
            else
            {
                CMDSpeed.Text = ("写入异常重启:");
                closePort();
                openPort();
            }
        }
        public delegate void dWriteToCom(byte[] data);
        public void writeToCom(byte[] data)
        {
            if (mainSP.IsOpen == true)
            {
                lock (locker)
                {
                    foreach(byte b in data)
                    {
                        writeBuffer[writePoint] = b;
                        writePoint++;
                    }
                }
            }
        }
        private bool closePort()
		{
            lock (locker)
            {
                writePoint = 0;
            }
            mainT.Stop();
            if (mainSP != null)
            {
                while (mainSP.IsOpen != false)
                {
                    int times = 0;
                    try
                    {
                        mainSP.Close();
                    }
                    catch
                    {
                        times++;
                        if (times >= 100)
                        {
                            CMDSpeed.Text = ("串口关不上了");
                        }
                    }
                }
                mainSP.Dispose();
            }
            if (ePortClose != null)
            {
                ePortClose(this, null);
            }
            return false;
        }

		private void ComPortControl_Load(object sender, EventArgs e)
		{

		}
    }
}
