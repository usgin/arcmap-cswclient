using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Principal;

namespace ArcMapAddin1
{
    class Log
    {
        private StreamWriter wLog;
        private string _logPath = "\\\\SERVER3\\DevelopmentDocs\\ArcGISAddIns\\Exceptions4CswClient\\";
        private Boolean isWrite;

        public Log(string logName)
        {
            string fileName = logName + ".txt";

            if (Directory.Exists(_logPath)) 
            { 
                fileName = _logPath + fileName;

                if (!File.Exists(fileName))
                { wLog = new StreamWriter(fileName); }
                else
                { wLog = File.AppendText(fileName); }

                wLog.WriteLine(DateTime.Now);
                wLog.WriteLine(WindowsIdentity.GetCurrent().Name);
                isWrite = true;
            }
            else
            { 
                isWrite = false;
                return;
            }
        }

        public void WriteLog(string logContent)
        {
            if (isWrite) { wLog.WriteLine(logContent); }
        }

        public void CloseLog()
        {
            if (isWrite)
            {
                wLog.WriteLine(" ");
                wLog.Close();
            }
        }
    }
}
