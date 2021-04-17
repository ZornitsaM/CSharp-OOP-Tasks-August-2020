using System;
using NUnit.Framework;


namespace Tests
{
    using Database;

    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        public void ConstructionEmptyCollection()
        {
            Database database = new Database();

            int actualResult = database.Count;
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]

        public void ConstructionReturnSomeResult()
        {
            Database database = new Database(1,2);

            int actualResult = database.Count;
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);

        }


        //[Test]

        //public void ConstructionReturntTwoNumbers()
        //{
        //    Database database = new Database(1, 2);

        //    int[] actualResult = database.Fetch();
        //    int[] expectedResult = { 1, 2 };

        //    Assert.AreEqual(expectedResult, actualResult);

        //}


        [Test]

        public void ConstructorWithMoreThan16Elements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(new int[17]);
            });
                
        }


        [Test]

        public void ByAddTestingMoreThan16Elements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(new int[16]);
                database.Add(1);
            });

        }


        [Test]

        public void ByAddTestingMoreLessThan16Elements() //---> œ⁄–¬» ¬¿–»¿Õ“
        {
            Database database = new Database(new int[14]);
            database.Add(1);

            int expectedResult = 15;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);

        }


        //[Test]

        //public void AdddTwoNumbersByAddTestingMoreLessThan16Elements()//---> ¬“Œ–» ¬¿–»¿Õ“
        //{
        //    Database database = new Database();
        //    database.Add(2);
        //    database.Add(3);

        //    int[] expectedResult = { 2, 3 };
        //    int[] actualResult = database.Fetch();

        //    Assert.AreEqual(expectedResult, actualResult);

        //}


        [Test]

        public void RemoveWhenCountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database();
                database.Remove();
            });

        }

        [Test]

        public void RemoveWhenCountIsUpperThanZero() 
        {
            Database database = new Database(new int[2]);
            database.Remove();


            int expectedResult = 1;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);

        }



        //[Test]

        //public void RemoveWhenCountCollectionIsUpperThanZero()
        //{
        //    Database database = new Database(1,2,3);
        //    database.Remove();

        //    int[] expectedResult = { 1, 2 };
        //    int[] actualResult = database.Fetch();

        //    Assert.AreEqual(expectedResult, actualResult);

        //}

        [Test]

        public void Fetch()
        {
            Database database = new Database(1,2);
           
            int[] expectedResult = { 1, 2 };
            int[] actualResult = database.Fetch();

            Assert.AreEqual(expectedResult, actualResult);

        }


    }
}