using System;
using System.Collections.Generic;
using System.Text;

namespace PO5
{
    public interface IBuyer
    {
        void BuyFood();

        public int Food { get; set; }

        string Name { get; }
    }
}
