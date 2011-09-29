using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ArcMapAddin1
{
    class Log
    {
        private StreamWriter wLog;

        public Log(string logName)
        {
            string fileName = logName + ".txt";

            if (!File.Exists(fileName))
            { wLog = new StreamWriter(fileName); }
            else
            { wLog = File.AppendText(fileName); }

            wLog.WriteLine(DateTime.Now);
        }

        public void WriteLog(string logContent)
        {
            wLog.WriteLine(logContent);
        }

        public void CloseLog()
        {
            wLog.WriteLine(" ");
            wLog.Close();
        }
    }
}
