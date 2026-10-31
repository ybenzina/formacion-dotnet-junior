# Ejercicio 1 — Repositorio y dominio

**Días 1 y 2 · estimación: 4 h** · Issue: «P1 · Ej1 · Repositorio y dominio»

## Objetivo

Crear el repositorio `court-connect` como en un proyecto real, documentar el dominio y programar sus reglas de negocio con tests, sin base de datos ni API todavía.

## Antes de empezar (≈ 20 min)

Tienes que tener el entorno instalado y comprobado ([`entorno.md`](../../../docs/court-connect/entorno.md)). Si no, hazlo primero.

Conceptos nuevos de hoy. Búscalos en el [glosario](../../../docs/court-connect/glosario.md) y, cuando los uses, añádelos a tu glosario con tus palabras:

- **Dominio**, **entidad**, **objeto de valor** y **regla de negocio**: lo que vas a programar hoy.
- **Capa** y **dependencia entre proyectos**: por qué el proyecto `Domain` no referencia a ningún otro proyecto ni paquete de base de datos o web.
- **Clase** frente a **record**: lee [Tipos de registro de C#](https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/types/records), sobre todo «Cuándo usar registros». Fíjate en lo que dice de Entity Framework Core.

## Parte A — Crear el repositorio (≈ 40 min)

Sigue la checklist de [`docs/court-connect/plantilla-repo/README.md`](../../../docs/court-connect/plantilla-repo/README.md): repo público en DeemSoft, ajustes de PR, ruleset de `main`, etiquetas, milestones y primer PR (`chore/estructura-inicial`) con `AGENTS.md`, `CLAUDE.md`, plantillas y `.editorconfig`.

Cuando Yamel fusione ese PR, se crearán las issues del resto del reto.

## Parte B — Documentar el dominio (≈ 50 min)

Rama `docs/dominio`. Lee [`docs/court-connect/enunciado-dominio.md`](../../../docs/court-connect/enunciado-dominio.md). Si ya has hablado con tu grupo (apartado «Antes de escribir `domain.md`» del enunciado), ten a mano sus respuestas; si no, hazlo antes de la demo 1 y deja las conclusiones en `docs/discovery.md`. Escribe `docs/domain.md` en `court-connect` con:

- Descripción breve del dominio, con tus palabras.
- Glosario español–inglés.
- Diagrama entidad-relación en **Mermaid** (GitHub lo dibuja solo).
- Las reglas R1 a R6, indicando **qué entidad comprueba cada una**.
- Respuestas a las preguntas del final del enunciado.

Puedes incluir este PR en el de la parte C si te resulta más cómodo, pero en commits separados.

## Parte C — Solución y reglas de dominio (≈ 2 h 10 min)

Rama `feature/dominio`.

1. Crea la solución **a mano** con la CLI:
   - `CourtConnect.slnx` en la raíz.
   - `src/CourtConnect.Domain` (biblioteca de clases).
   - `tests/CourtConnect.UnitTests` (xUnit), con una referencia al proyecto Domain.
   - Carpetas y `.csproj` van **sin** el prefijo de la organización; el *namespace* y el ensamblado sí lo llevan (`DeemSoft.CourtConnect.Domain`), declarado una sola vez en un `Directory.Build.props` en la raíz. Ver [`architecture/README.md`](../../../docs/court-connect/architecture/README.md#nomenclatura): ¿por qué se acortan las rutas?
   - Con el SDK 10, `dotnet new sln` genera `.slnx`. Mira qué contiene.
   - Un **`global.json`** en la raíz que fije el SDK 10 (`dotnet new globaljson`). Elige una política de `rollForward` y explica en el PR qué significa. Así tú, Yamel y la CI usáis el mismo SDK.
2. En el proyecto Domain, crea las entidades `Court`, `Game`, `Player` y `Registration`, y un `enum` para cada estado (`GameStatus`, `RegistrationStatus`):
   - Escríbelas como **clases**, no como records: tienen identidad y cambian de estado. Si dudas, vuelve a «Antes de empezar».
   - Usa **constructores tradicionales** que validen los datos obligatorios antes de asignarlos. Los constructores principales los verás en el ejercicio 3, en los servicios.
   - **Sin atributos de validación** (`[Required]`, `[MaxLength]`…) en el dominio: aquí las reglas se comprueban en código, en constructores y métodos. Los atributos llegan en el ejercicio 3, en los DTOs.
   - Pista: si una propiedad tiene `set` público, cualquiera puede saltarse tus reglas. ¿Cómo lo evitas?
3. Implementa las reglas **R1 a R6** dentro del dominio. Pistas de diseño (decide tú):
   - ¿Quién crea una inscripción? ¿Un constructor público de `Registration` o un método del partido?
   - ¿Cómo comunicas que una regla no se cumple: excepción de dominio o un objeto resultado? Justifícalo en `domain.md`.
   - Las reglas con fechas (R3, R4, R5) necesitan saber «qué hora es ahora». No uses `DateTime.Now` dentro del dominio: recibe la fecha o usa `TimeProvider`.
   - La hora de un partido es un instante concreto. Decide cómo la representas (`DateTimeOffset`, UTC…) y anótalo en `domain.md`.
4. Escribe los tests. Como mínimo, estos casos:
   - R1: inscribir con plazas libres; inscribir en la **última** plaza; rechazar cuando está lleno.
   - R2: rechazar la segunda inscripción activa del mismo jugador; permitirla si la primera está cancelada.
   - R3: edad justo en el mínimo y un día por debajo. El jugador que **cumple años el mismo día** del partido. Un partido con edad mínima inferior a 16 no se puede crear.
   - R4: rechazar en partido borrador y cerrado; rechazar a la hora de inicio o después; aceptar un minuto antes.
   - R5: cancelar libera la plaza; cancelar dos veces no hace nada raro (decide qué debe pasar); rechazar la cancelación cuando el partido ya ha empezado.
   - R6: el importe es el precio por jugador del partido en el momento de apuntarse.
   - Las validaciones de las entidades (apodo vacío, jugador menor de 16, plazas < 2, duración ≤ 0, precio negativo…).

   Usa `[Theory]` con `[InlineData]` para los casos que solo cambian en los datos (edades, fechas, estados): menos duplicación y más claro.
5. `dotnet build` y `dotnet test` en verde. PR hacia `main`.

## Criterios de aceptación

- [ ] Repo creado y configurado según la checklist.
- [ ] `docs/domain.md` con diagrama Mermaid y las reglas asignadas a entidades.
- [ ] Domain sin referencias a EF Core ni a ASP.NET Core.
- [ ] R1 a R6 implementadas y todos los casos del paso 4 cubiertos.
- [ ] Cobertura de Domain ≥ 80 % (compruébala en local con `dotnet test --collect:"XPlat Code Coverage"`).
- [ ] **Calidad:** este PR tiene que poder superar el gate de SonarQube Cloud: fiabilidad, seguridad y mantenibilidad A en el código nuevo, cobertura del código nuevo ≥ 80 %, duplicación ≤ 3 % y todos los security hotspots revisados. Solo cuenta lo que añades o cambias. Detalles y trucos: [`docs/court-connect/calidad.md`](../../../docs/court-connect/calidad.md).
- [ ] `docs/learning/glosario.md` creado con el glosario base y los términos de hoy reescritos con tus palabras.
- [ ] PR con «Uso de IA» y «Comparación con IA».

## Extra

- `Nickname` (el apodo, con su longitud y caracteres permitidos) como **record** y objeto de valor, usado por `Player`. Compara cómo queda frente a un `string` suelto.
- Un informe de cobertura en HTML con ReportGenerator.

## Preguntas para la demo

- El proyecto `Domain` no tiene paquetes NuGet de EF Core ni referencias a otros proyectos de la solución. ¿Qué problema habría si los tuviera? Piensa en qué pasaría si mañana cambiamos de base de datos, o si quieres probar las reglas sin base de datos.
- La regla R1 (no superar las plazas) la compruebas en una entidad. ¿En cuál y por qué? Si la comprobaras solo en la API, ¿qué otro camino podría saltársela?
- La regla R4 depende de la hora actual. ¿Cómo haces que el test dé siempre el mismo resultado, lo ejecutes el día que lo ejecutes?
- `Game` es una clase. ¿Qué pasaría si fuera un record y tuvieras dos partidos con los mismos datos? ¿En qué parte del reto sí usarías records?

## Comparación con IA

Cuando el PR esté abierto, pide a la IA que diseñe las mismas entidades y reglas. Anota en la descripción del PR: qué hizo distinto, qué es mejor, qué es peor y qué no te convence.

## Recursos

- [Glosario técnico del reto](../../../docs/court-connect/glosario.md)
- [Tipos de registro de C#](https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/types/records)
- [Tutorial de pruebas unitarias con xUnit](https://learn.microsoft.com/es-es/dotnet/core/testing/unit-testing-csharp-with-xunit)
- [`dotnet sln`](https://learn.microsoft.com/es-es/dotnet/core/tools/dotnet-sln)
- [Diagramas Mermaid en GitHub](https://docs.github.com/es/get-started/writing-on-github/working-with-advanced-formatting/creating-diagrams)
- [`docs/Guia-xUnit-Intermedio.md`](../../../docs/Guia-xUnit-Intermedio.md) de este repo.
