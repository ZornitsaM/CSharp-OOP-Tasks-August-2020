using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {

        private string name;
        private double money;
        private List<Product> bag;

        public Person(string name, double money)
        {
            this.bag = new List<Product>();
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }
        

        public double Money
        {
            get { return money; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts => this.bag.AsReadOnly();
       

    }
}
