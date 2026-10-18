# Ejercicio 4 — Tests de integración y CI

**Jueves 22 de octubre · unas 4 h** · Issue: «S7 · Ej4 · Tests de integración y CI»

## Objetivo

Probar la API de extremo a extremo contra un SQL Server real en contenedor, y ejecutar build y tests automáticamente en cada PR.

## Pasos

### 1. Tests de integración (≈ 2 h) — rama `test/integracion-api`

- Proyecto `tests/CourtConnect.IntegrationTests` con `Microsoft.AspNetCore.Mvc.Testing` y `Testcontainers.MsSql`.
- Una *fixture* que arranca un SQL Server en contenedor una vez por ejecución, aplica las migraciones y configura `WebApplicationFactory` para usarlo en lugar de tu base de datos local.
- Casos mínimos (uno o varios por **cada endpoint** de la tabla del ejercicio 3):
  - `GET /camps` solo devuelve campus abiertos, con las plazas libres correctas.
  - `GET` de campus y jugador inexistentes → 404.
  - Altas con datos inválidos → 400 con ProblemDetails (un `[Theory]` con varios cuerpos inválidos).
  - Inscripción correcta → 201 y queda guardada.
  - Campus lleno y inscripción duplicada → 409.
  - Cancelar → 204 y la plaza vuelve a estar libre; cancelar otra vez → el código que decidiste.
- Cada test prepara sus propios datos: el orden de ejecución no debe importar.
- Pista: si el proyecto de tests no «ve» la clase `Program` de la API, averigua por qué y cómo se resuelve.

### 2. Workflow de CI (≈ 1 h 30 min) — rama `chore/ci`

- `.github/workflows/ci.yml` que, en cada PR hacia `main` y en cada push a `main`:
  - Instala el SDK con `actions/setup-dotnet` leyendo el `global.json` del repo (`global-json-file: global.json`), sin escribir la versión en el workflow.
  - Ejecuta `restore`, `build` y `test`.
- Usa un runner **`ubuntu-latest`**: Testcontainers necesita Docker con contenedores Linux, y los runners de Windows no lo ofrecen.
- Referencias: `docs/Guia-CI.md` y `.github/workflows/build.yml` de este repo (este último incluye SonarCloud, que es para mañana).

### 3. Hacer obligatoria la CI (≈ 30 min)

- Cuando el workflow haya pasado una vez, añade su job como **status check obligatorio** en el ruleset de `main`.
- Comprueba que un PR con un test roto no se puede fusionar.

## Criterios de aceptación

- [ ] Todos los casos mínimos en verde, en local y en la CI.
- [ ] Con los tests unitarios y de integración juntos, cobertura ≥ 80 % del código de la API (compruébalo en local).
- [ ] Duplicación baja en los tests: datos de prueba en *builders* o métodos auxiliares, casos parecidos en `[Theory]`.
- [ ] El workflow se ejecuta en cada PR y en `main`.
- [ ] La CI es obligatoria para fusionar en `main`.
- [ ] El nombre de la organización o del repo no aparece escrito a mano en el workflow.
- [ ] La versión del SDK sale del `global.json`, no del workflow.

## Extra

- Badge del estado de la CI en el README.
- Caché de paquetes NuGet en el workflow.

## Preguntas para la demo

- ¿Qué diferencia hay entre tus tests unitarios y los de integración? ¿Qué detecta cada uno que el otro no?
- ¿Qué pasa, paso a paso, cuando abres un PR?
- ¿Por qué el runner es Linux?

## Comparación con IA

Con el PR abierto, pide a la IA el workflow y la fixture de integración, y compáralos con los tuyos: versiones de las acciones, caché, cómo limpia el contenedor.

## Recursos

- [Pruebas de integración en ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/test/integration-tests)
- [Testcontainers para .NET](https://dotnet.testcontainers.org/)
- [Compilar y probar .NET con GitHub Actions](https://docs.github.com/es/actions/use-cases-and-examples/building-and-testing/building-and-testing-net)
- [Rulesets de GitHub](https://docs.github.com/es/repositories/configuring-branches-and-merges-in-your-repository/managing-rulesets/about-rulesets)
