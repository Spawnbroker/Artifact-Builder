﻿using CardCrawler.Entities;
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
            file.cdn_root = test;
            // Assert
            Assert.AreEqual(test, file.cdn_root);
        }

        [TestMethod]
        public void FileExpirationDatePropTest()
        {
            // Arrange
            CardSetFile file = new CardSetFile();
            // Act
            file.expire_time = 1541860748;
            // Assert
            Assert.AreEqual(1541860748, file.expire_time);
        }

        [TestMethod]
        public void UrlPropTest()
        {
            // Arrange
            CardSetFile file = new CardSetFile();
            const string testUrl = "http://website.com";
            // Act
            file.url = testUrl;
            // Assert
            Assert.AreEqual(testUrl, file.url);
        }
    }
}
