# Ejercicio 2 — Cuentas, login y roles

**Días 11 y 12 · estimación: 7 h** · Issue: «P2 · Ej2 · Cuentas, login y roles»

## Objetivo

Que cada jugador tenga su cuenta y que **quién eres lo diga la sesión, no la petición**. Hasta ahora cualquiera podía apuntar a cualquier jugador poniendo su `Id` en el cuerpo: eso se acaba hoy.

Es el ejercicio más difícil del reto. Si te atascas más de una hora en el mismo punto, pregunta en Discord.

## Antes de empezar (≈ 1 h)

Conceptos nuevos (añádelos al glosario): **autenticación** frente a **autorización**, **ASP.NET Core Identity**, **token de portador** (*bearer token*), **cookie de autenticación**, **claim**, **rol**, **política de autorización**, **401 frente a 403** e **IDOR** (*insecure direct object reference*).

Lecturas:

- [Uso de Identity para proteger un back-end de API web](https://learn.microsoft.com/es-es/aspnet/core/security/authentication/identity-api-authorization): `AddIdentityApiEndpoints` y `MapIdentityApi`.
- [Autorización basada en roles](https://learn.microsoft.com/es-es/aspnet/core/security/authorization/roles) y [basada en políticas](https://learn.microsoft.com/es-es/aspnet/core/security/authorization/policies).
- [OWASP: Broken Access Control](https://owasp.org/Top10/A01_2021-Broken_Access_Control/): el riesgo número 1 de las aplicaciones web, y el que evitan R7 y R8.

## Pasos

Rama `feature/identidad`.

### 1. Identity en la API (≈ 2 h)

- Identity con EF Core sobre tu `CourtConnectDbContext` (o uno propio, decide y justifícalo), con roles: `Organizer` y `Player`.
- `MapIdentityApi` para registrarse y entrar. Fíjate en qué devuelve `/login`.
- Una cuenta corresponde a un jugador: al registrarse, el jugador completa su perfil (apodo, nombre, fecha de nacimiento) con un endpoint como `POST /players/me`. El jugador guarda el `Id` de su cuenta.
- Datos de prueba: un organizador y varios jugadores, con contraseñas **solo** en los secretos de usuario o en el código de *seeding* de desarrollo, nunca en `appsettings.json`.

### 2. Proteger la API (≈ 2 h)

- Los endpoints de consulta pública (`GET /games`, `GET /games/{id}`) siguen abiertos. Todo lo demás exige estar autenticado.
- Los de gestión (canchas y partidos) exigen el rol `Organizer`, con una **política**.
- `POST /games/{id}/registrations` ya **no** recibe el jugador en el cuerpo: lo saca del usuario autenticado.
- Reglas nuevas, **en el dominio o en la aplicación** (decide y justifícalo), no solo en el endpoint:
  - **R7:** solo el organizador de un partido puede modificarlo, abrirlo o cerrarlo. El partido guarda quién lo organiza.
  - **R8:** un jugador solo se apunta a sí mismo y solo cancela sus propias inscripciones.
- Decide qué devuelves cuando alguien intenta cancelar la inscripción de otro: ¿403 o 404? Anótalo en el PR con el motivo.

### 3. Login en la web (≈ 2 h)

- Páginas de registro y de login (Static SSR). La web llama a la API para entrar y guarda la sesión en una **cookie** de la propia web.
- Un `DelegatingHandler` añade el token a cada llamada del `HttpClient` tipado. Así ninguna página tiene que acordarse de hacerlo.
- El formulario de apuntarse deja de mostrar la lista de jugadores: apunta al usuario de la sesión.
- Ojo: en las páginas Static SSR hay una petición HTTP por página y puedes leer la sesión de ella. En las interactivas del ejercicio 3 **no** (no hay una petición por cada clic). Lee ya [Escenarios de seguridad adicionales de Blazor del lado del servidor](https://learn.microsoft.com/es-es/aspnet/core/blazor/security/additional-scenarios), el apartado sobre pasar tokens, porque mañana lo necesitas.

### 4. Tests (≈ 1 h)

- Integración: un método auxiliar que registra un usuario, entra y devuelve un `HttpClient` autenticado.
- Casos mínimos: sin token → 401; jugador en un endpoint de organizador → 403; apuntarse a sí mismo → 201; cancelar la inscripción de otro → el código que decidiste; un organizador que abre el partido de otro → rechazado (R7).
- Unitarios de R7 y R8 donde las hayas puesto.

## Criterios de aceptación

- [ ] Registro, login y cierre de sesión desde la web.
- [ ] Ningún endpoint que modifique datos acepta peticiones anónimas.
- [ ] El jugador nunca viaja en el cuerpo de la petición: sale de la sesión.
- [ ] R7 y R8 implementadas y probadas, también con tests de integración.
- [ ] Ninguna contraseña ni clave en el repositorio.
- [ ] **Calidad:** gate superado; revisa con atención los security hotspots de este PR.

## Extra

- Renovar el token cuando caduca (`/refresh`).
- Entrar con Google, Microsoft o Facebook: investiga cómo encajaría con esta arquitectura y escríbelo en el PR. Implementarlo solo si sobra tiempo.

## Preguntas para la demo

- ¿Qué diferencia hay entre autenticación y autorización? Pon un ejemplo de cada una en tu código.
- Antes de este ejercicio, ¿cómo podía alguien cancelar la inscripción de otro jugador? ¿Qué es un IDOR y dónde lo has evitado?
- ¿Por qué R8 no basta con comprobarla en la web?
- ¿Dónde vive el token cuando estás usando la web, y quién lo envía a la API?
- ¿Cuándo devuelves 401 y cuándo 403?

## Comparación con IA

Pide a la IA la protección de `POST /registrations/{id}/cancel` y compárala con la tuya. ¿Comprueba el dueño de la inscripción o solo que el usuario esté autenticado?

## Recursos

- [Identity en ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/security/authentication/identity)
- [Identity para API web (`MapIdentityApi`)](https://learn.microsoft.com/es-es/aspnet/core/security/authentication/identity-api-authorization)
- [Autenticación y autorización en Blazor](https://learn.microsoft.com/es-es/aspnet/core/blazor/security/)
- [OWASP Top 10](https://owasp.org/Top10/)
