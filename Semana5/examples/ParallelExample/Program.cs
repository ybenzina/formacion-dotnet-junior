using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class ParallelExample
{
    static long DoWork(int i)
    {
        long acc = 0;
        for (int k = 0; k < 20000; k++)
        {
            acc += (i * 31 + k) % 97;
        }
        return acc;
    }

    static long ProcessSequential(int[] items)
    {
        long total = 0;
        foreach (var i in items) total += DoWork(i);
        return total;
    }

    static long ProcessParallelForEach(int[] items)
    {
        long total = 0;
        System.Threading.Tasks.Parallel.ForEach(items,
            () => 0L,
            (item, loopState, local) => local + DoWork(item),
            local => System.Threading.Interlocked.Add(ref total, local));
        return total;
    }

    static async Task Main()
    {
        var n = 2000;
        var items = Enumerable.Range(0,n).ToArray();

        var sw = Stopwatch.StartNew();
        var s = ProcessSequential(items);
        sw.Stop();
        Console.WriteLine($"Sequential: {sw.ElapsedMilliseconds}ms total={s}");

        sw.Restart();
        var p = ProcessParallelForEach(items);
        sw.Stop();
        Console.WriteLine($"Parallel.ForEach: {sw.ElapsedMilliseconds}ms total={p}");

        Console.WriteLine("Equal: " + (s==p));
    }
}
