# Arquitectura - CourtConnect

## Visión general
CourtConnect seguirá una arquitectura **Vertical Slice** con una capa `Domain` ligera para entidades y `Application` para casos de uso (handlers). `Infrastructure` contendrá EF Core y repositorios, `WebApi` y `Web.Blazor` las UIs.

## Capas
- Domain: Entidades y Value Objects.
- Application: Casos de uso (MediatR handlers), DTOs, interfaces.
- Infrastructure: EF Core, repositorios, adaptadores externos (Redis, email).
- WebApi: API REST (Swagger).
- Web.Blazor / Web.Mvc: UIs.
- Tests: Unit / Integration.

## Integración y despliegue
- GitHub Actions pipelines: build → test → sonar → deploy.
- Deploy target: Azure App Service (SaaS) or VM+IIS (IaaS) si se requiere.
- Monitoring: Application Insights + Serilog.

## Patrones a aplicar
- Dependency Injection (DI)
- Repository pattern
- Cache-aside with IDistributedCache (Redis)
- MediatR for Vertical Slice
- Options pattern for config

