using System;
using System.Threading;

public class ContadorCompartido
{
    private int _count;
    private readonly object _lockObj = new object();
    private readonly Mutex _mutex = new Mutex();

    public void Reset() => _count = 0;
    public int GetCount() => _count;

    // lock
    public void IncrementarConLock()
    {
        lock (_lockObj)
        {
            _count++;
        }
    }

    // Monitor.Enter / Monitor.Exit con try/finally
    public void IncrementarConMonitor()
    {
        Monitor.Enter(_lockObj);
        try
        {
            _count++;
        }
        finally
        {
            Monitor.Exit(_lockObj);
        }
    }

    // Mutex.WaitOne() / ReleaseMutex()
    public void IncrementarConMutex()
    {
        _mutex.WaitOne();
        try
        {
            _count++;
        }
        finally
        {
            _mutex.ReleaseMutex();
        }
    }

    // Interlocked increment
    public void IncrementarConInterlocked()
    {
        Interlocked.Increment(ref _count);
    }
}
