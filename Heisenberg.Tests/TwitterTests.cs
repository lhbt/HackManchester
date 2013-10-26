using Heisenberg.Twitter;
using NUnit.Framework;
using System.Collections.Generic;
using TweetSharp;

namespace Heisenberg.Tests
{
    [TestFixture]
    public class TwitterTests
    {
        [Test]
        public void ReturnMappedStatuses()
        {
            var twitterApiWrapper = new TwitterApiWrapper();

            var result = new TwitterSearchResult 
                        { Statuses = new List<TwitterStatus> { new TwitterStatus() } };

            var response = twitterApiWrapper.Map(result);

            Assert.That(response.Statuses.Count, Is.EqualTo(1));

        }
    }
}
