namespace Core.Model.Models
{
    using System;
    using Core.Data;

    public class Tweet
    {
        // Data
        public enum TweetType
        {
            Web,
            Mobile
        }

        // Fields

        // Initialization
        
        // Properties
        public User pUser { get; set; }
        public long pNumber { get; set; }
        
        public string pMessage { get; set; }
        public DateTime pTime { get; set; }
        public TweetType pTweetType { get; set; }

        public bool IsReaded { get; private set; }
        
        // Private Methods


        // Public Methods
        public string GetShortMessage()
        {
            return pMessage == null || pMessage.Length > TweetData.TweetShortLenght ? pMessage : string.Format("{0}...",pMessage.Substring(0, 29));
        }

        public void ReadMessage()
        {
            IsReaded = true;
        }

        public override string ToString()
        {
            return GetShortMessage();
        }
    }
}