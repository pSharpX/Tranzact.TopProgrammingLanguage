using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.TopProgrammingLanguage.Contracts.Config
{
    public class GoogleEngineConfig
    {
        public string SearchEngineId { get; set; }

        public string ApiKey { get; set; }

        public string BaseUrl { get; set; }

        public string CustomSearchPath { get; set; } = "customsearch/v1";
    }
}
