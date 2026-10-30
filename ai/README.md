# Referencias de IA del reto

Esta carpeta es la fuente de verdad de los agentes y prompts de `DeemSoft/formacion-dotnet-junior`. Se mantienen aquí y se instalan a mano por Pull Request en `DeemSoft/court-connect`. No hay nada instalado todavía. No se copia configuración de otros proyectos.

## Qué es cada cosa

| Pieza | Qué contiene | Autonomía | Quién la invoca |
| --- | --- | --- | --- |
| Agente personalizado (*custom agent*) | Un rol, instrucciones y herramientas en un fichero Markdown | La que permitan sus herramientas y límites; no significa ejecución autónoma | La persona lo selecciona; otro agente puede delegarle si está permitido |
| Skill | Una carpeta con instrucciones y, si hacen falta, recursos | No añade autonomía por sí solo; puede actuar en la conversación actual o en un contexto separado | La persona o el modelo, según su configuración |
| Fichero de prompt (*prompt file*) | Instrucciones reutilizables para una tarea concreta | Usa las capacidades del agente que lo ejecuta | La persona, como comando `/nombre` |

Un fichero no es un modelo ni un programa que esté ejecutándose. La herramienta lo carga y el modelo sigue sus instrucciones. Un subagente trabaja en su propio contexto; no equivale a conversar con un tutor. Las instrucciones guían el comportamiento, pero no son una barrera de seguridad infalible.

## Referencias disponibles

| Artefacto | Versión | Estado | Uso |
| --- | --- | --- | --- |
| [Tutor](artefactos/tutor/README.md) | 1.0.0 | `refined` | Ayuda gradual en las partes I y II; se instala en P2 · Ej5 |
| [Calidad](artefactos/calidad-sonarqube/README.md) | 1.0.0 | `draft` | Corregir issues de SonarQube Cloud desde la Parte III |
| [Documentación](artefactos/documentacion/README.md) | 1.0.0 | `draft` | Documentar según la configuración del repositorio |

No fijan modelo ni versión de .NET. Leen las convenciones y el SDK del repositorio destino. El reto usa .NET 10 en las partes I y II y migra a .NET 11 al empezar la III.

## Cuándo merece la pena

- No hay agente sin caso de uso documentado: problema repetido, límites, resultado y pruebas.
- Empieza por un prompt o por un rol de chat supervisado. No crees un agente para una pregunta puntual o una tarea que aún no sabes explicar.
- Añade más autonomía solo tras validar el flujo anterior en dos repositorios, con evidencia. Dos herramientas en el mismo repo no son dos repos.
- Siempre hay intervención humana: la persona decide el alcance, revisa los cambios y autoriza las acciones externas.

El tutor de Copilot es un rol conversacional con lectura, no un trabajador autónomo. Los skills de esta carpeta se invocan manualmente. Ninguna referencia está certificada ni tiene validación acreditada en dos repos.

## Ciclo de vida

1. **Diseño:** rellena [la plantilla breve](plantillas/diseno-agente.md).
2. **Prompt:** expresa rol, tarea, contexto, límites y salida esperada.
3. **Pruebas:** ejecuta los casos fijos y un caso propio en sesiones nuevas. Conserva entrada, salida real, herramienta, modelo, versión y resultado.
4. **Iteración:** cambia una cosa y repite los casos; una respuesta que «suena mejor» no basta.
5. **Versión:** crea una carpeta nueva, actualiza metadatos, cabeceras y CHANGELOG. Revisa todos los canales.
6. **Instalación:** PR al destino, comprobación de carga y pruebas. Registra solo instalaciones efectivas.
7. **Mantenimiento:** revisa compatibilidad, incidencias y deriva antes de actualizar. Para volver atrás, reinstala una versión anterior mediante PR y actualiza el registro.

## Convenciones

- **Identificador:** nombre estable del catálogo, como `calidad-sonarqube`.
- **Nombre de canal:** imperativo corto en inglés, como `fix-quality`. Se conserva entre repos. En prompts y skills se escribe `/fix-quality`; los agentes se eligen en el selector.
- **Versionado semántico (*SemVer*):** `MAJOR.MINOR.PATCH`. MAJOR cambia contratos, configuración o permisos de forma incompatible; MINOR añade capacidades compatibles; PATCH corrige instrucciones sin cambiar el contrato.
- Cada versión publicada queda inmóvil en `vX.Y.Z/`. Para una mejora, copia la versión en la fuente y cambia su número; no retoques copias instaladas.
- `draft`: propuesta pendiente de validar. `refined`: instrucciones concretadas y revisables; no acredita pruebas de instalación. `certified`: pruebas de todos los canales con evidencia y revisión humana aprobada. La versión y el estado son cosas distintas.
- [El esquema](esquema/metadata.schema.json) valida el catálogo; `validated_repos` contiene solo evidencia real. [La checklist](proceso/checklist.md) acompaña cada PR.
- Markdown y prompts en español; código e identificadores en inglés. La configuración decide el idioma de la documentación generada.

