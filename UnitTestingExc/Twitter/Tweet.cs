namespace Tweeter.Models
{
    using Contracts;
    using System;

    public class Tweet : ITweet
    {
        private const string ErrorMessage = "Message cannot be empty!";

        private string message;

        public Tweet(string message)
        {
            this.Message = message;
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ErrorMessage);
                }

                this.message = value;
            }
        }
    }
}