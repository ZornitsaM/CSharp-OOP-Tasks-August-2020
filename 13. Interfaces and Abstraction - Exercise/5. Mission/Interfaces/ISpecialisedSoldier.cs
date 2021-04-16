using PO7.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PO7.Interfaces
{
    public interface ISpecialisedSoldier:IPrivate
    {
        Corps Corps { get; }
    }
}
