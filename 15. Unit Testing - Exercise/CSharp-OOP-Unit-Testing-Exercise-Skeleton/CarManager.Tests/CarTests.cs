
using CarManager;
using NUnit.Framework;
using System;
using System.Xml.Schema;


namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstruktorShouldInitializeCorrectly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCpacity = 100;
            

            var car = new Car(make, model, fuelConsumption, fuelCpacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCpacity, car.FuelCapacity);
        }


        //[Test]
        //public void MakeShouldThrowExeption()
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        string make = null;
        //        string model = "Golf";
        //        double fuelConsumption = 2;
        //        double fuelCpacity = 100;

        //        Car car = new Car(make, model, fuelConsumption, fuelCpacity);

        //    });

        //}


        //[Test]
        //public void ModelShouldThrowExeption()
        //{

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        string make = "VW";
        //        string model = null;
        //        double fuelConsumption = 2;
        //        double fuelCpacity = 100;

        //        Car car = new Car(make, model, fuelConsumption, fuelCpacity);

        //    });

        //}


        //[Test]
        //public void FuelCinsumptionShouldThrowExeption()
        //{

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        string make = "VW";
        //        string model = "Golf";
        //        double fuelConsumption = 0;
        //        double fuelCpacity = 100;

        //        Car car = new Car(make, model, fuelConsumption, fuelCpacity);

        //    });

        //}

        //[Test]
        //public void FuelQuantityShouldThrowExeption()
        //{

        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        string make = "VW";
        //        string model = "Golf";
        //        double fuelConsumption = 2;
        //        double fuelCpacity = 0;

        //        Car car = new Car(make, model, fuelConsumption, fuelCpacity);

        //    });

        //}

        [Test]
        [TestCase(null,"Golf",20,10)]
        [TestCase("VW", null, 20, 10)]
        [TestCase("VW", "Golf", -10, 20)]
        [TestCase("VW", "Golf", -0, 20)]
        [TestCase("VW", "Golf", 10, -20)]
        [TestCase("VW", "Golf", 10, 0)]

        public void AllPropertiesMustThrowExeption(string make,string model,double fuelConsumption,
            double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));

        }

        [Test]
        public void ShouldRefuelNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCpacity = 100;


            Car car = new Car(make, model, fuelConsumption, fuelCpacity);
            int expectedFuelAmount = 10;

            car.Refuel(10);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);

        }

        [Test]
        public void ShouldRefuelUntilTheTotalFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCpacity = 100;


            Car car = new Car(make, model, fuelConsumption, fuelCpacity);
            
            car.Refuel(150);
            int expectedFuelAmount = 100;
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);

        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void ShouldRefuelThrowExByNegativeValue(double inputAmount)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCpacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCpacity);
            Assert.Throws<ArgumentException>(() => car.Refuel(inputAmount));
        }

        [Test]
        public void ShouldDriveNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCpacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCpacity);
            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);

        }

        [Test]
        public void ShouldDriveByEx()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCpacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCpacity);
            Assert.Throws<InvalidOperationException>(() => car.Drive(20));
           
        }
    }
}