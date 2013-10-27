using System.Collections.Generic;
using System.Web.Http;
using Heisenberg.Domain;
using Heisenberg.Domain.Interfaces;

namespace Heisenberg.Controllers
{
    public class TwitterHashtagController : ApiController
    {
        private readonly ISocialMediaWrapper _socialMediaWrapper;

        public TwitterHashtagController(ISocialMediaWrapper socialMediaWrapper)
        {
            _socialMediaWrapper = socialMediaWrapper;
        }

        public IEnumerable<Tweet> Get()
        {
            return _socialMediaWrapper.QueryHashtag("#hackmanchester");
        }
    }
}
