using System;
using RestSharp;

namespace Heisenberg.GitHub
{
    public static class GitHelper
    {
        private static RestClient _client;

        public static void ConfigureClient(string userName, string repoName)
        {
            _client = new RestClient()
            {
                BaseUrl = string.Format("https://api.github.com/repos/{0}/{1}", userName, repoName),
                Authenticator = new HttpBasicAuthenticator("BreakingCodeHackMan", "sleepdepriveddevboy")
            };
        }

        public static dynamic ExecuteRequest(string request)
        {
            var restRequest = new RestRequest()
            {
                Resource = request
            };

            var response = _client.Execute(restRequest);
            return response.Dynamic();
        }

        public static dynamic Dynamic(this IRestResponse response)
        {
            return SimpleJson.DeserializeObject(response.Content);
        }

        public static string ToIso8601(this DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mmZ");
        }
    }
}
