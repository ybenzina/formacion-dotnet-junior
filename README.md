# Formación .NET Junior

Repositorio de formación en C# y .NET. Contiene el plan, los enunciados, los anuncios y el material de apoyo. **No contiene soluciones en `main`.**

- `curso/`: curso de C# y .NET por semanas (`Semana1/` a `Semana6/`), con el plan y los enunciados.
- `reto/`: las tres partes del reto CourtConnect (`Parte1/` a `Parte3/`).
- `docs/`: guías y material de referencia.
- `docs/court-connect/`: dominio, calendario y material del reto CourtConnect.
- `.github/ISSUE_TEMPLATE/`: plantillas de issues del curso.

## Curso — C# y .NET (semanas 1 a 6)

Formación intermedia en C# y .NET para desarrolladores con experiencia previa en otros lenguajes (Java, JavaScript, Python…).

Objetivos:
- Fundamentos de C# y .NET.
- Git avanzado y solución .NET multiproyecto.
- Programación orientada a objetos y pruebas unitarias con xUnit.
- Asincronía y multihilo: tasks, threads y sincronización.
- Colecciones concurrentes, LINQ y pipelines (`Channel`, `BlockingCollection`).

Las soluciones del curso están en la rama `drissbego/integration`.

## Reto CourtConnect (tres partes)

Reto de 23 días de trabajo (Día 1 a Día 23, ver el [calendario](docs/court-connect/calendario.md)), con unas 4 horas al día, para tocar a mano las piezas básicas de una aplicación .NET actual, saber **supervisar** el código que genere la IA y acabar con un MVP desplegado. El dominio: una aplicación para quedar a jugar a baloncesto callejero.

- **Parte I · Fundamentos (días 1–8):** modelo de dominio y xUnit, EF Core con SQL Server en Docker, API con ASP.NET Core, tests de integración, GitHub Actions y SonarCloud.
- **Parte II · Web, identidad y contenedores (días 9–16):** Blazor (Static SSR e Interactive Server), cuentas, login y roles con Identity, panel del organizador y Docker Compose.
- **Parte III · MVP con SDD (días 17–23):** torneos con pago y caducidad y una segunda funcionalidad con Spec-Driven Development (GitHub Spec Kit), *slices* verticales, `BackgroundService` y despliegue en Azure Container Apps.

El código se desarrolla en un repositorio propio, **`DeemSoft/court-connect`**, que se crea el primer día del reto. Empieza por [`reto/Parte1/README.md`](reto/Parte1/README.md).

Los temas del plan original de ocho semanas que quedan para más adelante están en [`docs/fase2-pendiente.md`](docs/fase2-pendiente.md).

¡Empecemos!
