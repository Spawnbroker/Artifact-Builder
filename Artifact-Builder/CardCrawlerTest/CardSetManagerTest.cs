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
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task TestCardSetFileNullId()
        {
            // Arrange
            const string testContent = "test content";
            Mock<ILoggingAdapter<CardSetManager>> mockCardSetLogger = new Mock<ILoggingAdapter<CardSetManager>>();
            mockCardSetLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
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
            Mock<IHttpClientService> mockClientService = new Mock<IHttpClientService>();
            Mock<IJsonParsingManager> mockJsonManager = new Mock<IJsonParsingManager>();
            CardSetManager manager = new CardSetManager(mockCardSetLogger.Object, mockClientService.Object, mockJsonManager.Object);
            // Act
            await manager.GetCardSetFile(null);
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task TestCardSetFileEmptyId()
        {
            // Arrange
            const string testContent = "test content";
            Mock<ILoggingAdapter<CardSetManager>> mockCardSetLogger = new Mock<ILoggingAdapter<CardSetManager>>();
            mockCardSetLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
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
            Mock<IHttpClientService> mockClientService = new Mock<IHttpClientService>();
            Mock<IJsonParsingManager> mockJsonManager = new Mock<IJsonParsingManager>();
            CardSetManager manager = new CardSetManager(mockCardSetLogger.Object, mockClientService.Object, mockJsonManager.Object);
            // Act
            await manager.GetCardSetFile("");
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public async Task TestCardSetFileInvalidId()
        {
            // Arrange
            const string testContent = "test content";
            Mock<ILoggingAdapter<CardSetManager>> mockCardSetLogger = new Mock<ILoggingAdapter<CardSetManager>>();
            mockCardSetLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
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
            Mock<IHttpClientService> mockClientService = new Mock<IHttpClientService>();
            Mock<IJsonParsingManager> mockJsonManager = new Mock<IJsonParsingManager>();
            CardSetManager manager = new CardSetManager(mockCardSetLogger.Object, mockClientService.Object, mockJsonManager.Object);
            // Act
            CardSetFile setFile = await manager.GetCardSetFile("lkjhekljhdjkfgksghdf");
            // Assert
            // Invalid Set Id seems to return the base set, but we want to throw a format exception
        }

        [TestMethod]
        public async Task TestCardSetFileValidId()
        {
            // Arrange
            const string testContent = "test content";
            string testSetId = "00";
            string testFileLocation = @"{""cdn_root"":""https:\/\/ steamcdn - a.akamaihd.net\/ "",""url"":""\/ apps\/ 583950\/ resource\/ card_set_0.BB8732855C64ACE2696DCF5E25DEDD98D134DD2A.json"",""expire_time"":1541859144}";
            Mock<ILoggingAdapter<CardSetManager>> mockCardSetLogger = new Mock<ILoggingAdapter<CardSetManager>>();
            mockCardSetLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
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
            Mock<IHttpClientService> mockClientService = new Mock<IHttpClientService>();
            mockClientService.Setup(mockClient => mockClient.GetRawJsonFileLocation(testSetId)).Returns(Task.FromResult(testFileLocation));
            Mock<IJsonParsingManager> mockJsonManager = new Mock<IJsonParsingManager>();
            mockJsonManager.Setup(jsonManager => jsonManager.ParseRawJsonFileLocation(testFileLocation))
                .Returns(new CardSetFile
                {
                    cdn_root = @"https:\/\/ steamcdn - a.akamaihd.net\/",
                    expire_time = 1541859144,
                    url = @"\/apps\/583950\/resource\/card_set_0.BB8732855C64ACE2696DCF5E25DEDD98D134DD2A.json"
                });
            CardSetManager manager = new CardSetManager(mockCardSetLogger.Object, mockClientService.Object, mockJsonManager.Object);
            // Act
            CardSetFile setFile = await manager.GetCardSetFile(testSetId);
            // Assert
            Assert.IsNotNull(setFile);
            Assert.IsNotNull(setFile.cdn_root);
            Assert.IsNotNull(setFile.expire_time);
            Assert.IsNotNull(setFile.url);
        }
    }
}
