using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Services
{
    public interface IFileDataService
    {
        string GetLocalFileContents(string fileName);

        string SaveLocalFile(string fileName, string contents);
    }
}
