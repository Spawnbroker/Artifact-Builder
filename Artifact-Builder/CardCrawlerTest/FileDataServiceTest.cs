using CardCrawler.Adapters;
using CardCrawler.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CardCrawlerTest
{
    [TestClass]
    public class FileDataServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFileWithNullTest()
        {
            // Arrange
            Mock<ILoggingAdapter<FileDataService>> myLogger = new Mock<ILoggingAdapter<FileDataService>>();
            myLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
            FileDataService fileService = new FileDataService(myLogger.Object);
            // Act
            fileService.GetLocalFileContents(null);
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void GetFileWithInvalidFormatTest()
        {
            // Arrange
            const string invalidName = "<>:\"/\\|?*0..";
            Mock<ILoggingAdapter<FileDataService>> myLogger = new Mock<ILoggingAdapter<FileDataService>>();
            myLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
            FileDataService fileService = new FileDataService(myLogger.Object);
            // Act
            fileService.GetLocalFileContents(invalidName);
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetFileWithValidFormatTest()
        {
            // Arrange
            const string validFormatName = "I am in the correct format, but I do not exist.";
            Mock<ILoggingAdapter<FileDataService>> myLogger = new Mock<ILoggingAdapter<FileDataService>>();
            myLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
            FileDataService fileService = new FileDataService(myLogger.Object);
            // Act
            string fileContents = fileService.GetLocalFileContents(validFormatName);
            // Assert
        }

        [TestMethod]
        public void GetFileWithValidNameTest()
        {
            const string validFormatName = "CardSet00.json";
            Mock<ILoggingAdapter<FileDataService>> myLogger = new Mock<ILoggingAdapter<FileDataService>>();
            myLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
            FileDataService fileService = new FileDataService(myLogger.Object);
            // Act
            string fileContents = fileService.GetLocalFileContents(validFormatName);
            // Assert
            Assert.IsNotNull(fileContents);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveFileWithNullNameTest()
        {
            // Arrange
            const string testContent = "contents";
            Mock<ILoggingAdapter<FileDataService>> myLogger = new Mock<ILoggingAdapter<FileDataService>>();
            myLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
            FileDataService fileService = new FileDataService(myLogger.Object);
            // Act
            fileService.SaveLocalFile(null, testContent);
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SaveFileWithInvalidNameFormatTest()
        {
            // Arrange
            const string invalidName = "<>:\"/\\|?*0..";
            const string testContent = "contents";
            Mock<ILoggingAdapter<FileDataService>> myLogger = new Mock<ILoggingAdapter<FileDataService>>();
            myLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
            FileDataService fileService = new FileDataService(myLogger.Object);
            // Act
            fileService.SaveLocalFile(invalidName, testContent);
            // Assert
        }

        [TestMethod]
        public void SaveFileWithValidFormatTest()
        {
            // Arrange
            const string validFormatName = "This file does not exist.";
            const string testContent = "{ \"contents\" : \"hello\" }";
            Mock<ILoggingAdapter<FileDataService>> myLogger = new Mock<ILoggingAdapter<FileDataService>>();
            myLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
            FileDataService fileService = new FileDataService(myLogger.Object);
            // Act
            string fileContents = fileService.SaveLocalFile(validFormatName, testContent);
            // Assert
            Assert.IsNotNull(fileContents);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveFileWithNullContentTest()
        {
            // Arrange
            const string validFormatName = "This file does not exist.";
            Mock<ILoggingAdapter<FileDataService>> myLogger = new Mock<ILoggingAdapter<FileDataService>>();
            myLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
            FileDataService fileService = new FileDataService(myLogger.Object);
            // Act
            string fileContents = fileService.SaveLocalFile(validFormatName, null);
            // Assert
        }

        [TestMethod]
        public void SaveFileThatAlreadyExists()
        {
            // Arrange
            const string validFormatName = "This file does not exist.";
            const string testContent = "{ \"contents\" : \"hello\" }";
            const string newContent = "{ \"contents\" : \"changed\" }";
            Mock<ILoggingAdapter<FileDataService>> myLogger = new Mock<ILoggingAdapter<FileDataService>>();
            myLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>())).Verifiable();
            FileDataService fileService = new FileDataService(myLogger.Object);
            // Act
            string fileContents = fileService.SaveLocalFile(validFormatName, testContent);
            string newContents = fileService.SaveLocalFile(validFormatName, newContent);
            // Assert
            Assert.IsTrue(newContent.Equals(newContents));
        }
    }
}
