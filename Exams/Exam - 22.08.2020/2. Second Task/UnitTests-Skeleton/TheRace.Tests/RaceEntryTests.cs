using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTheUnitCar()
        {
            var data = new UnitCar("M", 5, 6);
            Assert.AreEqual("M", data.Model);
            Assert.AreEqual(5, data.HorsePower);
            Assert.AreEqual(6, data.CubicCentimeters);

        }

        [Test]
        public void TestTheUnitDriver()
        {
            var car = new UnitCar("K", 5, 10);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var data = new UnitDriver(null, car);
            });

        }

        [Test]
        public void TestCorrectUnitCar()
        {
            var car = new UnitCar("K", 5, 10);
            var data = new UnitDriver("L", car);
            Assert.AreEqual("L", data.Name);
            Assert.AreEqual(car, data.Car);

        }


        [Test]
        public void TestTheConstructor()
        {
            var data = new RaceEntry();
            Assert.IsNotNull(data);

        }


        [Test]
        public void TestTheCount()
        {
            var data = new RaceEntry();
            var car = new UnitCar("M", 5, 10);
            var driver = new UnitDriver("L", car);
            data.AddDriver(driver);

            Assert.AreEqual(1, data.Counter);

        }


        [Test]
        public void ADDDriverByNULL()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {

                var data = new RaceEntry();
                var car = new UnitCar("M", 5, 10);
                var driver = new UnitDriver("", car);
                data.AddDriver(null);
            });

        }


        [Test]
        public void ADDContainingDriver()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new RaceEntry();
                var car = new UnitCar("M", 5, 10);
                var driver = new UnitDriver("L", car);
                data.AddDriver(driver);
                data.AddDriver(driver);

            });

        }


        [Test]
        public void CalculatingByLessThan2()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new RaceEntry();
                var car = new UnitCar("M", 5, 10);
                var driver = new UnitDriver("L", car);
                data.AddDriver(driver);
                data.CalculateAverageHorsePower();


            });

        }

        [Test]
        public void JustCalculate()
        {
            var data = new RaceEntry();
            var car1 = new UnitCar("M", 5, 10);
            var car2 = new UnitCar("F", 4, 15);
            var car3 = new UnitCar("U", 3, 18);
            var driver1 = new UnitDriver("L", car1);
            var driver2 = new UnitDriver("P", car2);
            var driver3 = new UnitDriver("O", car3);
            data.AddDriver(driver1);
            data.AddDriver(driver2);
            data.AddDriver(driver3);
            var act  = data.CalculateAverageHorsePower();

            Assert.AreEqual(4, act);

        }

    }
}