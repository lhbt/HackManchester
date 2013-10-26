using System;
using System.Collections.Generic;
using System.Linq;
using GitSharp;
using GitSharp.Core.RevPlot;
using GitSharp.Core.Util;
using Heisenberg.SourceControlService;

namespace Heisenberg.GitHub
{
    public class GitHubParser : ISourceControlParser
    {
        public GitHubParser(string repoPath)
        {
            Repository = new Repository(repoPath);
        }

        public Repository Repository { get; private set; }

        public IEnumerable<string> GetLanguagesUsed()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetFilesList()
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfCommitsWithKeywordInComment(string keyword)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfCommitsInTheLastHour()
        {
            throw new System.NotImplementedException();
        }

        public int GetAmountOfLinesOfCode()
        {
            throw new System.NotImplementedException();
        }

        public int GetAmountOfMinutesSinceLastCommit()
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetFiles()
        {
            var files = new List<string>();


            return files;
        }

        public List<CommitWrapper> GetCommits()
        {
            var revWalk = new PlotWalk(Repository);
            revWalk.markStart(((GitSharp.Core.Repository)Repository).getAllRefsByPeeledObjectId().Keys.Select(revWalk.parseCommit));

            var commits = new List<CommitWrapper>();
            foreach (var commit in revWalk)
            {
                var tmp = commit.AsCommit(revWalk);
                
                commits.Add(new CommitWrapper
                {
                    Author = commit.getAuthorIdent().EmailAddress,
                    Comment = commit.getFullMessage(),
                    TimeCommited = tmp.Author.When.MillisToUtcDateTime()
                });
            }
            return commits;
        }
    }
}
