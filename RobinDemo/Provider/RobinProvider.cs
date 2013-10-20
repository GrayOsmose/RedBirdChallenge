namespace RobinDemo.Provider
{
    using System.Linq;
    using System.Collections.Generic;
    using Core.Model.Interfaces;
    using Core.Model.Models;

    /// Mocker
    /// it contains all data and do not make RW operations with device like it usually happens
    public class RobinProvider : IProvider
    {
        // Fields
        private readonly List<User> flUser = new List<User>();
        private readonly List<Tweet> flTweet = new List<Tweet>();

        // Initialization

        // Private Methods
        private void CreateMockData()
        {
            // create users

            // create tweets for each user and date for it of course
        }

        // Public Methods
        public void InitializeUser(int inUserId)
        {
            // does nothing since no log in mocking data
            
            CreateMockData();
        }

        public IEnumerable<Tweet> GetTweets(out bool outIsLast, out int outLastNumber, int inLastNumber = 0)
        {
            var mlTweets = inLastNumber == 0
                               ? flTweet.Take(MockConstants.TweetFirstTakeCount).ToList()
                               : flTweet.TakeWhile((t, n) => n <= inLastNumber).Take(MockConstants.TweetFirstTakeCount).ToList();

            var mCount = mlTweets.Count();

            outIsLast = mCount <= inLastNumber + MockConstants.TweetFirstTakeCount;
            outLastNumber = inLastNumber + mCount;

            return mlTweets.ToList();
        }
    }
}