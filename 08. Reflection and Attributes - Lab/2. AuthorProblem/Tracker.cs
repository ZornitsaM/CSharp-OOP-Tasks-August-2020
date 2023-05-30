using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes<AuthorAttribute>();

                foreach (AuthorAttribute attr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }

        public void PrintClassesByAuthor()
        {
            var type = Assembly.GetExecutingAssembly().GetTypes();
            
            foreach (var currentType in type)
            {
                var attributes = currentType.GetCustomAttributes<AuthorAttribute>();

                foreach (AuthorAttribute attr in attributes)
                {
                    Console.WriteLine($"{currentType} is written by {attr.Name}");

                }
            }
        }
    }
}
