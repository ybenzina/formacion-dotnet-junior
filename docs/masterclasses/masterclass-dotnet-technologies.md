# Masterclass .NET Technologies — overview del ecosistema, la forma de trabajar, la IA y el reto CourtConnect

**Duración:** unas 2 horas, con las demos. **Cuándo:** al arrancar el reto, después del Día 0.
**Material:** `masterclass-dotnet-technologies.pptx` (44 diapositivas, con notas para el ponente) y `masterclass-dotnet-technologies-quiz.md`. Las diapositivas de contenido se muestran clic a clic; las de demo, enteras, con los pasos y «Qué observar» (la preparación está en sus notas).

Este guion Markdown separa **Qué decir** de **Contexto para Yamel** por bloque y demo. Es apoyo para preparar la sesión; no actualiza las notas del PowerPoint existente.

Es una masterclass de **visión general**: un mapa de lo que hay y de cómo vamos a trabajar. Cada bloque se desarrolla después en una masterclass específica (arquitectura; contenedores, Aspire y Azure; IA) o en los ejercicios del reto.

## 🎯 Objetivos

- Comprender la evolución del ecosistema .NET y su estado actual (.NET 10, LTS y STS).
- Conocer las herramientas del día a día: VS Code (o Visual Studio), Docker, SQL Server y GitHub.
- Entender el flujo de trabajo del equipo: ramas cortas, Pull Request, CI/CD y SonarQube Cloud.
- Usar la IA con criterio: tokens, prompts efectivos y una primera idea de agentes, MCP, RAG y SDD.
- Situar el reto CourtConnect: partes, dominio, arquitectura (adelanto) y qué hacer el Día 1.

## 🧩 Agenda

| Bloque | Tiempo | Diapositivas |
| --- | --- | --- |
| Apertura: objetivos, contenidos y demos planificadas | 5 min | 1–4 |
| 1. Historia .NET y visión general (con demo 1) | 20 min | 5–11 |
| 2. Metodologías, herramientas y entornos (con demos 2–4) | 35 min | 12–21 |
| 3. Desarrollo asistido por IA (con demo 5) | 25 min | 22–28 |
| 4. Reto CourtConnect (con demo 6) y cierre | 35 min | 29–44 |

### 1. Historia .NET y visión general

- De **.NET Framework** (2002, solo Windows) a **.NET Core** (2016, multiplataforma), **.NET 5** (2020, plataforma unificada) y **.NET 10** (2025).
- **Versiones y soporte:** una versión cada noviembre; las pares son **LTS** (soporte prolongado, 3 años) y las impares **STS** (soporte estándar, 2 años). .NET 8 y .NET 9 terminan soporte el 10/11/2026; .NET 10 lo tiene hasta el 14/11/2028. **.NET 11** se lanza en **.NET Conf 2026 (10–13 de noviembre)**. En proyectos de cliente, LTS. El reto usa .NET 10 en las partes I y II y empieza la Parte III migrando a .NET 11.
- **SDK:** herramientas para construir y probar; **runtime:** entorno que ejecuta la aplicación. **API:** operaciones que un programa ofrece a otro; **ORM:** mapea objetos y datos relacionales, como EF Core.
- **Ecosistema:**
  - Web y APIs: ASP.NET Core (Minimal APIs, controladores, MVC, Razor Pages) y Blazor (Static SSR, Server, WebAssembly). Legacy: WebForms, jQuery.
  - Comunicaciones: APIs REST y gRPC. Legacy: WCF / SOAP.
  - Datos: Entity Framework Core (ORM); ADO.NET y Dapper para SQL a mano.
  - Multiplataforma: .NET MAUI y MAUI Blazor Hybrid. (Xamarin no tiene soporte desde mayo de 2024.)
- **Despliegue:** on-premise (IIS, Windows Server) frente a cloud: App Service (PaaS), **Azure Container Apps** (lo que usará el reto, con Azure SQL) y AKS solo si hace falta Kubernetes.
- **Demo 1 · Azure:** recorrido por el portal (grupo de recursos, Container Apps, Azure SQL, Key Vault y costes).

**Notas del ponente:**

**Qué decir:** «.NET es una plataforma para construir aplicaciones. El lenguaje, las bibliotecas y el lugar donde las ejecutamos son decisiones distintas. Hoy ubicamos las piezas; no necesitas dominar todos los nombres».

