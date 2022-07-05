using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lemonReceiver.star_line_network_node
{
	public class nodeTable
	{
		public Dictionary<UInt16, node> nodeDict;
		System.Windows.Forms.Timer t;
		public nodeTable()
		{
			nodeDict = new Dictionary<UInt16, node>();
			t = new System.Windows.Forms.Timer();
			t.Interval = 1000;
			t.Tick += new EventHandler(t_Tick);
			t.Start();


			nodeTableF mainNTF;
			mainNTF = new nodeTableF(this);
			mainNTF.Show();
		}
        void t_Tick(object sender, EventArgs e)
		{
			foreach (node n in nodeDict.Values)
			{
				n.tick();
			}
		}
		public void nodeReceive(UInt16 addr)
		{
			if (nodeDict.ContainsKey(addr))
			{
				nodeDict[addr].active();
			}
			else
			{
				node n = new node(addr);
				nodeDict.Add(addr, n);
			}
		}

		public void receiveTHL(UInt16 addr, string T, string H, string L)
		{

			if (nodeDict.ContainsKey(addr) == false)
			{
				node n = new node(addr);
				nodeDict.Add(addr, n);
			}
			nodeDict[addr].active();
			nodeDict[addr].setTHL(T, H, L);

		}


	}
}
