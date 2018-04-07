using System;
using NUnit.Framework;
using Database_01;

namespace DatabaseTests
{
    public class DatabaseTests
    {
        [Test]
        public void CreatingADatabaseWith16SizeArrayShouldHaveA16SizeArray()
        {
            Database database = new Database(new int[16]);
            Assert.That(database.Ints.Length == 16);
        }

        [Test]
        public void CreatingADatabaseWithEmptyConstructorShouldHaveA16SizeArray()
        {
            Database database = new Database();
            Assert.That(database.Ints.Length == 16);
        }

        [Test]
        public void PassingAnArrayWithFewerArgsShouldThrowException()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => new Database(new int[1]), "Trying to create a db with wrong size does not throw an exception");
            Assert.That(ex.Message == "Db length should be 16!");
        }

        [Test]
        public void FullDbShouldBeAbleToRemove16Items()
        {
            Database database = new Database(new int[16]);
            for (int i = 0; i < 16; i++)
            {
                database.Remove();
            }
        }

        [Test]
        public void FullDbShouldNotBeAbleToRemove17Items()
        {
            Database database = new Database(new int[16]);

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
            Database database = new Database();
            Random random = new Random();

            for (int i = 0; i < 16; i++)
            {
                database.Add(random.Next(int.MinValue, int.MaxValue));
            }
        }

        [Test]
        public void EmptyDbShouldNotBeAbleToAdd17Items()
        {
            Database database = new Database();
            Random random = new Random();

            for (int i = 0; i < 16; i++)
            {
                database.Add(random.Next(int.MinValue, int.MaxValue));
            }

            Exception ex = Assert.Throws<InvalidOperationException>(() => database.Add(random.Next()), "Adding to a full db does not throw an exception");
            Assert.That(ex.Message == "Database is full!", "Incorrect exception message");
        }

        [Test]
        public void Removing16ItemsAndThenAdding16ItemsShouldWork()
        {
            Database database = new Database(new int[16]);
            Random random = new Random();

            for (int i = 0; i < 16; i++)
            {
                database.Remove();
            }

            for (int i = 0; i < 16; i++)
            {
                database.Add(random.Next(int.MinValue, int.MaxValue));
            }
        }

        [Test]
        public void FetchingDatabaseShouldReturnExactSameSequence()
        {
            Random random = new Random();
            int[] testArray = new int[16];

            for (int i = 0; i < 16; i++)
            {
                testArray[i] = random.Next();
            }

            Database db = new Database(testArray);
            Assert.AreEqual(testArray, db.Fetch());
        }

        [Test]
        public void FetchingDatabaseShouldReturnExactSameSequenceTestForTheTest()
        {
            Random random = new Random();
            int[] testArray = new int[16];

            for (int i = 0; i < 16; i++)
            {
                testArray[i] = random.Next();
            }

            Database db = new Database(testArray);
            Array.Reverse(testArray);
            Assert.AreNotEqual(testArray, db.Fetch());
        }

        [Test]
        public void TestFetchingWithFewerElements()
        {
            Database db = new Database();
            db.Add(5);
            db.Add(6);
            db.Add(-1000);

            int[] result = db.Fetch();
            Assert.That(result.Length == 3);
            Assert.That(result[0] == 5);
            Assert.That(result[1] == 6);
            Assert.That(result[2] == -1000);
        }
    }
}