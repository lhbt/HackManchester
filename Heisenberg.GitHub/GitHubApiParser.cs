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
        private readonly Dictionary<int, string> _gitPunchCardMapping;
        private const string FirstCommitSha = "d13f469d93ddba9950fea408380724c0872cc6ea";
        private int _totalAmountOfCommits;
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

            _gitPunchCardMapping = new Dictionary<int, string>
            {
                { 0, "Sunday" },
                { 1, "Monday" },
                { 2, "Tuesday" },
                { 3, "Wednesday" },
                { 4, "Thursday" },
                { 5, "Friday" },
                { 6, "Saturday" }
            };
        }

        private void GetTotalAmountOfCommits()
        {
            var lastCommit = GitHelper.ExecuteRequest("commits?per_page=1");
            var rep = GitHelper.ExecuteRequest("compare/" + FirstCommitSha + "..." + lastCommit[0].sha);

            _totalAmountOfCommits = int.Parse(rep.total_commits.ToString()) + 1;
        }

        public List<RepositoryCommit> GetCommits()
        {
            GetTotalAmountOfCommits();

            if (_commits == null)
            {
                _commits = new List<RepositoryCommit>();
                var rep =
                    GitHelper.ExecuteRequest("/commits?per_page=100&since=" + DateTime.Now.AddHours(-24).ToIso8601());
                FillCommitsList(rep);
                while (_commits.Count < _totalAmountOfCommits)
                {
                    var resp =
                        GitHelper.ExecuteRequest("/commits?per_page=100&until=" +
                                                 _commits.Last().TimeCommited.ToIso8601());
                    FillCommitsList(resp);
                }
            }
            else
            {
                var response = GitHelper.ExecuteRequest("/commits?per_page=100&since=" + _lastGetCommitTime.ToIso8601());
                FillCommitsList(response);
            }

            _lastGetCommitTime = DateTime.Now;

            return _commits;
        }

        private void FillCommitsList(dynamic resp)
        {
            foreach (var commit in resp)
            {
                if (_commits.Any(o => o.Sha == commit.sha)) continue;

                var newCommit = new RepositoryCommit
                {
                    Sha = commit.sha,
                    Author = commit.commit.author.name,
                    AvatarUrl = commit.author.avatar_url,
                    EmailAddress = commit.author.email,
                    Comment = commit.commit.message,
                    FilesModified = new List<string>(),
                    TimeCommited = DateTime.Parse(commit.commit.author.date)
                };

                //var origCommit = GitHelper.ExecuteRequest("/commits/" + commit.sha);
                //foreach (var file in origCommit.files)
                //    newCommit.FilesModified.Add(file.filename);

                _commits.Add(newCommit);
            }
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
            return _commits.Count(o => o.Comment.Contains(keyword));
        }

        public List<RepositoryCommit> GetCommitsMadeDuringTheLastHour()
        {
            return _commits.Where(o => (DateTime.Now - o.TimeCommited).TotalMinutes <= 60).ToList();
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

        public Dictionary<string, int> GetAmountOfCommitsPerHour()
        {
            var dic = new Dictionary<string, int>();
            var rep = GitHelper.ExecuteRequest("stats/punch_card");
            foreach (var entry in rep)
            {
                if (entry[2] != 0)
                {
                    dic.Add(GetTimePunchCard(int.Parse(entry[0].ToString()), int.Parse(entry[1].ToString())), int.Parse(entry[2].ToString()));
                }
            }
            return dic;
        }

        private string GetTimePunchCard(int day, int hour)
        {
            return _gitPunchCardMapping[day] + " - hour " + hour;
        }

        public bool IsKnownLanguage(string file)
        {
            return _knownLanguages.Keys.Contains(file.Split('.').Last());
        }

        public IEnumerable<TeamMember> GetContributingMembers()
        {
            if (_commits == null)
            {
                GetCommits();
            }

            var authors = _commits.GroupBy(x => x.Author);
            return authors.Select(x => new TeamMember() { Name = x.Key, Username = x.First().EmailAddress, AvatarUrl = x.First().AvatarUrl});
        }
    }
}
