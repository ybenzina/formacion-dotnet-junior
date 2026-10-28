using System;
using System.Threading;

class Program
{
    const int Threads = 10;
    const int IncrementsPerThread = 10000;

    static void Main()
    {
        var contador = new ContadorCompartido();

        RunAndPrint(contador, c => c.IncrementarConLock, "Lock");
        RunAndPrint(contador, c => c.IncrementarConMonitor, "Monitor");
        RunAndPrint(contador, c => c.IncrementarConMutex, "Mutex");
        RunAndPrint(contador, c => c.IncrementarConInterlocked, "Interlocked");

        Console.WriteLine("Pruebas manuales finalizadas");
    }

    static void RunAndPrint(ContadorCompartido contador, Func<ContadorCompartido, Action> getIncrementer, string name)
    {
        contador.Reset();
        var incrementer = getIncrementer(contador);

        var threads = new Thread[Threads];
        for (int i = 0; i < Threads; i++)
        {
            threads[i] = new Thread(() =>
            {
                for (int j = 0; j < IncrementsPerThread; j++)
                    incrementer();
            });
            threads[i].Start();
        }

        for (int i = 0; i < Threads; i++)
            threads[i].Join();

        int expected = Threads * IncrementsPerThread;
        Console.WriteLine($"{name}: esperado={expected}, obtenido={contador.GetCount()} -> {(contador.GetCount() == expected ? "OK" : "FAIL")}");
    }
}
