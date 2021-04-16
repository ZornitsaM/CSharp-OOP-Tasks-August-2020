using Solid_EX.Enum;
using Solid_EX.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_EX.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get ; set ; }

        public void Append(string dateTime,ReportLevel logLevel,string message)
        {
            if (logLevel>=this.ReportLevel)
            {
                Console.WriteLine(this.Layout.Format, dateTime, logLevel, message);

            }
        }
    }
}
