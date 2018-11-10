using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Entities
{
    public class CardSetFile
    {
        public string cdn_root { get; set; }
        public string url { get; set; }
        public int expire_time { get; set; }
    }
}
