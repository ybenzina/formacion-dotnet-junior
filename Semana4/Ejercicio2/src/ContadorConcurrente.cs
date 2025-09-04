using System.Threading;

namespace ConcurrencyLib;

public class ContadorConcurrente
{
    private int contadorNoSincronizado;
    private int contadorInterlocked;
    private int contadorLock;
    private readonly object lockObject = new();

    public int ValorNoSincronizado => contadorNoSincronizado;
    public int ValorInterlocked => contadorInterlocked;
    public int ValorLock => contadorLock;

    public void IncrementarNoSincronizado()
    {
        contadorNoSincronizado++;
    }

    public void IncrementarConLock()
    {
        lock (lockObject)
        {
            contadorLock++;
        }
    }

    public void IncrementarConInterlocked()
    {
        Interlocked.Increment(ref contadorInterlocked);
    }

    public void ResetearContadores()
    {
        contadorNoSincronizado = 0;
        contadorInterlocked = 0;
        contadorLock = 0;
    }
}
