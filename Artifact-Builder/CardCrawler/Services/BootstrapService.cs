using CardCrawler.Accessors;
using CardCrawler.Adapters;
using CardCrawler.Entities;
using CardCrawler.Managers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardCrawler.Services
{
    public class BootstrapService : IBootstrapService
    {
        private readonly ServiceProvider _serviceProvider;

        public BootstrapService()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
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

        public async Task Start(string[] args)
        {
            _serviceProvider.GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);
            var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogDebug("Starting application");
            IHttpClientService service = _serviceProvider.GetService<IHttpClientService>();
            string locationJson = await service.GetRawJsonFileLocation("01");
            IJsonParsingManager jsonParser = _serviceProvider.GetService<IJsonParsingManager>();
            CardSetFile cardSetFile = jsonParser.ParseRawJsonFileLocation(locationJson);
            logger.LogDebug(cardSetFile.ToString());
            string cardSetJson = await service.GetCardSetJson(cardSetFile);
            CardSet cards = jsonParser.ParseRawJsonFile(cardSetJson);
            logger.LogDebug(cards.ToString());
        }
    }
}
