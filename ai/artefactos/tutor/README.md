# Tutor · guide-learning

**v1.0.0 · refined.** Ayuda a Driss a comprender su trabajo sin resolver el ejercicio. Las pruebas de ejecución siguen pendientes.

## Cuándo usarlo

Para entender errores, aclarar conceptos y revisar código propio. Se instala en P2 · Ej5, después del diseño breve. Yamel revisa las entregas.

**No usar** para delegar ejercicios ni en `feature/sdd-*`. Los límites y la ayuda gradual están en el instalable.

## Instalación

En un solo PR de `court-connect`, instala estos dos ficheros con su cabecera:

| Herramienta | Fuente del paquete | Ruta destino | Invocación |
| --- | --- | --- | --- |
| Copilot en VS Code | [Agente](v1.0.0/copilot/.github/agents/guide-learning.agent.md) | `.github/agents/guide-learning.agent.md` | Seleccionar `guide-learning` |
| Claude Code y VS Code Local | [Skill compartido](v1.0.0/claude/.claude/skills/guide-learning/SKILL.md) | `.claude/skills/guide-learning/SKILL.md` | `/guide-learning` |

No copies los prefijos del paquete. El agente restringe herramientas a lectura y búsqueda; el skill no impone esa restricción técnica. En la práctica, usa el agente en VS Code y el skill en Claude Code.

Local también lee el skill de Claude: una sola copia reduce la deriva. `.github/skills/` solo se añade para usar un skill con el motor Copilot; este tutor ya tiene su agente y no la necesita.

## Pruebas y mejora

En P2 · Ej5 ejecuta **T1, T3, T4, T7 y un caso propio** de [pruebas.md](v1.0.0/pruebas.md) en ambas herramientas. La batería completa queda para la validación posterior.

Un único PR a la fuente reúne mejora `v1.1.0`, CHANGELOG, resultados y [registro](../../REGISTRO.md) de la **v1.0.0 instalada**, con [SHA-256](../../README.md#deriva-y-sha-256). Reinstalar la mejora es Extra; hasta entonces el registro no cambia a v1.1.0.
