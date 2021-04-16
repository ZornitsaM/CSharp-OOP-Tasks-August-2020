using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.ABSTRACT_Models
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }

        public virtual string MakeASound()
        {
            return base.ToString();
        }


        public virtual void AddFood(string nameFood,double quantity)
        {

        }

    }
}
