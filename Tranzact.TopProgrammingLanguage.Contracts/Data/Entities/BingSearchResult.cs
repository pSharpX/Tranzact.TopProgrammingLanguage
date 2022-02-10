using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Enum;

namespace Tranzact.TopProgrammingLanguage.Contracts.Data.Entities
{
    public class BingSearchResult : ISearchResult
    {
        public string _type { get; set; }

        public QueryContext QueryContext { get; set; }

        public WebPages WebPages { get; set; }

        public SearchEngineTypes GetSearchEngine()
        {
            return SearchEngineTypes.BING;
        }

        public string GetSearchTerm()
        {
            return this.QueryContext?.OriginalQuery;
        }

        public string GetSearchTime()
        {
            throw new NotImplementedException();
        }

        public long? GetTotal()
        {
            return this.WebPages?.TotalEstimatedMatches;
        }
    }

    public class QueryContext 
    {
        public string OriginalQuery { get; set; }
    }

    public class WebPages
    {
        public string WebSearchUrl { get; set; }

        public int TotalEstimatedMatches { get; set; }

        public WebPage[] Value { get; set; }

    }

    public class WebPage
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string DisplayUrl { get; set; }

        public string Snippet { get; set; }

        public DateTime DateLastCrawled { get; set; }

        public string CachedPageUrl { get; set; }

    }
}
