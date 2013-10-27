using System;
using System.IO;
using System.Linq;
using Heisenberg.GitHub;
using NUnit.Framework;

namespace Heisenberg.Tests
{
    public class GitHubTests
    {
        private GitHubApiParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new GitHubApiParser("lhbt", "hackmanchester");
            _parser.GetCommits(24);
        }

        [Test]
        public void CanGetListOfCommits()
        {
            var commits = _parser.GetCommits(1);
            Assert.That(commits, Is.Not.Null);
            Assert.That((DateTime.Now - commits.First().TimeCommited).Minutes < 60);
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
        public void CanGetAListOfLanguagesUsed()
        {
            var languagesUsed = _parser.GetLanguagesUsed();
            Assert.That(languagesUsed.Contains("c#"), Is.True);
            Assert.That(languagesUsed.Contains("javascript"), Is.True);
            Assert.That(languagesUsed.Contains("razor"), Is.True);
        }

        [Test]
        public void CanGetNumberOfCommitsWhichCommentContainsAKeyword()
        {
            Assert.That(_parser.GetNumberOfCommitsWithKeywordInComment("fix"), Is.GreaterThan(0));
        }

        [Test]
        public void CanGetAmountOfLinesOfCode()
        {
            Assert.That(_parser.GetAmountOfBytesOfCode(), Is.GreaterThan(0));
        }
    }
}
