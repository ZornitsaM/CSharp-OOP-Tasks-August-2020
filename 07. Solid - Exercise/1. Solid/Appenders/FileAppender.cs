using Solid_EX.Enum;
using Solid_EX.Layouts;
using Solid_EX.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_EX.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout,ILogFile logFile)
        {
            this.Layout = layout;
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; }
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get ; set ; }

        public void Append(string dateTime, ReportLevel logLevel, string message)
        {
            this.LogFile.Write(string.Format(this.Layout.Format,dateTime,logLevel,message));
        }
    }
}
