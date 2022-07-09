using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lemonReceiver.star_line_network_node
{
	public class node
	{
		const int LOSEDELAY = 60;
		//关于节点的属性
		private UInt16 addr;
		public UInt16 Addr { get { return addr; } }
		private int second;
		public bool Available { get { return (second < LOSEDELAY); } }
		private bool getTHL = false;
		public bool GetTHL { get { return getTHL; } }
		//类内成员
		public node(UInt16 a)
		{
			addr = a;
			second = 0;
		}
		public void tick()
		{
			if (second < LOSEDELAY)
			{
				second++;
			}
		}
		public void active()
		{
			second = 0;
		}
		public override string ToString()
		{
			string rev;
			rev = support.ushorToString(this.Addr);
			return rev;
		}
		public string stateToString()
		{
			if (this.Available)
			{
				return "开启";
			}
			else
			{
				return "关闭";
			}
		}
		private oneNodeFormcs nodeF;
		public void showForm()
		{
			nodeF = new oneNodeFormcs(support.ushorToString(this.Addr), TStore, HStore, Lstore);
			nodeF.closeMe += new EventHandler(nodeF_closeMe);
			nodeF.Text = "节点"+support.ushorToString(this.Addr);
			nodeF.Show();
		}

		void nodeF_closeMe(object sender, EventArgs e)
		{
			if (nodeF != null)
			{
				nodeF.Close();
			} 
			nodeF = null;
		}
		private string TStore = " 无", HStore = " 无", Lstore = " 无";
		public void setTHL(string T, string H, string L)
		{
			getTHL = true;
			TStore = T;
			HStore = H;
			Lstore = L;
			if (nodeF != null)
			{
				nodeF.upData(T, H, L);
			}
		}
		static public bool isAPriorToB(node a, node b)
		{
			if (a.addr > b.addr)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
