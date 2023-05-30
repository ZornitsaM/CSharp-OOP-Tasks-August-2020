using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Exception_Handling_LAB
{
    public class Parking
    {
        private readonly List<Car> cars;

        public Parking()
        {
            this.cars = new List<Car>();
        }

        public void AddCar(Car car)
        {
            if (this.Cars.Count<50)
            {
                this.cars.Add(car);
            }
        }

        public IReadOnlyCollection<Car> Cars => this.cars;
    }
}
