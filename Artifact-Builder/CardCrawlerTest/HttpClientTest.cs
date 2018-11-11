using CardCrawler.Accessors;
using CardCrawler.Adapters;
using CardCrawler.Entities;
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
        public async Task TestGetRawJsonFileWithValidSetId()
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
            string result = await clientService.GetRawJsonFileLocation("00");
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task TestGetCardSetJsonWithNull()
        {
            // Arrange
            const string testContent = @"{ ""card_set"":{ ""version"":1,""set_info"":{ ""set_id"":0,""pack_item_def"":0,""name"":{ ""english"":""Base Set""} },""card_list"":[{""card_id"":1000,""base_card_id"":1000,""card_type"":""Stronghold"",""card_name"":{""english"":""Ancient Tower""},""card_text"":{},""mini_image"":{""default"":""https://steamcdn-a.akamaihd.net/apps/583950/icons/set00/1000.91b2ed80da07ef5cf343540b09687fbf875168c8.png""},""large_image"":{""default"":""https://steamcdn-a.akamaihd.net/apps/583950/icons/set00/1000_large_english.3dea67025da70c778d014dc3aae80c0c0a7008a6.png""},""ingame_image"":{},""hit_points"":80,""references"":[]}]}}";
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            Mock<HttpMessageHandler> mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpClientAccessor = new HttpClientAccessor(mockMessageHandler.Object);
            HttpClientService clientService = new HttpClientService(myLogger.Object, httpClientAccessor);
            // Act
            string result = await clientService.GetCardSetJson(null);
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task TestGetCardSetJsonWithEmpty()
        {
            // Arrange
            const string testContent = @"{ ""card_set"":{ ""version"":1,""set_info"":{ ""set_id"":0,""pack_item_def"":0,""name"":{ ""english"":""Base Set""} },""card_list"":[{""card_id"":1000,""base_card_id"":1000,""card_type"":""Stronghold"",""card_name"":{""english"":""Ancient Tower""},""card_text"":{},""mini_image"":{""default"":""https://steamcdn-a.akamaihd.net/apps/583950/icons/set00/1000.91b2ed80da07ef5cf343540b09687fbf875168c8.png""},""large_image"":{""default"":""https://steamcdn-a.akamaihd.net/apps/583950/icons/set00/1000_large_english.3dea67025da70c778d014dc3aae80c0c0a7008a6.png""},""ingame_image"":{},""hit_points"":80,""references"":[]}]}}";
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            Mock<HttpMessageHandler> mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpClientAccessor = new HttpClientAccessor(mockMessageHandler.Object);
            HttpClientService clientService = new HttpClientService(myLogger.Object, httpClientAccessor);
            CardSetFile file = new CardSetFile();
            file.cdn_root = "";
            file.url = "";
            // Act
            string result = await clientService.GetCardSetJson(file);
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public async Task TestGetCardSetJsonValid()
        {
            // Arrange
            CardSetFile cardSetFile = new CardSetFile()
            {
                cdn_root = "https://steamcdn-a.akamaihd.net/",
                expire_time = 00000,
                url = "/apps/583950/resource/card_set_0.BB8732855C64ACE2696DCF5E25DEDD98D134DD2A.json"
            };
            const string testContent = @"{ ""card_set"":{ ""version"":1,""set_info"":{ ""set_id"":0,""pack_item_def"":0,""name"":{ ""english"":""Base Set""} },""card_list"":[{""card_id"":1000,""base_card_id"":1000,""card_type"":""Stronghold"",""card_name"":{""english"":""Ancient Tower""},""card_text"":{},""mini_image"":{""default"":""https://steamcdn-a.akamaihd.net/apps/583950/icons/set00/1000.91b2ed80da07ef5cf343540b09687fbf875168c8.png""},""large_image"":{""default"":""https://steamcdn-a.akamaihd.net/apps/583950/icons/set00/1000_large_english.3dea67025da70c778d014dc3aae80c0c0a7008a6.png""},""ingame_image"":{},""hit_points"":80,""references"":[]}]}}";
            Mock<ILoggingAdapter<HttpClientService>> myLogger = new Mock<ILoggingAdapter<HttpClientService>>();
            Mock<HttpMessageHandler> mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            HttpClientAccessor httpClientAccessor = new HttpClientAccessor(mockMessageHandler.Object);
            HttpClientService clientService = new HttpClientService(myLogger.Object, httpClientAccessor);
            // Act
            string result = await clientService.GetCardSetJson(cardSetFile);
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
