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
| `CourtConnect.Ui.Web` | Blazor Web App (render interactivo en servidor) que aloja los componentes y llama a la API por HTTP | Ui.Components |
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

- **Sin MediatR.** Servicios de aplicación simples. (MediatR pasó a licencia comercial en 2025, y para el reto no aporta.)
- **Blazor Web App en modo Server,** con los componentes en una Razor Class Library. Así esos mismos componentes podrían usarse más adelante en WebAssembly (PWA) o en MAUI Blazor Hybrid sin reescribirlos.
- **SQL Server en Docker** en local, accedido con EF Core. Cambiar de proveedor (por ejemplo, a PostgreSQL) afectaría sobre todo a Infrastructure y a las migraciones.
- **El reloj se inyecta** (`TimeProvider`): las reglas que dependen de fechas (R3, R4, la caducidad) tienen que poder probarse.
- **Docker y GitHub Actions:** build, tests y SonarCloud en cada PR. Las imágenes se construyen en la CI.

## Fuera del reto

Autenticación, despliegue en Azure, Redis, MAUI y observabilidad. Ver `docs/fase2-pendiente.md`.
