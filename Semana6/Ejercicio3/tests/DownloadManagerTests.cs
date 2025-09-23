using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


// Tests básicos que validan reintentos y completitud.
public class DownloadManagerTests
{
    [Fact]
    public async Task BlockingCollectionPipeline_DeberiaCompletarConErroresControlados()
    {
        var request = new DownloadRequest(new Uri("https://example.com/test"), "t1.bin", 5);
        var downloader = new SimulatedDownloader(failureProbability: 0.4, minDelayMs: 1, maxDelayMs: 10);
        var options = new DownloadManagerOptions
        {
            MaxConcurrentDownloads = 1,
            MaxConcurrentPartsPerFile = 2,
            MaxRetriesPerPart = 6,
            UseChannelPipeline = false
        };


        var manager = new DownloadManager(options, downloader);


        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));


        await manager.DownloadAsync(new[] { request }, cts.Token, null);
        Assert.True(true);
    }


    [Fact]
    public async Task ChannelPipeline_DeberiaFallarAlExcederElLimiteDeReintentos()
    {
        var request = new DownloadRequest(new Uri("https://example.com/test2"), "t2.bin", 3);
        var downloader = new SimulatedDownloader(failureProbability: 0.95, minDelayMs: 1, maxDelayMs: 5);
        var options = new DownloadManagerOptions
        {
            MaxConcurrentDownloads = 1,
            MaxConcurrentPartsPerFile = 2,
            MaxRetriesPerPart = 1,
            UseChannelPipeline = true
        };


        var manager = new DownloadManager(options, downloader);
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));


        await Assert.ThrowsAnyAsync<Exception>(() => manager.DownloadAsync(new[] { request }, cts.Token, null));
    }
}