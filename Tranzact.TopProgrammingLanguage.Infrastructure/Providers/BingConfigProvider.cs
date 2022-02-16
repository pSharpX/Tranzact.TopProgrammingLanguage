using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Config;
using Tranzact.TopProgrammingLanguage.Contracts.Providers;

namespace Tranzact.TopProgrammingLanguage.Infrastructure.Providers
{
    public class BingConfigProvider : IBingConfigProvider
    {
        private readonly IOptions<BingEngineConfig> _options;

        public BingConfigProvider(IOptions<BingEngineConfig> options)
        {
            _options = options;
        }

        public BingEngineConfig GetSearchEngineConfig()
        {
            return _options.Value;
        }
    }
}
