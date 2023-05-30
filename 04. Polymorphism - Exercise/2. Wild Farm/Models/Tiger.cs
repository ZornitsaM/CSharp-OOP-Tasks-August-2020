using WildFarm.ABSTRACT_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        private double inputQuantity;

        private readonly List<string> procent = new List<string>
        {
            "Meat",
        };

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string MakeASound()
        {
            return "ROAR!!!";
        }

        public override void AddFood(string nameFood, double quantity)
        {
            if (!procent.Contains(nameFood))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {nameFood}!");
            }

            inputQuantity = quantity;
            this.Weight += quantity * 1.00;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, { this.Breed}, { this.Weight}, { this.LivingRegion}, {inputQuantity}]";
        }
    }
}
