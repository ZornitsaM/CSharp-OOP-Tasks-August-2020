
using System;
namespace Skeleton
{
    public class Dragon
    {
        private IIntroducer introducer;
        public Dragon(string name, ConsoleIntroducer introducer)
        {

            this.Name = name;
            this.introducer=introducer;
        }
        public string Name { get;}

        public void Introduce()
        {
            introducer.Introduce($"My name is{this.Name}");
        }
    }
}
