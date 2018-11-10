using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CardCrawler.Accessors
{
    public class HttpClientAccessor : IHttpClientAccessor
    {
        public HttpClient _client { get; }
        
        public HttpClientAccessor() : this(new HttpClientHandler())
        {
        }

        public HttpClientAccessor(HttpMessageHandler messageHandler)
        {
            _client = new HttpClient(messageHandler);
            _client.BaseAddress = new Uri("https://playartifact.com/cardset/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
