using CardCrawler.Adapters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CardCrawler.Services
{
    public class FileDataService : IFileDataService
    {
        private readonly ILoggingAdapter<FileDataService> _logger;

        public FileDataService(ILoggingAdapter<FileDataService> logger)
        {
            _logger = logger;
        }

        public string GetLocalFileContents(string fileName)
        {
            if(string.IsNullOrEmpty(fileName))
            {
                Exception ex = new ArgumentNullException("fileName");
                _logger.LogError(ex, "Exception in FileDataService.GetLocalFileContents method.");
                throw ex;
            }
            if(fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                Exception ex = new FormatException("There were invalid characters in the file name. Please try again.");
                _logger.LogError(ex, "Exception in FileDataService.GetLocalFileContents method.");
                throw ex;
            }
            string workingPath = Directory.GetCurrentDirectory() + "\\" + fileName;
            string contents = null;
            try
            {
                using (StreamReader reader = new StreamReader(workingPath))
                {
                    contents = reader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception in FileDataService.GetLocalFileContents method.");
                throw ex;
            }
            return contents;
        }

        public string SaveLocalFile(string fileName, string contents)
        {
            if(string.IsNullOrEmpty(fileName))
            {
                ArgumentNullException ex = new ArgumentNullException("fileName");
                _logger.LogError(ex, "Exception thrown in FileDataService.SaveLocalFile method.");
                throw ex;
            }
            if(string.IsNullOrEmpty(contents))
            {
                ArgumentNullException ex = new ArgumentNullException("contents");
                _logger.LogError(ex, "Exception thrown in FileDataService.SaveLocalFile method.");
                throw ex;
            }
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                Exception ex = new FormatException("There were invalid characters in the file name. Please try again.");
                _logger.LogError(ex, "Exception in FileDataService.SaveLocalFile method.");
                throw ex;
            }
            string workingPath = Directory.GetCurrentDirectory() + "\\" + fileName;
            using (StreamWriter writer = new StreamWriter(workingPath, false))
            {
                writer.Write(contents);
            }
            return contents;
        }
    }
}
