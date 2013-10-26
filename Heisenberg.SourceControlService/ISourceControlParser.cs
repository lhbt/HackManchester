using System.Collections.Generic;
using Heisenberg.Domain;

namespace Heisenberg.SourceControlService
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
