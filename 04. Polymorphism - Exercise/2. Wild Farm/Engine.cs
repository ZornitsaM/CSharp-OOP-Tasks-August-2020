using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.ABSTRACT_Models;
using WildFarm.Models;

namespace WildFarm
{
    public class Engine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();
            int coun = 0;

            while (input != "End")
            {
                try
                {
                    var splittedInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (coun % 2 == 0)
                    {
                        if (splittedInput[0] == "Cat")
                        {
                            string name = splittedInput[1];
                            double weight = double.Parse(splittedInput[2]);
                            string livingRegion = splittedInput[3];
                            string breed = splittedInput[4];

                            Cat cat = new Cat(name, weight, livingRegion, breed);
                            Console.WriteLine(cat.MakeASound());
                            animals.Add(cat);

                        }

                        else if (splittedInput[0] == "Tiger")
                        {
                            string name = splittedInput[1];
                            double weight = double.Parse(splittedInput[2]);
                            string livingRegion = splittedInput[3];
                            string breed = splittedInput[4];

                            Tiger tiger = new Tiger(name, weight, livingRegion, breed);
                            Console.WriteLine(tiger.MakeASound());
                            animals.Add(tiger);
                        }

                        else if (splittedInput[0] == "Owl")
                        {
                            string name = splittedInput[1];
                            double weight = double.Parse(splittedInput[2]);
                            double wingSize = double.Parse(splittedInput[3]);

                            Owl owl = new Owl(name, weight, wingSize);
                            Console.WriteLine(owl.MakeASound());
                            animals.Add(owl);

                        }

                        else if (splittedInput[0] == "Hen")
                        {
                            string name = splittedInput[1];
                            double weight = double.Parse(splittedInput[2]);
                            double wingSize = double.Parse(splittedInput[3]);

                            Hen hen = new Hen(name, weight, wingSize);
                            Console.WriteLine(hen.MakeASound());
                            animals.Add(hen);

                        }

                        else if (splittedInput[0] == "Mouse")
                        {
                            string name = splittedInput[1];
                            double weight = double.Parse(splittedInput[2]);
                            string livingRegion = splittedInput[3];

                            Mouse mouse = new Mouse(name, weight, livingRegion);
                            Console.WriteLine(mouse.MakeASound());
                            animals.Add(mouse);
                        }

                        else if (splittedInput[0] == "Dog")
                        {
                            string name = splittedInput[1];
                            double weight = double.Parse(splittedInput[2]);
                            string livingRegion = splittedInput[3];

                            Dog dog = new Dog(name, weight, livingRegion);
                            Console.WriteLine(dog.MakeASound());
                            animals.Add(dog);
                        }

                    }

                    else
                    {
                        string nameVegatables = splittedInput[0];
                        double quantity = double.Parse(splittedInput[1]);
                        Animal currentAnimal = animals[animals.Count - 1];
                        currentAnimal.AddFood(nameVegatables, quantity);
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                coun++;
                input = Console.ReadLine();

            }


            foreach (Animal item in animals)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
