# Temas del plan original — dónde se aprende cada uno

El plan original, después del curso, tenía ocho semanas más (7 a 14). Se ha sustituido por el **reto CourtConnect** en tres partes (`reto/Parte1/` a `reto/Parte3/`, 23 días de trabajo, ver [calendario](court-connect/calendario.md)). La arquitectura prevista para Àmbit ha orientado qué temas entran en el reto, cuáles se aprenden directamente en el proyecto real y cuáles quedan fuera.

| Tema | Plan original | Dónde se aprende ahora |
| --- | --- | --- |
| Inyección de dependencias y ciclos de vida; patrón Singleton | — | Parte I (ejercicio 3 y demo 1) y masterclass de arquitectura |
| Repositorio y unidad de trabajo, y qué hace ya EF Core | — | Parte I (ejercicio 3) y masterclass de arquitectura |
| Arquitectura: SOLID, Clean Architecture, *Vertical Slice* | Semana 11 | [Masterclass de arquitectura](masterclasses/masterclass-architecture.md), prevista para el domingo siguiente al Día 5, a mitad del ejercicio 3 (fecha real en el calendario); Parte III para funcionalidades SDD en *slices* |
| Patrones: Singleton, Factory, Strategy, Adapter, Decorator y Options | — | Masterclass de arquitectura, con ejemplos cortos y revisión del servicio propio |
| Docker, Compose y Aspire local | — | Parte II, ejercicio 4; [cloud, sesión 1](masterclasses/masterclass-cloud-local.md), el domingo siguiente al Día 15 por la mañana, como repaso y ampliación |
| Componentes Blazor y modos de render | Semana 9 | Parte II (ejercicios 1 y 3) |
| Seguridad: Identity, tokens, roles y políticas | Semana 13 | [Lectura de 15 minutos](court-connect/seguridad-en-15-minutos.md) antes de P2 · Ej2; [masterclass 0 de seguridad](masterclasses/masterclass-security.md), dos sesiones de 90 min después del reto y antes de Àmbit, sin fecha fija; incluye Entra ID y opciones para familias sin elegir proveedor |
| `BackgroundService`, HTTP, resiliencia, idempotencia y outbox | — | Parte III para caducidad en el host `CourtConnect.Worker`; [masterclass de integraciones](masterclasses/masterclass-integrations.md), 90 min antes de Àmbit, sin fecha fija; aplicación ilustrativa a Holded, no un requisito añadido al reto |
| IA, agentes, pruebas y gobierno de referencias | — | [Masterclass de IA y agentes](masterclasses/masterclass-ai-agents.md), una sesión de 90 min con pausa, el domingo siguiente al Día 15 por la tarde, antes de P2 · Ej5; gobierno avanzado y puente a SDD como ampliación opcional |
| Despliegue en Azure (Container Apps, Azure SQL), IaC y costes | Semana 14 | [Cloud, sesión 2](masterclasses/masterclass-cloud-azure.md), el domingo siguiente al Día 20; despliegue de Parte III el Día 22 |
| Observabilidad: OpenTelemetry, Aspire, Application Insights | Semana 13 | Introducción en las dos sesiones cloud; implementación como extra de la Parte III y trabajo en la iteración 0 de Àmbit. Serilog, opcional |
| `IOptions` y configuración por entorno | Semana 9 | Introducción en arquitectura; aplicación en la iteración 0 de Àmbit |
| ADO.NET y Dapper | Semana 7 | En Àmbit, cuando llegue la migración de datos desde LOOP |
| Caché en memoria (`IMemoryCache`) | Semana 7 | Cuando haga falta |
| ASP.NET Core MVC | Semana 8 | Solo lectura, para reconocerlo en proyectos de mantenimiento |
| Minimal APIs frente a controladores | Semana 10 | Parte I (Minimal APIs; controladores, si los justifica) |
| gRPC | Semana 10 | Apéndice de lectura opcional en la masterclass de integraciones, fuera de sus 90 min |
| Tecnologías web heredadas: WebForms y jQuery/AJAX | Semana 8 | Fuera |
| Caché distribuida con Redis | Semana 11 | Fuera (el borrador `docs/court-connect/architecture/refactor-getevent-redis.md` queda como referencia) |
| .NET MAUI y MAUI Blazor Hybrid | Semana 12 | Fuera por ahora: primero la PWA |
| Microservicios, mensajería (Kafka), Grafana y Prometheus, Kubernetes | — | Fuera: no los necesita ni el reto ni Àmbit |

Las carpetas `Semana9/` a `Semana14/` con los enunciados originales (eran plantillas sin desarrollar) se eliminaron del repositorio. Siguen en el historial de Git.

## Guiones y quizzes nuevos

Los quizzes se hacen al día siguiente, fuera del tiempo de clase. Las convocatorias están en el [calendario](court-connect/calendario.md); seguridad e integraciones siguen sin fecha fija, antes del proyecto real. Cloud tiene [dos guiones independientes](masterclasses/masterclass-cloud.md), [quiz por sesión](masterclasses/masterclass-cloud-quiz.md) y una [hoja de costes solo para Yamel](masterclasses/masterclass-cloud-costes-yamel.md).

| Masterclass | Guion | Quiz |
| --- | --- | --- |
| 0: seguridad e identidad | [Dos sesiones de 90 min](masterclasses/masterclass-security.md) | [12 preguntas por sesión](masterclasses/masterclass-security-quiz.md) |
| Integraciones y tareas en segundo plano | [Una sesión de 90 min](masterclasses/masterclass-integrations.md) | [12 preguntas](masterclasses/masterclass-integrations-quiz.md) |
| IA y agentes | [Una sesión de 90 min con pausa](masterclasses/masterclass-ai-agents.md) | [12 preguntas y ampliación opcional](masterclasses/masterclass-ai-agents-quiz.md) |
