using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Heisenberg.Domain;
using Heisenberg.Domain.Interfaces;
using TweetSharp;

namespace Heisenberg.Twitter
{
    public class TwitterApiWrapper : ISocialMediaWrapper
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;

        public TwitterApiWrapper()
        {
            _consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            _consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            _accessToken = ConfigurationManager.AppSettings["AccessToken"];
            _accessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];
        }

        public IEnumerable<Tweet> QueryHashtag(string hashTag)
        {
            var service = Authorise();
            var result = service.Search(new SearchOptions { Q = hashTag });
            return Map(result);
        }

        public void SendStatusUpdate(string message)
        {
            var service = Authorise();
            var options = new SendTweetOptions { Status = message };
            service.SendTweet(options);
        }

        private ITwitterService Authorise()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);

            service.AuthenticateWith(_accessToken, _accessTokenSecret);

            return service;
        }

        private static IEnumerable<Tweet> Map(TwitterSearchResult result)
        {
            return result.Statuses.Select(x => new Tweet() { Text = x.Text, Timestamp = x.CreatedDate.ToString("HH:mm"), Author = x.Author.ScreenName }).ToList();
        }
    }
}
