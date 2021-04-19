

using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly List<IAquarium> aquariums;


        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType== "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }

            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);
            string result = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            return result;


        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType== nameof(Ornament))
            {
                decoration = new Ornament();
            }

            else if (decorationType== nameof(Plant))
            {
                decoration = new Plant();
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);
            string result = string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            return result;
        }





        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            

            if (fishType=="FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }

            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            //TODO
            if (fish.GetType()==typeof(FreshwaterFish) && aquarium.GetType()==typeof(FreshwaterAquarium))
            {
                aquarium.AddFish(fish);
                string result = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                return result;
            }

            //TODO
            if (fish.GetType() == typeof(SaltwaterFish) && aquarium.GetType() == typeof(SaltwaterAquarium))
            {
                aquarium.AddFish(fish);
                string result = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                return result;
            }

            return OutputMessages.UnsuitableWater;
        }



        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var totalPrice = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price);

            //TODO 2 SECOND DECIMAL POINT
            string result = string.Format(OutputMessages.AquariumValue, aquariumName,totalPrice);
            return result;
        }



        public string FeedFish(string aquariumName)
        {
            
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            foreach (var item in aquarium.Fish)
            {
                item.Eat();
            }

            string result = string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
            return result;
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (decoration==null)
            {
                string format = string.Format(ExceptionMessages.InexistentDecoration, decorationType);
                throw new InvalidOperationException(format);
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);
            string result = string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.aquariums)
            {
                sb.AppendLine(item.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
