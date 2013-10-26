using System.Collections.Generic;
using System.Linq;
using GitSharp;
using GitSharp.Core.RevPlot;

namespace Heisenberg.GitHub
{
    public class GitHubParser : GitHubApiWrapper
    {
        public GitHubParser(string repoPath)
        {
            Repository = new Repository(repoPath);
        }

        public Repository Repository { get; private set; }

        public List<GitSharp.Core.Commit> GetCommits()
        {
            var mRevwalk = new PlotWalk(Repository);
            mRevwalk.markStart(((GitSharp.Core.Repository)Repository).getAllRefsByPeeledObjectId().Keys.Select(mRevwalk.parseCommit));

            return mRevwalk.Select(commit => commit.AsCommit(mRevwalk)).Select(dummy => dummy).ToList();
        }

        public List<string> GetFiles()
        {
            var files = new List<string>();

            return files;
        }
    }
}
