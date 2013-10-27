using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Http;

namespace Heisenberg.Controllers
{
    public class NotificationsController : ApiController
    {
        private static readonly ConcurrentBag<string> _statuses = new ConcurrentBag<string>(); 
        
        public void BuildNotification(Notification notification)
        {
            _statuses.Add(notification.Status);
        }

        public IEnumerable<string> BuildStatuses()
        {
            return _statuses.ToArray();
        }
    }

    [DataContract]
    public class Notification
    {
        [DataMember(Name = "application")]
        public Application Application { get; set; }

        [DataMember(Name = "build")]
        public Build Build { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

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