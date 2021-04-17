using System;

namespace Skeleton
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var dragon = new Dragon("Drago", new ConsoleIntroducer());
            dragon.Introduce();

        }
    }
}
