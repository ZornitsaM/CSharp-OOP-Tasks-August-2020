namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    using Robots;

    [TestFixture]
    public class RobotsTests
    {
        [Test]

        public void ConstructorRobot()
        {
            var data = new Robot("K", 5);

            string ex = "K";
            int exCap = 5;

            Assert.AreEqual(ex, data.Name);
            Assert.AreEqual(exCap, data.MaximumBattery);
            Assert.AreEqual(exCap, data.Battery);
        }

        [Test]

        public void ConstructorRobotManager()
        {
            var data = new RobotManager(5);
            data.Add(new Robot("K", 6));

            Assert.AreEqual(5, data.Capacity);
            Assert.AreEqual(1, data.Count);

        }


        [Test]

        public void CapacityUnderZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var data = new RobotManager(-20);
            });

        }

        [Test]

        public void CapacityIsEqualZero()
        {
            
             var data = new RobotManager(5);

            Assert.AreEqual(5, data.Capacity);

        }

        [Test]

        public void AddAnExisitingRobbot()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new RobotManager(20);
                data.Add(new Robot("K", 5));
                data.Add(new Robot("K", 6));
            });

        }



        [Test]

        public void FullCapacity()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new RobotManager(1);
                data.Add(new Robot("K", 5));
                data.Add(new Robot("2", 5));
            });

        }

        [Test]

        public void RemoveNonExistingRobot()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new RobotManager(10);
                data.Add(new Robot("K", 5));
                data.Remove("O");
            });

        }

        [Test]

        public void RemoveExistingRobot()
        {
                var data = new RobotManager(10);
                data.Add(new Robot("K", 5));
            data.Add(new Robot("L", 5));
            data.Remove("K");

            Assert.AreEqual(1, data.Count);
            

        }


        [Test]

        public void NonExistingRobotWORK()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new RobotManager(10);
                data.Add(new Robot("K", 5));
                data.Add(new Robot("O", 5));
                data.Add(new Robot("P", 5));
                data.Work("M", "Cleaner", 5);
            });

        }

        [Test]

        public void ExistingRobotWORK()
        {
            var data = new RobotManager(10);
            var robbot = new Robot("K", 5);
            data.Add(robbot);
            data.Add(new Robot("O", 5));
            data.Add(new Robot("P", 5));
            data.Work("K", "Cleaner", 5);


            Assert.AreEqual(0, robbot.Battery);

        }

        [Test]

        public void ExistingRobotWORKWithLowBattery()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new RobotManager(10);
                data.Add(new Robot("K", 5));
                data.Add(new Robot("O", 5));
                data.Add(new Robot("P", 5));
                data.Work("K", "Cleaner", 10);
            });

        }


        [Test]

        public void ExistingRobotWORKWithOKBattery()
        {
                var data = new RobotManager(10);
            var robbot = new Robot("K", 5);
                data.Add(robbot);
                data.Add(new Robot("O", 5));
                data.Add(new Robot("P", 5));
                data.Work("K", "Cleaner", 2);


            Assert.AreEqual(3, robbot.Battery);
          

        }



        [Test]

        public void ChargeNonExistingRobot()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new RobotManager(10);
                data.Add(new Robot("K", 5));
                data.Charge("O");
            });

        }

        [Test]

        public void ChargeExistingRobot()
        {
            var data = new RobotManager(10);
            var robbot = new Robot("K", 10);

            robbot.Battery = 5; //--> за да видим дали се пълне батерията я сетване на по-малко от макс кап.
            data.Add(robbot);

            data.Charge("K");

            Assert.AreEqual(10, robbot.Battery);

        }

    }
}
