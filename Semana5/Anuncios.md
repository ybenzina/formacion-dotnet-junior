# 📢 Semana 5 – Tasks, Threads y Sincronización

**🎯 Objetivo de la semana**  
Consolidar el uso de `Task`/`async`, conocer `Thread`/`ThreadPool`/`background threads`, practicar paralelismo CPU‑bound con `Parallel.For/ForEach` y PLINQ, y aprender primitivas de sincronización (`lock`, `Monitor`, `Mutex`, `Interlocked`).

**🛠️ Tareas prácticas** (ramas: `<githubuser>/semana5-ejX`)
1. **Ejercicio 1 – Thread vs Task (OBLIGATORIO)**  
   - Implementar `DoWork(int i)` (CPU-bound).  
   - Crear four runners: Threads manuales, Background threads, ThreadPool (`QueueUserWorkItem`) y `Task.Run` + `Task.WhenAll`.  
   - Medir tiempos con `Stopwatch` y documentar observaciones.  
   - Implementar cancelación en la versión `Task` (uso de `CancellationToken`).

2. **Ejercicio 2 – Paralelismo CPU‑bound (OBLIGATORIO)**  
   - Implementar `ProcessSequential`, `ProcessParallelForEach` (con `localInit`/`localFinally`), `ProcessParallelFor` y `ProcessPLINQ`.  
   - Medir tiempos para N = 10k / 100k / 1M y comentar cuándo el paralelismo mejora el rendimiento.  
   - **Bonus:** `Parallel.ForEachAsync` (solo si el delegado es `async` — ejemplo y nota).

3. **Ejercicio 3 – Sincronización (OBLIGATORIO)**  
   - Ampliar `ContadorCompartido` con `IncrementarConMonitor()` y `IncrementarConMutex()`.  
   - Tests comparativos entre `sin protección`, `lock`, `Monitor`, `Interlocked` y `Mutex`.

4. **Ejercicio 4 – Colecciones básicas (OBLIGATORIO, ligero)**  
   - Prácticas con `List`, `Dictionary`, `Stack`, `Queue` (Add/Remove/Sort/Find/TryGet).  
   - Tests de casos límite (clave duplicada, pop en stack vacío, etc.).

**📚 Recursos obligatorios / recomendados**  
- Documentación `/docs` incluida en el repo (LINQ QuickRef, Delegados, Channel vs BlockingCollection, Testing async).

**📌 Checklist para PRs**  
- [ ] Rama creada como: `<tuusuario>/semana5-ejX` (ej: `drissbego/semana5-ej1`)  
- [ ] `dotnet build` OK  
- [ ] `dotnet test` OK (pegar salida en la descripción del PR)  
- [ ] Tests relevantes incluidos (concurrencia: incrementar carga para evitar flakiness)  
- [ ] No usar `.Result` / `.Wait()` en código async  
- [ ] Revisar y aplicar sugerencias de `.editorconfig` (naming, estilo)

**🚀 A programar!**
