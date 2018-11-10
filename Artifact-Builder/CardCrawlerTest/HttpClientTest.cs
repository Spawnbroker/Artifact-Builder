using CardCrawler.Accessors;
using CardCrawler.Adapters;
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
    public class HttpClientTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task TestGetRawJsonFileWithNull()
        {
            // Arrange
            const string testContent = "test content";
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            Mock<HttpMessageHandler> mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpClientAccessor = new HttpClientAccessor(mockMessageHandler.Object);
            // Act
            HttpClientService clientService = new HttpClientService(myLogger.Object, httpClientAccessor);
            string result = await clientService.GetRawJsonFileLocation(null);
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task TestGetRawJsonFileWithEmpty()
        {
            // Arrange
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            const string testContent = "test content";
            Mock<HttpMessageHandler> mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpClientAccessor = new HttpClientAccessor(mockMessageHandler.Object);
            // Act
            HttpClientService clientService = new HttpClientService(myLogger.Object, httpClientAccessor);
            string result = await clientService.GetRawJsonFileLocation("");
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task TestGetRawJsonFileWithInvalidSetId()
        {
            // Arrange
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            const string testContent = @"{""cdn_root"":""https:\/\/ steamcdn - a.akamaihd.net\/ "",""url"":""\/ apps\/ 583950\/ resource\/ card_set_0.BB8732855C64ACE2696DCF5E25DEDD98D134DD2A.json"",""expire_time"":1541859144}";
            Mock<HttpMessageHandler> mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpClientAccessor = new HttpClientAccessor(mockMessageHandler.Object);
            // Act
            HttpClientService clientService = new HttpClientService(myLogger.Object, httpClientAccessor);
            string result = await clientService.GetRawJsonFileLocation("welfhskdjfkgsdmfgbnsver");
            // Assert
            // Invalid Set Id seems to return the base set
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetRawJsonFileWithValidSetId()
        {
            // Arrange
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            const string testContent = @"{""cdn_root"":""https:\/\/ steamcdn - a.akamaihd.net\/ "",""url"":""\/ apps\/ 583950\/ resource\/ card_set_0.BB8732855C64ACE2696DCF5E25DEDD98D134DD2A.json"",""expire_time"":1541859144}";
            Mock<HttpMessageHandler> mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpClientAccessor = new HttpClientAccessor(mockMessageHandler.Object);
            // Act
            HttpClientService clientService = new HttpClientService(myLogger.Object, httpClientAccessor);
            Task<string> result = clientService.GetRawJsonFileLocation("00");
            // Assert
            Assert.IsNotNull(result.Result);
        }
    }
}
