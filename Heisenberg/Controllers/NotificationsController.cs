using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Http;
using Heisenberg.Domain.Messages;
using Heisenberg.Domain.Messaging;

namespace Heisenberg.Controllers
{
    public class NotificationsController : ApiController
    {
        private readonly IEventPublisher _eventPublisher;

        public NotificationsController(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }
        
        public void BuildNotification(Notification notification)
        {
            if (notification.Build.Status == "succeeded")
            {
                _eventPublisher.Publish(new BuildSucceeded());
            }
            else
            {
                _eventPublisher.Publish(new BuildFailed());
            }
        }

        public IEnumerable<string> BuildStatuses()
        {
            return new List<string>();
        }
    }

    [DataContract]
    public class Notification
    {
        [DataMember(Name = "application")]
        public Application Application { get; set; }

        [DataMember(Name = "build")]
        public Build Build { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }

    [DataContract]
    public class Application
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }

    [DataContract]
    public class Build
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
        //  "build": {
        //    "id": "bar",
        //    "branch" : {
        //         "name" : "baz",
        //         "commit" : {
        //             "id" : "77d991fe61187d205f329ddf9387d118a09fadcd",
        //             "message" : "Implement foobar"
        //         }
        //    },
    }
}