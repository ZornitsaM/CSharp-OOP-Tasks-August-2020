using PO8.Interfaces;
using System;
using System.Collections.Generic;

namespace PO8
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input!="End")
            {
                var currentInput = input.Split();
                Citizen citizen = new Citizen(currentInput[0], currentInput[1], int.Parse(currentInput[2]));
                IResident resident = citizen;
                IPerson person = citizen;

               
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
            
        }
    }
}
