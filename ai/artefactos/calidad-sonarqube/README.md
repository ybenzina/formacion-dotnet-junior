# Calidad .NET · fix-quality

**v1.0.0 · draft.** Para inventariar y corregir issues de SonarQube Cloud en un repo .NET de GitHub. Pruebas de ejecución pendientes.

## Cuándo usarla

**Solo desde la Parte III.** En las partes I y II, Driss supera el quality gate por su cuenta. No sirve para resolver ejercicios, analizar otros lenguajes ni rebajar el gate.

Necesita el SDK del repo, acceso a SonarQube Cloud y `gh` autenticado. Obtiene organización y project key de la configuración real. Prepara `SONAR_TOKEN` fuera del chat.

## Instalación e invocación

Copia el [skill](v1.0.0/claude/.claude/skills/fix-quality/SKILL.md) con su cabecera:

| Motores | Ruta destino | Invocación |
| --- | --- | --- |
| Claude Code y VS Code Local | `.claude/skills/fix-quality/SKILL.md` | `/fix-quality` |

Solo para el motor **Copilot**, añade una copia del mismo fichero en `.github/skills/fix-quality/SKILL.md`. Local lee ambas carpetas: no las dupliques para usar Local. Una copia compartida reduce la deriva entre herramientas.

Instala por PR, comprueba [SHA-256](../../README.md#deriva-y-sha-256) y actualiza [el registro](../../REGISTRO.md). Si actualizas una instalación anterior, retira las variantes redundantes como explica [la guía](../../README.md#instalación-manual).

## Cómo se trabaja

Las tres paradas son **acordar alcance**, **aprobar el plan** y **revisar cada módulo**. Por defecto corrige P1–P3 y muestra el inventario completo, incluidos P4–P5 pendientes.

El skill detalla la matriz, las ramas `quality/<scope>`, los falsos positivos y las pruebas. El gate se verifica contra el PR y commit correctos, no solo con un build local.

Ejecuta [la batería](v1.0.0/pruebas.md) y un caso propio con Claude Code y VS Code Local. Guarda resultados reales. Las mejoras vuelven a esta fuente mediante nueva versión y CHANGELOG.
