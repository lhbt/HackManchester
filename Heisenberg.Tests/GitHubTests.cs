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
        public void CanGetNumberOfFiles()
        {
            var files = _parser.GetFiles();
            Assert.That(files, Is.Not.Null);
            Assert.That(files.Count, Is.GreaterThan(0));
        }
    }
}
