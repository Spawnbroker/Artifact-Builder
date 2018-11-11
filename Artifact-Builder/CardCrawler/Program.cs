using CardCrawler.Accessors;
using CardCrawler.Adapters;
using CardCrawler.Entities;
using CardCrawler.Managers;
using CardCrawler.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CardCrawler
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            BootstrapService bootstrapper = new BootstrapService();
            await bootstrapper.Start(args);
            Console.ReadKey();
        }
    }
}
