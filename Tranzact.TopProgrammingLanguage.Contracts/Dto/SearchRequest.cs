using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.TopProgrammingLanguage.Contracts.Dto
{
    public class SearchRequest
    {
        public List<string> SearchTerms { get; set; }

        public SearchRequest(List<string> searchTerms)
        {
            SearchTerms = searchTerms;
        }
    }
}
