using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Adapters
{
    public interface ILoggingAdapter<T>
    {
        void LogError(Exception ex, string message, params object[] args);

        void LogError(Exception ex, string message);

        void LogInformation(string message, params object[] args);

        void LogInformation(string message);
    }
}
