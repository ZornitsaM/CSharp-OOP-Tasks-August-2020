using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_LAB
{
    public class Sorter
    {
        public ICollection<int> Sort(ICollection<int> collection,string algorithm)
        {
            if (algorithm.ToLower()=="selection")
            {
                return SelectionSort(collection);
            }

            else if (algorithm.ToLower() == "quick")
            {
                return QuickSort(collection);
            }
            throw new ArgumentException();

        }

         ICollection<int> SelectionSort(ICollection<int> collection)
        {
            Console.WriteLine("Selection rulz");
            return collection;
        }

        ICollection<int> QuickSort(ICollection<int> collection)
        {
            Console.WriteLine("Quick rulz");
            return collection;
        }
    }
}
