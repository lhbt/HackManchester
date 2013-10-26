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
            var repo = _parser.OpenRepo();
            Assert.That(repo.Name, Is.EqualTo("HackManchester"));
        }
    }
}
