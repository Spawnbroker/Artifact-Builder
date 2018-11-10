using CardCrawler.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawlerTest
{
    [TestClass]
    public class CardSetFileTest
    {
        [TestMethod]
        public void ContentDeliveryRootPropTest()
        {
            // Arrange
            CardSetFile file = new CardSetFile();
            const string test = "testWebsite";
            // Act
            file.ContentDeliveryRoot = test;
            // Assert
            Assert.AreEqual(test, file.ContentDeliveryRoot);
        }

        [TestMethod]
        public void FileExpirationDatePropTest()
        {
            // Arrange
            CardSetFile file = new CardSetFile();
            DateTime today = new DateTime(2018, 11, 10);
            // Act
            file.FileExpirationDate = today;
            // Assert
            Assert.AreEqual(today, file.FileExpirationDate);
        }

        [TestMethod]
        public void UrlPropTest()
        {
            // Arrange
            CardSetFile file = new CardSetFile();
            const string testUrl = "http://website.com";
            // Act
            file.Url = testUrl;
            // Assert
            Assert.AreEqual(testUrl, file.Url);
        }
    }
}
