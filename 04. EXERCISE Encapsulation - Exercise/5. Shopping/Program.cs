using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var inputPersons = Console.ReadLine().Split(new char[] { '=', ';' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                var inputProducts = Console.ReadLine().Split(new char[] { '=', ';' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                var persons = new List<Person>();
                var products = new List<Product>();

                for (int i = 0; i < inputPersons.Length; i += 2)
                {
                    string currentName = inputPersons[i];
                    decimal money = decimal.Parse(inputPersons[i + 1]);
                    Person person = new Person(currentName, money);
                    persons.Add(person);

                }

                for (int i = 0; i < inputProducts.Length; i += 2)
                {
                    string currentProduct = inputProducts[i];
                    decimal money = decimal.Parse(inputProducts[i + 1]);
                    Product product = new Product(currentProduct, money);
                    products.Add(product);

                }
                string command = Console.ReadLine();

                while (command!="END")
                {
                    var splittedCommand = command.Split();

                    string namePerson = splittedCommand[0];
                    string nameProduct = splittedCommand[1];

                    Person currentPerson = persons.FirstOrDefault(x => x.Name == namePerson);
                    Product currentProduct = products.FirstOrDefault(x => x.Name == nameProduct);
                    currentPerson.AddToBag(currentProduct);
                    


                    command = Console.ReadLine();

                }

                foreach (var item in persons)
                {

                    Console.WriteLine(item);
                   
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
    }
}
