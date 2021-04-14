using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree

{
    public class Person
    {


        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts => this.bagOfProducts.AsReadOnly();

        public void AddToBag(Product product)
        {
            if (this.Money-product.Cost>=0)
            {
                this.bagOfProducts.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }

            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.BagOfProducts.Count==0)
            {
                return $"{this.Name} - Nothing bought";

            }
            return $"{this.Name} - {string.Join(", ", this.BagOfProducts.Select(x => x.Name))}";
        }

    }
}
