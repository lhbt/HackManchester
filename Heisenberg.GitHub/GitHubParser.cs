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
        private Dictionary<string, string> _knownLanguages;

        public GitHubParser(string repoPath)
        {
            Repository = new Repository(repoPath);
            _knownLanguages = new Dictionary<string, string>
            {
                { "cs", "c#" },
                { "js", "javascript" },
                { "html", "HTML"},
                { "cshtml", "razor" },
                { "xaml", "WPF" }
            };
        }

        public Repository Repository { get; private set; }

        public List<string> GetLanguagesUsed()
        {
            return (from file in GetFilesList() 
                    where _knownLanguages.Keys.Contains(file.Split('.').Last()) 
                    select _knownLanguages[file.Split('.').Last()]).Distinct().ToList();
        }

        public int GetNumberOfCommitsWithKeywordInComment(string keyword)
        {
            throw new System.NotImplementedException();
        }

        public int GetAmountOfLinesOfCode()
        {
            throw new System.NotImplementedException();
        }

        public int GetAmountOfMinutesSinceLastCommit()
        {
            return (DateTime.Now - Repository.Head.CurrentCommit.CommitDate.DateTime).Minutes;
        }

        public List<CommitWrapper> GetCommits()
        {
            var revWalk = new PlotWalk(Repository);
            revWalk.markStart(((GitSharp.Core.Repository)Repository).getAllRefsByPeeledObjectId().Keys.Select(revWalk.parseCommit));

            return (from commit in revWalk
                let tmp = commit.AsCommit(revWalk)
                select new CommitWrapper
                {
                    Author = commit.getAuthorIdent().EmailAddress, 
                    Comment = commit.getFullMessage(), 
                    TimeCommited = tmp.Author.When.MillisToUtcDateTime().ToLocalTime()
                }).ToList();
        }

        public List<string> GetFilesList()
        {
            return Repository.Index.Entries.ToList();
        }

        public int GetNumberOfCommitsInTheLastHour()
        {
            return GetCommits().Count(commit => (DateTime.Now - commit.TimeCommited).Minutes <= 60);
        }
    }
}
