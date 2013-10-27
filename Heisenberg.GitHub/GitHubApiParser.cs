using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heisenberg.Domain;
using Heisenberg.Domain.Interfaces;
using RestSharp.Extensions;

namespace Heisenberg.GitHub
{
    public class GitHubApiParser : ISourceControlParser
    {
        private readonly Dictionary<string, string> _knownLanguages;
        private List<RepositoryCommit> _commits;
        private DateTime _lastGetCommitTime;

        public GitHubApiParser(string username, string reponame)
        {
            GitHelper.ConfigureClient(username, reponame); 
            _knownLanguages = new Dictionary<string, string>
            {
                { "cs", "c#" },
                { "js", "javascript" },
                { "html", "HTML"},
                { "cshtml", "razor" },
                { "xaml", "WPF" }
            };
        }

        public List<RepositoryCommit> GetCommits(int hours)
        {
            DateTime since;

            if (_commits == null)
            {
                _commits = new List<RepositoryCommit>();
                since = DateTime.Now.AddHours(-hours);
            }
            else since = _lastGetCommitTime;

            var rep = GitHelper.ExecuteRequest("/commits?per_page=100&since=" + since.ToIso8601());

            foreach (var commit in rep)
            {
                if (_commits.Any(o => o.Sha == commit.sha)) continue;

                var newCommit = new RepositoryCommit
                {
                    Sha = commit.sha,
                    Author = commit.commit.author.name,
                    Comment = commit.commit.message,
                    FilesModified = new List<string>(),
                    TimeCommited = DateTime.Parse(commit.commit.author.date)
                };

                //var origCommit = GitHelper.ExecuteRequest("/commits/" + commit.sha);
                //foreach (var file in origCommit.files)
                //    newCommit.FilesModified.Add(file.filename);

                _commits.Add(newCommit);
            }

            _lastGetCommitTime = DateTime.Now;

            return _commits;
        }

        public List<string> GetLanguagesUsed()
        {
            return (from file in GetFilesList()
                    where IsKnownLanguage(file)
                    select _knownLanguages[file.Split('.').Last()]).Distinct().ToList();
        }

        public List<string> GetFilesList()
        {
            var rep = GitHelper.ExecuteRequest("git/trees/master?recursive=1");
            var files = new List<string>();

            foreach (var file in rep.tree)
            {
                if (file.type == "blob")    
                    files.Add(file.path);
            }

            return files;
        }

        public int GetNumberOfCommitsWithKeywordInComment(string keyword)
        {
            return GetCommits(1).Count(o => o.Comment.Contains("keyword"));
        }

        public List<RepositoryCommit> GetCommitsMadeDuringTheLastHour()
        {
            return GetCommits(1);
        }

        public int GetAmountOfBytesOfCode()
        {
            var rep = GitHelper.ExecuteRequest("git/trees/master?recursive=1");
            var counter = 0;

            foreach (var file in rep.tree)
            {
                if (file.type == "blob" && IsKnownLanguage(file.path))
                    counter += file.size;
            }

            return counter;
        }

        public int GetAmountOfMinutesSinceLastCommit()
        {
            var lastCommit = GitHelper.ExecuteRequest("commits?per_page=1");
            var dateLastCommit = DateTime.Parse((string)lastCommit[0].commit.author.date);

            return (DateTime.Now - dateLastCommit).Minutes;
        }

        public bool IsKnownLanguage(string file)
        {
            return _knownLanguages.Keys.Contains(file.Split('.').Last());
        }
    }
}
