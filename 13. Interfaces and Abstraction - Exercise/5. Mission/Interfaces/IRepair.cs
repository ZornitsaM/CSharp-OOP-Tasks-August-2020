using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Interfaces
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWork { get; }
    }
}
