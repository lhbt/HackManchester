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
        private MongoCollection<BuildResultEntity> GetBuildResults()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var server = client.GetServer();
            MongoDatabase database = server.GetDatabase(url.DatabaseName);
            var buildResults =  database.GetCollection<BuildResultEntity>("BuildResults");
            return buildResults;
        }
        
        public IEnumerable<BuildResult> GetMostRecentBuildResults(int count)
        {
            var collection = GetBuildResults();

            MongoCursor<BuildResultEntity> entities = collection.FindAll().SetSortOrder(SortBy.Descending("Timestamp")).SetLimit(count);

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
            var collection = GetBuildResults();

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
            var collection = GetBuildResults();

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
