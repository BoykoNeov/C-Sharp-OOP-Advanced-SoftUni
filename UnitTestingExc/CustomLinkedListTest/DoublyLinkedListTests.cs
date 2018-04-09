using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CustomLinkedListTest
{
    public class DoblyLinkedListTests
    {
        [Test]
        public void AddingElementToLinkedList()
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();
            linkedList.Add(5);
            linkedList.Add(10);
            linkedList.Add(15);

            Assert.That(linkedList.SequenceEqual(new int[] { 5, 10, 15 }), "Add does not add correctly elements to the linked list");
        }

        [Test]
        public void TestLinkedListHasCorrectNumberOfElementsAfterAdd()
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();
            for (int i = 0; i < 100; i++)
            {
                linkedList.Add(i);
            }

            Assert.That(linkedList.Count == 100);
        }

        [Test]
        public void TestAddBeforeWorksCorrectly()
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>
            {
                1,
                2
            };

            linkedList.Clear();
            Assert.That(linkedList.SequenceEqual(new int[0]));
        }

        [Test]
        public void TestRemoveWorksCorrectly()
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>
            {
                1,
                2,
                5,
                6
            };

            linkedList.Remove(5);
            Assert.That(linkedList.SequenceEqual(new int[] { 1, 2, 6 }));
        }

        [Test]
        public void TestRemoveFirst()
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>
            {
                1,
                2,
                5,
                6
            };

            linkedList.RemoveFirst();
            Assert.That(linkedList.SequenceEqual(new int[] { 2, 5, 6 }),"Remove first does not remove first element in collection");
        }

        [Test]
        public void TestForEachWorksCorrectly()
        {
            List<int> testList = new List<int>();
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>
            {
                1,
                2,
                5,
                6
            };

            linkedList.ForEach(testList.Add);
            Assert.That(testList.SequenceEqual(linkedList), "For each is no applied successfully to each linked list element");
        }

        [Test]
        public void TestTryingToRemoveItemFromEmptyListThrowsCorrectException()
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();
            Exception ex = Assert.Throws<InvalidOperationException>(() => linkedList.RemoveFirst());
            Assert.That(ex.Message.Equals("List is empty!"), "Trying to remove element from empty list does not throw correct exception");
        }
    }
}