using CardCrawler.Accessors;
using CardCrawler.Adapters;
using CardCrawler.Entities;
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

        public async Task<string> GetCardSetJson(CardSetFile file)
        {
            if(file == null 
                || string.IsNullOrEmpty(file.cdn_root)
                || string.IsNullOrEmpty(file.url))
            {
                ArgumentNullException ex = new ArgumentNullException("file");
                _logger.LogError(ex, "CardSetFile cannot be null or empty.");
                throw ex;
            }
            if(file.cdn_root.Contains(@"\/"))
            {
                FormatException ex = new FormatException("Invalid url format, escape characters are still in the string.");
                _logger.LogError(ex, "Exception thrown in HttpClientService.GetCardSetJson method.");
                throw ex;
            }
            string result = null;
            HttpResponseMessage response = await _client.GetAsync(file.cdn_root + file.url);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

        public async Task<string> GetRawJsonFileLocation(string setId)
        { 
            if(string.IsNullOrEmpty(setId))
            {
                ArgumentNullException ex = new ArgumentNullException("setId");
                _logger.LogError(ex, "Exception thrown in HttpClientService.GetRawJsonFileLocation method.");
                throw ex;
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
