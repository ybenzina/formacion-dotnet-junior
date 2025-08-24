# Snippets útiles - async, locks, SemaphoreSlim, Interlocked, CancellationToken

// Task.WhenAll example
var tasks = urls.Select(DescargarPaginaAsync);
var resultados = await Task.WhenAll(tasks);

// Cancellation
public async Task LongOperationAsync(CancellationToken ct)
{
    for(int i=0;i<10;i++)
    {
        ct.ThrowIfCancellationRequested();
        await Task.Delay(100, ct);
    }
}

// Test with cancellation
[Fact]
public async Task LongOperation_Cancelled_Throws()
{
    var cts = new CancellationTokenSource(50);
    await Assert.ThrowsAsync<TaskCanceledException>(() => LongOperationAsync(cts.Token));
}
