

using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Races;
using EasterRaces.Repositories;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;



        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();

        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var existDriver = this.drivers.GetAll().FirstOrDefault(x => x.Name == driverName);
            if (existDriver==null)
            {
                string mess = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(mess);
            }

            var existCar = this.cars.GetAll().FirstOrDefault(x => x.Model == carModel);

            if (existCar == null)
            {
                //TODO Car name OR model could be not found
                string mess = string.Format(ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(mess);
            }

            existDriver.AddCar(existCar);
            string msg = string.Format(OutputMessages.CarAdded, driverName, carModel);
            return msg;

        }


        public string AddDriverToRace(string raceName, string driverName)
        {
            var existRace = this.races.GetAll().FirstOrDefault(x => x.Name == raceName);

            if (existRace==null)
            {
                string mess = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(mess);
            }

            var existDriver = this.drivers.GetAll().FirstOrDefault(x => x.Name == driverName);
            if (existDriver == null)
            {
                string mess = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(mess);
            }

            existRace.AddDriver(existDriver);
            string msg = string.Format(OutputMessages.DriverAdded, driverName, raceName);
            return msg;

        }


        public string CreateCar(string type, string model, int horsePower)
        {
            var existCar = this.cars.GetAll().FirstOrDefault(x => x.Model == model);
            if (existCar!=null)
            {
                string ms = string.Format(ExceptionMessages.CarExists, model);
                throw new ArgumentException(ms);
            }

            ICar car = null;
           
            if (type== "Muscle")
            {
                car = new MuscleCar(model, horsePower);
                
            }

            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
               
            }


            this.cars.Add(car);
            string msg = string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
            return msg;

        }


        public string CreateDriver(string driverName)
        {
            var existDriver = this.drivers.GetAll().FirstOrDefault(x=>x.Name==driverName);


            if (existDriver!=null)
            {
                string ms = string.Format(ExceptionMessages.DriversExists, driverName);
                throw new ArgumentException(ms);
            }

            var driver = new Driver(driverName);

            this.drivers.Add(driver);

            string msg = string.Format(OutputMessages.DriverCreated, driverName);
            return msg;



        }


        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name)!=null)
            {
                string message = string.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(message);
            }

            var race = new Race(name, laps);
            this.races.Add(race);
            string msg = string.Format(OutputMessages.RaceCreated, name);
            return msg;

        }


        public string StartRace(string raceName)
        {
            var existRace = this.races.GetAll().FirstOrDefault(x => x.Name == raceName);
            
            if (existRace==null)
            {
                string ms = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(ms);

            }

            if (this.drivers.GetAll().Count<3)
            {
                string ms = string.Format(ExceptionMessages.RaceInvalid, raceName,3);
                throw new InvalidOperationException(ms);
            }

            var laps = existRace.Laps;
            var dic = new Dictionary<string, double>();


            foreach (var item in this.drivers.GetAll().Where(x=>x.CanParticipate==true))
            {
                var currentRes = item.Car.CalculateRacePoints(laps);
                dic.Add(item.Name, currentRes);
            }

            
            var sortedDrivers = dic.OrderByDescending(x => x.Value);
            int count = 1;
          

            StringBuilder sb = new StringBuilder();
            
            foreach (var item in sortedDrivers.Take(3))
            {
                if (count==1)
                {
                    sb.AppendLine($"Driver {item.Key} wins {raceName} race.");
                    count++;
                }

                else if (count==2)
                {
                    sb.AppendLine($"Driver {item.Key} is second in {raceName} race.");
                    count++;
                }

                else
                {
                    sb.AppendLine($"Driver {item.Key} is third in {raceName} race.");
                    count++;
                }
               
            }

            this.races.Remove(existRace);
            return sb.ToString().TrimEnd();

        }
    }
}
