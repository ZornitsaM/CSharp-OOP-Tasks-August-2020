using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var inputPersons = Console.ReadLine().Split(new string[] { "=", ";" }, 
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                var inputProducts = Console.ReadLine().Split(new string[] { "=", ";" }, 
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                var persons = new List<Person>();
                var products = new List<Product>();

                for (int i = 0; i < inputPersons.Length; i += 2)
                {
                    string currentName = inputPersons[i];
                    double money = double.Parse(inputPersons[i + 1]);
                    Person person = new Person(currentName, money);
                    persons.Add(person);

                }

                for (int i = 0; i < inputProducts.Length; i += 2)
                {
                    string currentProduct = inputProducts[i];
                    double money = double.Parse(inputProducts[i + 1]);
                    Product product = new Product(currentProduct, money);
                    products.Add(product);


                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    var splittedCommand = command.Split();

                    string namePerson = splittedCommand[0];
                    string nameProduct = splittedCommand[1];

                    Person currentPerson = persons.FirstOrDefault(x => x.Name == namePerson);
                    double moneyPerson = currentPerson.Money;
                    Product currentProduct = products.FirstOrDefault(x => x.Name == nameProduct);
                    double moneyProduct = currentProduct.Cost;

                    if (moneyPerson- moneyProduct >=0)
                    {
                        currentPerson.Money -= moneyProduct;
                        curre
                        Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                    }

                    else
                    {
                        Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                    }


                    command = Console.ReadLine();
                }


                foreach (Person item in persons)
                {
                    if (item.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine($"{item.Name} - Nothing bought");
                    }

                    else
                    {
                        Console.Write($"{item.Name} - {string.Join(", ", item.BagOfProducts.Select(x => x.Name))}");
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
