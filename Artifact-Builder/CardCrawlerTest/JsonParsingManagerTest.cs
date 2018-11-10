using CardCrawler.Adapters;
using CardCrawler.Entities;
using CardCrawler.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawlerTest
{
    [TestClass]
    public class JsonParsingManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRawJsonNull()
        {
            // Arrange
            Mock<ILoggingAdapter<JsonParsingManager>> mockLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            JsonParsingManager manager = new JsonParsingManager(mockLogger.Object);
            // Act
            manager.ParseRawJsonFile(null);
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRawJsonEmpty()
        {
            // Arrange
            Mock<ILoggingAdapter<JsonParsingManager>> mockLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            JsonParsingManager manager = new JsonParsingManager(mockLogger.Object);
            // Act
            manager.ParseRawJsonFile("");
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestRawJsonInvalidFormat()
        {
            // Arrange
            Mock<ILoggingAdapter<JsonParsingManager>> mockLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            JsonParsingManager manager = new JsonParsingManager(mockLogger.Object);
            // Act
            manager.ParseRawJsonFile("I am not a JSON string");
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void TestRawJsonValidFormat()
        {
            // Arrange
            Mock<ILoggingAdapter<JsonParsingManager>> mockLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            JsonParsingManager manager = new JsonParsingManager(mockLogger.Object);
            // Act
            const string validJsonData = @"{ ""card_set"":{ ""version"":1,""set_info"":{ ""set_id"":0,""pack_item_def"":0,""name"":{ ""english"":""Base Set""} },""card_list"":[{""card_id"":1000,""base_card_id"":1000,""card_type"":""Stronghold"",""card_name"":{""english"":""Ancient Tower""},""card_text"":{},""mini_image"":{""default"":""https://steamcdn-a.akamaihd.net/apps/583950/icons/set00/1000.91b2ed80da07ef5cf343540b09687fbf875168c8.png""},""large_image"":{""default"":""https://steamcdn-a.akamaihd.net/apps/583950/icons/set00/1000_large_english.3dea67025da70c778d014dc3aae80c0c0a7008a6.png""},""ingame_image"":{},""hit_points"":80,""references"":[]}]}}";
            CardSet set = manager.ParseRawJsonFile(validJsonData);
            // Assert
            Assert.IsNotNull(set);
            Assert.IsNotNull(set.Cards);
            Assert.IsTrue(set.Cards.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFileLocationNull()
        {
            // Arrange
            Mock<ILoggingAdapter<JsonParsingManager>> mockLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            JsonParsingManager manager = new JsonParsingManager(mockLogger.Object);
            // Act
            manager.ParseRawJsonFileLocation(null);
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFileLocationEmpty()
        {
            // Arrange
            Mock<ILoggingAdapter<JsonParsingManager>> mockLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            JsonParsingManager manager = new JsonParsingManager(mockLogger.Object);
            // Act
            manager.ParseRawJsonFileLocation("");
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestFileLocationInvalidFormat()
        {
            // Arrange
            Mock<ILoggingAdapter<JsonParsingManager>> mockLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            JsonParsingManager manager = new JsonParsingManager(mockLogger.Object);
            // Act
            manager.ParseRawJsonFileLocation("I am not a JSON string");
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestFileLocationValidFormat()
        {
            // Arrange
            Mock<ILoggingAdapter<JsonParsingManager>> mockLogger = new Mock<ILoggingAdapter<JsonParsingManager>>();
            JsonParsingManager manager = new JsonParsingManager(mockLogger.Object);
            // Act
            const string validJsonData = @"{ ""cdn_root"":""https:\/\/steamcdn-a.akamaihd.net\/"",""url"":""\/apps\/583950\/resource\/card_set_0.BB8732855C64ACE2696DCF5E25DEDD98D134DD2A.json"",""expire_time"":1541860748}";
            CardSetFile cardSetFile = manager.ParseRawJsonFileLocation(validJsonData);
            // Assert
            Assert.IsNotNull(cardSetFile);
            Assert.IsNotNull(cardSetFile.ContentDeliveryRoot);
            Assert.IsNotNull(cardSetFile.FileExpirationDate);
            Assert.IsNotNull(cardSetFile.Url);
        }
    }
}
