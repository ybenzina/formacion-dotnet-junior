# Semana5 — Ejercicio 2: Paralelismo con Parallel.For / Parallel.ForEach / PLINQ

## Objetivo
Paralelizar operaciones CPU-bound sobre grandes colecciones y aprender patrones para evitar contención.

## Pasos
1. Genera dataset: `var items = Enumerable.Range(0, N).ToArray();` (N configurable).  
2. Implementa:
   - `ProcessSequential(items)` — bucle `foreach`.  
   - `ProcessParallelForEach(items)` — `Parallel.ForEach` con `localInit`/`localFinally`.  
   - `ProcessParallelFor(items)` — `Parallel.For` con patrón similar.  
   - `ProcessPLINQ(items)` — `items.AsParallel().Select(Process).Sum()`.  
3. Mide tiempos (`Stopwatch`) para N = 10k / 100k / 1M y documenta observaciones.  
4. BONUS: ejemplo y nota práctica sobre `Parallel.ForEachAsync` (usar cuando el delegado es `async`/I/O-bound).

## Snippet esencial
```csharp
long total = 0;
Parallel.ForEach(items,
  () => 0L,
  (item, loopState, local) => local + Process(item),
  local => Interlocked.Add(ref total, local)
);
```

## Tests (sugeridos)
- Comparar igualdad de resultados entre versiones.  
- Test que muestre contención si implementas una versión naive (sin `Interlocked` o `localInit`).

## Entregable
- Implementación + `README.md` con tablas/tiempos y conclusiones.
