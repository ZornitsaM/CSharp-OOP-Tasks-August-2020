using System;
using System.Collections.Generic;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            int level = int.Parse(Console.ReadLine());
            List<Wizard> heroes = new List<Wizard>();

            Hero hero = new Hero(userName, level);
            var currentHero = new DarkWizard(userName, level);

            heroes.Add(currentHero);

        }
    }
}
