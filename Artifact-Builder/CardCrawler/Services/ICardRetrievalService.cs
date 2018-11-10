using CardCrawler.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Services
{
    public interface ICardRetrievalService
    {
        List<CardSet> All();
        CardSet GetCardSetById(string id);
        ArtifactCard GetCardById(string id);
        ArtifactCard GetCardByName(string name);
        List<ArtifactCard> GetCardsByType(string type);
        string GetRawSetData();
    }
}
