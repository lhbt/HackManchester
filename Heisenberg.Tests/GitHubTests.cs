using Heisenberg.GitHub;
using NUnit.Framework;

namespace Heisenberg.Tests
{
    [TestFixture]
    public class GitHubTests
    {
        private GitHubParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new GitHubParser();    
        }

        [Test]
        public void CanConnectToAGivenRepository()
        {
            const string repoPath = @"C:\Users\Laurent\Documents\GitHub\HackManchester";
            Assert.That(_parser.OpenRepo(repoPath), Is.True);
        }

        [Test]
        public void CanGetListOfCommits()
        {
            //var commits = _parser.GetCommits();
        }
    }
}
