using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tranzact.TopProgrammingLanguage.App.View;
using Tranzact.TopProgrammingLanguage.Contracts.Config;
using Tranzact.TopProgrammingLanguage.Contracts.Data.Repositories;
using Tranzact.TopProgrammingLanguage.Contracts.Providers;
using Tranzact.TopProgrammingLanguage.Contracts.Services;
using Tranzact.TopProgrammingLanguage.Core.Services;
using Tranzact.TopProgrammingLanguage.Infrastructure.Data.Repositories;
using Tranzact.TopProgrammingLanguage.Infrastructure.Providers;

namespace Tranzact.TopProgrammingLanguage.App
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information);
            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpClientProvider, HttpClientProvider>();
            services.AddSingleton<IBingConfigProvider, BingConfigProvider>();
            services.AddSingleton<IGoogleConfigProvider, GoogleConfigProvider>();

            services.AddSingleton<IGoogleSearchRepository, GoogleSearchRepository>();
            services.AddSingleton<IBingSearchRepository, BingSearchRepository>();
            services.AddSingleton<IYahooSearchRepository, YahooSearchRepository>();

            services.AddSingleton<ISearchEngineResolver, SearchEngineResolver>();
            services.AddSingleton<ISearchFightService, SearchFightService>();

            services.AddSingleton<GoogleSearchService>();
            services.AddSingleton<BingSearchService>();
            services.AddSingleton<YahooSearchService>();
            services.AddSingleton<AppView>();

            services.Configure<BingEngineConfig>(options => Configuration.GetSection("BingEngineConfig").Bind(options));
            services.Configure<GoogleEngineConfig>(options => Configuration.GetSection("GoogleEngineConfig").Bind(options));
        }
    }
}
