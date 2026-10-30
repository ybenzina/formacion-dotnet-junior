# Tutor · guide-learning

**v1.0.0 · refined.** Ayuda a Driss a comprender su trabajo sin hacer el ejercicio por él. Concreta el modo tutor del reto; el estado editorial no acredita pruebas realizadas. No hay repositorios validados todavía.

## Cuándo usarlo

Para entender un error, aclarar un concepto o revisar código propio de los ejercicios. Se instala en el ejercicio 5 de la Parte II, después del diseño propio. Yamel mantiene la revisión técnica; el tutor no aprueba entregas.

**No usar** para obtener una solución completa, delegar la implementación ni trabajar en `feature/sdd-*`. Allí se sigue el flujo SDD con especificación aprobada, no este tutor. Las instrucciones del repositorio siguen vigentes aunque cambies de agente.

## Instalación

Desde [v1.0.0](v1.0.0/CHANGELOG.md), copia el fichero de cada canal a la misma ruta relativa desde la raíz de `court-connect`:

| Herramienta | Fuente del paquete | Ruta destino | Invocación |
| --- | --- | --- | --- |
| GitHub Copilot en VS Code | [Agente](v1.0.0/copilot/.github/agents/guide-learning.agent.md) | `.github/agents/guide-learning.agent.md` | Seleccionar `guide-learning` en el selector de agentes |
| Claude Code | [Skill](v1.0.0/claude/.claude/skills/guide-learning/SKILL.md) | `.claude/skills/guide-learning/SKILL.md` | `/guide-learning` en la conversación principal |

No copies los prefijos `copilot/` ni `claude/`. Conserva la cabecera, comprueba la carga en cada herramienta y realiza la instalación por PR. No sobrescribas una personalización existente sin revisarla. Sigue [la comprobación SHA-256](../../README.md#deriva-y-sha-256) y [el registro](../../REGISTRO.md), con una fila por fichero instalado tras fusionar el PR.

El agente de Copilot limita herramientas a lectura y búsqueda. El skill de Claude da instrucciones en la conversación principal, **no impone por sí solo una restricción técnica de escritura**: las instrucciones y permisos del entorno siguen siendo necesarios. No se usa `allowed-tools` como si fuera una lista de prohibiciones. En ambos casos se valida el comportamiento, no solo la presencia del fichero.

## Pruebas y mejora

Ejecuta [pruebas.md](v1.0.0/pruebas.md) en ambas herramientas y añade un caso propio. Anota las salidas reales en el PR; no marques una prueba como superada solo porque las instrucciones contienen esa regla.

Compara con el diseño previo y propone una mejora mediante PR **a esta fuente**, con nueva versión, CHANGELOG y repetición de pruebas. No edites la copia instalada como fuente de verdad. La actualización del destino y del registro va después. Los modelos no están fijados: registra cuál probaste.
