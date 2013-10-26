using System;
using System.Collections.Generic;

namespace Heisenberg.SourceControlService
{
    public class CommitWrapper
    {
        public string Author { get; set; }
        public DateTime TimeCommited { get; set; }
        public string Comment { get; set; }
        public List<string> FilesModified { get; set; }
    }
}
