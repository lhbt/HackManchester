using System.Collections.Generic;

namespace Heisenberg.Domain.Interfaces
{
    public interface IBuildStatusReadModel
    {
        IEnumerable<BuildResult> GetMostRecentBuildResults(int count);
    }
}
