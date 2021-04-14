using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Interfaces
{
    public interface IPrivate:ISoldier
    {
        decimal Salary { get; }
    }
}
