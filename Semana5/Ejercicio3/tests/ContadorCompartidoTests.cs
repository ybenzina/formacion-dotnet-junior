using System;
using System.Threading;
using Xunit;

public class ContadorCompartidoTests
{
    private const int Threads = 10;
    private const int IncrementsPerThread = 10000;

    private void RunTest(Action<ContadorCompartido> incrementer)
    {
        var c = new ContadorCompartido();
        var threads = new Thread[Threads];

        for (int i = 0; i < Threads; i++)
        {
            threads[i] = new Thread(() =>
            {
                for (int j = 0; j < IncrementsPerThread; j++)
                    incrementer(c);
            });
            threads[i].Start();
        }

        for (int i = 0; i < Threads; i++)
            threads[i].Join();

        Assert.Equal(Threads * IncrementsPerThread, c.GetCount());
    }

    [Fact]
    public void Lock_Works()
    {
        RunTest(c => c.IncrementarConLock());
    }

    [Fact]
    public void Monitor_Works()
    {
        RunTest(c => c.IncrementarConMonitor());
    }

    [Fact]
    public void Mutex_Works()
    {
        RunTest(c => c.IncrementarConMutex());
    }

    [Fact]
    public void Interlocked_Works()
    {
        RunTest(c => c.IncrementarConInterlocked());
    }
}
