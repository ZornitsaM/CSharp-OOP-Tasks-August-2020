using System;
using System.Collections.Generic;
using System.Text;

namespace PO5
{
    public class Pet : IName, IBirthday
    {
        public Pet(string name, string birthday)
          
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}
