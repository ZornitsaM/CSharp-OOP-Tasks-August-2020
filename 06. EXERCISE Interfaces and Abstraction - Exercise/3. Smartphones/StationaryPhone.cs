using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonInfo
{
    public class StationaryPhone : ICallable
    {
        public void Call(string phoneNumber)
        {
            bool isInvalid = false;
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                isInvalid = true;
                Console.WriteLine("Invalid number!");

            }

            if (!isInvalid && phoneNumber.Length == 10)
            {
                Console.WriteLine($"Calling... {phoneNumber}");
            }

            else if (!isInvalid && phoneNumber.Length == 7)
            {
                Console.WriteLine($"Dialing... { phoneNumber}");
            }
        }
    }
}
