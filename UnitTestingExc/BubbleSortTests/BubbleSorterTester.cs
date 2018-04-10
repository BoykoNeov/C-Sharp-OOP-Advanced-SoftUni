using System.Linq;
using BubbleSorter;
using NUnit.Framework;

namespace BubbleSortTests
{
    public class BubbleSorterTester
    {
        [Test]
        public void SorterTest()
        {
            int[] testInts = new int[] { 1, 4, 5, -10, 20, 0 };
            testInts = BubbleSorter<int>.BubbleSort(testInts).ToArray();
            Assert.That(testInts.SequenceEqual(new int[] { -10, 0, 1, 4, 5, 20 }));
        }

        [Test]
        public void SorterTest2()
        {
            int[] testInts = new int[] { 100, 1, 4, 5, -10, 20, 0, 1, -100 };
            testInts = BubbleSorter<int>.BubbleSort(testInts).ToArray();
            Assert.That(testInts.SequenceEqual(new int[] { -100, -10, 0, 1, 1, 4, 5, 20, 100 }));
        }
    }
}