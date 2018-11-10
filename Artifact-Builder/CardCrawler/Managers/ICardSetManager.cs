using CardCrawler.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Managers
{
    public interface ICardSetManager
    {
        CardSetFile GetCardSetFile(string setId);
    }
}
