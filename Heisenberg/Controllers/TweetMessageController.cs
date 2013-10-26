using System.Web.Http;
using Heisenberg.Twitter;

namespace Heisenberg.Controllers
{
    public class TweetMessageController : ApiController
    {
        public void Get()
        {
            var twitterApiWrapper = new TwitterApiWrapper();

            twitterApiWrapper.TweetMessage("Test tweet");
        }
    }
}
