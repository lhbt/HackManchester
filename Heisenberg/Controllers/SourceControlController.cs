using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using Heisenberg.Domain;
using Heisenberg.Domain.Interfaces;
using Newtonsoft.Json;

namespace Heisenberg.Controllers
{
    public class SourceControlController : ApiController
    {
        private readonly ISourceControlParser _parser;

        public SourceControlController(ISourceControlParser parser)
        {
            _parser = parser;
            _parser.GetCommits(24);
        }

        [HttpGet]
        public string Commits()
        {
            return _parser.GetCommitsMadeDuringTheLastHour().ToString();
        }

        [HttpGet]
        public int BytesOfCode()
        {
            return _parser.GetAmountOfBytesOfCode();
        }

        [HttpGet]
        public IEnumerable<string> LanguagesUsed()
        {
            return _parser.GetLanguagesUsed();
        }

        [HttpGet]
        public int Commits(string keyword)
        {
            return _parser.GetNumberOfCommitsWithKeywordInComment(keyword);
        }

        [HttpGet]
        public int MinutesSinceLastCommit()
        {
            return _parser.GetAmountOfMinutesSinceLastCommit();
        }

        [HttpGet]
        public IEnumerable<string> FilesList()
        {
            return _parser.GetFilesList();
        }

        [HttpGet]
        public IEnumerable<RepositoryCommit> ActualCommits()
        {
            return _parser.GetCommitsMadeDuringTheLastHour();
        }
    }
}