using System.Collections.Generic;

namespace Heisenberg.Domain.Interfaces
{
    public interface ISocialMediaWrapper
    {
        IEnumerable<string> QueryHashtag(string hashTag);
        void SendStatusUpdate(string message);
    }
}
