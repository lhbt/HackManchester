using System.Collections.Generic;
using System.Configuration;
using Heisenberg.Domain;
using Heisenberg.Domain.Interfaces;
using Heisenberg.Domain.Messages;
using Heisenberg.Domain.Messaging;
using Heisenberg.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Heisenberg.MongoDataStore
{
    public class BuildStatusReadModel : IBuildStatusReadModel, IHandles<BuildSucceeded>, IHandles<BuildFailed>
    {
        public IEnumerable<BuildResult> GetMostRecentBuildResults(int count)
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase(url.DatabaseName);
            var collection = database.GetCollection<BuildResultEntity>("BuildResults");

            MongoCursor<BuildResultEntity> entities = collection.FindAll().SetSortOrder(SortBy.Descending("timestamp")).SetLimit(count);

            IList<BuildResult> buildResults = new List<BuildResult>(count);

            foreach (BuildResultEntity entity in entities)
            {
                var commit = new Commit
                                {
                                    Id = entity.CommitId,
                                    Message = entity.CommitMessage,
                                    Timestamp = entity.Timestamp
                                };
                var buildResult = new BuildResult {Commit = commit, Succeeded = entity.Succeeded};
                buildResults.Add(buildResult);
            }

            return buildResults;
        }

        public void Handle(BuildSucceeded message)
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase(url.DatabaseName);
            var collection = database.GetCollection<BuildResultEntity>("BuildResults");

            var buildResultEntity = new BuildResultEntity
                                    {
                                        CommitId = message.Commit.Id,
                                        CommitMessage = message.Commit.Message,
                                        Timestamp = message.Commit.Timestamp,
                                        Succeeded = true
                                    };

            collection.Insert(buildResultEntity);
        }

        public void Handle(BuildFailed message)
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase(url.DatabaseName);
            var collection = database.GetCollection<BuildResultEntity>("BuildResults");

            var buildResultEntity = new BuildResultEntity
                                    {
                                        CommitId = message.Commit.Id,
                                        CommitMessage = message.Commit.Message,
                                        Timestamp = message.Commit.Timestamp,
                                        Succeeded = false
                                    };

            collection.Insert(buildResultEntity);
        }
    }
}
