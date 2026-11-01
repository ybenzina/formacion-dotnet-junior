# Quiz de seguridad e identidad

Al día siguiente de cada sesión de la [masterclass](masterclass-security.md), responde sus 12 preguntas en 15 minutos fuera de clase. Una respuesta correcta por pregunta. Explica las dudas antes de consultar las soluciones. Referencia de autoevaluación: 9/12 en cada bloque.

## Sesión 1: Fundamentos

### 1. Un usuario entra correctamente. ¿Qué demuestra?

- A) Que se ha comprobado su identidad, no el permiso sobre cada partido.
- B) Que puede consultar el partido enlazado desde la pantalla de entrada.
- C) Que el rol de su sesión acredita también el vínculo con el partido solicitado.
- D) Que basta ocultar en la web las acciones que su cuenta no deba realizar.

### 2. ¿Qué significa bearer token?

- A) Que su formato debe incluir una cabecera y un payload legibles.
- B) Que está ligado al equipo que lo recibió, incluso si alguien lo copia.
- C) Que quien lo posee puede presentarlo mientras conserve su validez.
- D) Que la API debe consultar al emisor en cada petición para aceptarlo.

### 3. ¿Por qué no ponemos secretos en un JWT firmado habitual?

- A) Porque HTTPS protege el token, pero la firma elimina su caducidad.
- B) Porque la firma protege integridad, pero no oculta los datos incluidos.
- C) Porque solo el emisor puede leer los datos y la API perdería acceso.
- D) Porque cambiar los permisos exige incluir los secretos en el nuevo token.

### 4. El login integrado de Identity devuelve un token que no es JWT. ¿Qué hacemos?

- A) Configuramos JWT bearer porque se presenta mediante la cabecera Bearer.
- B) Leemos sus campos como JWT y comprobamos solo la fecha de caducidad.
- C) Convertimos la cadena a JSON antes de entregarla al validador estándar JWT.
- D) Lo tratamos como opaco y dejamos su validación al mecanismo de Identity.

### 5. ¿Qué aporta una policy de autorización?

- A) Una regla que concede acceso por tipo de objeto, sin revisar su identidad.
- B) Una configuración visual para ocultar controles según el usuario.
- C) Un conjunto de condiciones de acceso, ampliable con controles sobre el recurso.
- D) Una validación de identidad que sustituye las reglas por recurso.

### 6. ¿Para qué sirve el salt de una contraseña?

- A) Para que contraseñas iguales generen hashes distintos con salts diferentes.
- B) Para recuperar la contraseña usando un valor guardado junto con el hash.
- C) Para que un hash rápido sea suficiente aunque se filtre la base completa.
- D) Para impedir validar una contraseña sin contactar con el servidor original.

### 7. ¿Qué describe un IDOR?

- A) Consultar un recurso propio mediante un identificador numérico predecible.
- B) Consultar un objeto ajeno cambiando su ID sin validar el permiso en el servidor.
- C) Intentar acceder a un objeto inexistente y recibir una respuesta 404.
- D) Mostrar el ID de un objeto público en la respuesta, sin que revele información privada.

### 8. ¿Qué afirmación sobre EF Core es correcta?

- A) Parametriza valores LINQ traducidos; el SQL manual y los permisos exigen revisión.
- B) Convierte texto concatenado en FromSqlRaw en parámetros de consulta seguros.
- C) Añade la identidad autenticada a las consultas LINQ traducidas para limitar sus resultados.
- D) Protege columnas y tablas variables igual que los valores de un parámetro.

### 9. ¿Qué deberíamos registrar al denegar un acceso?

- A) Cuerpo completo y cabeceras para reconstruir la petición, restringiendo los logs al equipo de soporte.
- B) Solo el código 403, sin acción ni referencia que permita investigar el caso.
- C) Nombre y ficha del afectado, para evitar búsquedas durante la investigación.
- D) Acción, resultado e IDs mínimos útiles, con acceso y conservación controlados.

### 10. ¿Qué aprovecha un CSRF?

