

namespace EasterRaces.Models.Cars
{
    public class SportsCar : Car
    {
        private const double CubicCentimeters = 3000;
        private const int MinHorsePower = 250;
        private const int MaxHorsePower = 450;
        public SportsCar(string model, int horsePower1)
            : base(model, horsePower1, CubicCentimeters, MinHorsePower, MaxHorsePower)
        {
            //TODO Range for HotsePower;


        }

        public override double CalculateRacePoints(int laps)
        {
            return base.CalculateRacePoints(laps);
        }
    }
}
