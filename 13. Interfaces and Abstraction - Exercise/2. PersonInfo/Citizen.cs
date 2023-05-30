using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonInfo
{
    public class Citizen : ILastNumberable
    {
        private string name;
        private string id;

        public Citizen(string name,  string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
      
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public void LastNumbers(string id, string number)
        {
            int countOfInpuNumber = number.Length;
            string lastCharNumbers = string.Empty;

            for (int i = id.Length - countOfInpuNumber; i <id.Length; i++)
            {
                lastCharNumbers += id[i];
            }

            if (lastCharNumbers==number)
            {
                Console.WriteLine(this.Id);
            }
        }
    }
}
