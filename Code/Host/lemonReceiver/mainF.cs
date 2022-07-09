using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using thSensor.ToNode;

namespace thSensor
{
    public partial class mainF : Form
    {
        public mainF()
        {
            InitializeComponent(); uartInit(); 
        }
        DataSR<sktPkg> sktsr;//包收发器
        socket mainSKT = new socket();//这里的socket是指无线传感网的Socket,而不是以太网.
        public void uartInit()
        {
            sktsr = new DataSR<sktPkg>(receiveSktPkg);//构造函数指定sktsr收到包的处理函数
            DataSR<byte[]>.linkBasr(mainCP.sr,mainSKT.basr);//将串口连接到包处理器上
            DataSR<sktPkg>.linkBasr(mainSKT.spsr, sktsr);//将包处理器连接到sktsr上
        }
        private void receiveSktPkg(sktPkg pkg)
        {
            DataGridViewRow aim_row = null;
            foreach (DataGridViewRow dgvr in mainDGV.Rows)
            {
                if ((UInt16)dgvr.HeaderCell.Tag == pkg.remote_addr)
                {
                    aim_row = dgvr;
                }
            }
            if (aim_row == null)
            {
                int rn = mainDGV.Rows.Add(new object[] { " ", "未知", "开/关", "开/关","开/关", "开/关" });
                aim_row = mainDGV.Rows[rn];
                aim_row.HeaderCell.Tag = pkg.remote_addr;
                aim_row.HeaderCell.Value = support.ushorToString(pkg.remote_addr);

            }
            switch (pkg.dst_port)
            {
         
                case 0xa1:
                    if (pkg.data[0] == 127)
                    {
                        aim_row.Cells["temperature"].Value = "未获得";
                    }
                    aim_row.Cells["humidity"].Value = "" + pkg.data[0] + "s";
                    break;
            }
        }

        private void mainDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            switch (e.ColumnIndex)
            {
                case 2:
                    ushort addr = (ushort)(mainDGV.Rows[e.RowIndex].HeaderCell.Tag);
                    sktsr.send(new sktPkg(new byte[]{01},0x80,0xa0,addr));
                    break;

                case 3:
                    ushort addr1 = (ushort)(mainDGV.Rows[e.RowIndex].HeaderCell.Tag);
                    sktsr.send(new sktPkg(new byte[] {01}, 0x80, 0xb0, addr1));
                    break;

                case 4:
                    ushort addr2 = (ushort)(mainDGV.Rows[e.RowIndex].HeaderCell.Tag);
                    sktsr.send(new sktPkg(new byte[] {01}, 0x80, 0xc0, addr2));
                    break;

                case 5:
                    ushort addr3 = (ushort)(mainDGV.Rows[e.RowIndex].HeaderCell.Tag);
                    sktsr.send(new sktPkg(new byte[] { 01 }, 0x80, 0xd0, addr3));
                    break;
            }

        }

        private void MainCP_Load(object sender, EventArgs e)
        {

        }

        private void StatusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
