using System;
using System.Collections.Generic;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Citizen> citizens = new List<Citizen>();

            while (input != "End")
            {
                var currendInput = input.Split();
                string name = currendInput[0];

                if (currendInput.Length==3)
                {
                    Citizen citizen = new Citizen(name, currendInput[2]);
                    citizens.Add(citizen);
                }
                else
                {
                    Citizen citizen = new Citizen(name, currendInput[1]);
                    citizens.Add(citizen);
                }
                input = Console.ReadLine();
            }

            string number = Console.ReadLine();

            for (int i = 0; i < citizens.Count; i++)
            {
                Citizen currentCitizen = citizens[i];
                currentCitizen.LastNumbers(currentCitizen.Id, number);
            }
        }
    }
}
