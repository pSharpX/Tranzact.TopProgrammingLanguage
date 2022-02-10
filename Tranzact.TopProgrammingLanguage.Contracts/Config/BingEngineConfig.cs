using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.TopProgrammingLanguage.Contracts.Config
{
    public class BingEngineConfig
    {
        public string SuscriptionKey { get; set; }

        public string CustomConfigId { get; set; }

        public string BaseUrl { get; set; }

        public string CustomSearchPath { get; set; } = "v7.0/custom/search";
    }
}
