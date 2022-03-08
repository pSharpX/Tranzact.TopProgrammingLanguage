using System;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories;
using Tranzact.TopProgrammingLanguage.Domain.Entities;

namespace Tranzact.TopProgrammingLanguage.Infrastructure.Data.Repositories
{
    public class YahooSearchRepository : IYahooSearchRepository
    {
        public Task<YahooSearchResult> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
