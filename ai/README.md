# Referencias de IA del reto

Esta carpeta es la fuente de verdad de las referencias de IA de `DeemSoft/formacion-dotnet-junior`. Se instalan por PR en `DeemSoft/court-connect`, salvo el revisor del mentor, instalado en este repo. Su primera instalación queda efectiva al fusionar el PR, según [el registro](REGISTRO.md).

## Qué es cada cosa

| Pieza | Qué contiene | Autonomía | Quién la invoca |
| --- | --- | --- | --- |
| Agente personalizado (*custom agent*) | Rol, instrucciones y herramientas en Markdown | Depende de sus herramientas y límites | La persona lo selecciona; puede admitir delegación |
| Skill | Carpeta con instrucciones y recursos | No añade autonomía por sí solo | La persona o el modelo, según la configuración |
| Fichero de prompt (*prompt file*) | Una tarea reutilizable en Markdown | La del agente que lo ejecuta | La persona, con `/nombre` |

El fichero no es el modelo: la herramienta lo carga como instrucciones. Aquí usamos agentes de tutoría y revisión y skills manuales, sin variantes `.prompt.md`.

## Referencias disponibles

| Artefacto | Versión | Estado | Uso |
| --- | --- | --- | --- |
| [Tutor](artefactos/tutor/README.md) | 1.0.0 | `refined` | Ayuda gradual en las partes I y II; se instala en P2 · Ej5 |
| [Calidad](artefactos/calidad-sonarqube/README.md) | 1.0.0 | `draft` | Corregir issues de SonarQube Cloud desde la Parte III |
| [Documentación](artefactos/documentacion/README.md) | 1.0.0 | `draft` | Documentar según la configuración del repositorio |
| [Revisor del reto](artefactos/revisor-reto/README.md) | 1.0.0 | `draft` | Para Yamel: PR, demos, seguimiento y borradores de Discord |

No fijan modelo ni SDK. El reto usa .NET 10 en las partes I y II y .NET 11 desde la III.

## Cuándo merece la pena

- Documenta primero el problema, los límites y cómo probarás el resultado.
- Empieza por un prompt o chat supervisado. Una pregunta puntual no necesita un agente.
- Más autonomía requiere validar el flujo previo en dos repos distintos, con evidencia.
- Siempre hay intervención humana para decidir alcance y revisar cambios.

El tutor es un rol de lectura, no un trabajador autónomo. Ninguna referencia está certificada todavía.

## Ciclo de vida

1. **Diseño:** rellena [la plantilla breve](plantillas/diseno-agente.md).
2. **Prompt:** escribe rol, tarea, contexto, límites y salida esperada.
3. **Pruebas:** casos fijos y uno propio; guarda entrada, salida, herramienta, modelo, versión y resultado.
4. **Iteración:** cambia una cosa y repite los casos.
5. **Versión:** nueva carpeta, metadatos, cabeceras y CHANGELOG.
6. **Instalación:** PR al destino, comprobación de carga y registro de la copia efectiva.
7. **Mantenimiento:** revisa compatibilidad y deriva; una vuelta atrás también se hace por PR.

## Convenciones

- **Identificador:** nombre del catálogo, como `calidad-sonarqube`. **Canal:** imperativo inglés, como `/fix-quality`; los agentes se eligen en el selector.
- **Versionado semántico (*SemVer*):** `MAJOR.MINOR.PATCH`: cambio incompatible, capacidad compatible o corrección. Una versión publicada en `vX.Y.Z/` no se reescribe.
- **Estados:** `draft`, propuesta; `refined`, instrucciones concretadas; `certified`, pruebas con evidencia y revisión humana aprobada. El estado no sustituye a las pruebas.
- [Esquema de metadatos](esquema/metadata.schema.json) y [checklist del PR](proceso/checklist.md). `validated_repos` solo recoge evidencia real.
- Instrucciones en español; código e identificadores en inglés. El YAML decide el idioma de la documentación generada.

## Instalación manual

Cada skill se distribuye **una sola vez**, bajo `claude/.claude/skills/`. Copia su carpeta a `.claude/skills/` en el destino: la leen **Claude Code y VS Code Local**. Los agentes de Copilot van en `.github/agents/`.

Solo si usas el motor **Copilot**, añade el mismo skill a `.github/skills/`. Local lee ambas ubicaciones: duplicarlas duplica el nombre. Una copia compartida reduce la deriva porque ambas herramientas leen los mismos bytes.

Conserva la cabecera, revisa archivos existentes e instala por PR. No borres personalizaciones ajenas.

Comprueba qué fichero carga la herramienta. En [REGISTRO.md](REGISTRO.md), una fila representa un fichero instalado; indica ambos motores si comparten la copia. No se instala nada automáticamente.

## Deriva y SHA-256

La deriva (*drift*) es una diferencia entre la copia y la versión fuente que declara. La cabecera identifica la versión; **SHA-256** comprueba sus bytes.

Desde `court-connect`, con ambos repos como carpetas hermanas:

```powershell
$source = '../formacion-dotnet-junior/ai/artefactos/tutor/v1.0.0/copilot/.github/agents/guide-learning.agent.md'
$installed = '.github/agents/guide-learning.agent.md'
$sourceHash = (Get-FileHash -LiteralPath $source -Algorithm SHA256).Hash
$installedHash = (Get-FileHash -LiteralPath $installed -Algorithm SHA256).Hash
$sourceHash
$installedHash
$sourceHash -eq $installedHash
```

Debe salir `True`. Registra los 64 caracteres de `$installedHash`. Después compara **copia, versión fuente y hash registrado**; si difieren, revisa el diff. Una versión antigua intacta no tiene deriva.

El hash incluye CRLF/LF, codificación y salto final. Compruébalo tras el checkout del PR fusionado, porque Git puede convertir los finales de línea.

Las mejoras van por PR a la fuente. Publicar una versión no la instala: el registro conserva la versión realmente copiada hasta que otro PR la actualice.

## Evolución futura

Con más repos, `git subtree split --prefix=ai` permitirá trasladar la carpeta con su historial a un repo de gobierno. La sincronización se automatizará entonces, no ahora.

## Formatos consultados

Documentación oficial revisada el 30 de octubre de 2026:

| Fuente | Decisión |
| --- | --- |
| [Agentes de VS Code](https://code.visualstudio.com/docs/copilot/customization/custom-agents) y [frontmatter](https://code.visualstudio.com/docs/agents/reference/custom-agent-file-reference) | Tutor y revisor en `.github/agents/*.agent.md`, seleccionados por la persona |
| [Skills de VS Code](https://code.visualstudio.com/docs/agent-customization/agent-skills) y [Claude Code](https://code.claude.com/docs/en/skills) | `.claude/skills/` compartida con Local; `.github/skills/` adicional solo para el motor Copilot |
| [Prompts](https://code.visualstudio.com/docs/copilot/customization/prompt-files), [subagentes](https://code.claude.com/docs/en/sub-agents) y [estilos](https://code.claude.com/docs/en/output-styles) | No se distribuyen estas variantes; el tutor mantiene la conversación principal |
