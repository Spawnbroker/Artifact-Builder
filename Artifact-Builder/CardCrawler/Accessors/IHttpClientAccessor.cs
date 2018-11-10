using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CardCrawler.Accessors
{
    public interface IHttpClientAccessor
    {
        HttpClient _client { get; }
    }
}
