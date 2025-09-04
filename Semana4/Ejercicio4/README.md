# Semana4 – Ejercicio 4: Descargador paralelo tolerante a fallos (OPCIONAL/AVANZADO)
**Branch sugerida:** `<git-user>/semana4-ej4`

## Objetivo
Implementar un gestor de descargas que muestre las ventajas de la asincronía y tolerancia a fallos:
- Descargar varios ficheros en paralelo (simulados o reales).
- Soportar descarga por "chunks" (partes) y reintentar solo las partes fallidas.
- Limitar concurrencia (p.e. N descargas simultáneas o M chunks simultáneos por fichero).
- Reportar progreso por fichero y global.

## Tareas propuestas (sugerencia concreta)
1. `DownloadManager`:
   - Entrada: lista de URLs (o simuladores).
   - Lanza hasta `MaxConcurrentDownloads` descargas simultáneas (usar `SemaphoreSlim`).
   - Para cada archivo, usa `ChunkedDownloader` para obtener partes en paralelo.
2. `ChunkedDownloader` (por ejemplo):
   - Divide el archivo en N partes (simulado por rango de bytes).
   - Descarga cada parte en paralelo con límite `MaxConcurrentPartsPerFile`.
   - Si una parte falla, reintentar hasta `MaxRetriesPerPart`. Solo reintentar la parte fallida.
3. Progreso y reintentos:
   - Exponer `IProgress<T>` o eventos `ProgressChanged` para informar estado.
   - Registrar reintentos realizados y fallidos en logs.
4. Tests:
   - Simular fallos en partes (p. ej. forzar excepción en una parte) y comprobar que se reintenta solo esa parte y que el gestor completa la descarga si los reintentos tienen éxito.
   - Test de límite de concurrencia (asegurar que no se excede MaxConcurrentDownloads).

## Entregable
- Código en `Semana4/Ejercicio4/src` y tests opcionales en `Semana4/Ejercicio4/tests/`.
- PR: `<git-user>/semana4-ej4` -> `<git-user>/integration`
