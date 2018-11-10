using CardCrawler.Accessors;
using CardCrawler.Adapters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CardCrawler.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientAccessor _clientAccessor;
        private readonly ILoggingAdapter<HttpClientService> _logger;
        private readonly HttpClient _client;

        public HttpClientService(ILoggingAdapter<HttpClientService> logger,
            IHttpClientAccessor clientAccessor)
        {
            this._logger = logger;
            this._clientAccessor = clientAccessor;
            this._client = _clientAccessor._client;
        }

        public async Task<string> GetRawJsonFileLocation(string setId)
        { 
            if(string.IsNullOrEmpty(setId))
            {
                throw new ArgumentNullException(setId);
            }
            string result = null;
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + setId);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
