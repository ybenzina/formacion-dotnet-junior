# Ejercicio 3 — API con ASP.NET Core

**Días 5 y 6 · estimación: 4 h** · Issue: «P1 · Ej3 · API con ASP.NET Core»

## Objetivo

Exponer los casos de uso del dominio en una API REST, con validación, errores bien formados y documentación OpenAPI.

## Antes de empezar (≈ 45 min)

Conceptos nuevos de hoy (en el [glosario](../../../docs/court-connect/glosario.md)): **API REST**, **endpoint**, **Minimal API**, **códigos de estado HTTP**, **ProblemDetails**, **OpenAPI**, **DTO**, **servicio de aplicación**, **repositorio**, **inyección de dependencias** y **constructor principal**.

Lectura: [Tutorial: Creación de una API mínima con ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/tutorials/min-web-api), versión .NET 10. Fíjate en `MapGroup`, `TypedResults` y en por qué usa DTOs. No hace falta que lo programes entero.

La [masterclass de arquitectura](../../../docs/masterclasses/masterclass-architecture.md) está prevista para **el domingo siguiente al Día 5**, a mitad de este ejercicio; la fecha real está en el [calendario](../../../docs/court-connect/calendario.md). Lleva el servicio de aplicación tal como lo tengas, aunque esté incompleto. Revisaremos responsabilidades, inyección de dependencias y patrones. Lo que aún no exista se trabajará en papel. Si la sesión llega antes de terminar, acaba el ejercicio aplicando lo aprendido; si llega después, úsala para repasarlo antes de la demo 1. No hace falta convertir toda la aplicación a slices.

## Pasos

Rama `feature/api`.

### 1. Capa de aplicación (≈ 1 h)

- Proyecto `src/CourtConnect.Application`: servicios de aplicación (por ejemplo, `RegistrationService`), DTOs de entrada y salida e interfaces de los repositorios.
- Implementa los repositorios en Infrastructure.
- La API **no** devuelve entidades del dominio: devuelve DTOs. ¿Por qué?
- Escribe los **DTOs como records**: solo llevan datos, se comparan por valor y no cambian. Es el caso de uso típico de un record (compáralo con las entidades del ejercicio 1, que son clases).
- Los servicios reciben sus dependencias por inyección. Aquí puedes usar **constructores principales** (`public class RegistrationService(IGameRepository games)`): para inyectar dependencias son más cortos que el constructor tradicional. Ojo: sus parámetros se pueden reasignar; no lo hagas.

### 2. Endpoints (≈ 2 h)

Usa **Minimal APIs** con grupos de endpoints (`MapGroup`). Si prefieres controladores, justifícalo en el PR.

| Método y ruta | Qué hace | Respuestas |
| --- | --- | --- |
| `GET /games` | Partidos abiertos, que no han empezado, con sus plazas libres | 200 |
| `GET /games/{id}` | Detalle de un partido | 200, 404 |
| `POST /courts` | Alta de cancha (para pruebas) | 201, 400 |
| `POST /games` | Alta de partido (para pruebas) | 201, 400, 404 |
| `POST /players` | Alta de jugador | 201, 400, 409 |
| `GET /players/{id}` | Detalle de jugador | 200, 404 |
| `POST /games/{id}/registrations` | Apuntar a un jugador | 201, 400, 404, 409 |
| `GET /games/{id}/registrations` | Apuntados a un partido | 200, 404 |
| `POST /registrations/{id}/cancel` | Cancelar una inscripción | 204, 404, 409 |

- Todavía no hay login: el jugador va en el cuerpo de la petición. En la Parte II lo sustituirá la sesión, y verás por qué esto de ahora sería un agujero de seguridad.
- Las reglas incumplidas (sin plazas, duplicada, edad insuficiente, partido no abierto o ya empezado, apodo repetido) devuelven **409** o **400** con **ProblemDetails**. Decide cuál en cada caso y anótalo.
- Validación de la entrada (campos obligatorios, longitudes, fechas coherentes) con **atributos** en los DTOs (`[Required]`, `[MaxLength]`, `[Range]`). En .NET 10 las Minimal APIs pueden validarlos automáticamente: averigua cómo se activa. La validación de la API (formato de la entrada) no sustituye a las reglas del dominio (R1 a R6).
- Registra con `ILogger` las inscripciones creadas y rechazadas.

