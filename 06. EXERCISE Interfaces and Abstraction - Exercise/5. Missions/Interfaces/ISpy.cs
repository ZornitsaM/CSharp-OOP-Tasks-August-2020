using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Interfaces
{
    public interface ISpy:ISoldier
    {
        int CodeNumber { get; }
    }
}
