using System.Collections.Generic;

namespace Heisenberg.SourceControlService
{
    public interface ISourceControlParser
    {
        List<CommitWrapper> GetCommits();
        IEnumerable<string> GetLanguagesUsed();
        IEnumerable<string> GetFilesList();
        int GetNumberOfCommitsWithKeywordInComment(string keyword);
        int GetNumberOfCommitsInTheLastHour();
        int GetAmountOfLinesOfCode();
        int GetAmountOfMinutesSinceLastCommit();
    }
}
