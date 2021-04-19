namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;
    using Aquariums;
    using NUnit.Framework;
    

    [TestFixture]

    public class AquariumsTests
    {

        [Test]

        public void TestTheConstructor()
        {
            var data = new Aquarium("Mimi", 5);
            string exName = "Mimi";
            int exCap = 5;

            Assert.AreEqual(exName, data.Name);
            Assert.AreEqual(exCap, data.Capacity);
            
        }

        [Test]

        public void TestTheConstructorListCount()
        {
            var data = new Aquarium("Mimi", 5);
            var fish = new Fish("koko");
            data.Add(fish);
            int exCount = 1;

            Assert.AreEqual(exCount,data.Count);

        }

        [Test]

        public void TestTheNameIfNull()
        {
            var data = new Aquarium("Mimi", 5);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var data = new Aquarium(null, 5);
            });

        }

        [Test]

        public void TestTheNameIfEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var data = new Aquarium(string.Empty, 5);
            });

        }


        //TODO
        [Test]

        public void TestTheNameIfWhiteSpaces()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var data = new Aquarium("", 5);
            });

        }



        [Test]

        public void TestThaCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var data = new Aquarium("Mimi", -1);
            });

        }



        [Test]
        
        public void AddWhenThereisNoCapacity()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Aquarium("Mimi", 5);

                data.Add(new Fish("M"));
                data.Add(new Fish("K"));
                data.Add(new Fish("L"));
                data.Add(new Fish("Y"));
                data.Add(new Fish("R"));
                data.Add(new Fish("R"));

            });
               
        }

        [Test]

        public void AddWhenThereisCapacity()
        {
           var data = new Aquarium("Mimi", 5);

           data.Add(new Fish("M"));
           data.Add(new Fish("K"));
           data.Add(new Fish("L"));
           data.Add(new Fish("Y"));

            int exCount = 4;
            Assert.AreEqual(exCount, data.Count);
        }


        [Test]

        public void RemoveIfThereIsNOTFish()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Aquarium("Momo", 5);
                data.Add(new Fish("K"));
                data.Add(new Fish("M"));
                data.Add(new Fish("O"));

                data.RemoveFish("L");
            });
           
        }

        [Test]

        public void RemoveIfThereIsFish()
        {
                var data = new Aquarium("Momo", 5);
                data.Add(new Fish("K"));
                data.Add(new Fish("M"));
                data.Add(new Fish("O"));

                data.RemoveFish("K");

            int exCount = 2;
            Assert.AreEqual(exCount, data.Count);
          

        }


        [Test]

        public void SellFishWhenIsNotAvailable()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Aquarium("Momo", 5);
                data.Add(new Fish("K"));
                data.Add(new Fish("M"));
                data.Add(new Fish("O"));

                data.RemoveFish("L");
            });

        }

        [Test]

        public void SellFishWhenIsAvailable()
        {
            var data = new Aquarium("Momo", 5);
            Fish fishOne = new Fish("K");
            
            data.Add(fishOne);
            Fish soldFish = data.SellFish("K");
            soldFish.Available = false;

            Assert.AreEqual(false, soldFish.Available);
         

           
           

        }

        [Test]

        public void Report()
        {
            var data = new Aquarium("Momo", 5);
            Fish fishOne = new Fish("K");
            Fish fishTwo = new Fish("M");
            data.Add(fishOne);
            data.Add(fishTwo);

            string ex = "Fish available at Momo: K, M";
            string act = data.Report();

            Assert.AreEqual(ex, act);

        }
    }
}
