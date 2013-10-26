﻿using Heisenberg.Twitter;
using System.Web.Http;

namespace Heisenberg.Controllers
{
    public class TwitterController : ApiController
    {
        public TwitterStatusResponse Get()
        {
            var twitterApiWrapper = new TwitterApiWrapper();

            return twitterApiWrapper.QueryHashtag("#hackmanchester");
        }
    }
}
