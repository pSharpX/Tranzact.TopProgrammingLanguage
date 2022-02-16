using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories;
using Tranzact.TopProgrammingLanguage.Contracts.Dto;
using Tranzact.TopProgrammingLanguage.Contracts.Services;

namespace Tranzact.TopProgrammingLanguage.Core.Services
{
    public class YahooSearchService : ISearchService
    {
        private readonly IYahooSearchRepository _searchRepository;

        public YahooSearchService(IYahooSearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public Task<SearchEngineResponse> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<List<SearchEngineResponse>> Search(List<string> searchTerms)
        {
            throw new NotImplementedException();
        }
    }
}
