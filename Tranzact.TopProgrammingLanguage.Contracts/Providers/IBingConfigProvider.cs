using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Config;

namespace Tranzact.TopProgrammingLanguage.Contracts.Providers
{
    public interface IBingConfigProvider: ISearchEngineConfigProvider<BingEngineConfig>
    {
    }
}
