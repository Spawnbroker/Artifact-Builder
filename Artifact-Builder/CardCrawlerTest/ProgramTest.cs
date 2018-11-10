using CardCrawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawlerTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void TestMain()
        {
            Program.Main(new string[] { "test data 1", "test data 2", "test data 3" });
        }
    }
}
