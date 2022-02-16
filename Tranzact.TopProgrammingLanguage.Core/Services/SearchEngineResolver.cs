using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Tranzact.TopProgrammingLanguage.Contracts.Enum;
using Tranzact.TopProgrammingLanguage.Contracts.Services;

namespace Tranzact.TopProgrammingLanguage.Core.Services
{
    public class SearchEngineResolver : ISearchEngineResolver
    {
        private readonly IDictionary<SearchEngineTypes, ISearchService> _searchEngines;

        public SearchEngineResolver(GoogleSearchService googleSearchService, BingSearchService bingSearchService, YahooSearchService yahooSearchService)
        {
            this._searchEngines = new Dictionary<SearchEngineTypes, ISearchService>
            {
                { SearchEngineTypes.GOOGLE, googleSearchService },
                { SearchEngineTypes.BING, bingSearchService },
                { SearchEngineTypes.YAHOO, yahooSearchService }
            }.ToImmutableDictionary();
        }

        public ISearchService Get(SearchEngineTypes searchEngine)
        {
            if (this._searchEngines.ContainsKey(searchEngine))
            {
                return this._searchEngines[searchEngine];
            }
            throw new NotImplementedException("search engine service not implemented");
        }

    }
}
