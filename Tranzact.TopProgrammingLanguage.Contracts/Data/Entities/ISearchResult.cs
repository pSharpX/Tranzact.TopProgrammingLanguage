using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Enum;

namespace Tranzact.TopProgrammingLanguage.Contracts.Data.Entities
{
    public interface ISearchResult
    {
        long GetTotal();

        string GetSearchTerm();

        string GetSearchTime();

        SearchEngineTypes GetSearchEngine();
    }
}
