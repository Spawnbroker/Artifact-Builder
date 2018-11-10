using CardCrawler.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Services
{
    public interface ICardRetrievalService
    {
        CardSet GetCardSet();
    }
}
