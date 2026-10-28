# 📈 Feedback técnico — Semana 4

## Lo más destacable

- Implementaciones claras y didácticas: la comparación entre versión sin sincronizar y versiones con `lock`/`Interlocked` es muy útil para aprender.
- Correcto uso de `async`/`await` y `Task.WhenAll` en el WebSimulator.
- `OperacionesAsync` incluye `CancellationToken` y manejo limpio (try/finally) — buen diseño para testing y cancelación cooperativa.
- Uso de recursos externos (IA y StackOverflow) para resolver dudas: positivo — fomenta siempre comentar/atribuir brevemente en la descripción del PR si se ha tomado un snippet/idea concreta.

## Puntos de mejora y recomendaciones (ordenadas)

1. **Issues y checks (proceso)**
   - Varias issues quedan abiertas o sin checklist actualizados. Pide que al mergear indiquen `Fixes #NN` o cierren manualmente el issue. Esto mejora trazabilidad y muestra claramente qué está terminado.

2. **Aplicar sugerencias de `.editorconfig`**
   - Son mostly *info/suggestions* (naming). No penalizaría por esto, pero sí pediría que las corrija gradualmente (ej.: formateo, nombres privados en camelCase, evitar guiones bajos si no es la convención). Ejecutar `dotnet format` y/o analizar con los analyzers.

3. **Tests de concurrencia: robustez**
   - Para detectar race conditions de forma fiable conviene aumentar la carga (p. ej. 1k o 10k tasks en test) o repetir el test varias veces con un pequeño loop.
   - Añadir tests para entradas inválidas (null, listas vacías) y para casos límite.

4. **Atribuciones y uso de IA / StackOverflow**
   - Excelente que hayas usado IA y StackOverflow como ayuda para entender y disponer de soporte los ejercicios incluyendo comentarios en el código dónde has necesitado consultar y en la descripción del PR cuando una solución se basa en una fuente externa (p.e. “Basado en respuesta en StackOverflow: enlace” o “asistido con ChatGPT para ...”).

## Cambios concretos sugeridos pendientes de integrar

Tienes pendiente de revisar y fusionar los cambios de las mejoras sugeridas de la semana3 dónde se han corregido los siguientes aspectos:

- **Renombrar** cualquier clase plural que represente una entidad (por ejemplo `Tareas` → `Tarea`) y actualizar referencias.
- **No exponer** listas internas directamente; usar `IReadOnlyList<T>` o `IEnumerable<T>` en API públicas.
