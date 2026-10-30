# Documentación · document-repo

**v1.0.0 · draft.** Un único flujo, configurable por repositorio, para documentación funcional, técnica, XML y comentarios de código. No presupone una versión de .NET, un modelo ni el idioma de entrega. Ejecución e instalación pendientes.

## Cuándo usarlo

Para documentar comportamiento y contratos que ya existen, o contrastarlos con especificaciones aprobadas. No sirve para decidir requisitos, implementar funcionalidades, resolver ejercicios abiertos ni presentar intenciones como comportamiento confirmado.

Lee código, pruebas, specs y `docs/domain.md` cuando exista. Si una fuente falta o contradice otra, lo indica y pide aclaración. Los huecos se identifican como **[por confirmar]**; no se completan con conjeturas.

## Instalación

Copia la variante elegida manteniendo ruta y cabecera, mediante PR al destino:

| Motor | Fuente del paquete | Ruta destino | Invocación |
| --- | --- | --- | --- |
| VS Code Local | [Prompt](v1.0.0/copilot/.github/prompts/document-repo.prompt.md) | `.github/prompts/document-repo.prompt.md` | `/document-repo` |
| Copilot | [Skill](v1.0.0/copilot/.github/skills/document-repo/SKILL.md) | `.github/skills/document-repo/SKILL.md` | `/document-repo` |
| Claude Code | [Skill](v1.0.0/claude/.claude/skills/document-repo/SKILL.md) | `.claude/skills/document-repo/SKILL.md` | `/document-repo` |

No dupliques prompt y skill del mismo nombre en Local. Comprueba qué fichero carga el motor y registra cada copia efectiva según [la guía SHA-256](../../README.md#deriva-y-sha-256) y [REGISTRO.md](../../REGISTRO.md).

## Configuración YAML

La configuración del destino vive en **`docs/documentacion.config.yml`**. No se instala una configuración global ni se activa un ejemplo automáticamente. Si falta, el flujo pregunta por los tipos, idiomas, salidas, públicos y proyectos; propone crearla y espera acuerdo antes de documentar.

Los ejemplos comentan cada campo y se pueden copiar al destino tras revisarlos:

- [CourtConnect](v1.0.0/ejemplos/court-connect.yml): funcional en español en `docs/`; técnica en inglés en `docs/technical-doc/`; XML y comentarios en inglés.
- [Entrega ficticia](v1.0.0/ejemplos/client-delivery.yml): los cuatro tipos en catalán. No representa a ningún cliente real.

**La definición del artefacto no cambia entre estos casos; solo cambia el YAML.** Las rutas de proyectos de ejemplo son patrones, no afirmaciones sobre una solución real. Hay que comprobar sus coincidencias antes de generar documentación.

### Contrato de configuración

| Campo | Significado |
| --- | --- |
| `version` | Versión del contrato YAML, actualmente `1`; no es la versión del artefacto |
| `types` | Contiene los cuatro bloques: `functional`, `technical`, `xml` y `comments` |
| `enabled` | Booleano `true`/`false`; si es `false`, no genera ni modifica ese tipo |
| `language` | Idioma del texto generado: `es`, `en` o `ca` en estos ejemplos; cualquier otro requiere acordarlo |
| `output` | Para funcional/técnica, directorio relativo al repo; para XML/comentarios, literal `source`, que significa el archivo C# original |
| `audience` | Público del documento; orienta vocabulario, detalle y contexto |
| `scope` | Alcance explícito por proyectos y visibilidad |
| `include_projects` | Lista de globs relativos a la raíz que seleccionan `.csproj`; `/` como separador, `*` un segmento y `**` recursivo |
| `exclude_projects` | Lista de globs excluidos; gana frente a inclusión. `[]` significa ninguna exclusión adicional |
| `visibility` | Lista no vacía de `public`, `protected`, `internal` o `private`; aplica a los símbolos documentados, no concede permisos |

Todos los campos de cada bloque son obligatorios, incluso si está desactivado. No hay valores por defecto implícitos. `include_projects: []`, tipos desconocidos, claves duplicadas, una salida absoluta/fuera del repo o un patrón sin coincidencias son motivos para parar y preguntar. No se modifica el YAML para forzar coincidencias.

En XML se deben incluir `public` y `protected`; `protected` incluye los accesos combinados que contienen ese modificador. La visibilidad efectiva tiene en cuenta el tipo contenedor y el contrato público de una implementación explícita de interfaz. El alcance no autoriza cambios en fuentes generadas o de terceros. La configuración no es un comando ejecutable.

El YAML usa espacios, nunca tabuladores de indentación. Se valida con un parser YAML y el contrato anterior antes de actuar; no se añade un esquema opcional por ahora. No cambies identificadores ni firmas al traducir documentación: los existentes se conservan y los ejemplos nuevos usan identificadores en inglés.

## Validación y mantenimiento

Ejecuta [los casos fijos](v1.0.0/pruebas.md) y uno propio por canal. Para XML, compara diagnósticos antes/después con generación de documentación habilitada: revisa CS1591 y CS1574 en el alcance, sin suprimirlos ni cambiar el proyecto por defecto. Para cambios solo documentales fuera de C#, revisa fuentes, enlaces y salida configurada.

Una compilación correcta no garantiza que una descripción sea cierta: contrástala con código y requisitos. La mejora se publica aquí en una nueva versión con CHANGELOG; las copias y sus hashes se actualizan después por PR.
