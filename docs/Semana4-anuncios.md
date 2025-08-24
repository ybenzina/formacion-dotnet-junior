📢 **Semana 4 – Asincronía y Multihilo (async/await, Task, locks, semáforos)**

🎯 **Objetivo de la semana**
Consolidar el uso de `async/await` y `Task`, entender sincronización básica (`lock`, `SemaphoreSlim`, `Interlocked`) y aprender a testear métodos asíncronos con xUnit.

🛠️ **Tareas prácticas** (ramas: <githubuser>/semana4-ejX)
1. **Ejercicio 1 – Métodos async y Task (OBLIGATORIO)**
   - Implementar `WebSimulator` con `DescargarPaginaAsync`, `ContarPalabrasAsync` y `ContarPalabrasMultiplesAsync` (uso de `Task.WhenAll`).
   - Tests async con xUnit.

2. **Ejercicio 2 – Concurrencia y sincronización (OBLIGATORIO)**
   - `ContadorConcurrente` (versión sin sincronizar y con `lock` / `Interlocked`).
   - `AccesoLimitado` con `SemaphoreSlim`.
   - Tests que demuestren race condition y soluciones.

3. **Ejercicio 3 – Testeo avanzado de async y Cancelación (OBLIGATORIO)**
   - Tests para comprobar cancelación con `CancellationToken` y manejo de `TaskCanceledException`.
   - Tests que validen las versiones sincronizadas del contador.

4. **Ejercicio 4 – Descargador paralelo tolerante a fallos (OPCIONAL/AVANZADO)**
   - Implementar un gestor de descargas que descargue varios ficheros en paralelo.
   - Soportar descarga por "chunks" (partes) y reintentar solo las partes fallidas.
   - Limitar concurrencia, reportar progreso y tolerancia a fallos.

📚 **Recurso obligatorio**: Implement asynchronous tasks (Microsoft Learn)
https://learn.microsoft.com/es-es/training/modules/implement-asynchronous-tasks/

📌 **Checklist PRs**:
- Rama creada como: `<tuusuario>/semana4-ejX` (ej: `drissbego/semana4-ej1`)
- `dotnet build` OK
- `dotnet test` OK (pegar salida en la descripción del PR)
- Tests async con `async Task` como firma
- No usar `.Result`/`.Wait()`
- Revisar PROBLEMS y sugerencias de `.editorconfig`

¡A programar! 🚀
