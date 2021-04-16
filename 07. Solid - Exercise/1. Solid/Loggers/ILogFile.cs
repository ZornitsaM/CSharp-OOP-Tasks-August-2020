using System;
using System.Collections.Generic;

using System.Text;

namespace Solid_EX.Loggers
{
    public interface ILogFile
    {
        void Write(string message);

        int Size { get; }
    }
}
