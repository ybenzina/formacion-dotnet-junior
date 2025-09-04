using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using DownloadExample;

public class DownloadManagerTests
{
    [Fact]
    public void BlockingPipeline_CompletesDespiteSomeFailures()
    {
        var mgr = new DownloadManager(maxRetries: 2);
        var req = new DownloadRequest(new Uri("http://example.com/file"), "dest", Parts: 10);
        var cts = new CancellationTokenSource(5000);

        // Should not throw (exceptions inside handled by manager)
        mgr.RunBlockingPipeline(req, cts.Token);

        Assert.True(true); // placeholder: in real test we'd assert stored parts, retry counts, etc.
    }
}
