using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Domain.Enums;

namespace Tranzact.TopProgrammingLanguage.Contracts.Services
{
    public interface ISearchEngineResolver
    {
        ISearchService Get(SearchEngineTypes searchEngine);
    }
}
