using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public record ProducerConsumerResult(int Produced, int Consumed);

public static class ProducerConsumer
{
    // Inicia N productores y M consumidores
    public static async Task<ProducerConsumerResult> RunProducersConsumersAsync(
        int producerCount = 10,
        int itemsPerProducer = 100,
        int consumerCount = 5,
        int boundedCapacity = 10000,
        CancellationToken cancellationToken = default)
    {
        var collection = new BlockingCollection<int>(boundedCapacity);
        long produced = 0;
        long consumed = 0;

        // Start producers
        var producerTasks = new List<Task>();
        for (int p = 0; p < producerCount; p++)
        {
            var task = Task.Run(() =>
            {
                for (int i = 0; i < itemsPerProducer; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    collection.Add(i, cancellationToken);
                    Interlocked.Increment(ref produced);
                }
            }, cancellationToken);
            producerTasks.Add(task);
        }

        // Inicia consumidores
        var consumerTasks = new List<Task>();
        for (int c = 0; c < consumerCount; c++)
        {
            var task = Task.Run(() =>
            {
                foreach (var item in collection.GetConsumingEnumerable(cancellationToken))
                {
                    Interlocked.Increment(ref consumed);
                }
            }, cancellationToken);
            consumerTasks.Add(task);
        }

        // Espera a que los productores terminen
        await Task.WhenAll(producerTasks).ConfigureAwait(false);
        collection.CompleteAdding();

        // Espera a que los consumidores terminen
        await Task.WhenAll(consumerTasks).ConfigureAwait(false);

        return new ProducerConsumerResult((int)produced, (int)consumed);
    }

    // Inicia tareas y va incrementando el valor `key` `incrementsPerTask`
    public static async Task<int> ConcurrentDictionaryIncrementsAsync(
        string key,
        int taskCount = 1000,
        int incrementsPerTask = 1,
        CancellationToken cancellationToken = default)
    {
        var dict = new ConcurrentDictionary<string, int>();

        var tasks = new List<Task>();
        for (int t = 0; t < taskCount; t++)
        {
            tasks.Add(Task.Run(() =>
            {
                for (int i = 0; i < incrementsPerTask; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    // Use AddOrUpdate to increment atomically
                    dict.AddOrUpdate(key, 1, (_, old) => old + 1);
                }
            }, cancellationToken));
        }

        await Task.WhenAll(tasks).ConfigureAwait(false);

        dict.TryGetValue(key, out var final);
        return final;
    }
}
