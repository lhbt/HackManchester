using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IronGitHub;
using Authorization = IronGitHub.Entities.Authorization;

namespace Heisenberg.GitHub
{
    public class GitHubApiWrapper
    {
        private object _lockObject = new object();

        protected GitHubApi Api;

        //[SetUp]
        public void CreateGitHubApi()
        {
            Api = GitHubApi.Create();
        }

        /// <summary>
        /// Logs into the GitHub API using the test account for integration testing. If there is a matching authorization for the given scopes from a previous test, it is reused
        /// </summary>
        /// <param name="scopes">The scopes to request access to</param>
        protected async Task Authorize(IEnumerable<Scopes> scopes = null)
        {
            if (Api.Context.Authorization == Authorization.Anonymous ||
                (scopes != null &&
                Api.Context.Authorization.Scopes != null &&
                !Api.Context.Authorization.Scopes.Intersect(scopes).Any()))
            {
                var authorization = await Api.Authorize(
                                        new NetworkCredential("username", "password"),
                                        scopes,
                                        "IronGithub Integration Test");
                lock (_lockObject)
                {
                    Api.Context.Authorize(authorization);
                }
            }
        }
    }
}