**Contexto para Yamel:** Diferenciar SDK, herramientas para construir, y runtime, entorno para ejecutar. Mostrar el recorrido web, API y SQL sin instalar cada alternativa. Antes de impartir la sesión, volver a verificar soporte y fechas de versiones en las fuentes oficiales del final; no presentar una versión prevista como ya publicada. La elección del reto no implica elegir el mismo despliegue para cualquier proyecto.

### 2. Metodologías, herramientas y entornos

- Ciclo de vida del software y **Scrum** en breve (roles, sprints, backlog, reuniones).
- **Nuestro flujo de ramas:** ramas cortas (`feature/`, `fix/`, `docs/`) y **PR** con «Qué / Por qué / Cómo se ha comprobado / Uso de IA», revisión y *merge*.
  - Mientras no hay nada en producción, las ramas van directas a `main` (así empieza el reto).
  - Con código en producción se separa el desarrollo en curso de lo productivo: `feature/` → `develop` (integración de la iteración) → `main` (producción, versiones etiquetadas). Es un Git flow simplificado; los nombres pueden variar (`integration` en lugar de `develop`).
- **CI/CD con GitHub Actions:** cada PR y cada push a las ramas principales (`main` y, con código en producción, `develop`) → restore, build, test y análisis. SDK fijado con `global.json`. Secretos en GitHub, nunca en el YAML. Despliegue a Container Apps en la Parte III.
- **PR:** propuesta de cambio para revisar; **CI:** comprobaciones automáticas de integración; **CD:** entrega o despliegue automatizado. Un **quality gate** es un conjunto de umbrales de calidad que puede bloquear el cambio.
- **Calidad con SonarQube Cloud** (antes SonarCloud): quality gate *Sonar way*, solo sobre código nuevo, **bloqueante** y con **dos checks** (el job de la CI y `SonarCloud Code Analysis`). SonarQube for IDE (antes SonarLint) en el editor. Detalle: `docs/court-connect/calidad.md`.
- **Seguridad y datos desde el primer día:** secretos fuera del repo (user-secrets, secretos de GitHub, Key Vault), datos ficticios y mínimos, autorización en el servidor (R7 y R8), dependencias sin vulnerabilidades, logs sin datos personales y revisión del código generado por IA. Son los riesgos del PR trampa del final.
- **Herramientas:** VS Code con C# Dev Kit y las extensiones recomendadas (Visual Studio como alternativa), Docker Desktop, SQL Server (extensión mssql o SSMS) y GitHub.
- **Contenedor:** ejecución aislada de una aplicación con sus dependencias. **Autorización:** decidir si una persona puede realizar una acción sobre un dato; no basta con que haya iniciado sesión.
- **Demos 2, 3 y 4:** GitHub Actions (después de CI/CD), SonarQube Cloud (después de Calidad) y VS Code con SQL Server en Docker (después de Herramientas).

**Notas del ponente:**

**Qué decir:** «Un PR es una propuesta de cambio que otra persona revisa. La CI ejecuta comprobaciones repetibles. Que compile no demuestra que haga lo correcto ni sustituye la revisión».

**Contexto para Yamel:** Mostrar un cambio desde su issue hasta la revisión, distinguiendo los dos checks del reto. Explicar por qué el flujo de ramas cambia cuando hay una versión en producción, sin convertirlo en una regla universal. La seguridad aparece desde el primer ejercicio; enlazar la [lectura breve](../court-connect/seguridad-en-15-minutos.md). La [masterclass 0 de seguridad](masterclass-security.md) profundiza después del reto y antes de Àmbit; no retrasa esas prácticas básicas.

### 3. Desarrollo asistido por IA

- **Cómo la usamos en el reto:** `AGENTS.md` como fuente única (Claude y Copilot), **modo tutor**, «primero tú, después la IA», sección «Uso de IA» en cada PR, sin secretos ni datos reales. Excepción: la Parte III (SDD).
- **Tokens y ventana de contexto:** qué es un token, qué «ve» el modelo en cada petición, por qué se paga por tokens y cómo ver el consumo (`/cost` en Claude Code; peticiones premium en Copilot).
- **Token:** unidad de texto procesada; **ventana de contexto:** información que puede considerar; **prompt:** petición con instrucciones y contexto. **Agente:** rol que usa herramientas dentro de permisos definidos.
- **Prompts efectivos:** contexto, tarea, restricciones, formato de salida, criterio de terminado; pedir un plan antes del código; iterar.
- **Agentes, MCP y RAG**, lo justo para el reto. La [masterclass de IA y agentes](masterclass-ai-agents.md) desarrolla agentes, pruebas y gobierno; MCP y RAG quedan aquí como referencias introductorias.
- **MCP:** protocolo de conexión con herramientas y contexto; **RAG:** recuperar información para apoyar una respuesta. Ninguno garantiza que la respuesta sea correcta.
- **Demo 5 · IA:** pedir a la IA un prompt, revisarlo, ejecutarlo y ver el consumo (después de los prompts efectivos).
- **SDD**, desarrollo dirigido por una especificación acordada, con GitHub Spec Kit: constitución → especificación → aclaraciones → plan → tareas → implementación. Se usa en la Parte III y sirve de piloto para decidir cómo trabajar con IA en proyectos reales.

