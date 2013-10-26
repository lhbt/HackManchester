using System.IO;
using System.Linq;
using Heisenberg.GitHub;
using NUnit.Framework;

namespace Heisenberg.Tests
{
    public class GitHubTests
    {
        private GitHubParser _parser;

        //[SetUp]
        //public void Setup()
        //{
        //    var repoPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName; 
        //    _parser = new GitHubParser(repoPath);    
        //}

        //[Test]
        //public void CanOpenAGivenRepository()
        //{
        //    Assert.That(_parser.Repository, Is.Not.Null);
        //}

        //[Test]
        //public void CanGetListOfCommits()
        //{
        //    var commits = _parser.GetCommits();
        //    Assert.That(commits, Is.Not.Null);
        //    Assert.That(commits.Count, Is.GreaterThan(0));
        //}

        //[Test]
        //public void CanGetFilesList()
        //{
        //    var files = _parser.GetFilesList();
        //    Assert.That(files, Is.Not.Null);
        //    Assert.That(files.Count(), Is.GreaterThan(0));
        //}

        //[Test]
        //public void CanKnowHowLongAgoWasTheLastCommit()
        //{
        //    Assert.That(_parser.GetAmountOfMinutesSinceLastCommit(), Is.TypeOf<int>());
        //}

        //[Test]
        //public void CanGetNumberOfCommitsInTheLastHour()
        //{
        //    Assert.That(_parser.GetNumberOfCommitsInTheLastHour(), Is.GreaterThan(0));
        //}

        //[Test]
        //public void CanGetAListOfLanguagesUsed()
        //{
        //    var languagesUsed = _parser.GetLanguagesUsed();
        //    Assert.That(languagesUsed.Contains("c#"), Is.True);
        //    Assert.That(languagesUsed.Contains("javascript"), Is.True);
        //    Assert.That(languagesUsed.Contains("razor"), Is.True);
        //}

        //[Test]
        //public void CanGetNumberOfCommitsWhichCommentContainsAKeyword()
        //{
        //    Assert.That(_parser.GetNumberOfCommitsWithKeywordInComment("fix"), Is.GreaterThan(0));
        //}

        //[Test]
        //public void CanGetAmountOfLinesOfCode()
        //{
        //    Assert.That(_parser.GetAmountOfLinesOfCode(), Is.GreaterThan(0));
        //}
    }
}
