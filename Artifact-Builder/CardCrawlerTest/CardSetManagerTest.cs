using CardCrawler.Accessors;
using CardCrawler.Adapters;
using CardCrawler.Entities;
using CardCrawler.Managers;
using CardCrawler.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardCrawlerTest
{
    [TestClass]
    public class CardSetManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCardSetFileNullId()
        {
            // Arrange
            const string testContent = "test content";
            Mock<ILoggingAdapter<CardSetManager>> mockCardSetLogger = new Mock<ILoggingAdapter<CardSetManager>>();
            Mock<ILoggingAdapter<HttpClientService>> mockHttpLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            Mock<ILoggingAdapter<JsonParsingManager>> mockJsonLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            Mock<HttpMessageHandler> mockMessage = new Mock<HttpMessageHandler>();
            mockMessage.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpAccessor = new HttpClientAccessor(mockMessage.Object);
            Mock<HttpClientService> mockClientService = new Mock<HttpClientService>(mockHttpLogger.Object, httpAccessor);
            Mock<JsonParsingManager> mockJsonManager = new Mock<JsonParsingManager>(mockJsonLogger.Object);
            CardSetManager manager = new CardSetManager(mockCardSetLogger.Object, mockClientService.Object, mockJsonManager.Object);
            // Act
            manager.GetCardSetFile(null);
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCardSetFileEmptyId()
        {
            // Arrange
            const string testContent = "test content";
            Mock<ILoggingAdapter<CardSetManager>> mockCardSetLogger = new Mock<ILoggingAdapter<CardSetManager>>();
            Mock<ILoggingAdapter<HttpClientService>> mockHttpLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            Mock<ILoggingAdapter<JsonParsingManager>> mockJsonLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            Mock<HttpMessageHandler> mockMessage = new Mock<HttpMessageHandler>();
            mockMessage.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpAccessor = new HttpClientAccessor(mockMessage.Object);
            Mock<HttpClientService> mockClientService = new Mock<HttpClientService>(mockHttpLogger.Object, httpAccessor);
            Mock<JsonParsingManager> mockJsonManager = new Mock<JsonParsingManager>(mockJsonLogger.Object);
            CardSetManager manager = new CardSetManager(mockCardSetLogger.Object, mockClientService.Object, mockJsonManager.Object);
            // Act
            manager.GetCardSetFile("");
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestCardSetFileInvalidId()
        {
            // Arrange
            const string testContent = "test content";
            Mock<ILoggingAdapter<CardSetManager>> mockCardSetLogger = new Mock<ILoggingAdapter<CardSetManager>>();
            Mock<ILoggingAdapter<HttpClientService>> mockHttpLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            Mock<ILoggingAdapter<JsonParsingManager>> mockJsonLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            Mock<HttpMessageHandler> mockMessage = new Mock<HttpMessageHandler>();
            mockMessage.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpAccessor = new HttpClientAccessor(mockMessage.Object);
            Mock<HttpClientService> mockClientService = new Mock<HttpClientService>(mockHttpLogger.Object, httpAccessor);
            Mock<JsonParsingManager> mockJsonManager = new Mock<JsonParsingManager>(mockJsonLogger.Object);
            CardSetManager manager = new CardSetManager(mockCardSetLogger.Object, mockClientService.Object, mockJsonManager.Object);
            // Act
            CardSetFile setFile = manager.GetCardSetFile("lkjhekljhdjkfgksghdf");
            // Assert
            // Invalid Set Id seems to return the base set, but we want to throw a format exception
            Assert.Fail();
        }

        [TestMethod]
        public void TestCardSetFileValidId()
        {
            // Arrange
            const string testContent = "test content";
            Mock<ILoggingAdapter<CardSetManager>> mockCardSetLogger = new Mock<ILoggingAdapter<CardSetManager>>();
            Mock<ILoggingAdapter<HttpClientService>> mockHttpLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            Mock<ILoggingAdapter<JsonParsingManager>> mockJsonLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            Mock<HttpMessageHandler> mockMessage = new Mock<HttpMessageHandler>();
            mockMessage.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpAccessor = new HttpClientAccessor(mockMessage.Object);
            Mock<HttpClientService> mockClientService = new Mock<HttpClientService>(mockHttpLogger.Object, httpAccessor);
            Mock<JsonParsingManager> mockJsonManager = new Mock<JsonParsingManager>(mockJsonLogger.Object);
            CardSetManager manager = new CardSetManager(mockCardSetLogger.Object, mockClientService.Object, mockJsonManager.Object);
            // Act
            CardSetFile setFile = manager.GetCardSetFile("00");
            // Assert
            Assert.IsNotNull(setFile);
            Assert.IsNotNull(setFile.ContentDeliveryRoot);
            Assert.IsNotNull(setFile.FileExpirationDate);
            Assert.IsNotNull(setFile.Url);
        }
    }
}
