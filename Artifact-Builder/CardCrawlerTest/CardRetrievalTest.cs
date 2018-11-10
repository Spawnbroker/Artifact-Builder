using CardCrawler.Adapters;
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
        [ExpectedException(typeof(NotImplementedException))]
        public void TestGetCardSet()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            try
            {
                CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
                myCardService.GetCardSet();
            }
            catch (NotImplementedException)
            {
                throw;
            }
            // Assert
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
