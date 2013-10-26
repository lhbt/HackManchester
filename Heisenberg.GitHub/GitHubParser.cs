using System.Collections.Generic;
using GitSharp;

namespace Heisenberg.GitHub
{
    public class GitHubParser : GitHubApiWrapper
    {
        private Repository _repo;

        public GitHubParser()
        {
            //_repo = Repository.FindRepository();
        }

        public bool OpenRepo(string repoPath)
        {
            return Repository.IsValid(repoPath);
        }

        public List<Commit> GetCommits()
        {
            throw new System.NotImplementedException();
        }
    }
}
