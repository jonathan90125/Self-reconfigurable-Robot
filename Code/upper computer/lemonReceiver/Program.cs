using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace thSensor
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
        public static mainF mainForm;
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			mainForm = new mainF();
            Application.Run(mainForm);
		}
	}
}
