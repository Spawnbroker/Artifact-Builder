﻿using CardCrawler.Adapters;
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
            string result = await service.GetRawJsonFileLocation("00");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            services.AddLogging();
            services.AddTransient<ICardRetrievalService, CardRetrievalService>();
            services.AddTransient<ILoggingAdapter<CardRetrievalService>, LoggingAdapter<CardRetrievalService>>();
            services.AddTransient<ILoggingAdapter<HttpClientService>, LoggingAdapter<HttpClientService>>();
            services.AddTransient<IHttpClientService, HttpClientService>();
        }
    }
}
