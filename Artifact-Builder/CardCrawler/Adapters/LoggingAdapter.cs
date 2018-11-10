using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Adapters
{
    public class LoggingAdapter<T> : ILoggingAdapter<T>
    {
        private readonly ILogger<T> _logger;

        public LoggingAdapter(ILogger<T> logger)
        {
            this._logger = logger;
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
