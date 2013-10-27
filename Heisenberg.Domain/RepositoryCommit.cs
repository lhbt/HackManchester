using System;
using System.Collections.Generic;

namespace Heisenberg.Domain
{
    public class RepositoryCommit
    {
        public string Author { get; set; }
        public DateTime TimeCommited { get; set; }
        public string Comment { get; set; }
        public List<string> FilesModified { get; set; }
        public string Sha { get; set; }
    }
}
