using Solid_EX.Appenders;
using Solid_EX.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_EX.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders
        {
            get
            {
                return this.appenders;
            }
            private set
            {
                if (value==null)
                {
                    throw new ArgumentNullException(nameof(Appenders),"Value cannot be null");
                }

                this.appenders = value;
            }
        }

        public void Error(string dateTime, string message)
        {
            for (int i = 0; i <this.Appenders.Length; i++)
            {
                this.Appenders[i].Append(dateTime, ReportLevel.Error, message);
            }
        }

        public void Critical(string dateTime, string message)
        {
            for (int i = 0; i < this.Appenders.Length; i++)
            {
                this.Appenders[i].Append(dateTime, ReportLevel.Critical, message);
            }
        }

        public void Fatal(string dateTime, string message)
        {
            for (int i = 0; i < this.Appenders.Length; i++)
            {
                this.Appenders[i].Append(dateTime, ReportLevel.Fatal, message);
            }
        }

        public void Info(string dateTime, string message)
        {
            for (int i = 0; i < this.Appenders.Length; i++)
            {
                this.Appenders[i].Append(dateTime, ReportLevel.Info, message);
            }
        }

        public void Warning(string dateTime, string message)
        {
            for (int i = 0; i < this.Appenders.Length; i++)
            {
                this.Appenders[i].Append(dateTime, ReportLevel.Warning, message);
            }
        }
    }
}
