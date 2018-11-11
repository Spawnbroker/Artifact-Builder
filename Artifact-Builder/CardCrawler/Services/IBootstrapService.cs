using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardCrawler.Services
{
    public interface IBootstrapService
    {
        Task Start(string[] args);
    }
}
