using System;
using NOC.Models;

namespace NOC.Interfaces
{
    public interface IPdfFileDownloader
    {
       void downloadLocalyStoredPdfFile(string fileName, byte[] data);
       // event EventHandler<DownloadEventArgs> OnFileDownloaded;
    }
}
