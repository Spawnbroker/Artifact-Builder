using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Adapters
{
    public interface ILoggingAdapter<T>
    {
        void LogInformation(string message, params object[] args);

        void LogInformation(string message);
    }
}
