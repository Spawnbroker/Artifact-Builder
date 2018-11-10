using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Adapters
{
    public class LoggingAdapter<CardRetrievalService> : ILoggingAdapter<CardRetrievalService>
    {
        private readonly ILoggingAdapter<CardRetrievalService> _logger;

        public LoggingAdapter(ILoggingAdapter<CardRetrievalService> logger)
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
