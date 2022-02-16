using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.TopProgrammingLanguage.Contracts.Providers
{
    public interface IHttpClientProvider
    {
        HttpClient GetHttpClient();
    }
}
