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
    public class GoogleConfigProvider : IGoogleConfigProvider
    {
        private readonly IOptions<GoogleEngineConfig> _options;

        public GoogleConfigProvider(IOptions<GoogleEngineConfig> options)
        {
            _options = options;
        }

        public GoogleEngineConfig GetSearchEngineConfig()
        {
            return _options.Value;
        }
    }
}
