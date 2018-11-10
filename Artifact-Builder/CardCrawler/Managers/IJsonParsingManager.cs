using CardCrawler.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Managers
{
    public interface IJsonParsingManager
    {
        CardSetFile ParseRawJsonFileLocation(string location);

        CardSet ParseRawJsonFile(string rawJson);
    }
}
