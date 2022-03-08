using System.Collections.Generic;

namespace Tranzact.TopProgrammingLanguage.Contracts.Dto
{
    public class SearchRequest
    {
        public List<string> SearchTerms { get; set; }

        public SearchRequest(List<string> searchTerms)
        {
            SearchTerms = searchTerms;
        }
    }
}
