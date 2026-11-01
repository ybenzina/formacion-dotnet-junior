# Ronda 3: correcciones de las masterclasses

Repo `formacion-dotnet-junior`, rama `docs/masterclass-arquitectura`.

**Reglas.** Sin commit, push ni staging. No toques ningún PowerPoint. Conserva los cambios previos y cambia solo lo que se indica aquí. No toques `masterclass-dotnet-technologies.md` ni su quiz. Mantén el formato actual: lenguaje para un junior, notas con «Qué decir» y «Contexto para Yamel». Código según el `AGENTS.md` de la plantilla (constructores principales en servicios, LINQ con sintaxis de métodos, sin `^` ni `..`) y el `.editorconfig` (tipos explícitos en lugar de `var`; si el tipo es anónimo y `var` es obligatorio, déjalo con un comentario que lo diga).

Al terminar, informa fichero a fichero de qué has cambiado y por qué, y qué no has podido verificar.

## A. Decisiones de Yamel (obligatorias)

### A1. Parte III: worker continuo; el Job es solo una comparación

El ejercicio de despliegue mantiene el proceso de caducidad como el `BackgroundService` de los ejercicios 1 y 2. El Container Apps Job se estudia y se compara en clase, pero no se implementa.

- `reto/Parte3/Ejercicio4/README.md`: quita el apartado 7 («Caducidad en segundo plano», con el Job) y los tres criterios de aceptación añadidos sobre el Job.
  - Sustitúyelos por un apartado breve: la caducidad se despliega como proceso continuo con `minReplicas = 1` y `maxReplicas = 1`, y se justifica por qué (sin ingress y sin mínimo positivo no vuelve a arrancar).
  - Un solo criterio nuevo: mínimos y máximos explícitos de web, API y worker en el README.
  - Extra opcional, sin implementación: comparar con un Job usando la hoja de costes.
  - No añadas trabajo de implementación al Día 22.
- `masterclass-cloud-costes-yamel.md` y el taller de `masterclass-cloud-azure.md`:
  - La base es web + API + worker continuo (mín. 1, máx. 1, 720 h activas). El Job es la alternativa comparada y nunca se suma.
  - Las cifras ya verificadas no cambian; solo se invierten los papeles. Totales base normal: 780 h, 702.000 vCPU-s, 1.404.000 GiB-s. Pico: 786 h, 707.400 vCPU-s, 1.414.800 GiB-s. Alternativa con Job: 132 h y 138 h.
  - Paso 6 del taller: «sustituye el worker por el Job». Ajusta las preguntas de revisión y los criterios.
- `masterclass-cloud-azure.md` (diapositivas de Container Apps, mapa y escalado): worker continuo con mínimo 1 en la práctica; el Job, como alternativa para estudiar.
- `masterclass-cloud-quiz.md`, `masterclass-integrations.md` y su quiz: adapta los textos que presenten el Job como la opción del reto. Mantén la distinción worker continuo / Job.
- Deja intactos `reto/Parte3/Ejercicio1` y `Ejercicio2` y `docs/court-connect/architecture/README.md`.

### A2. IA y agentes: una sola sesión, el D 22/11 por la tarde

| Fecha | Masterclass | Por qué ese día |
| --- | --- | --- |
| D 8/11 | Arquitectura | Mitad del ejercicio 3 |
| D 22/11, mañana | Cloud 1: contenedores, Compose y Aspire | Justo después del ejercicio de Docker (V 20/11) |
| D 22/11, tarde | IA y agentes | Justo antes del ejercicio 5 de la Parte II (L 23/11), donde instala el tutor y crea el revisor |
| D 29/11 | Cloud 2: Azure, IaC y costes | Antes del despliegue (M 1/12) |
| Antes de Àmbit | Seguridad (dos sesiones) e integraciones | Sin fecha |

- `masterclass-ai-agents.md`: una sola sesión de **90 minutos con una pausa de 10 dentro** (la agenda suma 90). Marca como «(prescindible)» los bloques que se pueden quitar para quedar en 60.
- Prioriza lo que Driss necesita para el ejercicio 5. El resto (gobierno entre repos, versionado avanzado…) pasa a una sección «Ampliación opcional», con sus diapositivas aparte, sin fecha o como lectura. Decide tú el corte y justifícalo en una línea por cada diapositiva movida.
- Quiz de IA: 12 preguntas de la sesión más un bloque opcional para la ampliación. Al menos 6 de las 12 deben ser conceptuales (ver B4).
- Diapositiva 20: título neutro «promptops-common (genérico)», sin «DeemSoft» ni «presenta Yamel».
  - Puntos clave: «Presentación reservada; la prepara Yamel».
  - Notas con las dos partes: «Qué decir» para completar por Yamel y «Contexto para Yamel» que la enlace con la diapositiva 13 (evolución futura, no una migración ya hecha).
