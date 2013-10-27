namespace Heisenberg.Domain
{
    public class BuildResult
    {
        public Commit Commit { get; set; }
        public bool Succeeded { get; set; }
    }
}