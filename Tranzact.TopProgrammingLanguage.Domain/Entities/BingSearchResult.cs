﻿using System;
using Tranzact.TopProgrammingLanguage.Domain.Enums;
using Tranzact.TopProgrammingLanguage.Domain.Common;

namespace Tranzact.TopProgrammingLanguage.Domain.Entities
{
    public class BingSearchResult : ISearchResult
    {
        public string _type { get; set; }

        public QueryContext QueryContext { get; set; }

        public WebPages WebPages { get; set; }

        public BingSearchResult()
        {
        }

        public BingSearchResult(string searchTerm)
        {
            this.QueryContext = new QueryContext()
            {
                OriginalQuery = searchTerm
            };
        }

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

        public long GetTotal()
        {
            return this.WebPages?.TotalEstimatedMatches ?? 0;
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
