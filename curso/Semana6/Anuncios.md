# 📢 Semana 6 – Colecciones concurrentes, LINQ y Download Manager (pipeline)

**🎯 Objetivo de la semana**  
Consolidar el uso de colecciones concurrentes (productor/consumidor), dominar LINQ para consultas y aplicar todo en un ejercicio integrador: **Download Manager** diseñado como pipeline (opciones: `BlockingCollection` o `Channel<T>`).

**🛠️ Tareas prácticas** (ramas: `<git-user>/semana6-ejX`)
1. **Ejercicio 1 – Colecciones concurrentes (OBLIGATORIO)**  
   - Implementar productor/consumidor con `BlockingCollection<T>`.  
   - Implementar versión alternativa con `ConcurrentQueue<T>` + `SemaphoreSlim`.  
   - Implementar ejemplo con `ConcurrentDictionary` y `AddOrUpdate` bajo alta concurrencia.  
   - Tests que verifiquen que N items producidos == N items consumidos y conteos por clave correctos.

2. **Ejercicio 2 – LINQ y delegados (VITAMINADO, OBLIGATORIO)**  
   - Queries: `Where`, `Select`, `OrderBy`, `GroupBy`, `Join` y materialización con `ToList()`.  
   - Implementar `Filtrar<T>(IEnumerable<T>, Func<T,bool>)` y comparar con `Where`.  
   - Tests para casos vacíos, todos aprobados, empates y comparación con LINQ.

3. **Ejercicio 3 – Download Manager (REFORMA/IMPLEMENTACIÓN, INTEGRADOR)**  
   - Refactorizar/implementar el gestor de descargas usando pipeline: `BlockingCollection` y `Channel<T>` (bounded).  
   - Soportar cancelación (`CancellationToken`), reintentos por parte fallida y reporte de progreso.  
   - Tests que simulen fallos en partes y validen reintentos y completitud.

**📚 Recursos y ayuda**  
- Consulta `/docs` para: LINQ QuickRef, Delegados/Lambdas, Channel vs BlockingCollection y Testing async/concurrency.

**📌 Checklist para PRs**  
- [ ] Rama creada como `<git-user>/semana6-ejX`  
- [ ] `dotnet build` OK  
- [ ] `dotnet test` OK (pegar salida)  
- [ ] Tests incluidos y robustos (carga suficiente)  
- [ ] README con cómo ejecutar y qué observar
