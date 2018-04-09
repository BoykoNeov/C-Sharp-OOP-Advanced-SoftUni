namespace MathClass.Tests
{
    using NUnit.Framework;
    using System;

    public class MathClassTests
    {
        [TestCase(0.6, ExpectedResult = 0.9272952180016123)]
        [TestCase(0.5, ExpectedResult = 1.0471975511965979)]
        public double ArcusCosineShouldReturnCorrectValue(double input)
        {
            double result = Math.Acos(input);
            return Math.Acos(input);
        }

        [TestCase(-1, 1)]
        [TestCase(-1.5, 1.5)]
        [TestCase(-2147483647, 2147483647)]
        public void AbsoluteMethodShouldReturnPositiveValue(double input, double expected)
        {
            var actual = Math.Abs(input);
            Assert.That(expected.Equals(actual));
        }

        [TestCase(-1, 1)]
        [TestCase(-1.5, 1.5)]
        [TestCase(-2147483647, 2147483647)]
        public void AbsoluteMethodShouldReturnPositiveValue(decimal input, decimal expected)
        {
            decimal actual = Math.Abs(input);
            Assert.That(expected.Equals(actual));
        }


        [TestCase(9.3, 9)]
        [TestCase(1.99, 1)]
        [TestCase(0.999999999, 0)]
        [TestCase(-2.5, -3)]
        public void FloorMethodShouldReturnExpectedValue(double input, double expected)
        {
            double actual = Math.Floor(input);

            Assert.That(expected.Equals(actual));
        }
    }
}