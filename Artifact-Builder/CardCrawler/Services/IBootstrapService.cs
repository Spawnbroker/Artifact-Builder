﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardCrawler.Services
{
    public interface IBootstrapService
    {
        void ConfigureServices(IServiceCollection services);
    }
}
