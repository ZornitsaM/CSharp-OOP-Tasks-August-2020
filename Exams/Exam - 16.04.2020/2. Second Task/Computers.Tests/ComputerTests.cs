namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTheConstructorPart()
        {
            var data = new Part("K", 6);

            Assert.AreEqual("K", data.Name);
            Assert.AreEqual(6, data.Price);

      
        }

        [Test]
        public void TestTheConstructorComputer()
        {
            var data = new Computer("O");
            data.AddPart(new Part("r", 5));

            Assert.AreEqual("O", data.Name);
            Assert.IsNotNull(data);


        }
        [Test]
        public void TestTheNameNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var data = new Computer(null);
            });
           

        }

        [Test]
        public void TestTheNameWt()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var data = new Computer("  ");
            });


        }


        [Test]
        public void TotalPrice()
        {
            var data = new Computer("O");
            data.AddPart(new Part("r", 5));
            data.AddPart(new Part("k", 5));
            data.AddPart(new Part("d", 5));
            var result = data.TotalPrice;

            Assert.AreEqual(15, result);
            
        }

        [Test]
        public void AddPartNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new Computer("P");
                data.AddPart(null);
            });


        }

        [Test]
        public void RemovePart()
        {
            var data = new Computer("O");
            Part part = new Part("r", 5);
            data.AddPart(part);
           

            Assert.IsTrue(data.RemovePart(part));

        }

        [Test]
        public void GetPart()
        {
            var data = new Computer("O");
            Part part1 = new Part("r", 5);
            Part part2 = new Part("m", 5);
            data.AddPart(part1);
            data.AddPart(part2);



            Assert.That(data.GetPart("r") == part1);

        }
    }
}