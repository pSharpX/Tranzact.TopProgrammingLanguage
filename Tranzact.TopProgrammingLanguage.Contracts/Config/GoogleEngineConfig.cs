using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.TopProgrammingLanguage.Contracts.Config
{
    public class GoogleEngineConfig: SearchEngineConfig
    {
        public string SearchEngineId { get; set; }

        public string ApiKey { get; set; }

        public override string CustomSearchPath { get; set; } = "customsearch/v1";
    }
}
