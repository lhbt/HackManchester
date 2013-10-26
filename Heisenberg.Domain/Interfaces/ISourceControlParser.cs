using System.Collections.Generic;

namespace Heisenberg.Domain.Interfaces
{
    public interface ISourceControlParser
    {
        List<RepositoryCommit> GetCommits();
        List<string> GetLanguagesUsed();
        List<string> GetFilesList();
        int GetNumberOfCommitsWithKeywordInComment(string keyword);
        int GetNumberOfCommitsInTheLastHour();
        int GetAmountOfLinesOfCode();
        int GetAmountOfMinutesSinceLastCommit();
    }
}
