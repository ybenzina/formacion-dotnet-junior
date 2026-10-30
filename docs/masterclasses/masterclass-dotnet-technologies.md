# Masterclass .NET Technologies — overview del ecosistema, la forma de trabajar, la IA y el reto CourtConnect

**Duración:** unas 2 horas, con las demos. **Cuándo:** al arrancar el reto, después del Día 0.
**Material:** `masterclass-dotnet-technologies.pptx` (44 diapositivas, con notas para el ponente) y `masterclass-dotnet-technologies-quiz.md`. Las diapositivas de contenido se muestran clic a clic; las de demo, enteras, con los pasos y «Qué observar» (la preparación está en sus notas).

Es una masterclass de **visión general**: un mapa de lo que hay y de cómo vamos a trabajar. Cada bloque se desarrolla después en una masterclass específica (arquitectura; contenedores, Aspire y Azure; IA) o en los ejercicios del reto.

## 🎯 Objetivos

- Comprender la evolución del ecosistema .NET y su estado actual (.NET 10, LTS y STS).
- Conocer las herramientas del día a día: VS Code (o Visual Studio), Docker, SQL Server y GitHub.
- Entender el flujo de trabajo del equipo: ramas cortas, Pull Request, CI/CD y SonarQube Cloud.
- Usar la IA con criterio: tokens, prompts efectivos y una primera idea de agentes, MCP, RAG y SDD.
- Situar el reto CourtConnect: partes, dominio, arquitectura (adelanto) y qué hacer el Día 1.

## 🧩 Agenda

| Bloque | Tiempo | Diapositivas |
|---|---|---|
| Apertura: objetivos, contenidos y demos planificadas | 5 min | 1–4 |
| 1. Historia .NET y visión general (con demo 1) | 20 min | 5–11 |
| 2. Metodologías, herramientas y entornos (con demos 2–4) | 35 min | 12–21 |
| 3. Desarrollo asistido por IA (con demo 5) | 25 min | 22–28 |
| 4. Reto CourtConnect (con demo 6) y cierre | 35 min | 29–44 |

### 1. Historia .NET y visión general

- De **.NET Framework** (2002, solo Windows) a **.NET Core** (2016, multiplataforma), **.NET 5** (2020, plataforma unificada) y **.NET 10** (2025).
- **Versiones y soporte:** una versión cada noviembre; las pares son **LTS** (3 años) y las impares **STS** (2 años). .NET 8 y .NET 9 terminan soporte el 10/11/2026; .NET 10 lo tiene hasta el 14/11/2028. **.NET 11** se lanza en **.NET Conf 2026 (10–13 de noviembre)**. En proyectos de cliente, LTS. El reto usa .NET 10 en las partes I y II y empieza la Parte III migrando a .NET 11.
- **Ecosistema:**
  - Web y APIs: ASP.NET Core (Minimal APIs, controladores, MVC, Razor Pages) y Blazor (Static SSR, Server, WebAssembly). Legacy: WebForms, jQuery.
  - Comunicaciones: APIs REST y gRPC. Legacy: WCF / SOAP.
  - Datos: Entity Framework Core (ORM); ADO.NET y Dapper para SQL a mano.
  - Multiplataforma: .NET MAUI y MAUI Blazor Hybrid. (Xamarin no tiene soporte desde mayo de 2024.)
- **Despliegue:** on-premise (IIS, Windows Server) frente a cloud: App Service (PaaS), **Azure Container Apps** (lo que usará el reto, con Azure SQL) y AKS solo si hace falta Kubernetes.
- **Demo 1 · Azure:** recorrido por el portal (grupo de recursos, Container Apps, Azure SQL, Key Vault y costes).

### 2. Metodologías, herramientas y entornos

- Ciclo de vida del software y **Scrum** en breve (roles, sprints, backlog, reuniones).
- **Nuestro flujo de ramas:** ramas cortas (`feature/`, `fix/`, `docs/`) y **PR** con «Qué / Por qué / Cómo se ha comprobado / Uso de IA», revisión y *merge*.
  - Mientras no hay nada en producción, las ramas van directas a `main` (así empieza el reto).
  - Con código en producción se separa el desarrollo en curso de lo productivo: `feature/` → `develop` (integración de la iteración) → `main` (producción, versiones etiquetadas). Es un Git flow simplificado; los nombres pueden variar (`integration` en lugar de `develop`).
- **CI/CD con GitHub Actions:** cada PR y cada push a las ramas principales (`main` y, con código en producción, `develop`) → restore, build, test y análisis. SDK fijado con `global.json`. Secretos en GitHub, nunca en el YAML. Despliegue a Container Apps en la Parte III.
- **Calidad con SonarQube Cloud** (antes SonarCloud): quality gate *Sonar way*, solo sobre código nuevo, **bloqueante** y con **dos checks** (el job de la CI y `SonarCloud Code Analysis`). SonarQube for IDE (antes SonarLint) en el editor. Detalle: `docs/court-connect/calidad.md`.
- **Seguridad y datos desde el primer día:** secretos fuera del repo (user-secrets, secretos de GitHub, Key Vault), datos ficticios y mínimos, autorización en el servidor (R7 y R8), dependencias sin vulnerabilidades, logs sin datos personales y revisión del código generado por IA. Son los riesgos del PR trampa del final.
- **Herramientas:** VS Code con C# Dev Kit y las extensiones recomendadas (Visual Studio como alternativa), Docker Desktop, SQL Server (extensión mssql o SSMS) y GitHub.
- **Demos 2, 3 y 4:** GitHub Actions (después de CI/CD), SonarQube Cloud (después de Calidad) y VS Code con SQL Server en Docker (después de Herramientas).

