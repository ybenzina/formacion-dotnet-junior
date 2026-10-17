# Formación .NET Junior

Repositorio de formación en C# y .NET. Contiene el plan, los enunciados, los anuncios y el material de apoyo. **No contiene soluciones en `main`.**

- `Semana1/` a `Semana8/`: plan y enunciados de cada semana.
- `docs/`: guías y material de referencia.
- `docs/court-connect/`: dominio y material del reto CourtConnect (fase 2).
- `.github/ISSUE_TEMPLATE/`: plantillas de issues de la fase 1.

## Fase 1 — C# y .NET (semanas 1 a 6)

Formación intermedia en C# y .NET para desarrolladores con experiencia previa en otros lenguajes (Java, JavaScript, Python…).

Objetivos:
- Fundamentos de C# y .NET.
- Git avanzado y solución .NET multiproyecto.
- Programación orientada a objetos y pruebas unitarias con xUnit.
- Asincronía y multihilo: tasks, threads y sincronización.
- Colecciones concurrentes, LINQ y pipelines (`Channel`, `BlockingCollection`).

Las soluciones de la fase 1 están en la rama `drissbego/integration`.

## Fase 2 — Reto CourtConnect (semanas 7 y 8)

Reto de dos semanas (19 al 30 de octubre de 2026), con unas 4 horas al día, para tocar a mano las piezas básicas de una aplicación .NET actual y saber **supervisar** el código que genere la IA.

- **Semana 7 — Del dominio a la API con CI:** modelo de dominio y xUnit, EF Core con SQL Server en Docker, API con ASP.NET Core, tests de integración, GitHub Actions y SonarCloud.
- **Semana 8 — Web, contenedores y SDD:** Blazor, Docker y una funcionalidad hecha con Spec-Driven Development (GitHub Spec Kit).

El código se desarrolla en un repositorio propio, **`DeemSoft/court-connect`**, que se crea el primer día del reto. Empieza por [`Semana7/README.md`](Semana7/README.md).

Los temas de la fase 2 original que quedan para más adelante están en [`docs/fase2-pendiente.md`](docs/fase2-pendiente.md).

¡Empecemos!
