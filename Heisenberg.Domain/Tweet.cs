using System;

namespace Heisenberg.Domain
{
    public class Tweet
    {
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public string Author { get; set; }
    }
}