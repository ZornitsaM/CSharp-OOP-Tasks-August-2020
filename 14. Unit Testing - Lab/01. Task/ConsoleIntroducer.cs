
using System;
namespace Skeleton
{
    public class ConsoleIntroducer : IIntroducer
    {
        public void Introduce(string message)
        {
           Console.WriteLine(message);
        }
    }
}
