using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyLib;

public class AccesoLimitado
{
    private readonly SemaphoreSlim semaphore;
    private int operacionesConcurrentes;
    private readonly object lockObject = new();

    public AccesoLimitado(int maxConcurrencia)
    {
        semaphore = new SemaphoreSlim(maxConcurrencia, maxConcurrencia);
    }

    public int OperacionesConcurrentes 
    { 
        get 
        {
            lock (lockObject)
            {
                return operacionesConcurrentes;
            }
        }
    }

    public async Task EjecutarOperacionAsync(Func<Task> operacion)
    {
        await semaphore.WaitAsync();
        try
        {
            lock (lockObject)
            {
                operacionesConcurrentes++;
            }

            await operacion();
        }
        finally
        {
            lock (lockObject)
            {
                operacionesConcurrentes--;
            }
            semaphore.Release();
        }
    }
}
