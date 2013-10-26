using System.Collections.Generic;

namespace Heisenberg.Domain.Interfaces
{
    public interface ISocialMediaWrapper
    {
        IEnumerable<Tweet> QueryHashtag(string hashTag);
        void SendStatusUpdate(string message);
    }
}
