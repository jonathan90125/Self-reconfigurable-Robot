using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;

namespace thSensor.ToNode
{
    class socketRecord
    {
        Queue<sktPkg> save_temp;
        Timer saveT;
        static string path = "SKT文本记录\\";
        string file_name;
        public socketRecord()
        {
            Directory.CreateDirectory(path);
            save_temp = new Queue<sktPkg>(1024);
            file_name = path + getFileName();
            saveT = new Timer();
            saveT.AutoReset = true;
            saveT.Interval = 60000;
            saveT.Elapsed += new ElapsedEventHandler(saveT_Elapsed);
            saveT.Start() ;
         }
        ~socketRecord()
        {
            save();
        }
        public void addSktPkg(sktPkg pkg)
        {
            save_temp.Enqueue(pkg);
            if (save_temp.Count > 1000)
            {
                save();
                changeFileName();
            }
        }

		private  void saveT_Elapsed(object sender, ElapsedEventArgs e)
        {
            save();
            changeFileName();
        }

        private void save()
        {
            if (save_temp.Count != 0)
            {
                try
                {
                    FileStream fs = new FileStream(file_name, FileMode.Append, FileAccess.Write, FileShare.Read);
                    StreamWriter sw = new StreamWriter(fs);
                    while (save_temp.Count != 0)
                    {
                        try
                        {
                            sktPkg s = save_temp.Dequeue();
                            sw.Write(s.ToCsv());
                            sw.WriteLine();
                        }
                        catch
                        {
                        }
                    }
                    sw.Dispose();
                    fs.Dispose();
                }
                catch
                {
                }
            }
        }
        private void changeFileName()
        {
            FileInfo fn = new FileInfo(file_name);
            if (fn.Length > 1 * 1024 * 1024)
            {
                file_name = path + getFileName();
            }
        }
        private string getFileName()
        {
            return "SKT文本记录" + System.DateTime.Now.ToString("yyyy年MM月dd日HH-mm-ss") + ".csv";
        }
    }
}
