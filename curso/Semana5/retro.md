# 📈 Retro — Semana 5 (Feedback y recomendaciones)

## Resumen de fortalezas
- ✅ **Funcionalidad completa:** todos los ejercicios (1–4) resueltos y funcionando.
- ✅ **Tests:** cobertura básica y tests de concurrencia/parallel implementados; `dotnet test` se ejecuta correctamente y se incorporó la salida en la PR. Excelente práctica.
- ✅ **Uso didáctico:** las implementaciones comparativas (threads vs tasks, secuencial vs parallel) son claras y pedagógicas — buen trabajo para aprender diferencias prácticas.
- ✅ **Buenas prácticas en PRs:** las PRs incluyen salida de tests y explicación — facilita revisión.

## Puntos de mejora (ordenados por prioridad)
1. **PROBLEMS / warnings en el código** (issue #32):
   - Hay advertencias e "infos" detectadas por el editor (naming, reglas de `.editorconfig`). No rompen la build, pero conviene solucionarlas para que el código cumpla las normas definidas.
   - Acción: ejecutar `dotnet format` y aplicar los cambios. Revisa las "bombillas" en VS/VSCode y acepta las correcciones cuando sean razonables.

2. **Documentación y conclusiones** (issue #33):
   - Añade en cada `README.md` de ejercicio una sección *Observaciones y Conclusiones* donde expliques: resultados de las mediciones, por qué una aproximación fue mejor, lecciones aprendidas y posibles mejoras. Esto aparece marcado en el issue.

3. **Solución global / fichero solución** (issue #34):
   - Sería muy útil añadir un `.sln` en la raíz o incluir los proyectos de cada ejercicio en una solución para facilitar `dotnet build` y `dotnet test` desde la raíz. Alternativamente, subir un zip con la estructura de solución.

4. **Actualizar checks en issues / cierre** (issue #35):
   - Cuando se hayan aplicado las correcciones, cierra los issues o marca las checklists como completadas. Añade una nota en el comentario del issue indicando qué cambios incluiste (por ejemplo: "He aplicado dotnet format y añadido README con conclusiones; PR #12 referencia").

5. **Tests de robustez para concurrencia** (mejora formativa):
   - Aumentar carga en tests concurrentes (p.ej. 1k o 10k tareas en ambientes locales) o repetir tests en bucle para reducir la posibilidad de que condiciones de carrera pasen desapercibidas. Añadir tests que validen invariantes (p.ej. `IEnumerable` result lengths, totals) en lugar de timing.

## Sugerencias de cambios concretos (snippets y comandos)
- Ejecutar formateo y revisar sugerencias:
  ```bash
  dotnet tool install -g dotnet-format
  dotnet format
  ```
- Añadir una solución global (ejemplo):
  ```bash
  dotnet new sln -n FormacionDotNet
  dotnet sln FormacionDotNet.sln add Semana5/Ejercicio1/src/*.csproj Semana5/Ejercicio2/src/*.csproj Semana5/Ejercicio3/src/*.csproj Semana5/Ejercicio4/src/*.csproj
  ```
- Ejemplo de README: incluir una sección `## Observaciones y Conclusiones` con tablas de tiempos y decisiones.

## Checklist final antes de cerrar la semana
- [ ] Resolver warnings/infos en PROBLEMS o justificar por PR su omisión.
- [ ] Añadir observaciones/conclusiones en cada README.
- [ ] Añadir/actualizar solución global (`.sln`) o instrucciones claras para ejecutar desde la raíz.
- [ ] Cerrar issues #32–#35 cuando esté aplicado y actualizar la traza en los PRs.
- [ ] (Opcional) Añadir tests adicionales de estrés para concurrencia.

---
