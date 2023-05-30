using System;
using System.Collections.Generic;
using System.Text;

namespace PO5
{
    public class Rebel : IAge, IBuyer
    {
        private string group;
        private const int food = 0;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public int Age { get; set; }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public int Food { get; set; }

        public string Name { get; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
