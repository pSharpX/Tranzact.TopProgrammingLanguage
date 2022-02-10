using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Entities;

namespace Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories
{
    public interface ISearchRepository<TResult> where TResult: ISearchResult 
    {
        Task<TResult> Search(string searchTerm);
    }
}
