using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Entities
{
    public class CardSetFile
    {
        public string ContentDeliveryRoot { get; set; }
        public string Url { get; set; }
        public DateTime FileExpirationDate { get; set; }
    }
}
