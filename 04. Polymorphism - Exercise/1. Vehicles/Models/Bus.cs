using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism_EX.Models
{
    public class Bus : Vehicle
    {
        private const double AirCondition = 1.4;
        private double defaultFuelConsumption;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.defaultFuelConsumption = fuelConsumption;
        }


        public bool IsEmpty { get; set; }
        public override bool Drive(double distance)
        {
            if (!this.IsEmpty)
            {
                this.FuelConsumption += AirCondition;
            }

            bool result = base.Drive(distance);
            this.FuelConsumption = defaultFuelConsumption;
            return result;
        }

    }
}