- Calendario: añade la masterclass de IA en `docs/court-connect/calendario.md`, `reto/Parte2/Anuncios.md`, `reto/Parte2/README.md`, `reto/Parte2/Ejercicio5/README.md` (enlace y aviso «antes de este ejercicio») y `docs/fase2-pendiente.md` (quita los «por concretar»). Revisa también `masterclass-cloud.md`.

## B. Correcciones

### B1. Densidad en pantalla

Máximo **4 términos nuevos en negrita por diapositiva** en pantalla. Parte la diapositiva o mueve los términos secundarios al glosario, sin devolverlos a las notas. Recoloca los minutos de la agenda, sin cambiar los totales. Diapositivas con 5 o más, según la numeración actual:
- arquitectura: 06, 17, 19, 21, 22;
- cloud-local: 02, 03, 08 (hay 10 términos);
- cloud-azure: 03, 07, 08, 09;
- seguridad: 03, 11, 12;
- integraciones: 08.

Integraciones tiene unos 29 términos en 90 min frente a 15 «imprescindibles»: recorta o pasa al glosario.

### B2. Quizzes (los cinco)

- La opción correcta no debe ser la más larga ni la más corta de forma sistemática. Objetivo: como máximo el 35 % de las preguntas de cada quiz con la correcta como más larga única, y otro 35 % como más corta única. Hoy es la más corta en 13 de 24 (seguridad), 7 de 20 (arquitectura), 5 de 12 (integraciones) y 8 de 24 (IA).
- Distractores plausibles y con matices de longitud parecida. Quita los absolutos («cualquier», «todos», «siempre», «únicamente», «garantiza»). En IA, «aunque» aparece en 10 opciones incorrectas y en una sola correcta: reparte o quítalo.
- Mantén las letras repartidas y sin rachas de más de 2.
- Seguridad, pregunta 4: el enunciado dice «su token opaco» y la respuesta D «Lo tratamos como opaco». Cámbialo a «devuelve un token que no es JWT».
- Seguridad: la cabecera del quiz dice «al día siguiente, fuera de clase», pero las diapositivas 10 y 21 dicen «Hacer después las preguntas». Unifica.

### B3. Seguridad (`masterclass-security.md`)

- Diap. 12: añade a las notas qué flujos están desaconsejados. Implicit es «SHOULD NOT» y contraseña directa al cliente (ROPC) es «MUST NOT» según RFC 9700. Code + PKCE también para SPA. PKCE debe usar S256.
- Diap. 18 (RGPD, contexto para Yamel):
  - Edad de consentimiento en España: 14 años (LOPDGDD art. 7, BOE-A-2018-16673). Bajo 14, consentimiento de quien ejerza la patria potestad o tutela.
  - Notificación de brecha a la AEPD: a más tardar en 72 horas.
  - Evaluación de impacto: cita el art. 35 y marca «no verificado en fuente oficial». No afirmes nada de los artículos 6, 8, 9 y 35 que no hayas cotejado con una fuente oficial.
  - Cambia el comentario residual sobre «extracción automática» (línea ~384) por «no verificado».
- Diap. 20: la frase «los cuatro controles JWT» no se explica. Enuméralos (iss, aud, firma, exp) en una diapositiva anterior y añade `alg` en las notas.
- Diap. 8: la nota «los endpoints personalizados no heredan protección por llamarse desde Blazor» es imprecisa. Matiza: los Minimal APIs que reciben formularios exigen antiforgery por defecto, `app.UseAntiforgery()` es necesario en Blazor, y los que reciben JSON con cookie sí necesitan revisión. Fuente: Microsoft Learn, «Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core».
- Diap. 17: añade el aviso sobre navegaciones requeridas (un filtro puede filtrar también al padre) y que `IgnoreQueryFilters` desactiva todos los filtros nombrados.
- Términos que hoy solo están en notas o faltan: proveedor de identidad (11), HttpOnly/Secure/SameSite y refresh token (2), `MapIdentityApi` (3), MFA (13), RGPD expandido y «base jurídica» (18), B2B (14). Explícalos en pantalla respetando el máximo de B1.
- `var`: en la diap. 9 usa `List<string>` (o el tipo que corresponda) en lugar de `var contacts`. En la diap. 7, `var games` es anónimo: déjalo con un comentario. Usa `ILogger<Program>` en lugar de `ILogger<TrainingDbContext>`.

