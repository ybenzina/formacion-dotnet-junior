# 📈 Retro — Semana 6 (Feedback y recomendaciones)

## Fortalezas observadas
- ✅ **Implementaciones funcionales:** Ejercicio 1 y Ejercicio 2 están implementados correctamente; las soluciones muestran comprensión de pipes de proceso, colecciones concurrentes y LINQ.
- ✅ **Código didáctico:** las implementaciones (productor/consumidor, ConcurrentDictionary, consultas LINQ) son claras y bien estructuradas.
- ✅ **Flujo de trabajo:** Ramas de trabajo creadas correctamente y integración en `drissbego/integration` .

## Áreas a mejorar (prioridad y acciones concretas)
1. **Documentación: Observaciones y Conclusiones (alta)**
   - Añadir una sección `## Observaciones y Conclusiones` en los README de Ej1 y Ej2 (ya implementados) y especialmente para Ej3 cuando esté lista.
   - Indica por ejemplo: por qué elegiste `BlockingCollection`/`Channel`, mediciones, trade-offs y limitaciones detectadas.

2. **PROBLEMS / Warnings (alta)**
   - Resuelve las advertencias que aparecen en el panel PROBLEMS (naming, sugerencias de `.editorconfig`). Aunque no rompen la build, mejorar la adherencia a reglas de estilo es importante para calidad profesional.

3. **Ejercicio 3: diseño y pruebas (alta)**
   - Si el Download Manager aún no está completo, asegúrate de incluir: cancelación, bounded channels/BlockingCollection, reintentos limitados y reporting.
   - Añade tests que simulen fallos deterministas para validar la política de reintentos.

4. **Solución global / facilitación (media)**
   - Añade los ejercicios a la solución global `formacion-dotnet-junior.sln` manteniendo la estructura  que hay para las semanas y ejercicios anteriores creaando carpetas de solución para la semana y el ejercicio y luego añadiendo los proyectos de código y test en cada una para facilitar el build/test desde la raíz.

## Notas técnicas y snippets útiles

## Checklist antes de cerrar la semana
- [ ] Añadir sección `Observaciones y Conclusiones` a cada README.
- [ ] Resolver PROBLEMS y aplicar `dotnet format`.
- [ ] Completar Ejercicio 3 y añadir tests de reintentos y cancelación.
- [ ] Añadir ejercicio 3 a `.sln` global o instrucciones claras para ejecutar desde la raíz.
