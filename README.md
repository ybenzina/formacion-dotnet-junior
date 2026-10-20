# Formación .NET Junior

Repositorio de formación en C# y .NET. Contiene el plan, los enunciados, los anuncios y el material de apoyo. **No contiene soluciones en `main`.**

- `Semana1/` a `Semana6/`: plan y enunciados de cada semana de la fase 1.
- `Parte1/` a `Parte3/`: las tres partes del reto CourtConnect (fase 2).
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

## Fase 2 — Reto CourtConnect (tres partes)

Reto del 21 de octubre al 20 de noviembre de 2026, con unas 4 horas al día, para tocar a mano las piezas básicas de una aplicación .NET actual, saber **supervisar** el código que genere la IA y acabar con un MVP desplegado. El dominio: una aplicación para quedar a jugar a baloncesto callejero.

- **Parte I · Fundamentos (21–30 oct):** modelo de dominio y xUnit, EF Core con SQL Server en Docker, API con ASP.NET Core, tests de integración, GitHub Actions y SonarCloud.
- **Parte II · Web, identidad y contenedores (2–11 nov):** Blazor (Static SSR e Interactive Server), cuentas, login y roles con Identity, panel del organizador y Docker Compose.
- **Parte III · MVP con SDD (12–20 nov):** torneos con pago y caducidad y una segunda funcionalidad con Spec-Driven Development (GitHub Spec Kit), *slices* verticales, `BackgroundService` y despliegue en Azure Container Apps.

El código se desarrolla en un repositorio propio, **`DeemSoft/court-connect`**, que se crea el primer día del reto. Empieza por [`Parte1/README.md`](Parte1/README.md).

Los temas de la fase 2 original que quedan para más adelante están en [`docs/fase2-pendiente.md`](docs/fase2-pendiente.md).

¡Empecemos!
