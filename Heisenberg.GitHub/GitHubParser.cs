using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronGitHub;
using IronGitHub.Apis;
using IronGitHub.Entities;

namespace Heisenberg.GitHub
{
    public class GitHubParser : GitHubApiWrapper
    {
        public GitHubParser()
        {
            this.CreateGitHubApi();
        }

        public Repository OpenRepo()
        {
            return Api.Repositories.Get("lhbt", "HackManchester").Result;
        }
    }
}
