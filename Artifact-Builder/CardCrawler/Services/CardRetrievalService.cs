using System;
using System.Collections.Generic;
using System.Text;
using CardCrawler.Entities;
using Microsoft.Extensions.Logging;

namespace CardCrawler.Services
{
    public class CardRetrievalService : ICardRetrievalService
    {
        private readonly ILogger _logger;

        public CardRetrievalService(ILogger<CardRetrievalService> logger)
        {
            this._logger = logger;
        }

        public CardSet GetCardSet()
        {
            _logger.LogInformation("Logger called from inside CardRetrievalService.");
            Console.ReadKey();
            throw new NotImplementedException();
        }
    }
}