- A) Que un texto de usuario se renderiza como código dentro de la página.
- B) Que el servidor concatena valores recibidos dentro de una consulta SQL.
- C) Que el navegador envía la sesión al ejecutar una petición inducida desde otro sitio.
- D) Que el cliente acepta un certificado HTTPS emitido por otra organización.

### 11. ¿Qué riesgo añade renderizar HTML ajeno con `MarkupString`?

- A) Desactivar la comprobación de permisos del endpoint al interpretar el HTML devuelto como contenido fiable.
- B) Permitir SQL injection aunque la consulta que obtiene el HTML esté parametrizada.
- C) Evitar la codificación del texto y permitir XSS al renderizar contenido no fiable.
- D) Eliminar automáticamente los atributos HttpOnly y Secure de las cookies.

### 12. ¿Qué demuestra mejor una corrección de autorización?

- A) Que el botón desaparece para quien no tiene permiso, sin probar la API.
- B) Que rechaza accesos indebidos y conserva el acceso que sí está permitido.
- C) Que los casos negativos devuelven 403, sin probar también un caso permitido.
- D) Que un usuario autorizado recibe 200, sin cambiar de identidad ni recurso.

## Sesión 2: Identidad y privacidad

### 13. ¿Cómo se relacionan OAuth 2.0 y OIDC?

- A) OAuth identifica al usuario; OIDC añade permisos sobre objetos del negocio.
- B) Ambos son formatos de token; OAuth usa firma para acceso y OIDC añade cifrado para identificar al usuario.
- C) OIDC sustituye OAuth cuando una aplicación necesita llamar a otra API.
- D) OAuth trata acceso autorizado; OIDC añade identidad para la aplicación cliente.

### 14. ¿Para qué sirve PKCE?

- A) Para vincular el canje del código al cliente que conserva el verifier inicial.
- B) Para cifrar el access token durante todo su almacenamiento en el cliente.
- C) Para validar el permiso del usuario sobre cada recurso solicitado a la API.
- D) Para aceptar retornos variables si el cliente demuestra que conserva el verifier del flujo original.

### 15. ¿Qué token debe recibir una API protegida?

- A) El ID token de la web, si identifica al mismo usuario que llama.
- B) Un access token de otra API, si procede del mismo directorio.
- C) Un access token destinado a ella, validado con sus controles.
- D) El refresh token de la sesión, si todavía permite renovar el acceso.

### 16. Una persona tiene el app role de coordinador. ¿Qué falta?

- A) Aceptar la escuela seleccionada, porque el rol permite coordinar.
- B) Comprobar qué acciones y escuelas tiene asignadas esa persona en el servidor.
- C) Dar acceso a las escuelas asociadas al dominio de su correo verificado.
- D) Aplicar el rol solo en la web y confiar en sus llamadas a la API.

### 17. ¿Qué comparación sobre email OTP es correcta?

- A) External ID documenta esa opción; con Identity hay que diseñar e integrar el flujo.
- B) Confirmar un correo con Identity habilita automáticamente el login sin contraseña.
- C) MapIdentityApi incorpora el mismo flujo OTP y los protocolos de un external tenant.
- D) External ID resuelve además el vínculo legal entre el buzón y cada menor asociado.

### 18. La firma de un JWT es válida, pero su audience es otra API. ¿Qué hacer?

- A) Aceptarlo si el issuer es el mismo que usa esta aplicación.
- B) Aceptarlo si el rol que contiene coincide con la policy.
- C) Aceptarlo si la otra API pertenece a la misma organización.
- D) Rechazarlo porque no está destinado a la API receptora.

### 19. ¿Qué evalúa resource-based authorization?

- A) El rol y la autenticación, sin cargar ni identificar el objeto.
- B) La identidad, la acción solicitada y el objeto concreto.
- C) El endpoint y el formato del ID, sin comprobar asignaciones.
- D) La sesión y el origen de la web, sin evaluar el dato pedido.

### 20. ¿Qué aporta por sí solo un global query filter?

- A) Que ninguna escritura puede asignar datos a una sociedad distinta.
- B) Que la sociedad recibida desde el navegador pertenece al usuario.
- C) Una condición habitual de consulta, no el control completo de permisos.
- D) Que el filtro se mantiene incluso al usar IgnoreQueryFilters.

