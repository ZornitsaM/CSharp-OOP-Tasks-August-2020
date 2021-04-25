namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Computer
    {
		private string name;
        private List<Part> parts;


        //OK
        public Computer(string name)
        {
            this.Name = name;

            this.parts = new List<Part>();
        }



		public string Name
		{
            get
            {
                return this.name;
            }

            //OK X2
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), "Name cannot be null or empty!");
                }

                this.name = value;
            }
		}

        public IReadOnlyCollection<Part> Parts
            => this.parts.AsReadOnly();

        //OK
        public decimal TotalPrice
            => this.Parts.Sum(x => x.Price);

        public void AddPart(Part part)
        {
            //OK
            if (part == null)
            {
                throw  new InvalidOperationException("Cannot add null!");
            }

            this.parts.Add(part);
        }

        //OK
        public bool RemovePart(Part part)
            => this.parts.Remove(part);

        //OK
        public Part GetPart(string partName)
            => this.Parts.FirstOrDefault(x => x.Name == partName);
    }
}
