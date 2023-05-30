using System;
using ValidationAttributes.Models;

namespace ValidationAttributes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person
             (
                 "POPO",
                 36
             );

            bool isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);
        }
    }
}
