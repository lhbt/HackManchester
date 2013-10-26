using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace Heisenberg.Twitter
{
    public class TwitterApiWrapper
    {
        private string _consumerKey;
        private string _consumerSecret; 

        public TwitterApiWrapper()
        {
            _consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            _consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];

        }

        private void Authorise()
        {
            // In v1.1, all API calls require authentication
            var service = new TwitterService(_consumerKey, _consumerSecret);

            // Step 1 - Retrieve an OAuth Request Token
            OAuthRequestToken requestToken = service.GetRequestToken();

            // Step 2 - Redirect to the OAuth Authorization URL
            Uri uri = service.GetAuthorizationUri(requestToken);
            Process.Start(uri.ToString());

            // Step 3 - Exchange the Request Token for an Access Token
            string verifier = "123456"; // <-- This is input into your application by your user
            OAuthAccessToken access = service.GetAccessToken(requestToken, verifier);

            // Step 4 - User authenticates using the Access Token
            service.AuthenticateWith(access.Token, access.TokenSecret);
            var result = service.Search(new SearchOptions { Q = "#hackmanchester" });
        }
    }
}
