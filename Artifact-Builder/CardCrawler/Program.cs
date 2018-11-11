using CardCrawler.Accessors;
using CardCrawler.Adapters;
using CardCrawler.Entities;
using CardCrawler.Managers;
using CardCrawler.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CardCrawler
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogDebug("Starting application");
            IHttpClientService service = serviceProvider.GetService<IHttpClientService>();
            string locationJson = await service.GetRawJsonFileLocation("00");
            IJsonParsingManager jsonParser = serviceProvider.GetService<IJsonParsingManager>();
            CardSetFile cardSetFile = jsonParser.ParseRawJsonFileLocation(locationJson);
            string cardSetJson = await service.GetCardSetJson(cardSetFile);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            services.AddLogging();
            services.AddTransient<ICardRetrievalService, CardRetrievalService>();
            services.AddTransient<ILoggingAdapter<CardRetrievalService>, LoggingAdapter<CardRetrievalService>>();
            services.AddTransient<IHttpClientService, HttpClientService>();
            services.AddTransient<ILoggingAdapter<HttpClientService>, LoggingAdapter<HttpClientService>>();
            services.AddSingleton<IHttpClientAccessor, HttpClientAccessor>();
            services.AddTransient<ICardSetManager, CardSetManager>();
            services.AddTransient<ILoggingAdapter<CardSetManager>, LoggingAdapter<CardSetManager>>();
            services.AddTransient<IJsonParsingManager, JsonParsingManager>();
            services.AddTransient<ILoggingAdapter<JsonParsingManager>, LoggingAdapter<JsonParsingManager>>();
        }
    }
}
