using CardCrawler.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardCrawler.Managers
{
    public interface ICardSetManager
    {
        Task<CardSetFile> GetCardSetFile(string setId);
    }
}
