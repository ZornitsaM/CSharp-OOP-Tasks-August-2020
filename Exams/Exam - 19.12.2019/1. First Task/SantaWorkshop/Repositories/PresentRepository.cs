

using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly ICollection<IPresent> presents;


        public PresentRepository()
        {
            this.presents = new List<IPresent>();
        }
        public IReadOnlyCollection<IPresent> Models => (IReadOnlyCollection<IPresent>)this.presents;

        public void Add(IPresent model)
        {
            this.presents.Add(model);
        }

        public IPresent FindByName(string name)
            => this.presents.FirstOrDefault(x => x.Name == name);
       

        public bool Remove(IPresent model)
            => this.presents.Remove(model);
       
    }
}
