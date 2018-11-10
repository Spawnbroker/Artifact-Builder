using CardCrawler.Adapters;
using CardCrawler.Entities;
using CardCrawler.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Managers
{
    public class CardSetManager : ICardSetManager
    {
        private readonly ILoggingAdapter<CardSetManager> _logger;
        private readonly IHttpClientService _httpService;
        private readonly IJsonParsingManager _jsonParser;

        public CardSetManager(ILoggingAdapter<CardSetManager> logger,
            IHttpClientService httpService,
            IJsonParsingManager jsonParser)
        {
            this._logger = logger;
            this._httpService = httpService;
            this._jsonParser = jsonParser;
        }

        public CardSetFile GetCardSetFile(string setId)
        {
            throw new NotImplementedException();
        }
    }
}
