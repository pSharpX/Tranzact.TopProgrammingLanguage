using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Dto;
using Tranzact.TopProgrammingLanguage.Contracts.Enum;
using Tranzact.TopProgrammingLanguage.Contracts.Services;

namespace Tranzact.TopProgrammingLanguage.Core.Services
{
    public class SearchFightService : ISearchFightService
    {
        private readonly ISearchEngineResolver _searchEngineResolver;

        public SearchFightService(ISearchEngineResolver searchEngineResolver)
        {
            this._searchEngineResolver = searchEngineResolver;
        }

        public async Task<SearchResponse> process(SearchRequest request)
        {
            var tasks = new List<Task<List<SearchEngineResponse>>>();
            tasks.Add(this._searchEngineResolver.Get(SearchEngineTypes.GOOGLE).Search(request.SearchTerms));
            tasks.Add(this._searchEngineResolver.Get(SearchEngineTypes.BING).Search(request.SearchTerms));
            IEnumerable<List<SearchEngineResponse>> responses = await Task.WhenAll(tasks.ToArray());

            var searchResponse = new SearchResponse
            {
                ResultsBySearchTerm = responses
                .SelectMany(x => x)
                .GroupBy(x => x.SearchTerm)
                .Select(group => new SearchResponseBySearchTerm
                {
                    SearchTerm = group.Key,
                    Results = group.ToList()
                })
                .ToList(),

                ResultsBySearchEngine = responses
                .SelectMany(x => x)
                .GroupBy(x => x.SearchEngineName)
                .Select(group =>
                {
                    var searchEngineResponse = group.Where(x => x.Total == group.Max(x => x.Total)).First();
                    return new SearchResponseBySearchEngine
                    {
                        SearchEngine = group.Key,
                        SearchTermWinner = searchEngineResponse.SearchTerm,
                        Total = searchEngineResponse.Total
                    };
                })
                .ToList(),
            };

            return searchResponse;
        }
    }
}
