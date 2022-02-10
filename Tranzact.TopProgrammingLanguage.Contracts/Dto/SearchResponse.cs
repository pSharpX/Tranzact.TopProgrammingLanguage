using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.TopProgrammingLanguage.Contracts.Dto
{
    public class SearchResponse
    {
        public List<SearchResponseBySearchTerm> ResultsBySearchTerm { get; set; }

        public List<SearchResponseBySearchEngine> ResultsBySearchEngine { get; set; }

        public string SearchTermWinner => this.ResultsBySearchEngine.Where(x => x.Total == this.ResultsBySearchEngine.Max(x => x.Total)).First().SearchTermWinner;

    }
}
