namespace DateTime.Tests
{
    using System;
    using DateTimeNowAddDays;
    using Moq;
    using NUnit.Framework;

    public class DateTimeTests
    {
        private Mock<IDateTime> mockedDateTime;

        [SetUp]
        public void InitializeDateTime()
        {
            this.mockedDateTime = new Mock<IDateTime>();
        }

        [Test]
        public void DateTimeShouldReturnCorrectDate()
        {
            this.mockedDateTime.Setup(d => d.Now).Returns(DateTime.Now);

            string actual = DateTime.Now.ToShortDateString();
            string expected = this.mockedDateTime.Object.Now.ToShortDateString();
            string errorMsg = $"Method did not return the correct value. Expected: {expected}, actual: {actual}";

            Assert.That(expected.Equals(actual), errorMsg);
        }

        [Test]
        public void DateTimeShouldReturnCorrectTime()
        {
            this.mockedDateTime.Setup(d => d.Now).Returns(DateTime.Now);
            string actual = DateTime.Now.ToShortTimeString();
            string expected = this.mockedDateTime.Object.Now.ToShortTimeString();
            string errorMsg = $"Method did not return the correct value. Expected: {expected}, actual: {actual}";

            Assert.That(expected.Equals(actual), errorMsg);
        }

        [Test]
        public void AddDayInMiddleOfMonthShouldWorkProperly()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(new DateTime(2018, 04, 7));
            DateTime dateTime = this.mockedDateTime.Object.Now.AddDays(1);
            Assert.AreEqual(8, dateTime.Day);
        }

        [Test]
        public void AddDayAndChangeMonthShouldWorkProperly()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(new DateTime(2018, 04, 30));
            DateTime dateTime = this.mockedDateTime.Object.Now.AddDays(1);

            Assert.That(1 == dateTime.Day, "Day did not change when adding extra day at month's end");
            Assert.That(5 == dateTime.Month, "Month did not change when adding extra day at month's end");
        }

        [Test]
        public void AddNegativeDaysShouldWorkProperly()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(new DateTime(2018, 04, 07));
            DateTime dateTime = this.mockedDateTime.Object.Now.AddDays(-5);
            Assert.That(4 == dateTime.Month, "Month did change when adding negative days at months middle");
            Assert.That(2 == dateTime.Day, "Day did not change correctly when adding negative days");
        }

        [Test]
        public void AddNegativeDaysAndChangeMonthShouldWorkProperly()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(new DateTime(2018, 04, 01));
            DateTime dateTime = this.mockedDateTime.Object.Now.AddDays(-1);
            Assert.That(31 == dateTime.Day);
            Assert.That(3 == dateTime.Month);
        }

        [Test]
        public void AddDayToLeapYearFebruaryShouldWorkProperly()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(new DateTime(1984, 02, 28));
            DateTime dateTime = this.mockedDateTime.Object.Now.AddDays(1);
            Assert.That(29 == dateTime.Day);
            Assert.That(2 == dateTime.Month);
        }

        [Test]
        public void AddDayToNonLeapYearFebruaryShouldWorkProperly()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(new DateTime(2018, 02, 28));

            DateTime dateTime = this.mockedDateTime.Object.Now.AddDays(1);
            Assert.That(1 == dateTime.Day);
            Assert.That(3 == dateTime.Month);
        }

        [Test]
        public void AddDayToDateTimeMinValueShouldWorkProperly()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(DateTime.MinValue);
            Assert.DoesNotThrow(() => this.mockedDateTime.Object.Now.AddDays(1));
        }

        [Test]
        public void SubtractDayToDateTimeMinValueShouldThrowException()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(DateTime.MinValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => this.mockedDateTime.Object.Now.AddDays(-1));
        }

        [Test]
        public void AddDayToDateTimeMaxValueShouldThrowException()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(DateTime.MaxValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => this.mockedDateTime.Object.Now.AddDays(1));
        }

        [Test]
        public void SubtractDayToDateTimeMaxValueShouldWorkProperly()
        {
            this.mockedDateTime.Setup(x => x.Now).Returns(DateTime.MaxValue);
            Assert.DoesNotThrow(() => this.mockedDateTime.Object.Now.AddDays(-1));
        }
    }
}