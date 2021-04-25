

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System.Linq;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (!present.IsDone())
            {
                if (dwarf.Energy <= 0)
                {
                    break;
                }

                if (dwarf.Instruments.All(x => x.IsBroken()))
                {
                    break;
                }

                var currentInstrument = dwarf.Instruments.First();

                while (!currentInstrument.IsBroken() && dwarf.Energy > 0 && !present.IsDone())
                {
                    dwarf.Work();
                    currentInstrument.Use();
                    present.GetCrafted();
                }
               
                if (currentInstrument.IsBroken())
                {
                    dwarf.Instruments.Remove(currentInstrument);
                }

                if (dwarf.Energy<=0)
                {
                    break;
                }

            }
        }

    }
}
