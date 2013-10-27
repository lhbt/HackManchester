using System.Collections.Generic;

namespace Heisenberg.Domain.Interfaces
{
    public interface ITracer
    {
        IEnumerable<string> DbConnectionCheck();
    }
}
