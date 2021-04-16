using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double GramsCake = 250;
        private const double CaloriesCake = 1000;
        private const decimal CakePrice = 5m;

        public Cake(string name) 
            : base(name, CakePrice, GramsCake, CaloriesCake)
        {
        }
    }
}
