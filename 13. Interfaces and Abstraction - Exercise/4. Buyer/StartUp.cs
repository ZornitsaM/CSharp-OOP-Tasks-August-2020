using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PO5
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
          
            List<IBuyer> people = new List<IBuyer>();


            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length==4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthday = input[3];

                    Citizen citizen = new Citizen(name, age, id, birthday);
                    citizen.BuyFood();
                    people.Add(citizen);

                }

                else if (input.Length==3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    Rebel rebel = new Rebel(name, age, group);
                    rebel.BuyFood();
                    people.Add(rebel);
                }
            }


            string command = Console.ReadLine();
            int sumFood = 0;

            while (command!="End")
            {
               
                if (people.Any(x=>x.Name==command))
                {
                    var curentRebel = people.FirstOrDefault(x => x.Name == command);
                    sumFood += curentRebel.Food;
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine(sumFood);

        }
    }
}
