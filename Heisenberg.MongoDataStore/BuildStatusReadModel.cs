using System;
using System.Collections.Generic;
using Heisenberg.Domain;
using Heisenberg.Domain.Interfaces;
using Heisenberg.Domain.Messages;
using Heisenberg.Domain.Messaging;

namespace Heisenberg.MongoDataStore
{
    public class BuildStatusReadModel : IBuildStatusReadModel, IHandles<BuildSucceeded>, IHandles<BuildFailed>
    {
        public IEnumerable<BuildResult> GetMostRecentBuildResults(int count)
        {
            throw new NotImplementedException();
        }

        public void Handle(BuildSucceeded message)
        {
            throw new NotImplementedException();
        }

        public void Handle(BuildFailed message)
        {
            throw new NotImplementedException();
        }
    }
}
