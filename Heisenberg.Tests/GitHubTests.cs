using System.Linq;
using Heisenberg.GitHub;
using NUnit.Framework;

namespace Heisenberg.Tests
{
    [TestFixture]
    public class GitHubTests
    {
        private GitHubParser _parser;
        const string RepoPath = @"C:\Users\Laurent\Documents\GitHub\HackManchester";
        [SetUp]
        public void Setup()
        {
            _parser = new GitHubParser(RepoPath);    
        }

        [Test]
        public void CanOpenAGivenRepository()
        {
            Assert.That(_parser.Repository, Is.Not.Null);
        }

        [Test]
        public void CanGetListOfCommits()
        {
            var commits = _parser.GetCommits();
            Assert.That(commits, Is.Not.Null);
            Assert.That(commits.Count, Is.GreaterThan(0));
        }

        [Test]
        public void CanGetFilesList()
        {
            var files = _parser.GetFilesList();
            Assert.That(files, Is.Not.Null);
            Assert.That(files.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void CanKnowHowLongAgoWasTheLastCommit()
        {
            Assert.That(_parser.GetAmountOfMinutesSinceLastCommit(), Is.TypeOf<int>());
        }

        [Test]
        public void CanGetNumberOfCommitsInTheLastHour()
        {
            Assert.That(_parser.GetNumberOfCommitsInTheLastHour(), Is.GreaterThan(0));
        }
    }
}
