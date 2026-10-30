# Registro de instalaciones

No hay instalaciones registradas. Tener una referencia en `ai/artefactos/` no significa que esté instalada en una herramienta.

| Artefacto | Versión | Repo destino | Canal | Ruta instalada | Fecha | Quién lo instaló | SHA-256 del fichero instalado |
| --- | --- | --- | --- | --- | --- | --- | --- |

<!-- Ejemplo ficticio; sustituir los marcadores por datos comprobados, no descomentar tal cual.
| tutor | 1.0.0 | DeemSoft/court-connect | Copilot (agente) | .github/agents/guide-learning.agent.md | AAAA-MM-DD | persona instaladora | hash SHA-256 real de 64 caracteres |
-->

## Cómo registrar

1. Instala por PR, comprueba que la herramienta carga el fichero y ejecuta sus pruebas. Enlaza ese PR y sus resultados en la descripción del PR que actualice este registro.
2. Tras fusionar la instalación, comprueba el fichero en un checkout del destino. Calcula su SHA-256 como explica [la guía](README.md#deriva-y-sha-256) y compáralo con la misma versión de la fuente.
3. Añade una fila por fichero instalado. Si el skill se comparte, indica «Claude Code y VS Code Local (skill)» en Canal, sin duplicar la fila. Distingue el agente de Copilot y cualquier copia adicional para su motor. Fecha en formato `AAAA-MM-DD`; identifica a quien instaló, no al modelo.
4. Al actualizar o revertir una instalación, sustituye su fila por la versión, fecha y hash efectivos. El historial Git conserva el estado anterior. Si se desinstala, retira la fila mediante PR.

En P2 · Ej5, el PR de mejora a la fuente incluye las filas de la **v1.0.0 ya instalada**. Proponer v1.1.0 no significa haberla instalado; el registro solo cambia cuando se reinstala de verdad.

Una copia aún en una rama de trabajo no se registra como instalada en la rama destino. No inventes fechas ni hashes para completar la tabla. Una instalación no acredita por sí sola la validación del flujo en ese repositorio.
