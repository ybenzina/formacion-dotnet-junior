# Calidad .NET · fix-quality

**v1.0.0 · draft.** Referencia para inventariar y corregir issues de SonarQube Cloud en un repositorio .NET alojado en GitHub. No contiene claves de organización ni proyecto. No hay pruebas de ejecución acreditadas todavía.

## Cuándo usarla

**Solo desde la Parte III del reto.** En las partes I y II, Driss debe interpretar y superar el quality gate por sí mismo, con la ayuda conceptual del tutor cuando corresponda. No usar para generar soluciones de ejercicios, analizar otros lenguajes, ignorar hallazgos o rebajar el gate.

Requiere acceso al código, SDK y comandos del repo, análisis de SonarQube Cloud y GitHub CLI (`gh`) autenticado. Lee organización, project key y configuración del scanner de los archivos/CI reales del destino; si faltan o se contradicen, pregunta. `SONAR_TOKEN` se configura fuera del chat, con permisos mínimos; nunca se pega ni se muestra.

## Instalación e invocación

Copia el fichero elegido preservando la ruta desde la raíz del destino y la cabecera:

| Motor | Fuente del paquete | Ruta destino | Invocación |
| --- | --- | --- | --- |
| VS Code Local | [Prompt](v1.0.0/copilot/.github/prompts/fix-quality.prompt.md) | `.github/prompts/fix-quality.prompt.md` | `/fix-quality` |
| Copilot | [Skill](v1.0.0/copilot/.github/skills/fix-quality/SKILL.md) | `.github/skills/fix-quality/SKILL.md` | `/fix-quality` |
| Claude Code | [Skill](v1.0.0/claude/.claude/skills/fix-quality/SKILL.md) | `.claude/skills/fix-quality/SKILL.md` | `/fix-quality` |

El prompt es la variante para Local, no para el motor Copilot. No instales a la vez prompt y skill del mismo nombre para Local; comprueba qué fuente carga la herramienta si descubre varios skills. El cuerpo de las tres variantes es equivalente.

Instala por PR y compara SHA-256 según [la guía](../../README.md#deriva-y-sha-256); actualiza [el registro](../../REGISTRO.md) tras fusionar la instalación. La fuente está aquí, no en las copias.

## Cómo se trabaja

Hay tres paradas obligatorias: **acordar alcance** tras el inventario; **aprobar el plan** por lotes; **revisar cada módulo** antes de continuar. El alcance por defecto es P1–P3, pero el inventario muestra también P4–P5 y lo pendiente. Un issue con varios impactos toma la prioridad más alta, es decir, el menor número P de la matriz incluida en cada variante.

Los cambios se hacen en `quality/<scope>`, con la base confirmada según el flujo del repo. Los falsos positivos necesitan evidencia y confirmación individual, no una exclusión masiva. Compilar y pasar tests localmente no acredita el gate del PR: hay que comprobar el análisis y el commit correspondientes.

Ejecuta [la batería](v1.0.0/pruebas.md) en un entorno de práctica, empezando por lectura. No ejecutes acciones que cambien SonarQube o publiquen un PR sin autorización. Las mejoras se proponen a esta fuente mediante nueva versión y CHANGELOG.
