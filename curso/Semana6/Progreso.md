# 🚧 Progreso — Semana 6 (Colecciones concurrentes, LINQ y Download Manager)

**Estado general:** Parcial — **2 de 3 ejercicios completados** (Ejercicio 1 y 2), Ejercicio 3 (Download Manager) pendiente.
El código compila y las implementaciones están presentes; faltan documentar conclusiones en los READMEs y resolver warnings/PROBLEMS antes de cerrar la semana.

**Calificación orientativa (parcial):** **8.5 / 10** — buen nivel funcional; pendientes de documentación y limpieza de avisos en PROBLEMS.

## Ejercicios verificados
- **Ejercicio 1 — Colecciones concurrentes (BlockingCollection, ConcurrentDictionary):** implementado.
- **Ejercicio 2 — LINQ y delegados (vitaminado):** implementado.
- **Ejercicio 3 — Download Manager (pipeline):** **pendiente**

## Estado de integración
- Branches / PRs: Integradas en drissbego/integration las PRs 43 y 44 con los ejercicios 1 y 2.

## Checklist (estado actual)
- [x] Código implementado (Ej1, Ej2)
- [ ] README de cada ejercicio con sección "Observaciones y Conclusiones" (pendiente)
- [ ] PROBLEMS/warnings resueltos (pendiente)
- [ ] Ejercicio 3 completado y tests añadidos (pendiente)
- [x] Issues #36 y #37 atendidos y cerrados

## Acciones recomendadas (prioritarias)
1. **Documentar conclusiones**: en cada `Semana6/EjercicioX/README.md` añade una sección `## Observaciones y Conclusiones` con:
   - resultados y tablas de tiempos si aplica,
   - decisiones de diseño y por qué (p.ej. elección de Channel vs BlockingCollection),
   - aprendizajes y pasos siguientes.
2. **Revisar PROBLEMS**: abrir el proyecto en VS/VSCode y resolver warnings (`.editorconfig`), o ejecutar:
```bash
dotnet tool install -g dotnet-format
dotnet format
```
3. **Completar/terminar Ejercicio 3**: si queda trabajo por hacer en Download Manager, priorizar:
   - cancelación (`CancellationToken`), reintentos (`MaxRetriesPerPart`) y reporting de progreso,
   - tests que simulen fallos y verifiquen reintentos y completitud.
4. **Cerrar issues y actualizar PRs**: cuando subas cambios, en la descripción del PR incluye `Fixes #36` (o #37) para cerrar automáticamente el issue.
5. **Agregar proyectos a solución global  `formacion-dotnet-junior.sln`** (facilita `dotnet build` desde la raíz).

## Comandos útiles
- Ejecutar build y tests desde la raíz del repo (si hay .sln):
```bash
dotnet build
dotnet test
```
- Formateo:
```bash
dotnet format
```

## Próximos pasos propuestos
- Completar el Ejercicio 3 y añadir tests automatizados (xUnit) que validen reintentos y cancelación.
- Resolver PROBLEMS y actualizar READMEs — tras ello, se puede cerrar la semana y hacer una evaluación final.
