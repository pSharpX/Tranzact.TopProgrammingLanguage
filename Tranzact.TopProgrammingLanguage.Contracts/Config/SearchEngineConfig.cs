using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.TopProgrammingLanguage.Contracts.Config
{
    public abstract class SearchEngineConfig
    {
        public string BaseUrl { get; set; }

        public abstract string CustomSearchPath { get; set; }
    }
}
