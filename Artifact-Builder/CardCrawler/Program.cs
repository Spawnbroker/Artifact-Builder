using CardCrawler.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CardCrawler
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);
            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
                logger.LogDebug("Starting application");

            serviceProvider.GetService<ICardRetrievalService>().GetCardSet();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            serviceCollection.AddLogging();
            serviceCollection.AddTransient<ICardRetrievalService, CardRetrievalService>();
        }
    }
}
