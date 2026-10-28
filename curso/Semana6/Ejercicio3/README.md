# Semana6 — Ejercicio 3: Download Manager (pipeline refactor/implementación)

## Objetivo
Integrar asincronía, paralelismo y colecciones concurrentes en un gestor de descargas por partes.

## Diseño (resumen práctico)
- `DownloadManager` → recibe `DownloadRequest` con `Uri`, `Destination`, `Parts`.  
- Por fichero: Producer (genera `ChunkRequest`) → Stage descarga de partes (N workers) → Stage ensamblado.  
- Implementar **BlockingCollection pipeline** y **Channel pipeline** (bounded).  
- Soporte: cancelación (`CancellationToken`), reintentos por parte fallida, progresos con `IProgress<T>`.

## Práctica sugerida (pasos)
1. Implementar versión simulada (Task.Delay) para evitar I/O real.  
2. Implementar BlockingCollection pipeline con `CompleteAdding()` y workers que consumen `GetConsumingEnumerable()`.  
3. Implementar Channel pipeline con `Channel.CreateBounded` y `ReadAllAsync`.  
4. Tests: simular fallos en partes y validar reintentos/completitud.  
5. Documentar parámetros: `MaxConcurrentDownloads`, `MaxConcurrentPartsPerFile`, `MaxRetriesPerPart`.

## Entregable
- Código en `src/` y tests en `tests/`.  
- README con diagramas ASCII breves y ejemplos de ejecución (modo simulado).
