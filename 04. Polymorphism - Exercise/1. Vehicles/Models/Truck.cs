using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism_EX.Models
{
    public class Truck : Vehicle
    {
        private const double AirCondiotion = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirCondiotion;
        }

        public override double Refuel(double liters)
        {

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");

            }

            liters *=0.95;
            return base.Refuel(liters);
        }
    }
}
