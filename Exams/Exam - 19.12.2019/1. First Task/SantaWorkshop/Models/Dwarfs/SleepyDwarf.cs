

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int DefaultEnergy = 50;
        public SleepyDwarf(string name) 
            : base(name, DefaultEnergy)
        {
        }

        public override void Work()
        {
            base.Work();
            this.Energy -= 5;
        }
    }
}
