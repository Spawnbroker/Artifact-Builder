using CardCrawler.Entities;
using CardCrawler.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardCrawler.Managers
{
    public class ProgramManager : IProgramManager
    {
        private readonly ServiceProvider _serviceProvider;

        public ProgramManager(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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
