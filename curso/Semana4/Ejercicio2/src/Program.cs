using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConcurrencyLib;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Demostración de Concurrencia en C#\n");

        // Demostración del ContadorConcurrente
        await DemostrarContador();

        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();

        // Demostración del AccesoLimitado
        await DemostrarAccesoLimitado();
    }

    private static async Task DemostrarContador()
    {
        var contador = new ContadorConcurrente();
        var tareas = new List<Task>();
        const int numIteraciones = 1000;

        Console.WriteLine($"Creando {numIteraciones} tareas para cada tipo de contador...\n");

        // No sincronizado
        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < numIteraciones; i++)
        {
            tareas.Add(Task.Run(() => contador.IncrementarNoSincronizado()));
        }
        await Task.WhenAll(tareas);
        stopwatch.Stop();
        Console.WriteLine($"Contador No Sincronizado:");
        Console.WriteLine($"Valor esperado: {numIteraciones}");
        Console.WriteLine($"Valor actual: {contador.ValorNoSincronizado}");
        Console.WriteLine($"Tiempo: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"¿Race condition? {contador.ValorNoSincronizado != numIteraciones}\n");

        // Con lock
        contador.ResetearContadores();
        tareas.Clear();
        stopwatch.Restart();
        for (int i = 0; i < numIteraciones; i++)
        {
            tareas.Add(Task.Run(() => contador.IncrementarConLock()));
        }
        await Task.WhenAll(tareas);
        stopwatch.Stop();
        Console.WriteLine($"Contador con Lock:");
        Console.WriteLine($"Valor esperado: {numIteraciones}");
        Console.WriteLine($"Valor actual: {contador.ValorLock}");
        Console.WriteLine($"Tiempo: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"¿Race condition? {contador.ValorLock != numIteraciones}\n");

        // Con Interlocked
        contador.ResetearContadores();
        tareas.Clear();
        stopwatch.Restart();
        for (int i = 0; i < numIteraciones; i++)
        {
            tareas.Add(Task.Run(() => contador.IncrementarConInterlocked()));
        }
        await Task.WhenAll(tareas);
        stopwatch.Stop();
        Console.WriteLine($"Contador con Interlocked:");
        Console.WriteLine($"Valor esperado: {numIteraciones}");
        Console.WriteLine($"Valor actual: {contador.ValorInterlocked}");
        Console.WriteLine($"Tiempo: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"¿Race condition? {contador.ValorInterlocked != numIteraciones}");
    }

    private static async Task DemostrarAccesoLimitado()
    {
        const int maxConcurrencia = 3;
        var accesoLimitado = new AccesoLimitado(maxConcurrencia);
        var tareas = new List<Task>();
        const int numOperaciones = 10;

        Console.WriteLine($"\nDemostración de AccesoLimitado (máximo {maxConcurrencia} operaciones concurrentes)");
        Console.WriteLine("Cada * representa una operación en ejecución\n");

        for (int i = 0; i < numOperaciones; i++)
        {
            tareas.Add(accesoLimitado.EjecutarOperacionAsync(async () =>
            {
                Console.Write($"[{accesoLimitado.OperacionesConcurrentes} activas] ");
                for (int j = 0; j < accesoLimitado.OperacionesConcurrentes; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                await Task.Delay(500); // Simula trabajo
            }));
        }

        await Task.WhenAll(tareas);
        Console.WriteLine("\nTodas las operaciones completadas.");
    }
}
