using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lemonReceiver.star_line_network_node;

namespace lemonReceiver.star_line_network_node
{
	public partial class nodeTableF : Form
	{
		nodeTable mainNT;
		Timer updataT;
		int nodeNum=0, onNodeNum=0;
		public nodeTableF(nodeTable nt)
		{
			mainNT = nt;
			InitializeComponent();
			updataT = new Timer();
			updataT.Interval = 500;
			updataT.Tick += new EventHandler(updataT_Tick);
			updataT.Start();
			mainT.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(mainT_NodeMouseDoubleClick);
			searchTB.TextChanged += new EventHandler(searchTB_TextChanged);
			sortCB.SelectedIndex = 1;
			sortCB.SelectedIndexChanged += new EventHandler(sortCB_SelectedIndexChanged);
		}

		void sortCB_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (sortCB.SelectedIndex)
			{
				case 1:
					break;
				default:
					break;
			}
		}

		void searchTB_TextChanged(object sender, EventArgs e)
		{
			searchTB.BackColor = Color.White;
		}

		void mainT_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			node n = (node)e.Node.Tag;
			n.showForm();
		}
		void updataT_Tick(object sender, EventArgs e)
		{
			mainT.EndUpdate();
			onNodeNum=0;
			bool searched = false;
			this.searchTB.BackColor = Color.LightPink;
			foreach (node n in mainNT.nodeDict.Values)
			{
				string s = n.ToString();
				if (mainT.Nodes.ContainsKey(s) == false)
				{
					mainT.Nodes.Add(s, "地址" + s + "开启");
					mainT.Nodes[s].Tag = n;
					mainT.Sort();
				}
				if (n.Available == true)
				{

					mainT.Nodes[s].BackColor = Color.LightGreen;
					mainT.Nodes[s].Text = "地址" + s + " 开启";
					onNodeNum++;
				}
				else
				{
					mainT.Nodes[s].BackColor = Color.LightPink;
					mainT.Nodes[s].Text = "地址" + s + " 关闭";
				}
				if (n.GetTHL == true)
				{
					if (mainT.Nodes[s].BackColor == Color.LightGreen)
					{
						mainT.Nodes[s].BackColor = Color.Gold;
					}
					mainT.Nodes[s].Text += "(温湿度光照)";
				}
				if (s == searchTB.Text.ToUpper())
				{
					searched = true;
					mainT.Nodes[s].BackColor = Color.DarkBlue;
					mainT.Nodes[s].ForeColor = Color.White;
				}
				else
				{
					mainT.Nodes[s].ForeColor = Color.Black;
				}
			}
			if(searched == true)
			{
					this.searchTB.BackColor = Color.LightGreen;
			}
			else
			{
					this.searchTB.BackColor = Color.LightPink;
			}
			nodeNum = mainNT.nodeDict.Values.Count;
			nodeNumL.Text = "注册节点数量: " + nodeNum.ToString();
			onNodNumL.Text = "开启节点数量: " + onNodeNum.ToString();
			mainT.Update();
		}
	}
}
