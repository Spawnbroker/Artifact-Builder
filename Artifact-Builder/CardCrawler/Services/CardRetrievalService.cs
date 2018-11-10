using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public List<CardSet> All()
        {
            throw new NotImplementedException();
        }

        public ArtifactCard GetCardById(string id)
        {
            throw new NotImplementedException();
        }

        public ArtifactCard GetCardByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<ArtifactCard> GetCardsByType(string type)
        {
            throw new NotImplementedException();
        }
        
        public CardSet GetCardSetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
