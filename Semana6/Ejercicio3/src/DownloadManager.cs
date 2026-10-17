using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;


public class DownloadManager
{
    private readonly DownloadManagerOptions _options;
    private readonly IDownloader _downloader;


    public DownloadManager(DownloadManagerOptions options, IDownloader downloader)
    {
        _options = options;
        _downloader = downloader;
    }


    // Descarga multiples archivos en paralelo
    public async Task DownloadAsync(IEnumerable<DownloadRequest> requests, CancellationToken cancellationToken, IProgress<DownloadProgress>? progress = null)
    {
        var sem = new SemaphoreSlim(_options.MaxConcurrentDownloads);
        var tasks = new List<Task>();


        foreach (var req in requests)
        {
            await sem.WaitAsync(cancellationToken);
            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    if (_options.UseChannelPipeline)
                        await ChannelPipeline(req, cancellationToken, progress);
                    else
                        await BlockingCollectionPipeline(req, cancellationToken, progress);
                }
                finally
                {
                    sem.Release();
                }
            }, cancellationToken));
        }


        await Task.WhenAll(tasks);
    }

    // BlockingCollection pipeline
    private async Task BlockingCollectionPipeline(DownloadRequest request, CancellationToken cancellationToken, IProgress<DownloadProgress>? progress)
    {
        // Poner partes a descargar
        var queue = new BlockingCollection<ChunkRequest>(_options.MaxConcurrentPartsPerFile * 2);


        // Guardar partes descargadas
        var parts = new ConcurrentDictionary<int, byte[]>();
        var totalParts = request.Parts;
        var completedParts = 0;


        // Producer: genera ChunkRequest y marca CompleteAdding
        var producer = Task.Run(() =>
        {
            try
            {
                for (int i = 0; i < totalParts; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    queue.Add(new ChunkRequest(request.Uri, request.Destination, i, totalParts), cancellationToken);
                }
            }
            finally
            {
                queue.CompleteAdding();
            }
        }, cancellationToken);

        // Workers: consumen y descargan partes, si falla y aun quedan reintentos sigue intentando
        var workers = Enumerable.Range(0, _options.MaxConcurrentPartsPerFile).Select(_ => Task.Run(async () =>
        {
            foreach (var chunk in queue.GetConsumingEnumerable(cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested) break;


                var succeeded = false;
                while (!succeeded)
                {
                    chunk.Attempt++;
                    try
                    {
                        var data = await _downloader.DownloadChunk(chunk, cancellationToken);
                        // Guardar resultado
                        if (parts.TryAdd(chunk.PartIndex, data))
                        {
                            Interlocked.Increment(ref completedParts);
                            progress?.Report(new DownloadProgress(request.Destination, totalParts, completedParts));
                        }
                        succeeded = true;
                    }
                    catch (Exception)
                    {
                        if (chunk.Attempt >= _options.MaxRetriesPerPart)
                        {
                            // Maximo reintentos alcanzado: indica fallo
                            throw;
                        }
                        await Task.Delay(50 * chunk.Attempt, cancellationToken);
                    }
                }
            }
        }, cancellationToken)).ToArray();


        await Task.WhenAll(new[] { producer }.Concat(workers));


        // Ordena partes y "ensambla" en memoria
        var assembled = AssembleParts(parts, totalParts);
    }

    // Channel pipeline
    private async Task ChannelPipeline(DownloadRequest request, CancellationToken cancellationToken, IProgress<DownloadProgress>? progress)
    {
        var capacity = Math.Max(1, _options.MaxConcurrentPartsPerFile * 2);
        var channel = Channel.CreateBounded<ChunkRequest>(new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        });


        var parts = new ConcurrentDictionary<int, byte[]>();
        var totalParts = request.Parts;
        var completedParts = 0;


        // Producer escribiendo en el channel
        var producer = Task.Run(async () =>
        {
            for (int i = 0; i < totalParts; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var chunk = new ChunkRequest(request.Uri, request.Destination, i, totalParts);
                await channel.Writer.WriteAsync(chunk, cancellationToken);
            }
            channel.Writer.Complete();
        }, cancellationToken);


        // Workers leen desde el channel de forma asíncrona
        var workers = Enumerable.Range(0, _options.MaxConcurrentPartsPerFile).Select(_ => Task.Run(async () =>
        {
            await foreach (var chunk in channel.Reader.ReadAllAsync(cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested) break;


                var succeeded = false;
                while (!succeeded)
                {
                    chunk.Attempt++;
                    try
                    {
                        var data = await _downloader.DownloadChunk(chunk, cancellationToken);
                        if (parts.TryAdd(chunk.PartIndex, data))
                        {
                            Interlocked.Increment(ref completedParts);
                            progress?.Report(new DownloadProgress(request.Destination, totalParts, completedParts));
                        }
                        succeeded = true;
                    }
                    catch (Exception)
                    {
                        if (chunk.Attempt >= _options.MaxRetriesPerPart)
                        {
                            // Falló tras reintentos -> propagar excepción
                            throw;
                        }
                        await Task.Delay(50 * chunk.Attempt, cancellationToken);
                        // Reintento: el loop vuelve a intentar descargar el mismo chunk
                    }
                }
            }
        }, cancellationToken)).ToArray();

        await Task.WhenAll(new[] { producer }.Concat(workers));

    }

    private static byte[] AssembleParts(ConcurrentDictionary<int, byte[]> parts, int totalParts)
    {
        var buffers = new byte[totalParts][];
        for (int i = 0; i < totalParts; i++)
        {
            if (!parts.TryGetValue(i, out var part))
            {
                throw new InvalidOperationException($"Missing part {i} during assembly");
            }
            buffers[i] = part;
        }

        var totalSize = buffers.Sum(b => b.Length);
        var result = new byte[totalSize];
        var offset = 0;
        foreach (var b in buffers)
        {
            Buffer.BlockCopy(b, 0, result, offset, b.Length);
            offset += b.Length;
        }
        return result;
    }

}