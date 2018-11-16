using CardCrawler.Adapters;
using CardCrawler.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;
using static CardCrawler.Entities.CardSetFile;

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
            if(string.IsNullOrEmpty(rawJson))
            {
                throw new ArgumentNullException("rawJson");
            }
            JsonValue json = null;
            try
            {
                json = JsonValue.Parse(rawJson);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Exception thrown in JsonParsingManager.ParseRawJsonFile method.");
                throw new FormatException("rawJson was not in JSON format.", ex);
            }
            CardSetRootObject jsonObject = JsonConvert.DeserializeObject<CardSetRootObject>(rawJson);
            return jsonObject.card_set;
        }

        public CardSetFile ParseRawJsonFileLocation(string locationUrl)
        {
            if(string.IsNullOrEmpty(locationUrl))
            {
                throw new ArgumentNullException("locationUrl");
            }
            JsonValue jsonLocationUrl = null;
            try
            {
                jsonLocationUrl = JsonValue.Parse(locationUrl);
            }
            catch(ArgumentException ex)
            {
                _logger.LogError(ex, "Exception thrown in JsonParsingManager.ParseRawJsonFileLocation method.");
                throw new FormatException("locationUrl was not in JSON format.", ex);
            }
            CardSetFile cardSetFile = JsonConvert.DeserializeObject<CardSetFile>(locationUrl);
            string cdnRootKey = "cdn_root";
            string dateKey = "expire_time";
            string urlKey = "url";
            if (!jsonLocationUrl.ContainsKey(cdnRootKey)
             || !jsonLocationUrl.ContainsKey(dateKey)
             || !jsonLocationUrl.ContainsKey(urlKey))
            { 
                FormatException ex = new FormatException("locationUrl was in JSON format, but did not have the correct keys.");
                _logger.LogError(ex, "Exception thrown in JsonParsingManager.ParseRawJsonFileLocation method.");
                throw ex;
            }
            return cardSetFile;
        }
    }
}
