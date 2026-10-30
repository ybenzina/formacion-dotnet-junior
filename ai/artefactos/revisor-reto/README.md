# Revisor del reto · review-challenge

**v1.0.0 · draft.** Para Yamel: revisión de PR de CourtConnect, demos, seguimiento de viernes y borradores de Discord. No es el tutor de Driss ni asigna niveles por su cuenta. Las pruebas conversacionales siguen pendientes.

## Instalación y uso

Se instala en **`DeemSoft/formacion-dotnet-junior`**, donde están los enunciados. El código y los PR se leen de `DeemSoft/court-connect` con `gh` autenticado o un clon identificado.

| Herramienta | Fuente | Ruta instalada | Invocación |
| --- | --- | --- | --- |
| Copilot en VS Code | [Agente](v1.0.0/copilot/.github/agents/review-challenge.agent.md) | `.github/agents/review-challenge.agent.md` | Seleccionar `review-challenge` |
| Claude Code y VS Code Local | [Skill](v1.0.0/claude/.claude/skills/review-challenge/SKILL.md) | `.claude/skills/review-challenge/SKILL.md` | `/review-challenge` |

Conserva las cabeceras y compara [SHA-256](../../README.md#deriva-y-sha-256) con [el registro](../../REGISTRO.md). Una única copia del skill sirve para Claude y Local y reduce la deriva. `.github/skills/` solo se añadiría para usar un skill con el motor Copilot; aquí ya está su agente. No hay variante `.prompt.md`.

Indica número o URL del PR, parte para una demo, o milestone/semana para el seguimiento. El revisor pregunta si no puede deducir el ejercicio. Para Discord, indica si necesitas anuncio, resumen o recordatorio. El PR trampa solo se prepara por petición expresa de Yamel.

## Límites

Las notas privadas pueden explicar una corrección; **no se pegan en el PR**. Los comentarios para Driss son pistas, no soluciones. Yamel decide el veredicto y el nivel de la rúbrica. Sin evidencia, queda pendiente.

El agente dispone de `read`, `search` y `execute`, pero sus instrucciones limitan la ejecución a `gh` y `git` de lectura. **No es una barrera técnica:** `execute` no filtra subcomandos y el skill no restringe las herramientas de la sesión. Mantén las aprobaciones de comandos y revisa cada ejecución. No se han añadido hooks ni permisos automáticos.

Si pides publicar, muestra comando y texto y espera confirmación; la ejecución de esa escritura queda a cargo de Yamel, fuera de este rol. Discord siempre recibe solo un borrador, sin datos personales ni notas del PR trampa.

## Pruebas y mantenimiento

Ejecuta [los casos fijos](v1.0.0/pruebas.md) y uno propio en el agente de Copilot y el skill de Claude Code; comprueba también la carga en Local. Guarda salidas y herramienta/modelo reales. Instalar no equivale a certificar.

Las mejoras se proponen en esta fuente, con versión y CHANGELOG, antes de actualizar las copias. Formatos contrastados el 30 de octubre de 2026: [agentes y herramientas de VS Code](https://code.visualstudio.com/docs/agents/reference/custom-agent-file-reference), [skills en Local](https://code.visualstudio.com/docs/agent-customization/agent-skills) y [skills de Claude Code](https://code.claude.com/docs/en/skills).
