using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        var requests = new List<DownloadRequest>
{
    new DownloadRequest(new Uri("https://example.com/file1"), "file1.bin", 6),
    new DownloadRequest(new Uri("https://example.com/file2"), "file2.bin", 4)
};


        var downloader = new SimulatedDownloader(failureProbability: 0.1); // Probabilidad de fallo (10%)
        var options = new DownloadManagerOptions
        {
            MaxConcurrentDownloads = 2, // Maximo 2 descargas simultaneas
            MaxConcurrentPartsPerFile = 3, // Maximo 3 partes simultaneas por archivo
            MaxRetriesPerPart = 4, // Reintentar 4 veces cada parte antes de fallar
            UseChannelPipeline = true // Usar Blocking Collection en vez de Channel Pipeline
        };


        var manager = new DownloadManager(options, downloader);


        using var cts = new CancellationTokenSource();


        var progress = new Progress<DownloadProgress>(p =>
        {
            Console.WriteLine($"[{p.Destination}] {p.CompletedParts}/{p.TotalParts} => {p.Percent:F1}%");
        });


        try
        {
            await manager.DownloadAsync(requests, cts.Token, progress);
            Console.WriteLine("Descarga completada con exito");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Descarga fallida: {ex.Message}");
        }
    }
}