### 3. Desarrollo asistido por IA

- **Cómo la usamos en el reto:** `AGENTS.md` como fuente única (Claude y Copilot), **modo tutor**, «primero tú, después la IA», sección «Uso de IA» en cada PR, sin secretos ni datos reales. Excepción: la Parte III (SDD).
- **Tokens y ventana de contexto:** qué es un token, qué «ve» el modelo en cada petición, por qué se paga por tokens y cómo ver el consumo (`/cost` en Claude Code; peticiones premium en Copilot).
- **Prompts efectivos:** contexto, tarea, restricciones, formato de salida, criterio de terminado; pedir un plan antes del código; iterar.
- **Agentes, MCP y RAG**, lo justo para el reto. La masterclass de IA los verá a fondo.
- **Demo 5 · IA:** pedir a la IA un prompt, revisarlo, ejecutarlo y ver el consumo (después de los prompts efectivos).
- **SDD con GitHub Spec Kit:** constitución → especificación → aclaraciones → plan → tareas → implementación. Se usa en la Parte III y sirve de piloto para decidir cómo trabajar con IA en proyectos reales.

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
- **Antes del Día 1:** SDK de .NET 10, VS Code con las extensiones recomendadas, Docker Desktop, Git con acceso a DeemSoft y una primera entrada en SonarQube Cloud.

## 🧪 Demos

| Demo | Diapositiva | Qué se enseña | Preparación |
|---|---|---|---|
| 1. Azure | 11 | Recorrido por el portal: grupo de recursos, Container Apps, Azure SQL, Key Vault e identidad gestionada, costes | Suscripción de pruebas con un grupo de recursos de ejemplo, sin datos reales; nada de pago creado en directo |
| 2. GitHub Actions | 16 | Lanzar la CI desde un PR, seguir cada paso, romper un test y ver el bloqueo | Repo de prueba con un proyecto, un test, el workflow y un ruleset con el check obligatorio |
| 3. SonarQube Cloud | 18 | Quality gate, issues por tipo y severidad, hotspots y SonarQube for IDE | Un proyecto ya analizado (el repo de prueba de la demo 2) |
| 4. VS Code y SQL Server en Docker | 21 | `dotnet new`, extensiones recomendadas, un paquete NuGet, depurar y, si da tiempo, SQL Server en Docker con la extensión mssql | Proyecto de prueba, no CourtConnect; imagen de SQL Server descargada antes |
| 5. IA | 26 | Pedir a la IA un prompt efectivo, revisarlo, ejecutarlo y ver el consumo | Ejemplo neutro: un programa de consola que lea un CSV de partidos y muestre jugadores por cancha |
| 6. GitHub | 34 | Repo de formación, plantillas de issue y PR, issues y milestones, un PR de ejemplo y el ruleset de `main` | Repo de prueba con las plantillas de `.github/`, una issue y un PR de ejemplo |

Ninguna demo debe resolver ejercicios del reto.

## 🧭 Actividades después de la masterclass

| Nº | Actividad | Descripción |
|---|---|---|
| 1 | **Quiz** | El de esta masterclass (`masterclass-dotnet-technologies-quiz.md`) |
| 2 | **Día 1 del reto** | Crear `court-connect` siguiendo la checklist y entrar en SonarQube Cloud |
| 3 | **Descubrimiento** | Hablar 30–45 minutos con su grupo de juego antes de la demo 1 (`docs/discovery.md`) |
| 4 | **Glosario** | Empezar `docs/learning/glosario.md` con los términos de hoy |

## 📘 Recursos de apoyo

Enlaces comprobados el 29/10/2026.

### Documentación y cursos

- [Política de soporte de .NET (LTS y STS)](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core)
- [Documentación de .NET](https://learn.microsoft.com/es-es/dotnet/)
- [Tutorial: API mínima con ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/tutorials/min-web-api)
- [Learn: base de datos con una API mínima, EF Core y ASP.NET Core](https://learn.microsoft.com/es-es/training/modules/build-web-api-minimal-database/)
- [Learn: compilación de aplicaciones web con Blazor](https://learn.microsoft.com/es-es/training/paths/build-web-apps-with-blazor/)
- [Learn: introducción a GitHub Actions](https://learn.microsoft.com/es-es/training/modules/introduction-to-github-actions/)
- [Docker: primeros pasos](https://docs.docker.com/get-started/)
- [Tipos de registro (records) de C#](https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/types/records)
- [Identity para proteger una API web](https://learn.microsoft.com/es-es/aspnet/core/security/authentication/identity-api-authorization)
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
- [.NET Conf 2026](https://dotnet.microsoft.com/en-us/conf) (10–13 de noviembre, lanzamiento de .NET 11)

### Herramientas

- [VS Code](https://code.visualstudio.com/) · [Visual Studio Community](https://visualstudio.microsoft.com/)
- [SonarQube Cloud](https://sonarcloud.io/)
- [Documentación de GitHub Actions](https://docs.github.com/en/actions)
