using System;
using System.Collections.Generic;
using System.Text;

namespace Exception_Handling_LAB
{
    public class Car
    {
        public Car()
        {
            this.Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }
    }
}
