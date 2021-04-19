

using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections.Generic;
using AquaShop.Utilities.Messages;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishs;


        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishs = new List<IFish>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                //TODO 

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public  int Capacity { get; }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();
        public ICollection<IFish> Fish => this.fishs.AsReadOnly();






        public  void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }
        public  void AddFish(IFish fish)
        {
            if (this.Fish.Count==this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fishs.Add(fish);

        }
        public  void Feed()
        {
            foreach (var currentFish in this.Fish)
            {
                currentFish.Eat();
            }
            

        }
        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {(this.fishs.Any() ? string.Join(", ", this.fishs.Select(x=>x.Name)) : "none")}");
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");


            return sb.ToString().TrimEnd();

        }

        public bool RemoveFish(IFish fish)
        => this.fishs.Remove(fish);
    }
}
