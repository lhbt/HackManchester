using System;
using System.Collections.Generic;
using Heisenberg.Domain;
using Heisenberg.Domain.Interfaces;
using Heisenberg.Domain.Messages;
using Heisenberg.Domain.Messaging;

namespace Heisenberg.FakeDataStore
{
    public class FakeBuildStatusReadModel : IBuildStatusReadModel, IHandles<BuildSucceeded>, IHandles<BuildFailed>
    {
        public IEnumerable<BuildResult> GetMostRecentBuildResults(int count)
        {
            var commit1 = new Commit {Id = "foo", Message = "foo message", Timestamp = DateTime.UtcNow.AddMinutes(-2)};
            var buildResult1 = new BuildResult {Commit = commit1, Succeeded = false};
            var commit2 = new Commit {Id = "bar", Message = "bar message", Timestamp = DateTime.UtcNow.AddMinutes(-1)};
            var buildResult2 = new BuildResult {Commit = commit2, Succeeded = true};

            return new List<BuildResult>{buildResult1, buildResult2};
        }

        public void Handle(BuildFailed message)
        {
            var buildResult = new BuildResult {Commit = message.Commit, Succeeded = false};
            // Persist
        }

        public void Handle(BuildSucceeded message)
        {
            var buildResult = new BuildResult { Commit = message.Commit, Succeeded = true };
            // Persist
        }
    }
}
