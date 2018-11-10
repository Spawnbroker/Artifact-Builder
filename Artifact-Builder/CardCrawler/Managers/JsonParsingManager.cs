using CardCrawler.Adapters;
using CardCrawler.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Managers
{
    public class JsonParsingManager : IJsonParsingManager
    {
        private readonly ILoggingAdapter<JsonParsingManager> _logger;

        public JsonParsingManager(ILoggingAdapter<JsonParsingManager> logger)
        {
            this._logger = logger;
        }

        public CardSet ParseRawJsonFile(string rawJson)
        {
            throw new NotImplementedException();
        }

        public CardSetFile ParseRawJsonFileLocation(string locationUrl)
        {
            throw new NotImplementedException();
        }
    }
}
