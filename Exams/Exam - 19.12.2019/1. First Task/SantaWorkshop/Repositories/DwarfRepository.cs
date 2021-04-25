
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> dwarfs;

        public DwarfRepository()
        {
            this.dwarfs = new List<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models => (IReadOnlyCollection<IDwarf>)this.dwarfs;

        public void Add(IDwarf model)
        {
            this.dwarfs.Add(model);
        }

        public IDwarf FindByName(string name)
            => this.dwarfs.FirstOrDefault(x => x.Name == name);
        

        public bool Remove(IDwarf model)
            => this.dwarfs.Remove(model);
       
    }
}