## Instalación manual

Consulta el README de cada artefacto. Copia el contenido de la variante elegida sobre la raíz del destino, conservando sus rutas ocultas y su cabecera. No copies el contenedor `v1.0.0/copilot/` como una carpeta del proyecto. No sobrescribas un fichero existente sin comparar y acordar el cambio.

VS Code distingue motores de ejecución (*harnesses*): los `.prompt.md` se ejecutan en **Local**; el motor **Copilot** usa skills para esos flujos. Instala solo la variante que corresponda, para no duplicar el mismo comando. Comprueba en el menú qué archivo se ha cargado, especialmente si también hay skills de Claude con el mismo nombre.

No se instalan las referencias automáticamente en el repo de formación. Los ejemplos de configuración tampoco se activan solos. Todas las copias efectivas, incluso una instalación en formación, se anotan en [REGISTRO.md](REGISTRO.md), con una fila por fichero y canal.

## Deriva y SHA-256

La deriva (*drift*) ocurre cuando una copia ya no coincide con la versión de la fuente que declara. La cabecera identifica esa versión, pero no demuestra que el contenido esté intacto. **SHA-256** es una huella de los bytes de un fichero; no sustituye a una firma ni a la revisión humana.

Desde la raíz de `court-connect`, con ambos repos como carpetas hermanas, este ejemplo comprueba el tutor de Copilot:

```powershell
$source = '../formacion-dotnet-junior/ai/artefactos/tutor/v1.0.0/copilot/.github/agents/guide-learning.agent.md'
$installed = '.github/agents/guide-learning.agent.md'
$sourceHash = (Get-FileHash -LiteralPath $source -Algorithm SHA256).Hash
$installedHash = (Get-FileHash -LiteralPath $installed -Algorithm SHA256).Hash
$sourceHash
$installedHash
$sourceHash -eq $installedHash
```

Al instalar, verifica que sale `True` y anota los 64 caracteres de `$installedHash` en el registro. En revisiones posteriores, compara **copia, versión fuente indicada en la cabecera y hash registrado**. Si cualquiera difiere, revisa el diff: no actualices el registro para ocultarlo. Una versión antigua intacta está desactualizada, pero no tiene deriva.

El hash incluye CRLF/LF, codificación y salto final. Conserva los bytes al copiar y comprueba de nuevo tras el checkout del PR fusionado: Git puede convertir los finales de línea. Una diferencia solo de formato también se investiga antes de registrar la copia. No normalices contenido de una versión publicada a escondidas.

Las mejoras van por PR a la fuente con nueva versión y pruebas. Tras fusionarlas, otro PR instala esa versión en el destino; después se actualiza el registro con la fecha, persona y hash reales. No se modifica primero la copia para convertirla en una segunda fuente.

## Evolución futura

Cuando haya más artefactos o repos, se podrá mover `ai/` a un repositorio de gobierno de la organización conservando su historial con `git subtree split --prefix=ai`. Se revisarán las rutas y cabeceras y se automatizará la sincronización por PR. Ahora no hay scripts de sincronización ni necesidad de ellos.

## Formatos consultados

Documentación oficial consultada el 30 de octubre de 2026. Comprueba cambios de formato antes de publicar una nueva versión.

| Fuente | Decisión |
| --- | --- |
| [Agentes de VS Code](https://code.visualstudio.com/docs/copilot/customization/custom-agents) y [frontmatter](https://code.visualstudio.com/docs/agents/reference/custom-agent-file-reference) | Tutor en `.github/agents/*.agent.md`, seleccionado por la persona |
| [Prompts de VS Code](https://code.visualstudio.com/docs/copilot/customization/prompt-files) | `.github/prompts/*.prompt.md` solo para Local; `agent`, no el antiguo `mode` |
| [Skills de VS Code](https://code.visualstudio.com/docs/agent-customization/agent-skills) | `.github/skills/<nombre>/SKILL.md` para Copilot, con invocación manual |
| [Skills de Claude Code](https://code.claude.com/docs/en/skills) | `.claude/skills/<nombre>/SKILL.md`, sin `context: fork` para mantener el diálogo |
| [Subagentes de Claude Code](https://code.claude.com/docs/en/sub-agents) | `.claude/agents/*.md`; no se usan para este tutor conversacional |
| [Estilos de salida de Claude Code](https://code.claude.com/docs/en/output-styles) | `.claude/output-styles/*.md`; no se cambia el estilo de toda la sesión para un flujo concreto |
