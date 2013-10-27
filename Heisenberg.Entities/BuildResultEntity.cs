using System;

namespace Heisenberg.Entities
{
    public class BuildResultEntity : Entity
    {
        public bool Succeeded { get; set; }
        public string CommitId { get; set; }
        public string CommitMessage { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
