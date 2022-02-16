using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Providers;

namespace Tranzact.TopProgrammingLanguage.Infrastructure.Providers
{
    public class HttpClientProvider : IHttpClientProvider
    {
        public HttpClient GetHttpClient()
        {
            return new HttpClient();
        }
    }
}
