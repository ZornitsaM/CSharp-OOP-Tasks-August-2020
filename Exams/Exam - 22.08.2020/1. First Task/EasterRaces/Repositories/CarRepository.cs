

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> cars;


        public CarRepository()
        {
            this.cars = new List<ICar>();
        }


        public void Add(ICar model)
        {
            this.cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll() => (IReadOnlyCollection<ICar>)this.cars;
        

        public ICar GetByName(string name)
        {
            return this.cars.FirstOrDefault(x => x.Model == name);
            
        }

        public bool Remove(ICar model)
            => this.cars.Remove(model);
       
    }
}
