using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TweetSharp;

namespace Heisenberg.Twitter
{
    public class TwitterApiWrapper
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

        private ITwitterService Authorise()
        {
            // In v1.1, all API calls require authentication
            var service = new TwitterService(_consumerKey, _consumerSecret);

            service.AuthenticateWith(_accessToken, _accessTokenSecret);

            return service;
        }

        public TwitterStatusResponse QueryHashtag(string hashTag)
        {
            var service = Authorise();

            var result = service.Search(new SearchOptions { Q = hashTag });

            return Map(result);
        }

        public void TweetMessage(string message)
        {
            var service = Authorise();

            var options = new SendTweetOptions();
            options.Status = message;
            service.SendTweet(options);
        }

        public TwitterStatusResponse Map(TwitterSearchResult result)
        {
            var response = new TwitterStatusResponse();

            result.Statuses.ToList().ForEach(x => response.Statuses.Add(x.Text));

            return response;
        }
        
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterStatusResponse
    {
        public TwitterStatusResponse()
        {
            Statuses = new List<string>();
        }

        [JsonProperty("Statuses")]
        public List<string> Statuses;
    }
}
