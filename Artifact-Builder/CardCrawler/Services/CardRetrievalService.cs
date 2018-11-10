using System;
using System.Collections.Generic;
using System.Text;
using CardCrawler.Adapters;
using CardCrawler.Entities;
using Microsoft.Extensions.Logging;

namespace CardCrawler.Services
{
    public class CardRetrievalService : ICardRetrievalService
    {
        private readonly ILoggingAdapter<CardRetrievalService> _logger;

        public CardRetrievalService(ILoggingAdapter<CardRetrievalService> logger)
        {
            this._logger = logger;
        }

        public CardSet GetCardSet()
        {
            _logger.LogInformation("Logger called from inside CardRetrievalService.");
            throw new NotImplementedException();
        }
    }
}
