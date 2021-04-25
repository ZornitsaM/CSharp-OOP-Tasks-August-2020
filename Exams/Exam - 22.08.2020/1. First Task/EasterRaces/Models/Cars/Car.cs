

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private string model;

        private int minHorsePower;
        private int maxHorsePower;
        //private int horsePower;
        private int horsePower1;

        protected Car(string model, int horsePower1, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower1;
            this.CubicCentimeters = cubicCentimeters;

        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    string ms = string.Format(ExceptionMessages.InvalidModel, value, 4);
                    throw new ArgumentException(ms);
                }

                this.model = value;
            }
        }

        //public int HorsePower
        //{
        //    get { return horsePower; }
        //    private set
        //    {
        //         if (value<this.minHorsePower || value>this.maxHorsePower)
        //        {
        //            string ms = string.Format(ExceptionMessages.InvalidHorsePower, value);
        //            throw new ArgumentException(ms);
        //        }
        //        horsePower = value;
        //    }
        //}




        //TODO
        public double CubicCentimeters { get; }

        public int HorsePower
        {
            get { return this.horsePower1; }
            private set
            {
                if (value<minHorsePower || value>maxHorsePower)
                {
                    string ms = string.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(ms);
                }
                this.horsePower1 = value;
            }
        }

        public virtual double CalculateRacePoints(int laps)
        {
            var result = this.CubicCentimeters / this.HorsePower * laps;

            return result;

        }





    }
}
