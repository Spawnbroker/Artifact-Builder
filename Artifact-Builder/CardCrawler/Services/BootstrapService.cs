﻿using CardCrawler.Accessors;
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
        public ServiceProvider ServiceProvider { get; }

        public BootstrapService()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            this.ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void ConfigureServices(IServiceCollection services)
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
