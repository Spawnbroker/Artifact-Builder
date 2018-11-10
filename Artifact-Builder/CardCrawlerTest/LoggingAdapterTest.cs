using CardCrawler.Adapters;
using CardCrawler.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawlerTest
{
    [TestClass]
    public class LoggingAdapterTest
    {
        [TestMethod]
        public void TestLogInformationNoParams()
        {
            // Arrange
            Mock<ILogger<CardRetrievalService>> myLogger = new Mock<ILogger<CardRetrievalService>>();
            // Act
            LoggingAdapter<CardRetrievalService> logAdapter = new LoggingAdapter<CardRetrievalService>(myLogger.Object);
            logAdapter.LogInformation("Test logging");
            // Assert
        }

        [TestMethod]
        public void TestLogInformationWithParams()
        {
            // Arrange
            Mock<ILogger<CardRetrievalService>> myLogger = new Mock<ILogger<CardRetrievalService>>();
            // Act
            LoggingAdapter<CardRetrievalService> logAdapter = new LoggingAdapter<CardRetrievalService>(myLogger.Object);
            logAdapter.LogInformation("Test logging", new object[] { });
            // Assert
        }

        [TestMethod]
        public void TestLogErrorNoParams()
        {
            // Arrange
            Mock<ILogger<CardRetrievalService>> myLogger = new Mock<ILogger<CardRetrievalService>>();
            // Act
            LoggingAdapter<CardRetrievalService> logAdapter = new LoggingAdapter<CardRetrievalService>(myLogger.Object);
            logAdapter.LogError(new Exception(), "Test logging");
            // Assert
        }

        [TestMethod]
        public void TestLogErrorWithParams()
        {
            // Arrange
            Mock<ILogger<CardRetrievalService>> myLogger = new Mock<ILogger<CardRetrievalService>>();
            // Act
            LoggingAdapter<CardRetrievalService> logAdapter = new LoggingAdapter<CardRetrievalService>(myLogger.Object);
            logAdapter.LogError(new Exception(), "Test logging", new object[] { });
            // Assert
        }
    }
}
