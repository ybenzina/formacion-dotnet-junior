# Arquitectura del reto — CourtConnect

Propuesta para el reto. Es deliberadamente simple: el objetivo es entender cada pieza, no aplicar todos los patrones.

## Proyectos

| Proyecto | Responsabilidad | Referencia a |
|---|---|---|
| `DeemSoft.CourtConnect.Domain` | Entidades y reglas de negocio. Sin dependencias externas | — |
| `DeemSoft.CourtConnect.Application` | Casos de uso (servicios), DTOs e interfaces (repositorios, reloj, pasarela de pago) | Domain |
| `DeemSoft.CourtConnect.Infrastructure` | EF Core, `DbContext`, migraciones, repositorios, adaptadores | Domain, Application |
| `DeemSoft.CourtConnect.Api` | API REST con ASP.NET Core y OpenAPI | Application, Infrastructure |
| `DeemSoft.CourtConnect.Ui.Components` | Componentes Razor reutilizables (Razor Class Library) | — |
| `DeemSoft.CourtConnect.Ui.Web` | Blazor Web App (render interactivo en servidor) que aloja los componentes y llama a la API por HTTP | Ui.Components |
| `DeemSoft.CourtConnect.UnitTests` | Tests unitarios con xUnit | Domain, Application |
| `DeemSoft.CourtConnect.IntegrationTests` | Tests de la API con `WebApplicationFactory` y SQL Server en contenedor | Api |

`Domain` no referencia a nadie, y la web **no** accede a la base de datos: solo habla con la API.

## Decisiones del reto

- **Sin MediatR.** Servicios de aplicación simples. (MediatR pasó a licencia comercial en 2025, y para el reto no aporta.)
- **Blazor Web App en modo Server,** con los componentes en una Razor Class Library. Así esos mismos componentes podrían usarse más adelante en WebAssembly (PWA) o en MAUI Blazor Hybrid sin reescribirlos.
- **SQL Server en Docker** en local, accedido con EF Core. Cambiar de proveedor (por ejemplo, a PostgreSQL) afectaría sobre todo a Infrastructure y a las migraciones.
- **El reloj se inyecta** (`TimeProvider`): las reglas que dependen de fechas (R3, R4, la caducidad) tienen que poder probarse.
- **Docker y GitHub Actions:** build, tests y SonarCloud en cada PR. Las imágenes se construyen en la CI.

## Fuera del reto

Autenticación, despliegue en Azure, Redis, MAUI y observabilidad. Ver `docs/fase2-pendiente.md`.
