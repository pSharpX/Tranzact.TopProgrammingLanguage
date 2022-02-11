using System;
using Microsoft.Extensions.DependencyInjection;
using Tranzact.TopProgrammingLanguage.Contracts.Dto;
using Tranzact.TopProgrammingLanguage.App.View;
using System.Collections.Generic;

namespace Tranzact.TopProgrammingLanguage.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var appView = serviceProvider.GetService<AppView>();

            appView.Render(new SearchRequest(new List<string>() { "java", "c#"}));
            //appView.Render(new SearchRequest(new List<string>(args)));
        }
    }
}
