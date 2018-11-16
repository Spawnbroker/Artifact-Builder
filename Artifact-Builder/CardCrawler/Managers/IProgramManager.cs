using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardCrawler.Managers
{
    public interface IProgramManager
    {
        Task Start(string[] args);
    }
}
