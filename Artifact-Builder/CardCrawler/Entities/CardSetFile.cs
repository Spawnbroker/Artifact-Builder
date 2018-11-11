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

        public override string ToString()
        {
            string returnString = "CardSetFile Properties:\n"
                                + "\tcdn_root: " + cdn_root + "\n"
                                + "\texpire_time: " + expire_time + "\n"
                                + "\turl: " + url;
            return returnString;
        }
    }
}
