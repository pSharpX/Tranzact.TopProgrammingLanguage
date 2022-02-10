using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Enum;
using Tranzact.TopProgrammingLanguage.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Tranzact.TopProgrammingLanguage.Core.Services
{
    public class SearchEngineResolver : ISearchEngineResolver
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly Dictionary<SearchEngineTypes, ISearchService> _searchEngines;

        public SearchEngineResolver(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            this._searchEngines = new Dictionary<SearchEngineTypes, ISearchService>();
            this._searchEngines.Add(SearchEngineTypes.GOOGLE, this._serviceProvider.GetService<GoogleSearchService>());
            this._searchEngines.Add(SearchEngineTypes.BING, this._serviceProvider.GetService<BingSearchService>());
            this._searchEngines.Add(SearchEngineTypes.YAHOO, this._serviceProvider.GetService<YahooSearchService>());
        }

        public ISearchService Get(SearchEngineTypes searchEngine)
        {
            if (this._searchEngines.ContainsKey(searchEngine))
            {
                return this._searchEngines.GetValueOrDefault(searchEngine);
            }
            throw new NotImplementedException();
        }

    }
}
