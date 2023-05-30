using WildFarm.ABSTRACT_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private double inputQuantity;
        private readonly List<string> procent = new List<string>
        {
            "Vegetable",
             "Fruit"
        };

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string MakeASound()
        {
            return "Squeak";
        }

        public override void AddFood(string nameFood, double quantity)
        {
            if (!procent.Contains(nameFood))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {nameFood}!");
            }

            inputQuantity = quantity;
            this.Weight += quantity * 0.10;
        }

        public override string ToString()
        {
            return $"{ this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {inputQuantity}]";

        }
    }
}
