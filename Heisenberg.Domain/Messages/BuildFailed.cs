using Heisenberg.Domain.Messaging;

namespace Heisenberg.Domain.Messages
{
    public class BuildFailed : Event
    {
        public Commit Commit { get; set; }
    }
}