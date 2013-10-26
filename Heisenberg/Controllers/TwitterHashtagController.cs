using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Heisenberg.Domain.Interfaces;
using Newtonsoft.Json;

namespace Heisenberg.Controllers
{
    public class TwitterHashtagController : ApiController
    {
        private readonly ISocialMediaWrapper _socialMediaWrapper;

        public TwitterHashtagController(ISocialMediaWrapper socialMediaWrapper)
        {
            _socialMediaWrapper = socialMediaWrapper;
        }

        public TwitterStatusResponse Get()
        {
            IEnumerable<string> statuses = _socialMediaWrapper.QueryHashtag("#hackmanchester");

            return new TwitterStatusResponse {Statuses = statuses.ToList()};
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class TwitterStatusResponse
        {
            public TwitterStatusResponse()
            {
                Statuses = new List<string>();
            }

            [JsonProperty("Statuses")]
            public List<string> Statuses;
        }
    }
}
