# Semana5 — Ejercicio 1: Thread vs Task (+ ThreadPool y background threads)

## Objetivo
Implementar la misma unidad de trabajo *CPU-bound* con cuatro enfoques distintos y comparar ergonomía, cancelación y rendimiento.

## Pasos concretos
1. Implementa `long DoWork(int i)` (véase snippet).  
2. Implementa los cuatro runners:
   - `RunnerThreads(int n)` — crea N `Thread`, `Start()` y `Join()`.  
   - `RunnerBackgroundThreads(int n)` — igual que Threads pero `IsBackground = true`.  
   - `RunnerThreadPool(int n)` — usa `ThreadPool.QueueUserWorkItem` y coordina con `CountdownEvent`.  
   - `RunnerTasks(int n, CancellationToken ct)` — usa `Task.Run` y `Task.WhenAll` con cancelación.  
3. Mide tiempos con `Stopwatch` y documenta en el README de la solución.

## Snippets
```csharp
long DoWork(int i)
{
    long acc = 0;
    for (int k = 0; k < 100_000; k++)
        acc += (i * 31 + k) % 97;
    return acc;
}
```

```csharp
// Tasks runner
public async Task<long> RunnerTasks(int n, CancellationToken ct)
{
    var tasks = Enumerable.Range(0, n).Select(i => Task.Run(() => DoWork(i), ct));
    var results = await Task.WhenAll(tasks);
    return results.Sum();
}
```

## Tests (sugeridos)
- `TasksAndThreads_ShouldReturnSameTotal` — comparar resultados entre runners.  
- `RunnerTasks_Cancels` — verificar comportamiento con `CancellationTokenSource`.

## Entregable
- `src/` con implementaciones y `tests/` (xUnit).
