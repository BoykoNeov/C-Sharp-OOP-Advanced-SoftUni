using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Reflection;
using System.Linq;

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
            Assert.That(linkedList.SequenceEqual(new int[] { 5, 10, 15 }));
        }
    }
}