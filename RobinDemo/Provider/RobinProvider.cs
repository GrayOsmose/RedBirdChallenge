using System;

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

            for (var mIndex = 0; mIndex < MockConstants.NumberOfUsers; mIndex++)
            {
                flUser.Add(new User
	                {
		                pName = string.Format("{0} {1}","MrNoPersonalLife", mIndex),
						pPictureUrl = MockConstants.PictureUrl
	                });
            }

            // create tweets for each user and date for it of course


	        var mUserIndex = 0;
			for (var mIndex = 0; mIndex < MockConstants.NumberOfUserTweets; mIndex++)
	        {
		        flTweet.Add(new Tweet
			        {
						pMessage = MockConstants.TweetMessage,
						pNumber = mIndex + 1,
						pTime = DateTime.Now,
						pTweetType = Tweet.TweetType.Mobile,
						pUser = flUser[mUserIndex]
			        });

		        mUserIndex = (mUserIndex + 1) == MockConstants.NumberOfUsers
			                     ? 0
			                     : mUserIndex + 1;
	        }
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

			outLastNumber = inLastNumber + mCount;

			outIsLast = mCount < MockConstants.TweetFirstTakeCount;
            
            return mlTweets.ToList();
        }
    }
}