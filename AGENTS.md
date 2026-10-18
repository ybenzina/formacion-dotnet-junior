# Instrucciones comunes para asistentes de IA

Este archivo es la **única fuente** de instrucciones para cualquier asistente de IA en este repositorio (Claude, GitHub Copilot u otros). `CLAUDE.md` y `.github/copilot-instructions.md` solo apuntan aquí.

## Qué es este repositorio

- Repositorio de **material de formación** en .NET: plan, enunciados, anuncios, guías y scaffolds.
- **Yamel** es el mentor y quien prepara el material. **Driss** es el alumno.
- `main` contiene **solo enunciados y material, nunca soluciones**. Las soluciones de la fase 1 están en `drissbego/integration`. El código del reto de la fase 2 vive en otro repositorio: `DeemSoft/court-connect`.

## Reglas

- **No resuelvas ejercicios.** Si te piden la solución de un enunciado, no la des: explica conceptos, haz preguntas y da pistas. Las reglas completas del modo tutor están en `docs/court-connect/plantilla-repo/AGENTS.md`.
- **Material del mentor:** cuando Yamel prepara material (scaffolds, ejemplos, guías, CI de referencia) puedes generar código, siempre que no sea la solución de un ejercicio abierto.
- **Ningún dato de clientes reales** ni de otros proyectos de DeemSoft. Datos siempre ficticios.
- **No introduzcas secretos** ni credenciales.
- **Inspecciona antes de modificar** y no sobrescribas trabajo existente.

## Convenciones

- Namespaces y ensamblados: `DeemSoft.<Producto>.<Capa>` (por ejemplo, `DeemSoft.CourtConnect.Domain`). Se declara una vez en el `Directory.Build.props` de la raíz, no en cada `.csproj`.
- Carpetas, ficheros `.csproj` y solución **sin** el prefijo de organización (`src/CourtConnect.Domain`, `CourtConnect.slnx`), para no alargar las rutas.
- Repositorios en minúsculas con guiones (`court-connect`).
- Documentación en español.
- Flujo de Git: ramas cortas (`docs/`, `chore/`, `feature/`, `fix/`) y Pull Request con la sección «Uso de IA».