### B4. IA y agentes (`masterclass-ai-agents.md` y su quiz)

- **Define «agente»**, porque el ejercicio 5 lo pregunta. Anthropic distingue workflow (LLM y herramientas orquestados por rutas de código predefinidas) de agente (el LLM dirige dinámicamente su proceso y sus herramientas) y recomienda la solución más simple posible. Fuente: anthropic.com/engineering/building-effective-agents. Explica también qué es una herramienta y enlaza MCP con `masterclass-dotnet-technologies.md`.
- Diap. 4 y 10 («no edita archivos ni ejecuta comandos»): solo es cierto para el agente de Copilot (`tools: [read, search]`). El skill de Claude no impone esa restricción: `allowed-tools` solo preaprueba herramientas. Dilo así, y menciona los hooks `PreToolUse` como mecanismo para bloquear. Fuente: documentación de Claude Code, apartados de skills y memory.
- Solapamiento con el ejercicio 5: ese ejercicio pide investigar «sin mirar la referencia» y ejecutar T1, T3, T4 y T7. Las diapositivas 10 a 14 enseñan esos mismos casos. Demuestra con T2, T6 y T10, o solo con el revisor.
- Línea 5: quita la mención a Àmbit (el repo es público y `AGENTS.md` prohíbe datos de clientes reales).
- Diap. 3: explica por qué existe `CLAUDE.md` (con `CLAUDE.md`, Claude Code lee solo ese, y `AGENTS.md` entra con `@AGENTS.md`). **Verifica en code.claude.com/docs/en/memory antes de incluirlo.**
- Quiz: al menos 6 de las 12 preguntas conceptuales: agente frente a asistente y workflow, herramienta, MCP, instrucción de texto frente a permiso real.

### B5. Integraciones (`masterclass-integrations.md` y su quiz)

- Diap. 08: `await using AsyncServiceScope scope = ...` e `IOutboxDispatcher dispatcher = ...` (tipos explícitos). Menciona el `using Microsoft.Extensions.DependencyInjection;` que omite el fragmento.
- Diap. 07: el enlace llamado «Explicación oficial del patrón outbox» solo dedica una frase al outbox. Llámalo «mención oficial» o cambia la fuente.
- Diap. 04: añade los valores por defecto del handler estándar solo si los verificas en Microsoft Learn («Build resilient HTTP apps»), marcados «valores por defecto a fecha 31/10/2026; comprobar al instalar». Nombra `Retry.ShouldRetryAfterHeader` (el `Retry-After` no se respeta solo) y aclara que `DisableForUnsafeHttpMethods` deja reintentando los GET.
- Diap. 09: matiza «necesita otra estrategia» por «conviene valorar». Añade que un Job puede interrumpirse por mantenimiento, que existe `replicaRetryLimit` y que Microsoft recomienda diseñar para at-least-once: es el caso de outbox e idempotencia. Fuente: Container Apps Jobs.
- Diap. 06: aclara que el Idempotency-Key de la IETF es un borrador (no un RFC) y que manda el contrato del proveedor.
- Diap. 03: el texto «no compartir usuarios» confunde. Cámbialo por «reutilizamos conexiones, no estado de una petición».
- Define en pantalla, antes de usarlos: `pool`, `DbContext`, hosted service, Job.

### B6. Fechas residuales

`reto/Parte1/Ejercicio2/README.md:144` conserva «el 22/11»: sustitúyelo por referencia relativa (criterio actual: fechas absolutas solo en `calendario.md` y los anuncios).

## C. Verificación al terminar

1. Si hay SDK de .NET 10 en el equipo, compila todos los fragmentos de C# de las masterclasses en un proyecto temporal **fuera del repo** (por ejemplo en `%TEMP%`) y no guardes nada en el repo. Informa de errores. Si no hay SDK, dilo.
2. Repite: enlaces y anclas internos, agendas (suman lo declarado), numeración de diapositivas, términos en negrita por diapositiva (máximo 4), estadísticas de los quizzes (B2), restos de «por concretar», y que ningún texto presente el Job como requisito del reto.
3. Informa de lo que sigue sin verificar: precios, API de Holded, texto oficial del RGPD.
