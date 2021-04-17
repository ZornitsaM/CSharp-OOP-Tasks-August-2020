using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public void ByEmptyConstructor()
        {
            var data = new ExtendedDatabase();
            int ex = 0;
            int act = data.Count;
            Assert.AreEqual(ex, act);

        }

        [Test]

        public void ConstructorUpperThan16()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var data = new ExtendedDatabase(new Person[17]);
            });

        }


        [Test]

        public void ConstructorByAddingPeople()
        {
            var data = new ExtendedDatabase(new Person(92,"Popo"));
           
            Assert.AreEqual(1, data.Count);

        }


        [Test]

        public void AddMethodUpperThan16()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person[] persons = new Person[16];
               
                for (int i = 0; i < 16; i++)
                {
                    persons[i] = new Person(i + 1, $"A{i}");
                   
                }
                var data = new ExtendedDatabase(persons);
                data.Add(new Person(92, "Popo"));

            });

        }


        [Test]

        public void AddPersonWithSameNameThroughConstructor()
        {
            Person one = new Person(1, "A");
            Person two = new Person(2, "A");


            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new ExtendedDatabase(one, two);
            });

        }

        [Test]

        public void AddPersonWithSameIDThroughConstructor()
        {
            Person one = new Person(1, "A");
            Person two = new Person(1, "B");


            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new ExtendedDatabase(one, two);
            });

        }

        [Test]

        public void AddPersonWithTheSameUser()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person[] persons = new Person[2];

                for (int i = 0; i < 2; i++)
                {
                    persons[i] = new Person(i + 1, $"A{i}");

                }
                var data = new ExtendedDatabase(persons);
                data.Add(new Person(2, "A1"));

            });

        }


        [Test]

        public void AddPersonWithTheSameId()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person[] persons = new Person[2];

                for (int i = 0; i < 2; i++)
                {
                    persons[i] = new Person(i + 1, $"A{i}");

                }
                var data = new ExtendedDatabase(persons);
                data.Add(new Person(1, "A2"));

            });

        }

        [Test]

        public void JustAddANewPerson()
        {
            Person expectedResult = new Person(92, "Popo");
            var data = new ExtendedDatabase();
            data.Add(expectedResult);
            int ex = 1;
            int act = data.Count;

            Assert.AreEqual(ex, act);

        }


        [Test]

        public void RemoveByEmptyCount()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new ExtendedDatabase();
                data.Remove();

            });

        }



        [Test]

        public void RemoveByCountUpperThanZero()
        {
            var data = new ExtendedDatabase(new Person(92,"Lolo"));
            data.Remove();
            int ex = 0;
            int act = data.Count;

            Assert.AreEqual(ex, act);

        }


        [Test]

        public void FindByUsernameWhenNameIsNull()
        {
            Person person = new Person(92, "Gogo");

            Assert.Throws<ArgumentNullException>(() =>
            {
                //var data = new ExtendedDatabase(person);
                var data = new ExtendedDatabase();
                data.FindByUsername(null);
            });
        }


        [Test]

        public void FindByUsernameWhenNameIsEmpty()
        {
            Person person = new Person(92, "Gogo");

            Assert.Throws<ArgumentNullException>(() =>
            {
                //var data = new ExtendedDatabase(person);
                var data = new ExtendedDatabase();
                data.FindByUsername(string.Empty);
            });
        }

        [Test]

        public void FindByUsernameWhenNameIsOnlyWhitespace()
        {
            Person person = new Person(92, "Gogo");

            Assert.Throws<ArgumentNullException>(() =>
            {
                //var data = new ExtendedDatabase(person);
                var data = new ExtendedDatabase();
                data.FindByUsername("");
            });
        }


        [Test]

        public void FindByUsernameWhenNameIsNotExistByEmptyCollection()
        {
            //Person person = new Person(92, "Gogo");

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new ExtendedDatabase();
                data.FindByUsername("Popo");
            });
        }


        [Test]

        public void FindByUsernameWhenNameIsNotExist()
        {
            Person person = new Person(92, "Gogo");

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new ExtendedDatabase(person);
                data.FindByUsername("Popo");
            });
        }

        [Test]

        public void JustFindByUserName()
        {
            Person person = new Person(92, "Mimi");
            var data = new ExtendedDatabase(person);
            Person current = data.FindByUsername("Mimi");

            Assert.AreEqual(92, current.Id);
            Assert.AreEqual("Mimi", current.UserName);

        }

        [Test]

        public void FindByIdWhenIsLowerThanZero()
        {
            //Person person = new Person(92, "Gogo");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var data = new ExtendedDatabase();
                data.FindById(-2);
            });
        }


        [Test]

        public void FindByIdWhenIdIsNotExistByNoPeople()
        {
            //Person person = new Person(92, "Gogo");

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new ExtendedDatabase();
                data.FindById(3);
            });
        }


        [Test]

        public void FindByIdWhenIdIsNotExist()
        {
            Person person = new Person(92, "Gogo");

            Assert.Throws<InvalidOperationException>(() =>
            {
                var data = new ExtendedDatabase(person);
                data.FindById(3);
            });
        }

        [Test]

        public void JustFindById()
        {
            Person person = new Person(92, "Mimi");
            var data = new ExtendedDatabase(person);
            Person current = data.FindById(92);


            Assert.AreEqual(92, current.Id);
            Assert.AreEqual("Mimi", current.UserName);

        }
    }
}

        