# Semana 4 - Referencia: Asincronía y Concurrencia en C#

## async/await y Task
- `async Task` y `async Task<T>`: métodos asíncronos que devuelven una tarea.
- Usa `await` para esperar sin bloquear el hilo actual.
- Evita `.Result` y `.Wait()` en código async (pueden producir deadlocks).

Ejemplo básico:
```csharp
public async Task<string> DescargarPaginaAsync(string url)
{
    await Task.Delay(200); // simulación I/O
    return $"Contenido de {url}";
}
```

Ejecutar varias tareas en paralelo:
```csharp
var tasks = urls.Select(DescargarPaginaAsync);
var contenidos = await Task.WhenAll(tasks);
```

## Synchronization primitives
- `lock(obj)` — protección simple por sección crítica.
- `Interlocked.Increment(ref x)` — incrementos atómicos en enteros.
- `SemaphoreSlim` — limitar concurrencia (WaitAsync / Release).
- `CancellationToken` — permitir cancelar tareas cooperativamente.

Ejemplo Interlocked vs lock:
```csharp
// Interlocked
private int _count;
public void IncrementarSeguro() => Interlocked.Increment(ref _count);

// lock
private readonly object _lock = new();
public void IncrementarConLock() { lock(_lock) { _count++; } }
```

SemaphoreSlim ejemplo:
```csharp
private readonly SemaphoreSlim _sem = new SemaphoreSlim(3);
public async Task OperacionLimitadaAsync()
{
    await _sem.WaitAsync();
    try { await Task.Delay(200); }
    finally { _sem.Release(); }
}
```

## Testear async con xUnit
- Firma del test: `public async Task TestName()`
- Usa `await` dentro del test y `Assert.Equal(await ..., expected)`

Ejemplo xUnit async:
```csharp
[Fact]
public async Task DescargarPaginaAsync_DeberiaRetornarContenido()
{
    var sim = new WebSimulator();
    var contenido = await sim.DescargarPaginaAsync("http://ejemplo");
    Assert.Equal("Contenido de http://ejemplo", contenido);
}
```

## Pitfalls comunes
- No mezclar sincronía/asincronía sin cuidado (`.Result`, `.Wait()`).
- Deadlocks si `ConfigureAwait(false)` no se usa en librerías de consumo en entornos con sincronización de contexto (UI).
- Tests no determinísticos al probar concurrencia: repetir pruebas y aumentar carga para detectar race conditions.

## Recomendaciones de pruebas de concurrencia
- Ejecutar muchas tareas (p. ej. 1000) para aumentar probabilidad de detectar race conditions.
- Comparar versión no sincronizada vs sincronizada y demostrar pérdida de increments.
- Usar `Task.WhenAll` y `Task.Delay` en tests para coordinar timing.

