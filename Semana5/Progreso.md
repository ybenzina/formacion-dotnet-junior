# 🚧 Progreso — Semana 5 (Tasks, Threads y Sincronización)

**Estado general:** ✅ Ejercicios completados (Ejercicio 1..4). Compilación y ejecución correctas; tests unitarios ejecutados y verificados. Buen flujo de trabajo: PRs con salida de `dotnet test` en la descripción.

**Calificación orientativa:** **9 / 10** — Muy buen nivel funcional y de pruebas. Algunos puntos menores a mejorar (warnings/problemas de estilo y documentación).

## Entregables verificados

- **Ejercicio 1 — Thread vs Task (+ ThreadPool, background threads):** implementado y probado.
- **Ejercicio 2 — Parallel.For / Parallel.ForEach / PLINQ:** implementado y con mediciones/tests.
- **Ejercicio 3 — Sincronización (lock / Interlocked y extensiones):** implementado; añade Monitor/Mutex según enunciado y tests asociados.
- **Ejercicio 4 — Colecciones básicas:** implementado y con tests para casos límite.

## Resultado de tests

- `dotnet build` ✅
- `dotnet test` ✅ (tests ejecutados correctamente — la salida fue incluida en la descripción de las PRs)

## Notas rápidas (qué queda por cerrar)

- Hay issues relacionados (ver #32, #33, #34, #35) con comentarios sobre warnings y documentación. Incorporar las acciones indicadas (ver sección "Acciones recomendadas").
- Algunas advertencias en PROBLEMS (warnings/info) — no rompen la build pero conviene resolverlas para calidad.

## Checklist (estado)

- [x] Rama creada por alumno (`<githubuser>/semana5-ejX`)
- [x] PR hacia `drissbego/integration` con salida de tests
- [x] Compilación (`dotnet build`) ✅
- [x] Test (`dotnet test`) ✅
- [ ] Issues relacionados cerrados y checks actualizados (pendiente)
- [ ] Aplicar correcciones de estilo / warnings (pendiente)

## Acciones recomendadas (prioridad alta → baja)

1. **Revisar comentarios issues (#32–#35) y PROBLEMS** Aplicar las correcciones y recomendaciones para no acumular deuda o justificar.  En el IDE / ejecutar `dotnet format` y aplicar cambios sugeridos por `.editorconfig`. Comandos útiles:

   ```bash
   dotnet tool install -g dotnet-format
   dotnet format
   ```

2. **Actualizar README de cada ejercicio** con conclusiones y observaciones (según comentario en issues). Añadir tiempos/mediciones y lecciones aprendidas.
3. **Agregar los proyectos a solución global** . En un futuro añadir ejercicios a fichero de solución global `formacion-dotnet-junior.sln` para compilación teniendo en cuenta las propiedades de `Directory.Build.props` como  la ejecución de análisis de código.
4. **Marcar/actualizar checks en los issues** (usar checklist en descripción) para tener trazabilidad de lo completado.

## Recursos / comandos rápidos

- Ejecutar todos los tests desde la raíz del repositorio:

  ```bash
  dotnet test --no-build
  ```

- Aplicar formateo y reglas del editor:

  ```bash
  dotnet format
  ```

¡Buen trabajo!
