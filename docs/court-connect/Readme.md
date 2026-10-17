# CourtConnect - Proyecto de fin de Formación (Fase 2)

**CourtConnect** es una aplicación para **organizar quedadas y torneos de baloncesto**: creación de eventos, inscripciones (RSVP), gestión de ubicaciones y participantes. Este repositorio contiene la plantilla de solución, documentación y el plan de formación (semanas 7-14) para desarrollar CourtConnect de forma incremental.

## Qué incluye este paquete
- Plantilla de solución (proyectos skeleton en `src/`)
- Estructura de carpetas por semana: `Semana1`..`Semana14`
- Documentación técnica en `/docs` (modelo de datos, snippets, masterclass guides)
- CI workflow de ejemplo en `.github/workflows/ci.yml`
- Plantillas de PR e Issue para GitHub en `.github/`
- Script `create-sln.sh` para crear la solución con dotnet CLI en tu máquina local (requiere dotnet SDK)

## Cómo empezar (local)
1. Clona el repo.
2. Ejecuta `./create-sln.sh` en un entorno con dotnet SDK para crear la solución y añadir los proyectos (.NET SDK required).
3. Abre `CourtConnect.sln` en Visual Studio o usa `dotnet build`.
4. Para pruebas: `dotnet test`.

## Ramas de trabajo
- Usar nomenclatura profesional para ramas:
  - `drissbego/semana7-ejercicio1` (si quieres mantener compatibilidad histórica)
  - o `feature/dataaccess`, `feature/webui`, `feature/blazorui`, etc.
- Integración final en: `drissbego/integration`

## CI / Workflows
- Un workflow principal está en `.github/workflows/ci.yml`. Puedes tener varios workflows: GitHub Actions ejecutará todos los workflows que coincidan con los `on:` triggers.
- Para ejecutar workflows específicos por ruta o rama, usa `paths` or `branches` filters in the workflow YAML (see `.github/workflows/ci.yml`).
- Ejemplo: to run only when files in `src/CourtConnect.WebApi/**` change, add:
  ```yaml
  on:
    push:
      paths:
        - 'src/CourtConnect.WebApi/**'
  ```

## Notas
- Los proyectos generados son skeletons (archivos .csproj y Program.cs mínimos). Ejecuta `create-sln.bat` y luego añade referencias y paquetes desde tu entorno de desarrollo.
- Redis docker helper is provided in `/docs/architecture/docker-compose.redis.yml` for the cache exercise.
