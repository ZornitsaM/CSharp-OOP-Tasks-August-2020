using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Restaurant
{
    public abstract class Product
    {
        private string name;
        private decimal price;

        protected Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }



    }
}
