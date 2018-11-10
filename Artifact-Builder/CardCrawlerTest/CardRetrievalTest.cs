using CardCrawler.Adapters;
using CardCrawler.Entities;
using CardCrawler.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CardCrawlerTest
{
    [TestClass]
    public class CardRetrievalTest
    {
        [TestMethod]
        public void TestGetAllCards()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            List<CardSet> cards = myCardService.All();
            // Assert
            Assert.IsNotNull(cards);
            Assert.IsFalse(cards.Count == 0);
            // There should be two card sets right now
            Assert.IsTrue(cards.Count == 2);
        }

        [TestMethod]
        public void TestGetCardByNullId()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            ArtifactCard card = myCardService.GetCardById(null);
            // Assert
            Assert.IsNull(card);
        }

        [TestMethod]
        public void TestGetCardByEmptyId()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            ArtifactCard card = myCardService.GetCardById("");
            // Assert
            Assert.IsNull(card);
        }

        [TestMethod]
        public void TestGetCardByInvalidId()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            ArtifactCard card = myCardService.GetCardById("-1");
            // Assert
            Assert.IsNull(card);
        }

        [TestMethod]
        public void TestGetCardByValidId()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            // TODO: Insert valid ID here
            ArtifactCard card = myCardService.GetCardById("23");
            // Assert
            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void TestGetCardByNullName()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            ArtifactCard card = myCardService.GetCardByName(null);
            // Assert
            Assert.IsNull(card);
        }

        [TestMethod]
        public void TestGetCardByEmptyName()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            ArtifactCard card = myCardService.GetCardByName("");
            // Assert
            Assert.IsNull(card);
        }

        [TestMethod]
        public void TestGetCardByInvalidName()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            ArtifactCard card = myCardService.GetCardByName("oeiuro2iu3h4kjhksjdhf");
            // Assert
            Assert.IsNull(card);
        }

        [TestMethod]
        public void TestGetCardByValidName()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            // TODO: Insert valid Name here
            ArtifactCard card = myCardService.GetCardByName("Drow Ranger");
            // Assert
            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void TestGetCardByNullType()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            List<ArtifactCard> cards = myCardService.GetCardsByType(null);
            // Assert
            Assert.IsNull(cards);
        }

        [TestMethod]
        public void TestGetCardByEmptyType()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            List<ArtifactCard> cards = myCardService.GetCardsByType("");
            // Assert
            Assert.IsNull(cards);
        }

        [TestMethod]
        public void TestGetCardByInvalidType()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            List<ArtifactCard> cards = myCardService.GetCardsByType("oishdfkljhwkejrhkjwhegbjh4e");
            // Assert
            // The list should be empty, but not null
            Assert.IsNotNull(cards);
            Assert.IsTrue(cards.Count == 0);
        }

        [TestMethod]
        public void TestGetCardByValidType()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            List<ArtifactCard> cards = myCardService.GetCardsByType("Hero");
            // Assert
            Assert.IsNotNull(cards);
            Assert.IsTrue(cards.Count != 0);
        }

        [TestMethod]
        public void TestGetCardSetByNullId()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            CardSet cards = myCardService.GetCardSetById(null);
            // Assert
            Assert.IsNull(cards);
        }

        [TestMethod]
        public void TestGetCardSetByEmptyId()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            CardSet cards = myCardService.GetCardSetById("");
            // Assert
            Assert.IsNull(cards);
        }

        [TestMethod]
        public void TestGetCardSetByInvalidId()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            CardSet cards = myCardService.GetCardSetById("weruo2j3h4kjghkdghfjkyhqwjke");
            // Assert
            // CardSet should be empty, but not null
            Assert.IsNotNull(cards);
            Assert.IsNotNull(cards.Cards);
            Assert.IsTrue(cards.Cards.Count == 0);
        }

        [TestMethod]
        public void TestGetCardSetByValidId()
        {
            // Arrange
            Mock<ILoggingAdapter<CardRetrievalService>> myLogger = new Mock<ILoggingAdapter<CardRetrievalService>>();
            myLogger.Setup(logger => logger.LogInformation(It.IsAny<string>())).Verifiable();
            // Act
            CardRetrievalService myCardService = new CardRetrievalService(myLogger.Object);
            CardSet cards = myCardService.GetCardSetById("00");
            // Assert
            Assert.IsNotNull(cards);
            Assert.IsNotNull(cards.Cards);
            Assert.IsTrue(cards.Cards.Count != 0);
        }
    }
}
