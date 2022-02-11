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
    public class GoogleSearchRepository : IGoogleSearchRepository
    {
        private readonly HttpClient _httpClient;

        private readonly GoogleEngineConfig _engineConfig;

        public GoogleSearchRepository(IOptions<GoogleEngineConfig> options)
        {
            this._engineConfig = options.Value;
            this._httpClient = new HttpClient { BaseAddress = new Uri(this._engineConfig.BaseUrl) };
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); ;
        }

        public async Task<GoogleSearchResult> Search(string searchTerm)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["cx"] = this._engineConfig.SearchEngineId;
            query["q"] = searchTerm;
            query["key"] = this._engineConfig.ApiKey;
            string queryString = query.ToString();
            HttpResponseMessage httpResponse = await this._httpClient.GetAsync($"{this._engineConfig.CustomSearchPath}?{queryString}");

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                return JsonSerializer.Deserialize<GoogleSearchResult>(response, options);
            }
            return new GoogleSearchResult(searchTerm);
        }
    }
}
