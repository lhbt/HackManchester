using System.Web.Http;
using Heisenberg.Twitter;

namespace Heisenberg.Controllers
{
    public class TwitterHashtagController : ApiController
    {
        public TwitterStatusResponse Get()
        {
            var twitterApiWrapper = new TwitterApiWrapper();

            return twitterApiWrapper.QueryHashtag("#hackmanchester");
        }
    }
}
