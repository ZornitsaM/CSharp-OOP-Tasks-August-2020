using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.ABSTRACT_Models
{
    public abstract class Feline:Mammal
    {
        private string breed;

        protected Feline(string name, double weight, string livingRegion,string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

    }
}
