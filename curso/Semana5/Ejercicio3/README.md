# Semana5 — Ejercicio 3: Sincronización (lock, Monitor, Mutex, Interlocked)

## Objetivo
Añadir `Monitor` y `Mutex` a las implementaciones del contador y entender diferencias en alcance y coste.

## Pasos
1. Partir del `ContadorCompartido` existente. Añadir:
   - `IncrementarConMonitor()` — `Monitor.Enter/Exit` con try/finally.  
   - `IncrementarConMutex()` — `Mutex.WaitOne()` / `ReleaseMutex()`.  
2. Tests: reusar tests previos y añadir pruebas para `Monitor` y `Mutex`.  
3. Documentar en README diferencias entre `lock` (azucar), `Monitor` y `Mutex`.

## Snippets
```csharp
// Monitor
Monitor.Enter(_lockObj);
try { _count++; }
finally { Monitor.Exit(_lockObj); }

// Mutex
_mutex.WaitOne();
try { _count++; }
finally { _mutex.ReleaseMutex(); }
```

## Entregable
- Código y tests actualizados, README con conclusiones.
