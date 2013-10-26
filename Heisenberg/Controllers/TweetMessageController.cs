using System.Web.Http;
using Heisenberg.Domain.Interfaces;

namespace Heisenberg.Controllers
{
    public class TweetMessageController : ApiController
    {
        private readonly ISocialMediaWrapper _socialMediaWrapper;

        public TweetMessageController(ISocialMediaWrapper socialMediaWrapper)
        {
            _socialMediaWrapper = socialMediaWrapper;
        }

        public void Get()
        {
            _socialMediaWrapper.SendStatusUpdate("Test tweet #HackRooms");
        }
    }
}
