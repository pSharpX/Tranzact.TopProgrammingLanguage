using System.Collections.Generic;
using System.Linq;

namespace Tranzact.TopProgrammingLanguage.Contracts.Dto
{
    public class SearchResponse
    {
        public List<SearchResponseBySearchTerm> ResultsBySearchTerm { get; set; }

        public List<SearchResponseBySearchEngine> ResultsBySearchEngine { get; set; }

        public string SearchTermWinner()
        {
            if (this.ResultsBySearchEngine.Any())
            {
                return this.ResultsBySearchEngine.Where(x => x.Total == this.ResultsBySearchEngine.Max(x => x.Total)).First()?.SearchTermWinner;
            }
            return string.Empty;
        }

    }
}
