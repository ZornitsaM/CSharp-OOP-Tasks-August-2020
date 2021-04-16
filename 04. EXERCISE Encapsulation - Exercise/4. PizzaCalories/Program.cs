using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaArgs = Console.ReadLine().Split();
                Pizza pizza = new Pizza(pizzaArgs[1]);
                var doughArgs = Console.ReadLine().Split();
                Dough dough = new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));
                pizza.Dough = dough;

                string toppingInput = Console.ReadLine();

                while (toppingInput != "END")
                {
                    var toppingArgs = toppingInput.Split();
                    Topping topping = new Topping(toppingArgs[1], double.Parse(toppingArgs[2]));
                    pizza.AddTopping(topping);

                    toppingInput = Console.ReadLine();

                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
