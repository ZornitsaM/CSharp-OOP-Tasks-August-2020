using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism_EX.Models
{
    public class Car : Vehicle
    {
        private const double AirCondition = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : 
            base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirCondition;
        }


        public override bool Drive(double distance)
        {
            return base.Drive(distance);
        }

        public override double Refuel(double liters)
        {
            return base.Refuel(liters);
        }
    }
}
