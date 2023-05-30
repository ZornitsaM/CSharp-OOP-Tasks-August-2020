using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList :List<string>
    {
        private Random random = new Random();

        public string RandomString()
        {
            var elementIndex = random.Next(0, this.Count);
            var element = this[elementIndex];
            this.RemoveAt(elementIndex);

            return element;
        }
    }
}
