

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    string ms = string.Format(ExceptionMessages.InvalidName, value);
                    throw new ArgumentException(ms);
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get { return this.laps; }
            private set
            {
                if (value<1)
                {
                    string msg = string.Format(ExceptionMessages.InvalidNumberOfLaps, 1);
                    throw new ArgumentException(msg);
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>)this.drivers;

        public void AddDriver(IDriver driver)
        {

            if (driver==null)
            {
                string ms = string.Format(ExceptionMessages.DriverInvalid);
                throw new ArgumentNullException(ms);
            }

            if (!driver.CanParticipate)
            {
                string mss = string.Format(ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(mss);
            }

            if (this.drivers.Contains(driver))
            {
                string msg = string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.GetType().Name);
                throw new ArgumentNullException(msg);
            }

            this.drivers.Add(driver);


        }
    }
}
