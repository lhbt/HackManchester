using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Http;
using Heisenberg.Domain;
using Heisenberg.Domain.Interfaces;
using Heisenberg.Domain.Messages;
using Heisenberg.Domain.Messaging;

namespace Heisenberg.Controllers
{
    public class NotificationsController : ApiController
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IBuildStatusReadModel _buildStatusReadModel;

        public NotificationsController(IEventPublisher eventPublisher, IBuildStatusReadModel buildStatusReadModel)
        {
            _eventPublisher = eventPublisher;
            _buildStatusReadModel = buildStatusReadModel;
        }

        public void BuildNotification(Notification notification)
        {
            Commit commit = notification.Build.Branch.Commit;
            var domainCommit = new Domain.Commit
                                         {
                                             Id = commit.Id,
                                             Message = commit.Message,
                                             Timestamp = DateTime.UtcNow
                                         };

            if (notification.Build.Status == "succeeded")
            {
                _eventPublisher.Publish(new BuildSucceeded { Commit = domainCommit });
            }
            else
            {
                _eventPublisher.Publish(new BuildFailed { Commit = domainCommit });
            }
        }

        public IEnumerable<string> BuildStatuses()
        {
            return new List<string>{"succeeded", "failed"};
        }

        public IEnumerable<BuildResult> MostRecentBuildResults()
        {
            return _buildStatusReadModel.GetMostRecentBuildResults(15);
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

        [DataMember(Name="id")]
        public string Id { get; set; }

        [DataMember(Name="branch")]
        public Branch Branch { get; set; }
    }

    [DataContract]
    public class Branch
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
        
        [DataMember(Name = "commit")]
        public Commit Commit { get; set; }
    }

    [DataContract]
    public class Commit
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}