

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length<5)
                {
                    string ms = string.Format(ExceptionMessages.InvalidName, value,5);
                    throw new ArgumentException(ms);
                }

                this.name = value;
            }
        }


        public ICar Car { get; private set; }


        public int NumberOfWins { get; protected set; }



        //TODO
        public bool CanParticipate
            => this.Car != null;


        public void AddCar(ICar car)
        {
            if (car==null)
            {
                string ms = string.Format(ExceptionMessages.CarInvalid);
                throw new ArgumentNullException(ms);
            }

            this.Car = car;

        }


        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
