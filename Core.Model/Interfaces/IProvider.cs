using System.Collections.Generic;
using Core.Model.Models;

namespace Core.Model.Interfaces
{
    public interface IProvider
    {
        void InitializeUser(int inUserId);
        IEnumerable<Tweet> GetTweets(out bool outIsLast, out int outLastNumber, int inLastNumber = 0);
    }
}