**Notas del ponente:**

**Qué decir:** «La IA puede ayudar a entender una duda y también equivocarse con seguridad. Primero explicas lo que intentas, después pides una pista y compruebas el resultado. En SDD tu responsabilidad pasa por especificar y revisar lo generado».

**Contexto para Yamel:** Token: unidad de texto procesada. MCP: protocolo para conectar herramientas y fuentes de contexto; no concede por sí solo permisos seguros. RAG: recuperar información relevante para apoyar la generación; no elimina errores. No prometer que el modelo ha leído todo el repositorio. Pantallas de consumo, cuotas, precios y modelos disponibles: **por verificar** en la herramienta actual. La clase específica usa los artefactos reales de [ai/](../../ai/README.md); no anticipar la referencia del tutor antes de que Driss conserve su diseño propio.

### 4. Reto CourtConnect

- **Qué es y para qué:** una aplicación para quedar a jugar a baloncesto callejero; el objetivo es tocar a mano las piezas de una aplicación .NET actual para poder entender y supervisar el código que genere una IA. 23 días de unas 4 h en tres partes, en el repo público `DeemSoft/court-connect`.
- **Mapa:** Día 0; Parte I (días 1–8), Parte II (9–16) y Parte III (17–23), cada una con su demo. Plan en días relativos (`docs/court-connect/calendario.md`).
- **Dónde está cada cosa:** el repo de formación (curso, enunciados del reto, material), el repo `court-connect` (código, issues, PR, `domain.md`, glosario y retro) y Discord (anuncios, avisos de PR, dudas). Lo que vale la pena conservar va al repo por PR.
- **Cómo trabajas cada ejercicio:** prepara («Antes de empezar» y glosario) → issue con estimación → rama → primero tú → PR con «Uso de IA» y «Comparación con IA» → CI y Sonar en verde, revisión y *merge*, con las horas reales. Reunión de seguimiento los viernes; demo y retro al cerrar cada parte.
- **Demo 6 · GitHub:** repo de formación, plantillas de issue y PR, issues y milestones, un PR de ejemplo y el ruleset de `main`.
- **Reglas y si falta tiempo:** primero tú, flujo de trabajo, datos ficticios, horas reales y glosario; el proyecto real tiene prioridad y cada parte tiene su orden de recorte.
- **Formación en paralelo:** las lecturas y módulos de Learn de cada ejercicio (records, EF Core, API mínima, GitHub Actions, Blazor, Identity, Docker Compose, Spec Kit, Azure) y las masterclasses de arquitectura, contenedores e IA.
- **Cómo se evalúa:** rúbrica por tecnología (objetivo: nivel 3 o más), demos desde un clon limpio, comprobaciones objetivas y el PR trampa del Día 23 (`docs/court-connect/evaluacion.md`).
- **Visión general:** actores (jugador, organizador, capitán), piezas y dónde se ejecutan (web Blazor y API en Azure Container Apps, Azure SQL, secretos) y el camino del código: GitHub → GitHub Actions → registro de contenedores → Azure, con SonarQube Cloud como control de calidad. En local, Docker Compose.
- **Vista lógica de capas:** presentación (Ui.Web, Ui.Components), negocio (Api → Application → Domain) e infraestructura transversal (Infrastructure, SQL Server), con la dirección de las dependencias: todo apunta hacia Domain, Application define interfaces e Infrastructure las implementa, y la web llama a la API por HTTP.
- **Componentes de la arquitectura (adelanto):** qué hace cada proyecto y qué tests lo cubren.
- **Dominio:** Court, Game, Player y Registration; reglas R1–R8; torneos, equipos y pago en la Parte III (`docs/court-connect/enunciado-dominio.md`).
- **Sin MediatR** y con la web hablando solo con la API. A fondo en la masterclass de arquitectura.
- **Antes del Día 1:** SDK de .NET 10, VS Code con las extensiones recomendadas, Docker Desktop, Git con acceso a DeemSoft y una primera entrada en SonarQube Cloud. Guía paso a paso: [`docs/court-connect/entorno.md`](../court-connect/entorno.md).

