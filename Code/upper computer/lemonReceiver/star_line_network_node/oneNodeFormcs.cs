using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lemonReceiver.star_line_network_node
{
	public partial class oneNodeFormcs : Form
	{
		public Timer tmain;		
		public oneNodeFormcs(string a)
		{
			InitializeComponent();
			aL.Text = "地址: "+a;
			this.FormClosing += new FormClosingEventHandler(oneNodeFormcs_FormClosing);
			
		}

		void oneNodeFormcs_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.FormClosing -= oneNodeFormcs_FormClosing;
			button1_Click(this, null);
		}		
		public oneNodeFormcs(string a,string t,string h,string l)
		{
			InitializeComponent();
			aL.Text = "地址: "+a;
			tL.Text = "温度: "+t;
			hL.Text = "湿度: "+h;
			lL.Text = "光照: "+l;
		}
		public void upData( string t, string h, string l)
		{
			tL.Text = "温度: "+t;
			hL.Text = "湿度: "+h;
			lL.Text = "光照: "+l;
		}
		public event EventHandler closeMe;
		private void button1_Click(object sender, EventArgs e)
		{
			if (closeMe != null)
			{
				closeMe.Invoke(this, null);
			}

		}


	}
}
