using CardCrawler.Adapters;
using CardCrawler.Entities;
using CardCrawler.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CardCrawlerTest
{
    [TestClass]
    public class CardRetrievalTest
    {
        [TestMethod]
        public void TestGetCardSet()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            CardSet cards = myCardService.GetCardSet();
            Assert.IsNotNull(cards);
        }
    }
}