**Notas del ponente:**

**Qué decir:** «No tienes que construir todo el sistema el primer día. Cada parte añade una responsabilidad. Al terminar debes poder seguir una petición, explicar una decisión y mostrar cómo sabes que funciona».

**Contexto para Yamel:** Abrir el enunciado y separar requisitos, extras y recortes. El repositorio de formación contiene material; el código está en CourtConnect. Pedir a Driss que localice la tarea del Día 1 y su criterio de aceptación. No convertir una demo en una solución entregable. Consultar el [listado de formación](../fase2-pendiente.md) para situar arquitectura, cloud, seguridad, integraciones y agentes sin inventar fechas.

## 🧪 Demos

| Demo | Diapositiva | Qué se enseña | Preparación |
| --- | --- | --- | --- |
| 1. Azure | 11 | Recorrido por el portal: grupo de recursos, Container Apps, Azure SQL, Key Vault e identidad gestionada, costes | Suscripción de pruebas con un grupo de recursos de ejemplo, sin datos reales; nada de pago creado en directo |
| 2. GitHub Actions | 16 | Lanzar la CI desde un PR, seguir cada paso, romper un test y ver el bloqueo | Repo de prueba con un proyecto, un test, el workflow y un ruleset con el check obligatorio |
| 3. SonarQube Cloud | 18 | Quality gate, issues por tipo y severidad, hotspots y SonarQube for IDE | Un proyecto ya analizado (el repo de prueba de la demo 2) |
| 4. VS Code y SQL Server en Docker | 21 | `dotnet new`, extensiones recomendadas, un paquete NuGet, depurar y, si da tiempo, SQL Server en Docker con la extensión mssql | Proyecto de prueba, no CourtConnect; imagen de SQL Server descargada antes |
| 5. IA | 26 | Pedir a la IA un prompt efectivo, revisarlo, ejecutarlo y ver el consumo | Ejemplo neutro: un programa de consola que lea un CSV de partidos y muestre jugadores por cancha |
| 6. GitHub | 34 | Repo de formación, plantillas de issue y PR, issues y milestones, un PR de ejemplo y el ruleset de `main` | Repo de prueba con las plantillas de `.github/`, una issue y un PR de ejemplo |

Ninguna demo debe resolver ejercicios del reto.

### Notas de la demo 1: Azure

**Notas del ponente:**

**Qué decir:** «Vamos a localizar las piezas, quién puede acceder a ellas y dónde se consulta el coste. Ver un recurso en el portal no significa que la aplicación tenga permiso para leer sus datos».

**Contexto para Yamel:** Usar el entorno de pruebas ya preparado o capturas verificadas. No crear servicios de pago ni mostrar credenciales, identificadores personales o datos reales. Distinguir identidad de despliegue e identidad de ejecución. Reservar estimación detallada y limpieza para la clase cloud.

### Notas de la demo 2: GitHub Actions

**Notas del ponente:**

**Qué decir:** «Seguimos una ejecución: qué commit comprueba, qué pasos ejecuta y por qué falla. El estado debe corresponder al código que queremos revisar».

**Contexto para Yamel:** Usar el repositorio de prueba preparado, nunca romper el reto para la demostración. Mostrar una aserción significativa y el bloqueo del PR cuando falla. Si se usa una ejecución guardada, identificar su commit y no presentarla como recién ejecutada.

### Notas de la demo 3: SonarQube Cloud

**Notas del ponente:**

**Qué decir:** «Un análisis detecta ciertos problemas y un gate decide si se cumplen sus umbrales. Un test verde y un análisis pendiente son estados diferentes».

**Contexto para Yamel:** Mostrar el proyecto ya analizado y distinguir fallo, pendiente y no aplicable. Revisar evidencia del mismo commit que la CI. Explicar un hallazgo concreto sin afirmar que un gate verde demuestra ausencia de vulnerabilidades o comprensión del código.

### Notas de la demo 4: editor y SQL en Docker

**Notas del ponente:**

**Qué decir:** «Vamos a parar en una línea, mirar un valor y seguir el recorrido. Depurar sirve para contrastar lo que creemos que pasa con lo que ocurre de verdad».

**Contexto para Yamel:** Proyecto neutro y contenedor previamente preparados; no generar CourtConnect. Separar error de compilación, ejecución y conexión. No mostrar contraseñas ni borrar volúmenes para ahorrar tiempo. Si falta tiempo, priorizar una observación verificable sobre recorrer todas las extensiones.

