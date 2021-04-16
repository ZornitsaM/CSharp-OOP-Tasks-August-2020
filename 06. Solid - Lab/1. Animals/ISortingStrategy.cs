using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_LAB
{
    public interface ISortingStrategy
    {
        ICollection<int> Sort(ICollection<int>)
    }
}
