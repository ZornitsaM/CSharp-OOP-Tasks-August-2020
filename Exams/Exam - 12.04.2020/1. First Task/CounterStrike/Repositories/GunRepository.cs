

using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> guns;


        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => (IReadOnlyCollection<IGun>)this.guns;

        public void Add(IGun model)
        {
            //if (model.Name != nameof(Pistol) || model.Name != nameof(Rifle))
            //{
            //    throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            //}

            this.guns.Add(model);
        }

        public IGun FindByName(string name)
        {
            var currentGun = this.guns.FirstOrDefault(x => x.Name == name);


            if (currentGun == null)
            {
                return null;
            }

            //TODO
            return (Gun)currentGun;
        }

        public bool Remove(IGun model)
        {
            if (this.guns.Contains(model))
            {
                this.guns.Remove(model);
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
