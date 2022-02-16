using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.TopProgrammingLanguage.Contracts.Config
{
    public class BingEngineConfig: SearchEngineConfig
    {
        public string SuscriptionKey { get; set; }

        public string CustomConfigId { get; set; }

        public override string CustomSearchPath { get; set; } = "v7.0/custom/search";
    }
}
