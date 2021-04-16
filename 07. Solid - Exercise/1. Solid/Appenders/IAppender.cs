using Solid_EX.Enum;
using Solid_EX.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_EX.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel logLevel, string message);
    }
}
