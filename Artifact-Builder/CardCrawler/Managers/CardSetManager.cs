﻿using CardCrawler.Adapters;
using CardCrawler.Entities;
using CardCrawler.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<CardSetFile> GetCardSetFile(string setId)
        {
            if(string.IsNullOrEmpty(setId))
            {
                ArgumentNullException ex = new ArgumentNullException("setId");
                _logger.LogError(ex, "Exception thrown in CardSetManager.GetCardSetFile method.");
                throw ex;
            }
            int setIdInt;
            bool parseSucceeded = Int32.TryParse(setId, out setIdInt);
            if(!parseSucceeded)
            {
                FormatException ex = new FormatException("setId was not an integer.");
                _logger.LogError(ex, "Exception thrown in CardSetManager.GetCardSetFile method.");
                throw ex;
            }
            string fileLocation = await _httpService.GetRawJsonFileLocation(setId);
            return _jsonParser.ParseRawJsonFileLocation(fileLocation);
        }
    }
}
