namespace Tweeter.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Tweeter.Models;
    using Tweeter.Models.Contracts;

    public class TweeterTests
    {
        private IClient client;
        private IList<ITweet> testTweeters;

        [SetUp]
        public void InitializeData()
        {
            this.testTweeters = new List<ITweet>
            {
                new Tweet("First message"),
                new Tweet("Second message"),
                new Tweet("Third message")
            };

            this.client = new Client(this.testTweeters);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TweetConstructorShouldThrowExceptionWhenArgumentIsNullOrEmpty(string message)
        {
            string errorMessage = "Expected exception has not been thrown!";
            string expectedExceptionMessage = "Message cannot be empty!";
            Exception ex = Assert.Throws<ArgumentNullException>(() => new Tweet(message), errorMessage);
            PropertyInfo paramProperty = ex.GetType().GetProperty("ParamName");
            string actualExceptionMessage = (string)paramProperty.GetValue(ex);
            Assert.That(actualExceptionMessage == expectedExceptionMessage, errorMessage);
        }

        [Test]
        public void TweetConstructorShouldWorkProperly()
        {
            string message = "Some message";
            ITweet tweet = new Tweet(message);
            Assert.That(message == tweet.Message);
        }

        [Test]
        public void TestClientConstructor()
        {
            for (int i = 0; i < this.testTweeters.Count; i++)
            {
                ITweet actual = this.client.Tweeters[i];
                ITweet expected = this.testTweeters[i];
                Assert.That(expected == actual);
            }
        }

        [Test]
        public void TweetMethodShouldAddTweetAndReturnCorrectMessage()
        {
            string message = "Working properly!";

            Tweet tweet = new Tweet(message);
            string result = this.client.Tweet(tweet);

            string exceptionMessage = "The method did not return the correct message!";
            string tweetNotAdded = "Method did not add tweet to the collection!";

            Assert.AreEqual(message, result, exceptionMessage);

            Assert.That(() => this.client.Tweeters.Last().Equals(tweet), tweetNotAdded);
        }

        [Test]
        public void TweetMethodShouldThrowExceptionIfArgumentIsNull()
        {
            string exceptionMessage = "Expected exception has not been thrown!";
            Assert.That(() => this.client.Tweet(null), Throws.InvalidOperationException, exceptionMessage);
        }

        [Test]
        public void GetCurrentTweeterMethodShouldReturnCorrectMessage()
        {
            string expected = this.testTweeters.Last().Message;
            string actual = this.client.GetCurrentTweeter();
            string errorMsg = "The method did not return the correct message!";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [Test]
        public void GetCurrentTweeterMethodShouldThrowExceptionIfCollectionEmpty()
        {
            this.client = new Client();
            string exceptionMessage = "Expected exception has not been thrown!";

            Assert.That(() => client.GetCurrentTweeter(), Throws.InvalidOperationException, exceptionMessage);
        }

        [Test]
        public void TestNumbersOfMessagesAfterAddingSeveralTweets()
        {
            int expected = this.client.Tweeters.Count + 3;

            this.client.Tweet(new Tweet("New tweet1!"));
            this.client.Tweet(new Tweet("New tweet2!"));
            this.client.Tweet(new Tweet("New tweet3!"));

            int actual = this.client.Tweeters.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}