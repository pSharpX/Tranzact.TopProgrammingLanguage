using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Enum;

namespace Tranzact.TopProgrammingLanguage.Contracts.Services
{
    public interface ISearchEngineResolver
    {
        ISearchService Get(SearchEngineTypes searchEngine);
    }
}
