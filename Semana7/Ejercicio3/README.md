# Ejercicio 3 — API con ASP.NET Core

**Miércoles 21 de octubre · unas 4 h** · Issue: «S7 · Ej3 · API con ASP.NET Core»

## Objetivo

Exponer los casos de uso del dominio en una API REST, con validación, errores bien formados y documentación OpenAPI.

## Pasos

Rama `feature/api`.

### 1. Capa de aplicación (≈ 1 h)

- Proyecto `src/DeemSoft.CourtConnect.Application`: servicios de aplicación (por ejemplo, `RegistrationService`), DTOs de entrada y salida e interfaces de los repositorios.
- Implementa los repositorios en Infrastructure.
- La API **no** devuelve entidades del dominio: devuelve DTOs. ¿Por qué?

### 2. Endpoints (≈ 2 h)

Usa **Minimal APIs** con grupos de endpoints (`MapGroup`). Si prefieres controladores, justifícalo en el PR.

| Método y ruta | Qué hace | Respuestas |
|---|---|---|
| `GET /camps` | Campus abiertos con plazas libres | 200 |
| `GET /camps/{id}` | Detalle de un campus | 200, 404 |
| `POST /camps` | Alta de campus (para pruebas) | 201, 400 |
| `POST /players` | Alta de jugador | 201, 400 |
| `GET /players/{id}` | Detalle de jugador | 200, 404 |
| `POST /camps/{id}/registrations` | Inscribir un jugador | 201, 400, 404, 409 |
| `GET /camps/{id}/registrations` | Inscripciones de un campus | 200, 404 |
| `POST /registrations/{id}/cancel` | Cancelar una inscripción | 204, 404, 409 |

- Las reglas incumplidas (sin plazas, duplicada, fuera de edad, campus cerrado) devuelven **409** o **400** con **ProblemDetails**. Decide cuál en cada caso y anótalo.
- Validación de la entrada (campos obligatorios, longitudes, fechas coherentes).
- Registra con `ILogger` las inscripciones creadas y rechazadas.

### 3. OpenAPI y pruebas manuales (≈ 1 h)

- Activa el documento OpenAPI (en .NET 10, `AddOpenApi` y `MapOpenApi`).
- Crea `src/DeemSoft.CourtConnect.Api/CourtConnect.http` con una petición por endpoint, incluidos los casos de error. Ejecútalas con la extensión REST Client.

## Criterios de aceptación

- [ ] Los 8 endpoints funcionan contra SQL Server en Docker.
- [ ] Ninguna entidad del dominio sale por la API.
- [ ] Errores con ProblemDetails y códigos HTTP coherentes.
- [ ] Fichero `.http` con casos de éxito y de error.
- [ ] Tests unitarios de `RegistrationService` con dobles (mocks o fakes) de los repositorios, que cubran como mínimo:
  - inscripción correcta;
  - cada motivo de rechazo (campus inexistente, jugador inexistente, sin plazas, duplicada, fuera de edad, campus no abierto), mejor con un `[Theory]`;
  - cancelación correcta, de una inscripción inexistente y de una ya cancelada.
- [ ] Tests de los mapeos entre entidades y DTOs.
- [ ] **Calidad:** cobertura ≥ 80 % de Application. Los endpoints se cubren mañana con los tests de integración: el viernes, el código nuevo de la API tiene que llegar también al 80 %. Resto del gate en [`calidad.md`](../../docs/court-connect/calidad.md).

## Extra

- Interfaz visual para OpenAPI (por ejemplo, Scalar).
- Paginación en `GET /camps`.

## Preguntas para la demo

- ¿Qué diferencia hay entre 400, 404 y 409 en tu API?
- ¿Qué pasa por dentro desde que llega `POST /camps/{id}/registrations` hasta que se guarda en la base de datos?
- ¿Por qué DTOs y no entidades?

## Comparación con IA

Con el PR abierto, pide a la IA el endpoint de inscripción completo y compáralo: validación, manejo de errores, códigos de estado y dónde pone la lógica.

## Recursos

- [Minimal APIs](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/minimal-apis/overview)
- [Documentos OpenAPI en ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/openapi/aspnetcore-openapi)
- [Gestión de errores y ProblemDetails](https://learn.microsoft.com/es-es/aspnet/core/fundamentals/error-handling)
- [Ficheros .http](https://learn.microsoft.com/es-es/aspnet/core/test/http-files)
