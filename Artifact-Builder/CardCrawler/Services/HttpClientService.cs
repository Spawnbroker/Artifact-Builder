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
        private HttpClient _client;
        private readonly ILoggingAdapter<HttpClientService> _logger;

        public HttpClientService(ILoggingAdapter<HttpClientService> logger)
        {
            this._logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://playartifact.com/cardset/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetRawJsonFileLocation(string setId)
        { 
            if(string.IsNullOrEmpty(setId))
            {
                throw new ArgumentNullException(setId);
            }
            try
            {
                string result = null;
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + setId);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error thrown in HttpClientService.GetRawJsonFileLocation method.");
            }
            return null;
        }
    }
}
