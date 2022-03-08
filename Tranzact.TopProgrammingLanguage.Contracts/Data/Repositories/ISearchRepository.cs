using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Domain.Common;

namespace Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories
{
    public interface ISearchRepository<TResult> where TResult: ISearchResult 
    {
        Task<TResult> Search(string searchTerm);
    }
}
