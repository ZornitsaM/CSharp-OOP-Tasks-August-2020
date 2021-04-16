using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaxNameLenght = 15;
        private string name;
        private readonly List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            this.toppings = new List<Topping>();
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length>MaxNameLenght)
                {
                    throw new ArgumentException($"Pizza name should be between 1 and {MaxNameLenght} symbols.");
                }

                this.name = value;
            }
        }
        
        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public int CountOfToppings => this.toppings.Count;
        public double TotalCalories => CalculateTotalCalories();
      
        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count==10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);

        }

        private double CalculateTotalCalories()
        {
            double result = this.Dough.TotalCalories;

            foreach (Topping item in this.toppings)
            {
                result += item.TotalCalories;
            }

            return result;
        }


    }
}
