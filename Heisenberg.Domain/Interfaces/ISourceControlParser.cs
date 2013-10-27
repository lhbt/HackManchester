using System.Collections.Generic;

namespace Heisenberg.Domain.Interfaces
{
    public interface ISourceControlParser
    {
        List<string> GetLanguagesUsed();
        List<string> GetFilesList();
        int GetNumberOfCommitsWithKeywordInComment(string keyword);
        List<RepositoryCommit> GetCommitsMadeDuringTheLastHour();
        List<RepositoryCommit> GetCommits(int hours);
        int GetAmountOfBytesOfCode();
        int GetAmountOfMinutesSinceLastCommit();
    }
}