### Notas de la demo 5: IA

**Notas del ponente:**

**Qué decir:** «Revisemos el prompt antes de ejecutarlo: qué pide, qué prohíbe y cómo comprobaríamos la salida. Que otro modelo lo haya redactado no lo convierte en correcto».

**Contexto para Yamel:** Usar el CSV ficticio previsto, sin datos personales ni solución del ejercicio. Comparar resultado con entradas conocidas y señalar errores observados, no inventar una demo perfecta. Mostrar consumo solo si está disponible; no deducir precios de una cifra aislada de tokens.

### Notas de la demo 6: GitHub y el reto

**Notas del ponente:**

**Qué decir:** «La issue explica el trabajo; el PR propone cómo se ha hecho. En la revisión debes poder mostrar qué cambió y qué comprobaste, incluida la parte en la que usaste IA».

**Contexto para Yamel:** Mostrar plantillas y un PR ficticio del repositorio de prueba. Distinguir propuesta, aprobación y fusión. Cerrar pidiendo que Driss localice su siguiente tarea, sin publicar comentarios ni cambiar reglas del repositorio durante la explicación.

## 🧭 Actividades después de la masterclass

| Nº | Actividad | Descripción |
| --- | --- | --- |
| 1 | **Quiz** | El de esta masterclass (`masterclass-dotnet-technologies-quiz.md`) |
| 2 | **Día 1 del reto** | Crear `court-connect` siguiendo la checklist y entrar en SonarQube Cloud |
| 3 | **Descubrimiento** | Hablar 30–45 minutos con su grupo de juego antes de la demo 1 (`docs/discovery.md`) |
| 4 | **Glosario** | Empezar `docs/learning/glosario.md` con los términos de hoy |

## 📘 Recursos de apoyo

Revisar disponibilidad y versiones al preparar la sesión.

### Documentación y cursos

- [Política de soporte de .NET (LTS y STS)](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core)
- [Documentación de .NET](https://learn.microsoft.com/es-es/dotnet/)
- [Tutorial: API mínima con ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/tutorials/min-web-api)
- [Learn: base de datos con una API mínima, EF Core y ASP.NET Core](https://learn.microsoft.com/es-es/training/modules/build-web-api-minimal-database/)
- [Learn: compilación de aplicaciones web con Blazor](https://learn.microsoft.com/es-es/training/paths/build-web-apps-with-blazor/)
- [Learn: introducción a GitHub Actions](https://learn.microsoft.com/es-es/training/modules/introduction-to-github-actions/)
- [Docker: primeros pasos](https://docs.docker.com/get-started/)
- [Tipos de registro (records) de C#](https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/types/records)
- [Identity para proteger una API web (.NET 10)](https://learn.microsoft.com/es-es/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-10.0)
- [Learn: desarrollo Spec-Driven con GitHub Spec Kit](https://learn.microsoft.com/es-es/training/modules/spec-driven-development-github-spec-kit-enterprise-developers/)

### IA

- [Prompt engineering para GitHub Copilot](https://docs.github.com/en/copilot/concepts/prompting-and-context/prompt-engineering)
- [Prompt engineering para Claude](https://docs.claude.com/en/docs/build-with-claude/prompt-engineering/overview)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)
- [Curso Generative AI for Beginners .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet) (cinco lecciones con vídeos cortos)

### Vídeos

Los enlaces de YouTube de la versión anterior no funcionaban y se han quitado. Fuentes oficiales:

- [Canal de .NET en YouTube](https://www.youtube.com/dotnet)
- [Vídeos de .NET](https://dotnet.microsoft.com/en-us/learn/videos)
- [.NET Conf](https://dotnet.microsoft.com/en-us/conf) (consultar la edición y el programa vigentes)

### Herramientas

- [VS Code](https://code.visualstudio.com/) · [Visual Studio Community](https://visualstudio.microsoft.com/)
- [SonarQube Cloud](https://sonarcloud.io/)
- [Documentación de GitHub Actions](https://docs.github.com/en/actions)

## Glosario priorizado

**Imprescindibles (15):** SDK, runtime, API, ORM, PR, CI, CD, quality gate, contenedor, token, ventana de contexto, prompt, agente, SDD y autorización.

Los quince conceptos se explican de forma visible en sus bloques, antes de las notas del ponente.

**Que te suene:** LTS/STS, MCP, RAG, PaaS, Kubernetes y los productos alternativos del mapa. Se consultan cuando hagan falta; no son una lista para memorizar.
