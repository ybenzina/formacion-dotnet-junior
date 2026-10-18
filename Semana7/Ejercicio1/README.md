# Ejercicio 1 — Repositorio y dominio

**Lunes 19 de octubre · unas 4 h** · Issue: «S7 · Ej1 · Repositorio y dominio»

## Objetivo

Crear el repositorio `court-connect` como en un proyecto real, documentar el dominio y programar sus reglas de negocio con tests, sin base de datos ni API todavía.

## Parte A — Crear el repositorio (≈ 45 min)

Sigue la checklist de [`docs/court-connect/plantilla-repo/README.md`](../../docs/court-connect/plantilla-repo/README.md): repo público en DeemSoft, ajustes de PR, ruleset de `main`, etiquetas, milestones y primer PR (`chore/estructura-inicial`) con `AGENTS.md`, `CLAUDE.md`, plantillas y `.editorconfig`.

Cuando Yamel fusione ese PR, se crearán las issues del resto del reto.

## Parte B — Documentar el dominio (≈ 1 h)

Rama `docs/dominio`. Lee [`docs/court-connect/enunciado-dominio.md`](../../docs/court-connect/enunciado-dominio.md) y escribe `docs/domain.md` en `court-connect` con:

- Descripción breve del dominio, con tus palabras.
- Glosario español–inglés.
- Diagrama entidad-relación en **Mermaid** (GitHub lo dibuja solo).
- Las reglas R1 a R6, indicando **qué entidad comprueba cada una**.
- Respuestas a las preguntas del final del enunciado.

Puedes incluir este PR en el de la parte C si te resulta más cómodo, pero en commits separados.

## Parte C — Solución y reglas de dominio (≈ 2 h 15 min)

Rama `feature/dominio`.

1. Crea la solución **a mano** con la CLI:
   - `CourtConnect.slnx` en la raíz.
   - `src/CourtConnect.Domain` (biblioteca de clases).
   - `tests/CourtConnect.UnitTests` (xUnit), con referencia a Domain.
   - Con el SDK 10, `dotnet new sln` genera `.slnx`. Mira qué contiene.
   - Un **`global.json`** en la raíz que fije el SDK 10 (`dotnet new globaljson`). Elige una política de `rollForward` y explica en el PR qué significa. Así tú, Yamel y la CI usáis el mismo SDK.
2. Implementa en Domain las entidades `Camp`, `Player` y `Registration` y los estados que necesites.
3. Implementa las reglas **R1 a R6** dentro del dominio. Pistas de diseño (decide tú):
   - ¿Quién crea una inscripción? ¿Un constructor público de `Registration` o un método del campus?
   - ¿Cómo comunicas que una regla no se cumple: excepción de dominio o un objeto resultado? Justifícalo en `domain.md`.
   - Las reglas con fechas (R3, R4) necesitan saber «qué día es hoy». No uses `DateTime.Now` dentro del dominio: recibe la fecha o usa `TimeProvider`.
4. Escribe los tests. Como mínimo, estos casos:
   - R1: inscribir con plazas libres; inscribir en la **última** plaza; rechazar cuando está lleno.
   - R2: rechazar la segunda inscripción activa del mismo jugador; permitirla si la primera está cancelada.
   - R3: edad justo en el mínimo, justo en el máximo, por debajo y por encima. El jugador que **cumple años el mismo día** de inicio.
   - R4: rechazar en campus borrador y cerrado; rechazar el mismo día de inicio o después.
   - R5: cancelar libera la plaza; cancelar dos veces no hace nada raro (decide qué debe pasar).
   - R6: el importe es el precio del campus en el momento de inscribirse.
   - Las validaciones de las entidades (nombre vacío, plazas ≤ 0, fecha de fin anterior a la de inicio…).

   Usa `[Theory]` con `[InlineData]` para los casos que solo cambian en los datos (edades, fechas, estados): menos duplicación y más claro.
5. `dotnet build` y `dotnet test` en verde. PR hacia `main`.

## Criterios de aceptación

- [ ] Repo creado y configurado según la checklist.
- [ ] `docs/domain.md` con diagrama Mermaid y las reglas asignadas a entidades.
- [ ] Domain sin referencias a EF Core ni a ASP.NET Core.
- [ ] R1 a R6 implementadas y todos los casos del paso 4 cubiertos.
- [ ] Cobertura de Domain ≥ 80 % (compruébala en local con `dotnet test --collect:"XPlat Code Coverage"`).
- [ ] **Calidad:** este PR tiene que poder superar el gate de SonarQube Cloud: fiabilidad, seguridad y mantenibilidad A en el código nuevo, cobertura del código nuevo ≥ 80 %, duplicación ≤ 3 % y todos los security hotspots revisados. Solo cuenta lo que añades o cambias. Detalles y trucos: [`docs/court-connect/calidad.md`](../../docs/court-connect/calidad.md).
- [ ] PR con «Uso de IA» y «Comparación con IA».

## Extra

- `Tournament` y `Team` con su regla de número máximo de equipos.
- Un informe de cobertura en HTML con ReportGenerator.

## Preguntas para la demo

- ¿Por qué Domain no puede depender de EF Core?
- ¿Dónde se comprueba R1 y qué pasaría si se comprobara en la API?
- ¿Cómo has probado una regla que depende de la fecha actual?

## Comparación con IA

Cuando el PR esté abierto, pide a la IA que diseñe las mismas entidades y reglas. Anota en la descripción del PR: qué hizo distinto, qué es mejor, qué es peor y qué no te convence.

## Recursos

- [Tutorial de pruebas unitarias con xUnit](https://learn.microsoft.com/es-es/dotnet/core/testing/unit-testing-csharp-with-xunit)
- [`dotnet sln`](https://learn.microsoft.com/es-es/dotnet/core/tools/dotnet-sln)
- [Diagramas Mermaid en GitHub](https://docs.github.com/es/get-started/writing-on-github/working-with-advanced-formatting/creating-diagrams)
- `docs/Guia-xUnit-Intermedio.md` de este repo.
