# Arquitectura del reto — CourtConnect

Propuesta para el reto. Es deliberadamente simple: el objetivo es entender cada pieza, no aplicar todos los patrones.

## Proyectos

| Proyecto | Responsabilidad | Referencia a |
|---|---|---|
| `CourtConnect.Domain` | Entidades y reglas de negocio. Sin dependencias externas | — |
| `CourtConnect.Application` | Casos de uso (servicios), DTOs e interfaces (repositorios, reloj, pasarela de pago) | Domain |
| `CourtConnect.Infrastructure` | EF Core, `DbContext`, migraciones, repositorios, adaptadores | Domain, Application |
| `CourtConnect.Api` | API REST con ASP.NET Core y OpenAPI | Application, Infrastructure |
| `CourtConnect.Ui.Components` | Componentes Razor reutilizables (Razor Class Library) | — |
| `CourtConnect.Ui.Web` | Blazor Web App (Static SSR en las páginas públicas e Interactive Server en el panel del organizador) que aloja los componentes y llama a la API por HTTP | Ui.Components |
| `CourtConnect.UnitTests` | Tests unitarios con xUnit | Domain, Application |
| `CourtConnect.IntegrationTests` | Tests de la API con `WebApplicationFactory` y SQL Server en contenedor | Api |

`Domain` no referencia a nadie, y la web **no** accede a la base de datos: solo habla con la API.

## Nomenclatura

Las **carpetas y los `.csproj`** van sin el prefijo de organización, y la solución es `CourtConnect.slnx`. Las rutas se acortan bastante, que en Windows importa: el límite de 260 caracteres se alcanza antes de lo que parece cuando se suman los intermedios de `obj\`.

Los **namespaces y los ensamblados** sí lo llevan: `DeemSoft.CourtConnect.<Capa>`. No se repite en cada `.csproj`, se declara una vez en `Directory.Build.props` de la raíz, sobre el valor que el SDK usa por defecto:

```xml
<RootNamespace>DeemSoft.$(MSBuildProjectName)</RootNamespace>
<AssemblyName>DeemSoft.$(MSBuildProjectName)</AssemblyName>
```

Conviene saber que el ensamblado **no** es solo el nombre del `.dll`: una Razor Class Library sirve sus ficheros estáticos bajo `_content/<ensamblado>/`, así que cambiarlo rompería esas rutas en ejecución sin fallar la compilación.

## Decisiones del reto

- **Sin MediatR.** En las partes I y II, servicios de aplicación simples. Desde la Parte III, el código nuevo va en *slices* verticales (una carpeta por caso de uso) con *handlers* que son clases normales inyectadas. (MediatR tiene licencia comercial desde la versión 13, y para el reto no aporta.)
- **Blazor Web App con el modo de render elegido por página:** las páginas públicas (listado y ficha de partidos, apuntarse) en **Static SSR**; el panel del organizador en **Interactive Server**. Los componentes, en una Razor Class Library, para poder usarlos más adelante en WebAssembly (PWA) o en MAUI Blazor Hybrid sin reescribirlos.
- **Identidad con ASP.NET Core Identity en la API** (Parte II). La web guarda la sesión en una cookie y un `DelegatingHandler` añade el token a las llamadas a la API. Roles `Organizer` y `Player`; las reglas de autorización R7 y R8 viven en el dominio o en la aplicación, no solo en los endpoints.
- **SQL Server en Docker** en local, accedido con EF Core; **Azure SQL** al desplegar. Cambiar de proveedor (por ejemplo, a PostgreSQL) afectaría sobre todo a Infrastructure y a las migraciones.
- **El reloj se inyecta** (`TimeProvider`): las reglas que dependen de fechas (R3, R4, R5, la caducidad) tienen que poder probarse. Lo mismo con el azar, si se hacen los equipos aleatorios.
- **Proceso en segundo plano** (`BackgroundService`) para caducar las inscripciones pendientes de pago (Parte III).
- **Docker y GitHub Actions:** build, tests y SonarCloud en cada PR. Las imágenes se construyen en la CI.
- **Despliegue en Azure Container Apps** (Parte III), con la concesión gratuita y Azure SQL con la oferta gratuita en pausa al llegar al límite.

## Fuera del reto

Redis, MAUI, modo sin conexión, estadísticas, microservicios y mensajería. Aspire y OpenTelemetry son un extra de la Parte III y se trabajan en la iteración 0 de Àmbit. Ver `docs/fase2-pendiente.md`.