### 21. ¿Qué propuesta respeta mejor la minimización?

- A) Mostrar los campos necesarios a personal autorizado y evitar copias locales.
- B) Ocultar campos tras descargar a la web las fichas completas.
- C) Permitir exportaciones completas mientras el usuario tenga un rol del personal.
- D) Conservar los datos completos en logs para compensar su ausencia en pantalla.

### 22. ¿Qué cubre el contrato de encargado del tratamiento?

- A) La base jurídica de los tratamientos futuros elegidos por el proveedor.
- B) Instrucciones, obligaciones y garantías al tratar datos por cuenta ajena.
- C) La autorización para conservar copias al terminar el servicio contratado.
- D) Las medidas técnicas suficientes para excluir toda revisión de privacidad.

### 23. ¿Qué sustituye una managed identity de la API?

- A) Las comprobaciones de recurso, porque Azure ya autoriza el acceso a SQL.
- B) El login de cada familia, porque la API dispone de una identidad propia.
- C) Las asignaciones por escuela, si la identidad tiene acceso al Key Vault.
- D) Ciertas credenciales técnicas, no los permisos funcionales sobre los datos.

### 24. ¿Qué resultado debe salir del taller de Àmbit?

- A) Un proveedor aprobado a partir de comparar sus pantallas de entrada.
- B) Flujos, permisos, pruebas y dudas pendientes, sin dar decisiones por aprobadas.
- C) Un login dibujado y la suposición de que los roles ya delimitan las escuelas.
- D) Una elección técnica cerrada que deje privacidad para después de implementar.

## Soluciones razonadas

| Nº | Respuesta | Por qué |
| --- | --- | --- |
| 1 | A | Identidad comprobada no equivale a permiso sobre cualquier dato. |
| 2 | C | Bearer describe posesión y uso; no fija formato ni vincula por sí solo el token al equipo. |
| 3 | B | La firma protege integridad, no confidencialidad del payload. |
| 4 | D | El formato propio no es JWT; enviarlo como bearer no cambia su formato ni validador. |
| 5 | C | La policy agrupa requisitos; el acceso al recurso puede añadir condiciones. |
| 6 | A | El salt diversifica hashes; no cifra ni sustituye una función de contraseña costosa. |
| 7 | B | El fallo es omitir el permiso sobre el objeto, incluso si su ID es un GUID. |
| 8 | A | Parametrización y autorización son controles distintos; tablas y columnas no son valores parametrizables. |
| 9 | D | La auditoría necesita información útil pero mínima, con sus propios límites de acceso y retención. |
| 10 | C | El envío automático de sesión permite inducir acciones sin la intención del usuario. |
| 11 | C | Tratar datos como HTML evita una protección del renderizado de texto; no cambia las cookies ni SQL. |
| 12 | B | Una prueba positiva detecta una falsa solución que bloquea todo; las negativas comprueban el límite. |
| 13 | D | OIDC construye la identificación sobre mecanismos de OAuth, no define permisos de negocio. |
| 14 | A | PKCE exige demostrar que se conserva el verifier del flujo inicial. |
| 15 | C | Un ID token identifica al usuario ante el cliente; el refresh token renueva acceso, no sirve para la API. |
| 16 | B | La función del empleado no define automáticamente el alcance de sus datos. |
| 17 | A | Confirmación de correo no equivale a login OTP; el vínculo con un menor exige controles propios. |
| 18 | D | Una firma válida no corrige un destinatario incorrecto. |
| 19 | B | La decisión depende del objeto y la acción, además de la identidad. |
| 20 | C | Puede haber caminos que omiten filtros y escrituras que requieren validaciones propias. |
| 21 | A | Minimizar afecta campos, personas autorizadas y copias; ocultar después de descargar no limita la entrega. |
| 22 | B | El contrato articula obligaciones; no reemplaza permisos, medidas ni base jurídica. |
| 23 | D | La identidad técnica abre recursos cloud; la autorización funcional limita datos de personas. |
| 24 | B | El taller prepara una decisión informada y verificable, no la aprueba. |
