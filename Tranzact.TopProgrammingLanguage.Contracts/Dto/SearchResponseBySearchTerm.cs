using System.Collections.Generic;

namespace Tranzact.TopProgrammingLanguage.Contracts.Dto
{
    public class SearchResponseBySearchTerm
    {
        public List<SearchEngineResponse> Results { get; set; }

        public string SearchTerm { get; set; }

    }
}
