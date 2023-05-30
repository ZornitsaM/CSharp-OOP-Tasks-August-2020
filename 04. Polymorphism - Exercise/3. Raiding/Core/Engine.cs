using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Engine
{
    public class Engine
    {
        List<BaseHero> heroes = new List<BaseHero>();
        public Engine()
        {
            this.heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int sumPower = 0;
            int counter = int.Parse(Console.ReadLine());

            while (counter > 0)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType == "Druid")
                {
                    BaseHero druid = new Druid(name);
                    heroes.Add(druid);
                    counter--;
                }
                else if (heroType == "Paladin")
                {
                    BaseHero paladin = new Paladin(name);
                    heroes.Add(paladin);
                    counter--;
                }
                else if (heroType == "Rogue")
                {
                    BaseHero rogue = new Rogue(name);
                    heroes.Add(rogue);
                    counter--;
                }
                else if (heroType == "Warrior")
                {
                    BaseHero warrior = new Warrior(name);
                    heroes.Add(warrior);
                    counter--;
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var heroe in heroes)
            {
                Console.WriteLine(heroe.CastAbility());
            }

            foreach (BaseHero currentHero in heroes)
            {
                sumPower += currentHero.Power;
            }

            if (sumPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
