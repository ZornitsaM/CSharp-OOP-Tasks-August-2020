

using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private readonly Dictionary<string, IRobot> robots;
        private const int capacity = 10;
        public int Capacity => capacity;
        public IReadOnlyDictionary<string, IRobot> Robots => (IReadOnlyDictionary<string, IRobot>)this.robots;


        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public void Manufacture(IRobot robot)
        {
            if (Capacity==this.robots.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.robots.ContainsKey(robot.Name))
            {
                string final =  string.Format(ExceptionMessages.ExistingRobot, robot.Name);
                Console.WriteLine(final);
            }

           this.robots.Add(robot.Name, robot);
        }
        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }

            IRobot robot = this.robots[robotName];
            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robot.Name);

        }
    }
}
