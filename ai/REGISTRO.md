# Registro de instalaciones

Primera instalación: `revisor-reto`, solicitada por Yamel y copiada en este repo, en `docs/ai-agentes`. Las dos filas siguientes registran los ficheros y hashes de la rama; **quedan efectivas en la rama destino al fusionar este PR**. La carga en las herramientas y las pruebas conversacionales están pendientes.

| Artefacto | Versión | Repo destino | Canal | Ruta instalada | Fecha | Quién lo instaló | SHA-256 del fichero instalado |
| --- | --- | --- | --- | --- | --- | --- | --- |
| revisor-reto | 1.0.0 | DeemSoft/formacion-dotnet-junior | Copilot (agente) | .github/agents/review-challenge.agent.md | 2026-10-30 | Yamel | 06CB751671F4EFB5EA0DD6399C4F4877324D8C267C5FF62FBAF07CCF66F360EB |
| revisor-reto | 1.0.0 | DeemSoft/formacion-dotnet-junior | Claude Code y VS Code Local (skill) | .claude/skills/review-challenge/SKILL.md | 2026-10-30 | Yamel | 9290AC6C66F2582D2858B0D70DB021C8937D1FF8F7F4B863CFBE3B04B7FF6883 |

<!-- Ejemplo ficticio; sustituir los marcadores por datos comprobados, no descomentar tal cual.
| tutor | 1.0.0 | DeemSoft/court-connect | Copilot (agente) | .github/agents/guide-learning.agent.md | AAAA-MM-DD | persona instaladora | hash SHA-256 real de 64 caracteres |
-->

## Cómo registrar

1. Instala por PR, comprueba que la herramienta carga el fichero y ejecuta sus pruebas. Enlaza ese PR y sus resultados en la descripción del PR que actualice este registro.
2. Tras fusionar la instalación, comprueba el fichero en un checkout del destino. Calcula su SHA-256 como explica [la guía](README.md#deriva-y-sha-256) y compáralo con la misma versión de la fuente.
3. Añade una fila por fichero instalado. Si el skill se comparte, indica «Claude Code y VS Code Local (skill)» en Canal, sin duplicar la fila. Distingue el agente de Copilot y cualquier copia adicional para su motor. Fecha en formato `AAAA-MM-DD`; identifica a quien instaló, no al modelo.
4. Al actualizar o revertir una instalación, sustituye su fila por la versión, fecha y hash efectivos. El historial Git conserva el estado anterior. Si se desinstala, retira la fila mediante PR.

En P2 · Ej5, el PR de mejora a la fuente incluye las filas de la **v1.0.0 ya instalada**. Proponer v1.1.0 no significa haberla instalado; el registro solo cambia cuando se reinstala de verdad.

Por defecto, una copia aún en una rama de trabajo no se registra como instalada en la rama destino. La primera autoinstalación del revisor es la excepción acordada: se registra en este PR con la nota de efectividad pendiente y se vuelven a comprobar los hashes tras fusionarlo. No inventes fechas ni hashes. Una instalación no acredita por sí sola la validación del flujo.
