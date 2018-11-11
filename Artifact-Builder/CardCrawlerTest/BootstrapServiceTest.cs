using CardCrawler.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawlerTest
{
    [TestClass]
    public class BootstrapServiceTest
    {
        [TestMethod]
        public void BootstrapConstructorTest()
        {
            BootstrapService service = new BootstrapService();
        }
    }
}
