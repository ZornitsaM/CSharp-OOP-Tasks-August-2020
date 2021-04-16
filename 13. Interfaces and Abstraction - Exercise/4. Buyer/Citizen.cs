using System;
using System.Collections.Generic;
using System.Text;

namespace PO5
{
    public class Citizen : IAge, IId, IBirthday,IBuyer


    {
        private const int food = 0;
        public Citizen(string name, int age, string id, string birthday)
          
           
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
            this.Food = 0;
        }

        
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
        public string Name { get; set; }


        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;

        }
    }
}
