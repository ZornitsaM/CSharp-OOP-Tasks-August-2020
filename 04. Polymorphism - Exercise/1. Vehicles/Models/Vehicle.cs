using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism_EX.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            protected set
            {
                if (value > this.tankCapacity)
                {
                    fuelQuantity = 0;
                }

                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            protected set { fuelConsumption = value; }
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            private set { tankCapacity = value; }
        }

        public virtual bool Drive(double distance)
        {
            bool isEnought = this.fuelQuantity - this.FuelConsumption * distance >= 0;

            if (isEnought)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                return true;
            }
            return false;
        }

        public virtual double Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");

            }
            return this.FuelQuantity += liters;
        }
    }
}
