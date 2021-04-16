using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;
        private const double MinValue = 1;
        private const double MaxValue = 50;
        private readonly Dictionary<string, double> DefaultTypes = new Dictionary<string, double>()
        {
            {"meat",1.2},
            {"veggies",0.8},
            {"cheese",1.1},
            {"sauce",0.9},

        };
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (!this.DefaultTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value.ToLower();
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                string word = this.type.ToUpper();
                string completedWord = string.Empty;
                

                completedWord += word[0];


                for (int i = 1; i < this.Type.Length; i++)
                {
                    completedWord += this.Type[i];
                }



                if (value < MinValue || value > MaxValue)
                {


                    throw new ArgumentException($"{completedWord} weight should be in the range [{MinValue}..{MaxValue}].");
                }

                this.weight = value;
            }
        }

        public double CaloriesPerGram => BaseCaloriesPerGram * this.DefaultTypes[this.Type];
        public double TotalCalories => this.CaloriesPerGram * this.Weight;

    }
}
