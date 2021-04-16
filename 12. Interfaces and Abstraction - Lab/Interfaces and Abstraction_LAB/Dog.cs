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

        public string FirstName 
        { get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        dog
        
    }
}
