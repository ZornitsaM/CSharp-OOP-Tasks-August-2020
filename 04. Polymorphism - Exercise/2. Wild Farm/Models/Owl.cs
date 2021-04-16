using WildFarm.ABSTRACT_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Owl:Bird
    {
        private double inputQuantity;
        private readonly List<string> procent = new List<string>
        {
            "Meat",
            
        };

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string MakeASound()
        {
            return "Hoot Hoot";
        }


        public override void AddFood(string nameFood, double quantity)
        {
            if (!procent.Contains(nameFood))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {nameFood}!");
            }

            inputQuantity = quantity;
            this.Weight += quantity * 0.25;
        }



        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {inputQuantity}]";

        }
    }
}
