using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {

        private int horsePower;
        private double fuel;
        private const double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumption = defaultFuelConsumption;
           
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

      
        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public virtual double FuelConsumption { get; set; }


        public virtual void Drive(double kilometers)
        {
            bool canContinue = this.Fuel - kilometers * this.FuelConsumption >= 0;
            if (canContinue)
            {
                this.Fuel -= this.FuelConsumption * kilometers;
            }
            
        }

    }
}
