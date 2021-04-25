

using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars
{
    public class MuscleCar : Car
    {

        private const double CubicCentimeters = 5000;
        private const int MinHorsePower = 400;
        private const int MaxHorsePower = 600;
        private int horsePower;

        public MuscleCar(string model, int horsePower1)
: base(model, horsePower1, CubicCentimeters, MinHorsePower, MaxHorsePower)
        {
            //TODO Range for HotsePower;

        }


        public override double CalculateRacePoints(int laps)
        {
            return base.CalculateRacePoints(laps);
        }
        //public override int HorsePower
        //{
        //    get { return horsePower; }
        //    set
        //    {
        //        if (value<MinHorsePower || value>MaxHorsePower)
        //        {
        //            string ms = string.Format(ExceptionMessages.InvalidHorsePower, value);
        //            throw new ArgumentException(ms);
        //        }
        //        horsePower = value;
        //    }
        //}
    }
}
