namespace Robots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RobotManager
    {
        private List<Robot> robots;
        private int capacity;


        //OK
        public RobotManager(int capacity)
        {
            this.robots = new List<Robot>();
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            //OK
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid capacity!");
                }
                //OK
                this.capacity = value;
            }
        }


        //OK
        public int Count => this.robots.Count;

        public void Add(Robot robot)
        {
            //OK
            if (this.robots.Any(r => r.Name == robot.Name))
            {
                throw new InvalidOperationException($"There is already a robot with name {robot.Name}!");
            }


            //OK
            else if (this.robots.Count == this.capacity)
            {
                throw new InvalidOperationException("Not enough capacity!");
            }

            this.robots.Add(robot);
        }

        public void Remove(string name)
        {
            Robot robotToRemove = this.robots.FirstOrDefault(r => r.Name == name);

            //OK
            if (robotToRemove == null)
            {
                throw new InvalidOperationException($"Robot with the name {name} doesn't exist!");
            }

            //OK
            this.robots.Remove(robotToRemove);
        }

        public void Work(string robotName, string job, int batteryUsage)
        {
            Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

            //OK
            if (robot == null)
            {
                throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
            }
            //OK
            else if (robot.Battery < batteryUsage)
            {
                throw new InvalidOperationException($"{robot.Name} doesn't have enough battery!");
            }

            //OK
            robot.Battery -= batteryUsage;
        }

        public void Charge(string robotName)
        {
            Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

            //OK
            if (robot == null)
            {
                throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
            }


            //ok
            robot.Battery = robot.MaximumBattery;
        }
    }
}
