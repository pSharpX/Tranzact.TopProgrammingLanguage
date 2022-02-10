using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Dto;
using Tranzact.TopProgrammingLanguage.Contracts.Services;

namespace Tranzact.TopProgrammingLanguage.App.View
{
    public class AppView
    {
        private readonly ISearchFightService _service;

        public AppView(ISearchFightService service)
        {
            _service = service;
        }

        public void Render(SearchRequest request)
        {
            var response = _service.process(request).Result;

            response.ResultsBySearchTerm.ForEach(res =>
            {
                Console.WriteLine($"SearchTerm: {res.SearchTerm}");
                res.Results.ForEach(r =>
                {
                    Console.Write($"Search Engine: {r.SearchEngineName,-7} - ");
                    Console.Write(String.Format("{0,14:N0}", r.Total));
                    Console.WriteLine();
                });
                Console.WriteLine();
            });

            response.ResultsBySearchEngine.ForEach(res =>
            {
                Console.WriteLine($"{res.SearchEngine} Winner: {res.SearchTermWinner}");
            });
            Console.WriteLine();
            Console.WriteLine($"Total Winner: {response.SearchTermWinner}");
        }
    }
}
