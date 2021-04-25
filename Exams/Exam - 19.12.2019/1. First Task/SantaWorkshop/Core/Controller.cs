

using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private Workshop workshop;



        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
            this.workshop = new Workshop();

        }


        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            if (dwarfType == nameof(HappyDwarf))
            {
                dwarf = new HappyDwarf(dwarfName);

            }

            else if (dwarfType == nameof(SleepyDwarf))
            {
                dwarf = new SleepyDwarf(dwarfName);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);
            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }


        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var currenDwarf = this.dwarfs.FindByName(dwarfName);

            if (currenDwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            var instrument = new Instrument(power);
            currenDwarf.AddInstrument(instrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);


        }



        public string AddPresent(string presentName, int energyRequired)
        {
            var present = new Present(presentName, energyRequired);
            this.presents.Add(present);

            return string.Format(OutputMessages.PresentAdded, presentName);


        }

        public string CraftPresent(string presentName)
        {
            var present = this.presents.FindByName(presentName);

            var dwarves = this.dwarfs.Models.Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy).ToList();

            if (!dwarves.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);

            }

            while (dwarves.Count>0)
            {

                var current = dwarves.First();
                workshop.Craft(present, current);


                if (current.Energy == 0)
                {
                    dwarves.Remove(current);
                    this.dwarfs.Remove(current);//-->>махаме го и от двете и от лакалната и общата!
                
                }

                else if (!current.Instruments.Any())
                {
                    dwarves.Remove(current);//-->>махаме джуджето от локалната колекция 
                                            //от над 50 ЕНЕРГИЯ,В другата си оставя!

                }
                else if (present.IsDone())
                {
                    break;
                }

            }

            string output = string.Empty;

            if (present.IsDone())
            {
                output = string.Format(OutputMessages.PresentIsDone, presentName);
            }

            else
            {
                output = string.Format(OutputMessages.PresentIsNotDone, presentName);
            }

            return output;

        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            var countCrafted = this.presents.Models.Where(x => x.EnergyRequired == 0).ToList();

            sb.AppendLine($"{countCrafted.Count} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (var item in this.dwarfs.Models)
            {
                sb.AppendLine($"Name: {item.Name}");
                sb.AppendLine($"Energy: {item.Energy}");
                sb.AppendLine($"Instruments: {item.Instruments.Count(x => !x.IsBroken())} not broken left");

            }


            return sb.ToString().TrimEnd();

        }
    }
}
