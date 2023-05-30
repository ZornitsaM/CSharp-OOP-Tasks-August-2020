using PersonInfo;
using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split();
            var inputSites= Console.ReadLine().Split();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                StationaryPhone phone = new StationaryPhone();
                phone.Call(inputNumbers[i]);
            }

            for (int i = 0; i < inputSites.Length; i++)
            {
                Smartphone smart = new Smartphone();
                smart.Browse(inputSites[i]);
            }
        }
    }
}