### 3. OpenAPI, interfaz web y pruebas manuales (≈ 1 h 15 min)

- Activa el documento OpenAPI (en .NET 10, `AddOpenApi` y `MapOpenApi`). Ábrelo en el navegador (`/openapi/v1.json`): es la **definición** de tu API, la que usan otras herramientas para generar documentación y clientes.
- Añade **Swagger UI** (paquete `Swashbuckle.AspNetCore.SwaggerUi`), apuntando a `/openapi/v1.json`, para explorar y probar la API desde el navegador. Desde .NET 9 la plantilla ya no la trae: genera el documento OpenAPI, pero no la interfaz. Swagger UI es la más extendida en las empresas.
- Actívala **solo en desarrollo** (`app.Environment.IsDevelopment()`). ¿Por qué no la publicarías en producción?
- Completa el documento para que se entienda sin leer el código: nombre y descripción de cada endpoint (`WithName`, `WithSummary`) y sus respuestas posibles, incluidos los errores con ProblemDetails.
- Crea `src/CourtConnect.Api/CourtConnect.http` con una petición por endpoint, incluidos los casos de error. Ejecútalas con la extensión REST Client. El fichero `.http` sirve para repetir pruebas desde el editor y guardarlas en el repo; la interfaz web, para explorar la API y **enseñarla** en la demo.

## Criterios de aceptación

- [ ] Los 9 endpoints funcionan contra SQL Server en Docker.
- [ ] Ninguna entidad del dominio sale por la API.
- [ ] Errores con ProblemDetails y códigos HTTP coherentes.
- [ ] Documento OpenAPI en `/openapi/v1.json` y Swagger UI solo en desarrollo, con cada endpoint descrito y sus respuestas, también las de error.
- [ ] Fichero `.http` con casos de éxito y de error.
- [ ] Tests unitarios de `RegistrationService` con dobles (mocks o fakes) de los repositorios, que cubran como mínimo:
  - inscripción correcta;
  - cada motivo de rechazo (partido inexistente, jugador inexistente, sin plazas, duplicada, edad insuficiente, partido no abierto, partido ya empezado), mejor con un `[Theory]`;
  - cancelación correcta, de una inscripción inexistente y de una ya cancelada.
- [ ] Tests de los mapeos entre entidades y DTOs.
- [ ] **Calidad:** cobertura ≥ 80 % de Application. Los endpoints se cubren en el Ejercicio 4 con los tests de integración: en el Ejercicio 5, el código nuevo de la API tiene que llegar también al 80 %. Resto del gate en [`calidad.md`](../../../docs/court-connect/calidad.md).

## Extra

- **Scalar** (paquete `Scalar.AspNetCore`), otra interfaz que lee el mismo documento OpenAPI. Pruébala junto a Swagger UI y anota en el PR qué te aporta cada una.
- Paginación en `GET /games`.

## Preguntas para la demo

- Pon un ejemplo de tu API para cada código: 400, 404 y 409. ¿Por qué «partido lleno» es un 409 y no un 400?
- Sigue el camino de `POST /games/{id}/registrations`: ¿qué clase recibe la petición, cuál aplica las reglas, cuál guarda en la base de datos y cómo llega cada dependencia a su sitio?
- Si la API devolviera la entidad `Player` tal cual, ¿qué datos podrían salir que no deberían? ¿Qué más se rompería si mañana cambias la entidad?
- Los DTOs son records y las entidades, clases. Explica por qué en cada caso.
- Enseña tu API en Swagger UI. ¿Qué diferencia hay entre el documento OpenAPI y Swagger UI? ¿Y entre Swagger UI y el fichero `.http`?
- ¿Dónde se valida que el nombre no venga vacío y dónde que el partido no esté lleno? ¿Por qué en sitios distintos?

## Comparación con IA

Con el PR abierto, pide a la IA el endpoint de inscripción completo y compáralo: validación, manejo de errores, códigos de estado y dónde pone la lógica.

## Recursos

- [Minimal APIs](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/minimal-apis/overview)
- [Documentos OpenAPI en ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/openapi/aspnetcore-openapi)
- [Usar los documentos OpenAPI generados (Swagger UI y Scalar)](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/openapi/using-openapi-documents)
- [Gestión de errores y ProblemDetails](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/error-handling)
- [Ficheros .http](https://learn.microsoft.com/es-es/aspnet/core/test/http-files)
