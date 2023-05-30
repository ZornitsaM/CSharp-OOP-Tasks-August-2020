using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Solid_EX.Loggers
{
    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";
     
        public void Write(string message)
        {
            File.AppendAllText(LogFilePath, message+Environment.NewLine);
        }

        public int Size => File.ReadAllText(LogFilePath).Where(c => char.IsLetter(c)).Sum(x => x);
    }
}
