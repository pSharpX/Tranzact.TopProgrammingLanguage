using System;
using Tranzact.TopProgrammingLanguage.Domain.Enums;
using Tranzact.TopProgrammingLanguage.Domain.Common;

namespace Tranzact.TopProgrammingLanguage.Domain.Entities
{
    public class YahooSearchResult : ISearchResult
    {
        public SearchEngineTypes GetSearchEngine()
        {
            return SearchEngineTypes.YAHOO;
        }

        public string GetSearchTerm()
        {
            throw new NotImplementedException();
        }

        public string GetSearchTime()
        {
            throw new NotImplementedException();
        }

        public long GetTotal()
        {
            throw new NotImplementedException();
        }
    }
}
