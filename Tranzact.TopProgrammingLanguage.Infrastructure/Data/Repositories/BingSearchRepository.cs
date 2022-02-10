using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Tranzact.TopProgrammingLanguage.Contracts.Config;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Entities;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories;

namespace Tranzact.TopProgrammingLanguage.Infrastructure.Data.Repositories
{
    public class BingSearchRepository : IBingSearchRepository
    {
        private readonly HttpClient _httpClient;

        private readonly BingEngineConfig _engineConfig;

        public BingSearchRepository(IOptions<BingEngineConfig> options)
        {
            this._engineConfig = options.Value;
            this._httpClient = new HttpClient { BaseAddress = new Uri(this._engineConfig.BaseUrl) };
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); ;
            this._httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this._engineConfig.SuscriptionKey);
        }

        public async Task<BingSearchResult> Search(string searchTerm)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["customconfig"] = this._engineConfig.CustomConfigId;
            query["q"] = searchTerm;
            string queryString = query.ToString();
            HttpResponseMessage httpResponse = await this._httpClient.GetAsync($"{this._engineConfig.CustomSearchPath}?{queryString}");
            var response = await httpResponse.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<BingSearchResult>(response, options);
        }
    }
}
