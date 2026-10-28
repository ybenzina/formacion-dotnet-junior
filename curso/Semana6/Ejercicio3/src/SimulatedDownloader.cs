using System;
using System.Threading;
using System.Threading.Tasks;


// Implementacion que usa Task.Delay y puede fallar aleatoriamente
public class SimulatedDownloader : IDownloader
{
    private readonly Random _random = new();
    private readonly double _failureProbability;
    private readonly int _minDelayMs;
    private readonly int _maxDelayMs;


    public SimulatedDownloader(double failureProbability = 0.1, int minDelayMs = 50, int maxDelayMs = 200)
    {
        _failureProbability = Math.Clamp(failureProbability, 0.0, 1.0);
        _minDelayMs = Math.Max(1, minDelayMs);
        _maxDelayMs = Math.Max(_minDelayMs, maxDelayMs);
    }


    public async Task<byte[]> DownloadChunk(ChunkRequest chunkRequest, CancellationToken cancellationToken)
    {
        // Simula delay de descarga
        var delay = _random.Next(_minDelayMs, _maxDelayMs + 1);
        await Task.Delay(delay, cancellationToken);


        // Simula fallo aleatorio
        if (_random.NextDouble() < _failureProbability)
            throw new InvalidOperationException($"Simulated failure for part {chunkRequest.PartIndex}");


        // Simula contenido del chunk
        var size = 1024;
        var data = new byte[size];
        var seed = chunkRequest.PartIndex ^ DateTime.UtcNow.Millisecond;
        var rnd = new Random(seed);
        rnd.NextBytes(data);
        return data;
    }
}