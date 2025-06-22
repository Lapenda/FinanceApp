using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using FinanceApp.Managers;

public class HttpNewsClient
{
    private readonly HttpClient client = new HttpClient();

    public async Task DownloadNewsAsync(string url, string destination, IProgress<int> progress, int? speedLimit = null)
    {
        var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        var contentLength = response.Content.Headers.ContentLength ?? -1;

        using (var stream = await response.Content.ReadAsStreamAsync())
        using (var throttledStream = speedLimit.HasValue ? new ThrottleStream(stream, speedLimit.Value * 1024) : stream)
        using (var fileStream = new FileStream(destination, FileMode.Create))
        {
            byte[] buffer = new byte[8388608];
            long totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = await throttledStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, bytesRead);
                totalBytesRead += bytesRead;
                if (contentLength > 0)
                {
                    int progressPercentage = (int)((totalBytesRead * 100) / contentLength);
                    progress.Report(progressPercentage);
                }
            }
        }
    }
}