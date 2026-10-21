using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DownloadExample
{
    public record DownloadRequest(Uri Url, string Destination, int Parts = 10);

    public record ChunkRequest(Guid FileId, int PartIndex, int TotalParts, byte[]? Data = null);

    public class DownloadManager
    {
        private readonly int _maxRetries;

        public DownloadManager(int maxRetries = 3)
        {
            _maxRetries = maxRetries;
        }

        // Simulated download of a chunk
        private async Task<byte[]> DownloadChunkAsync(ChunkRequest chunk, CancellationToken ct)
        {
            // simulate variable latency and occasional failure
            await Task.Delay(50 + (chunk.PartIndex % 5) * 20, ct);
            if (chunk.PartIndex % 7 == 0) // artificial failure pattern
            {
                throw new InvalidOperationException("Simulated chunk failure");
            }
            // return dummy data
            return new byte[1024]; 
        }

        // BlockingCollection pipeline version
        public void RunBlockingPipeline(DownloadRequest req, CancellationToken ct)
        {
            var parts = req.Parts;
            var bc = new BlockingCollection<ChunkRequest>(boundedCapacity: parts * 2);
            var fileId = Guid.NewGuid();

            // Producer: generate chunk requests
            Task.Run(() =>
            {
                for (int i = 0; i < parts; i++)
                {
                    bc.Add(new ChunkRequest(fileId, i, parts));
                }
                bc.CompleteAdding();
            }, ct);

            // Consumer workers
            var failures = new ConcurrentDictionary<int,int>();
            var tasks = new List<Task>();
            for (int w = 0; w < Math.Min(4, parts); w++)
            {
                tasks.Add(Task.Run(() => {
                    foreach(var chunk in bc.GetConsumingEnumerable(ct))
                    {
                        int attempt = 0;
                        while (true)
                        {
                            try
                            {
                                var data = DownloadChunkAsync(chunk, ct).GetAwaiter().GetResult(); // sync call for demo; prefer async in real
                                // process data (store/assemble)
                                break;
                            }
                            catch(Exception)
                            {
                                attempt++;
                                failures.AddOrUpdate(chunk.PartIndex, 1, (_, old) => old + 1);
                                if (attempt > _maxRetries) break;
                            }
                        }
                    }
                }, ct));
            }

            Task.WaitAll(tasks.ToArray(), ct);
        }
    }
}
