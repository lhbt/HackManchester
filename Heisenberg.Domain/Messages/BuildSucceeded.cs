using Heisenberg.Domain.Messaging;

namespace Heisenberg.Domain.Messages
{
    public class BuildSucceeded : Event
    {
        public Commit Commit { get; set; }
    }
}
