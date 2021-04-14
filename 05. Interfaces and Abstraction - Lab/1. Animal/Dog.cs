using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_and_Abstraction_LAB
{
    class Dog : Animal,IObject
    {
        public Dog()
        {

        }
        Dog dog = new Dog();

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
