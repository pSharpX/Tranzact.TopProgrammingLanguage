using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Enum;

namespace Tranzact.TopProgrammingLanguage.Contracts.Data.Entities
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

        public long? GetTotal()
        {
            throw new NotImplementedException();
        }
    }
}
