using CardCrawler.Adapters;
using CardCrawler.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardCrawlerTest
{
    [TestClass]
    public class HttpClientTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetRawJsonFileWithNull()
        {
            // Arrange
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            HttpClientService clientService = new HttpClientService(myLogger.Object);
            Task<string> result = clientService.GetRawJsonFileLocation(null);
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetRawJsonFileWithEmpty()
        {
            // Arrange
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            HttpClientService clientService = new HttpClientService(myLogger.Object);
            Task<string> result = clientService.GetRawJsonFileLocation("");
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void TestGetRawJsonFileWithInvalidSetId()
        {
            // Arrange
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            HttpClientService clientService = new HttpClientService(myLogger.Object);
            Task<string> result = clientService.GetRawJsonFileLocation("welfhskdjfkgsdmfgbnsver");
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetRawJsonFileWithValidSetId()
        {
            // Arrange
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            HttpClientService clientService = new HttpClientService(myLogger.Object);
            Task<string> result = clientService.GetRawJsonFileLocation("00");
            // Assert
            Assert.IsNotNull(result.Result);
        }
    }
}
