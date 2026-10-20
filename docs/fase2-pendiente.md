# Fase 2 — Dónde se aprende cada tema

El plan original de la fase 2 tenía ocho semanas (7 a 14). Se ha sustituido por el **reto CourtConnect** en tres partes (`Parte1/` a `Parte3/`, del 21 de octubre al 20 de noviembre de 2026). La arquitectura prevista para Àmbit (20/10/2026) ha decidido qué temas entran en el reto, cuáles se aprenden directamente en el proyecto real y cuáles quedan fuera.

| Tema | Plan original | Dónde se aprende ahora |
|---|---|---|
| Inyección de dependencias y ciclos de vida; patrón Singleton | — | Parte I (ejercicio 3 y demo 1) y masterclass de arquitectura |
| Repositorio y unidad de trabajo, y qué hace ya EF Core | — | Parte I (ejercicio 3) y masterclass de arquitectura |
| Arquitectura: SOLID, Clean Architecture, *Vertical Slice* | Semana 11 | Masterclass de arquitectura (25/10) y Parte III (funcionalidades SDD en *slices*) |
| Componentes Blazor y modos de render | Semana 9 | Parte II (ejercicios 1 y 3) |
| Seguridad: Identity, tokens, roles y políticas | Semana 13 | Parte II (ejercicio 2). Entra ID solo en Àmbit, con la masterclass de seguridad |
| `BackgroundService` | — | Parte III (caducidad de las inscripciones) |
| Despliegue en Azure (Container Apps, Azure SQL) | Semana 14 | Parte III (ejercicio 4) y masterclass de contenedores, Aspire y Azure (8/11) |
| Observabilidad: OpenTelemetry, Aspire, Application Insights | Semana 13 | Extra de la Parte III; se trabaja en la iteración 0 de Àmbit. Serilog, opcional |
| `IOptions` y configuración por entorno | Semana 9 | Iteración 0 de Àmbit |
| ADO.NET y Dapper | Semana 7 | En Àmbit, cuando llegue la migración de datos desde LOOP |
| Caché en memoria (`IMemoryCache`) | Semana 7 | Cuando haga falta |
| ASP.NET Core MVC | Semana 8 | Solo lectura, para reconocerlo en proyectos de mantenimiento |
| Minimal APIs frente a controladores | Semana 10 | Parte I (Minimal APIs; controladores, si los justifica) |
| gRPC | Semana 10 | Masterclass opcional |
| Tecnologías web heredadas: WebForms y jQuery/AJAX | Semana 8 | Fuera |
| Caché distribuida con Redis | Semana 11 | Fuera (el borrador `docs/court-connect/architecture/refactor-getevent-redis.md` queda como referencia) |
| .NET MAUI y MAUI Blazor Hybrid | Semana 12 | Fuera por ahora: primero la PWA |
| Microservicios, mensajería (Kafka), Grafana y Prometheus, Kubernetes | — | Fuera: no los necesita ni el reto ni Àmbit |

Las carpetas `Semana9/` a `Semana14/` con los enunciados originales (eran plantillas sin desarrollar) se eliminaron del repositorio. Siguen en el historial de Git.
