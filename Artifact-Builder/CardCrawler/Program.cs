using CardCrawler.Adapters;
using CardCrawler.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CardCrawler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogDebug("Starting application");

            serviceProvider.GetService<ICardRetrievalService>().GetRawSetData();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            services.AddLogging();
            services.AddTransient<ICardRetrievalService, CardRetrievalService>();
            services.AddTransient<ILoggingAdapter<CardRetrievalService>, LoggingAdapter<CardRetrievalService>>();
        }
    }
}
