using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            //if (age<=15)
            //{
            //    Child child = new Child(name, age);
            //    Console.WriteLine(child);
            //}

            //else
            //{
            //    Person person = new Person(name, age);
            //    Console.WriteLine(person);
            //}


            Person person;

            if (age <= 15)
            {
                person = new Child(name, age);
                Console.WriteLine(person);
            }

            else
            {
                person = new Person(name, age);
                Console.WriteLine(person);
            }


        }
    }
}
