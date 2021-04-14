using System;
using System.Collections.Generic;
using System.Text;

namespace PO8.Interfaces
{
    public interface IResident
    {
        public string Name { get; }
        public string Country { get; }
        public string GetName();
    }
}
