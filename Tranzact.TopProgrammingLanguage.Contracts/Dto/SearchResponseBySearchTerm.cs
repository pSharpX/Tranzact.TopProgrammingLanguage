using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.TopProgrammingLanguage.Contracts.Dto
{
    public class SearchResponseBySearchTerm
    {
        public List<SearchEngineResponse> Results { get; set; }

        public string SearchTerm { get; set; }

    }
}
