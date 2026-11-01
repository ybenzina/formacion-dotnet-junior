# Seguridad en 15 minutos

**Lectura previa al ejercicio de cuentas, login y roles.** Dedica 10 minutos a leer y 5 a explicarlo con tus palabras. La masterclass de seguridad completa queda para antes de empezar con Àmbit.

## 1. Autenticación frente a autorización

- **Autenticación: «¿quién eres?»** Comprobar la identidad. Ejemplo: entrar con tu cuenta y contraseña.
- **Autorización: «¿puedes hacer esto?»** Comprobar permisos para una acción concreta. Haber entrado no permite modificar cualquier partido.

En una API, **401** suele indicar que falta una autenticación válida; **403**, que el usuario está identificado pero no tiene permiso. Ocultar un botón no protege la API: el servidor debe comprobar el acceso.

## 2. Cookie frente a token

- **Cookie de autenticación:** dato de sesión que el navegador guarda y envía automáticamente a las peticiones que correspondan según sus reglas. Evita volver a escribir la contraseña en cada página.
- **Token de acceso:** credencial que presenta un cliente para llamar a una API. Si es **bearer** (de portador), quien lo posee puede usarlo mientras sea válido. Se envía en la cabecera `Authorization: Bearer <token>`.

No son alternativas excluyentes: una cookie es un mecanismo del navegador; un token es una credencial. En este reto, **navegador → web: cookie propia; web → API: token**. El servidor web hace la llamada a la API.

Ambos deben protegerse: usa HTTPS y no pegues cookies ni tokens reales en repositorios, logs o herramientas externas.

## 3. JWT no significa cualquier token

**ASP.NET Core Identity** gestiona cuentas y contraseñas. `MapIdentityApi` publica sus operaciones de registro y login.

- **JWT (JSON Web Token):** formato estándar para transportar datos sobre una identidad. Un JWT firmado suele tener tres partes: cabecera, datos y firma. La firma permite detectar cambios; **no oculta los datos**. Leerlo no demuestra que sea válido: hay que comprobar firma, emisor, destinatario y caducidad.
- **Token opaco de `MapIdentityApi`:** cuando el login devuelve tokens, usa un formato propio protegido por ASP.NET Core, **no JWT**. Para el cliente es una cadena que guarda y presenta sin interpretar. Lo valida el mecanismo de Identity, no un lector de JWT. También puede emitir cookies, según el modo de login.

**Bearer describe cómo se usa la credencial, no su formato:** tanto un JWT como un token opaco pueden ser bearer.

## 4. Claims, roles y políticas

- **Claim:** dato sobre una identidad, como su identificador de cuenta. Se usa después de validar la autenticación; no se confía en un dato solo porque venga del cliente.
- **Rol:** categoría de usuario, como `Player` u `Organizer`. En ASP.NET Core se representa mediante claims de rol.
- **Política de autorización:** conjunto de condiciones que se comprueban para permitir una acción. Puede exigir un rol, un claim o una comprobación más específica.

Piensa en una acreditación: el claim identifica a la persona, el rol indica su función y la política decide si puede entrar. El rol no demuestra por sí solo que un recurso le pertenezca.

## Repaso sin código

1. ¿Estar autenticado permite cancelar cualquier inscripción?
2. ¿Todo token enviado como bearer es un JWT?
3. ¿Qué diferencia hay entre un dato de identidad y una condición de acceso?

**Referencia:** [Identity para API web, cookies y tokens (.NET 10)](https://learn.microsoft.com/es-es/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-10.0).
