using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Enum;

namespace Tranzact.TopProgrammingLanguage.Contracts.Data.Entities
{
    public class GoogleSearchResult : ISearchResult
    {
        public SearchQueries Queries { get; set; }

        public GoogleSearchResult()
        {
        }

        public GoogleSearchResult(string searchTerm)
        {
            this.Queries = new SearchQueries()
            {
                Request = new List<SearchQuery>() { new SearchQuery() { SearchTerms = searchTerm } }
            };
        }

        public SearchInformation SearchInformation { get; set; }

        public SearchEngineTypes GetSearchEngine()
        {
            return SearchEngineTypes.GOOGLE;
        }

        public string GetSearchTerm()
        {
            return this.Queries?.Request.First().SearchTerms;
        }

        public string GetSearchTime()
        {
            return this.SearchInformation?.FormattedSearchTime;
        }

        public long GetTotal()
        {
            return Convert.ToInt64(this.SearchInformation?.TotalResults);
        }
    }

    public class SearchInformation
    {
        public double SearchTime { get; set; }

        public string FormattedSearchTime { get; set; }

        public string TotalResults { get; set; }

        public string FormattedTotalResults { get; set; }

    }

    public class SearchQueries
    {

        public List<SearchQuery> Request { get; set; }

        public List<SearchQuery> NextPage { get; set; }

    }


    public class SearchQuery
    {
        public string Title { get; set; }

        public string TotalResults { get; set; }

        public string SearchTerms { get; set; }

        public int Count { get; set; }

        public int StartIndex { get; set; }

    }
}
