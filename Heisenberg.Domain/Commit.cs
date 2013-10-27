using System;

namespace Heisenberg.Domain
{
    public class Commit
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
