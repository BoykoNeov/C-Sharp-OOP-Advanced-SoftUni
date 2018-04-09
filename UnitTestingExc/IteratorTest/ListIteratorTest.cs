using System;
using System.Reflection;
using Iterator;
using NUnit.Framework;

namespace IteratorTest
{
    public class ListIteratorTest
    {
        [Test]
        public void CreatingIteratorWitNullArgumentsShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new ListIterator(null));
        }

        [Test]
        public void MoveShouldReturnTrueWhenThereIsNextElement()
        {
            ListIterator listIterator = new ListIterator("a", "b");
            Assert.That(listIterator.Move() == true);
        }

        [Test]
        public void MoveShouldReturnFalseWhenThereIsNoNextElement()
        {
            ListIterator listIterator = new ListIterator("a", "b");
            listIterator.Move();
            Assert.That(listIterator.Move() == false);
        }

        [Test]
        public void HasNextShouldReturnTrueWhenThereIsNextElement()
        {
            ListIterator listIterator = new ListIterator("a", "b");
            Assert.That(listIterator.HasNext() == true);
        }

        [Test]
        public void HasNextShouldReturnFalseWhenThereIsNoNextElement()
        {
            ListIterator listIterator = new ListIterator("a");
            Assert.That(listIterator.HasNext() == false);
        }

        [Test]
        public void CallingPrintOnEmptyCollectionShouldThrowException()
        {
            ListIterator iterator = new ListIterator();
            Exception ex = Assert.Throws<InvalidOperationException>(() => iterator.Print());
            Assert.That(ex.Message == "Invalid Operation!");
        }

        [Test]
        public void IteratorShouldPrintTheCorrectElement()
        {
            ListIterator iterator = new ListIterator("a", "b");
            FieldInfo lastPrintedField = iterator.GetType().GetField("lastPrinted", BindingFlags.NonPublic | BindingFlags.Instance);
            iterator.Print();
            string comparator = (string)lastPrintedField.GetValue(iterator);
            Assert.That("a".Equals(comparator));
            iterator.Move();
            iterator.Print();
            comparator = (string)lastPrintedField.GetValue(iterator);
            Assert.That("b".Equals(comparator));
        }
    }
}