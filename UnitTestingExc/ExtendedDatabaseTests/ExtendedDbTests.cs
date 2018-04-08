using System;
using NUnit.Framework;
using ExtendedDatabase;

namespace ExtendedDatabaseTests
{
    public class ExtendedDatabaseTests
    {
        [Test]
        public void CreatingADatabaseWith16SizeArrayShouldHaveA16SizeArray()
        {
            Database<Person> database = new Database<Person>(new Person[16]);
            Assert.That(database.Elements.Length == 16);
        }

        [Test]
        public void CreatingADatabaseWithEmptyConstructorShouldHaveA16SizeArray()
        {
            Database<Person> database = new Database<Person>();
            Assert.That(database.Elements.Length == 16);
        }

        [Test]
        public void PassingAnArrayWithFewerArgsShouldThrowException()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => new Database<Person>(new Person[1]), "Trying to create a db with wrong size does not throw an exception");
            Assert.That(ex.Message == "Db length should be 16!");
        }

        [Test]
        public void FullDbShouldBeAbleToRemove16Items()
        {
            Database<Person> database = new Database<Person>(new Person[16]);
            for (int i = 0; i < 16; i++)
            {
                database.Remove();
            }
        }

        [Test]
        public void FullDbShouldNotBeAbleToRemove17Items()
        {
            Database<Person> database = new Database<Person>(new Person[16]);

            for (int i = 0; i < 16; i++)
            {
                database.Remove();
            }

            Exception ex = Assert.Throws<InvalidOperationException>(() => database.Remove(), "Removing from an empty db does not throw an exception");
            Assert.That(ex.Message == "Database is empty", "Incorrect exception message");
        }

        [Test]
        public void EmptyDbShouldBeAbleToAdd16Items()
        {
            Database<Person> database = new Database<Person>();

            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, "a" + i));
            }
        }

        [Test]
        public void EmptyDbShouldNotBeAbleToAdd17Items()
        {
            Database<Person> database = new Database<Person>();

            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, "a" + i));
            }

            Exception ex = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(int.MaxValue, "a")), "Adding to a full db does not throw an exception");
            Assert.That(ex.Message == "Database is full!", "Incorrect exception message");
        }

        [Test]
        public void Removing16ItemsAndThenAdding16ItemsShouldWork()
        {
            Database<Person> database = new Database<Person>(new Person[16]);

            for (int i = 0; i < 16; i++)
            {
                database.Remove();
            }

            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, "a" + i));
            }
        }

        [Test]
        public void FetchingDatabaseShouldReturnExactSameSequence()
        {
            Random random = new Random();
            Person[] testArray = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                testArray[i] = new Person(i, "a" + i);
            }

            Database<Person> db = new Database<Person>(testArray);
            Assert.AreEqual(testArray, db.Fetch());
        }

        [Test]
        public void FetchingDatabaseShouldReturnExactSameSequenceTestForTheTest()
        {
            Person[] testArray = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                testArray[i] = new Person(i, "a" + i);
            }

            Database<Person> db = new Database<Person>(testArray);
            Array.Reverse(testArray);
            Assert.AreNotEqual(testArray, db.Fetch());
        }

        [Test]
        public void TestFetchingWithFewerElements()
        {
            Database<Person> db = new Database<Person>();
            db.Add(new Person(1, "A1"));
            db.Add(new Person(2, "A2"));
            db.Add(new Person(3, "A3"));

            Person[] result = db.Fetch();
            Assert.That(result.Length == 3);
            Assert.That(result[0].Equals(new Person(1, "A1")));
            Assert.That(result[1].Equals(new Person(2, "A2")));
            Assert.That(result[2].Equals(new Person(3, "A3")));
        }

        [Test]
        public void AddingANonUniqueByIdElementShouldThrowException()
        {
            Database<Person> db = new Database<Person>();
            db.Add(new Person(1, "A1"));
            db.Add(new Person(2, "A2"));
            Exception ex = Assert.Throws<InvalidOperationException>(() => db.Add(new Person(1, "A3")));
            Assert.That(ex.Message == "Database already contains an element with such Id!");
        }

        [Test]
        public void AddingANonUniqueByUsernameElementShouldThrowException()
        {
            Database<Person> db = new Database<Person>();
            db.Add(new Person(1, "A1"));
            db.Add(new Person(2, "A2"));
            Exception ex = Assert.Throws<InvalidOperationException>(() => db.Add(new Person(3, "A1")));
            Assert.That(ex.Message == "Database already contains an element with such Name");
        }

        [Test]
        public void FindElementByUsernameShouldReturnCorrectElement()
        {
            Database<Person> db = new Database<Person>();
            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, "a" + i));
            }

            Person personToFind = db.FindByUsername("a10");
            Assert.That(personToFind.Equals(new Person(10, "a10")));
        }

        [Test]
        public void PassingNullOrWhiteSpaceStringToFindByUsernameShouldThrowException()
        {
            Database<Person> db = new Database<Person>();
            db.Add(new Person(1, "A1"));
            db.Add(new Person(2, "A2"));
            bool exceptionIsThrown = false;

            try
            {
               var a = db.FindByUsername(" ");
            }
            catch(ArgumentException ex)
            {
               exceptionIsThrown = true;
               Assert.That(ex.ParamName == "Argument cannot be null or whitespace!");
            }

            Assert.That(exceptionIsThrown);
            exceptionIsThrown = false;

            try
            {
                db.FindByUsername(string.Empty);
            }
            catch (ArgumentException ex2)
            {
                exceptionIsThrown = true;
                Assert.That(ex2.ParamName == "Argument cannot be null or whitespace!");
            }

            Assert.That(exceptionIsThrown);
            exceptionIsThrown = false;

            try
            {
                db.FindByUsername(null);
            }
            catch (ArgumentException ex3)
            {
                exceptionIsThrown = true;
                Assert.That(ex3.ParamName == "Argument cannot be null or whitespace!");
            }

            Assert.That(exceptionIsThrown);
        }
    }
}