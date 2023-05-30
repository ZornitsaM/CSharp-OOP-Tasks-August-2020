using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.ABSTRACT_Models
{
    public abstract class Bird:Animal
    {
        private double wingSize;

        protected Bird(string name, double weight,double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get { return wingSize; }
            set { wingSize = value; }
        }
    }
}
