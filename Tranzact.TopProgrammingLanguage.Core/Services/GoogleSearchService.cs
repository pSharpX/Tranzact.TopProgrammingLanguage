using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Entities;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories;
using Tranzact.TopProgrammingLanguage.Contracts.Dto;
using Tranzact.TopProgrammingLanguage.Contracts.Services;

namespace Tranzact.TopProgrammingLanguage.Core.Services
{
    public class GoogleSearchService : ISearchService
    {
        private readonly IGoogleSearchRepository _searchRepository;

        public GoogleSearchService(IGoogleSearchRepository searchRepository)
        {
            this._searchRepository = searchRepository;
        }

        public async Task<SearchEngineResponse> Search(string searchTerm)
        {
            ISearchResult searchResult = await this._searchRepository.Search(searchTerm);
            return new SearchEngineResponse(searchResult);
        }

        public async Task<List<SearchEngineResponse>> Search(List<string> searchTerms)
        {
            IEnumerable<Task<SearchEngineResponse>> tasks = searchTerms.Select(k => this.Search(k));
            IEnumerable<SearchEngineResponse> searchResults = await Task.WhenAll(tasks.ToArray());
            return searchResults.ToList();
        }
    }
}
