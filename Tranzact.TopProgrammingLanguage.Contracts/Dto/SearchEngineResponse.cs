using Tranzact.TopProgrammingLanguage.Domain.Common;

namespace Tranzact.TopProgrammingLanguage.Contracts.Dto
{
    public class SearchEngineResponse
    {
        public SearchEngineResponse(ISearchResult searchResult)
        {
            this.SearchEngineName = searchResult.GetSearchEngine().ToString();
            this.Total = searchResult.GetTotal();
            this.SearchTerm = searchResult.GetSearchTerm();
        }

        public string SearchEngineName { get; set; }

        public string SearchTerm { get; set; }

        public long Total { get; set; }
    }
}
