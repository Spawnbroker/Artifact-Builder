using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Adapters
{
    public interface ILoggingAdapter<CardRetrievalService>
    {
        void LogInformation(string message, params object[] args);

        void LogInformation(string message);
    }
}
