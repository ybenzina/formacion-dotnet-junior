# Documentación · document-repo

**v2.0.0 · draft.** Un skill configurable para documentación funcional, técnica y de código (cabeceras XML y comentarios del porqué). Sin modelo ni versión de .NET fijados. Pruebas de ejecución pendientes. El contrato de configuración cambió respecto a la v1: mira [cómo migrar](#migrar-desde-version-1).

## Cuándo usarlo

Para documentar comportamiento existente y contrastarlo con especificaciones. No decide requisitos ni resuelve ejercicios abiertos.

Lee código, pruebas, specs y `docs/domain.md`; los huecos quedan como **[por confirmar]**. Las reglas detalladas de las cabeceras XML y de revisión están en el skill.

## Instalación

Copia el [skill](v2.0.0/claude/.claude/skills/document-repo/SKILL.md) con su cabecera mediante PR:

| Motores | Ruta destino | Invocación |
| --- | --- | --- |
| Claude Code y VS Code Local | `.claude/skills/document-repo/SKILL.md` | `/document-repo` |

Solo para el motor **Copilot**, añade el mismo fichero a `.github/skills/document-repo/SKILL.md`. Local lee ambas carpetas. Una copia compartida evita nombres duplicados y reduce la deriva.

Comprueba [SHA-256](../../README.md#deriva-y-sha-256) y actualiza [REGISTRO.md](../../REGISTRO.md). Para retirar variantes antiguas, sigue [la guía de instalación](../../README.md#instalación-manual).

## Configuración YAML

La configuración vive en **`docs/documentacion.config.yml`**. Si falta, el skill pregunta y propone crearla antes de documentar. Los ejemplos no se activan automáticamente:

- [CourtConnect](v2.0.0/ejemplos/court-connect.yml): funcional en español en `docs/`, técnica en inglés en `docs/technical/`, código (XML y comentarios) en inglés.
- [Entrega ficticia](v2.0.0/ejemplos/client-delivery.yml): los tres tipos en catalán.

**Solo cambia el YAML, no el skill.** Cada campo lleva un comentario. Adapta las rutas de ejemplo a proyectos que existan en el destino.

### Contrato de configuración

| Campo | Significado |
| --- | --- |
| `version` | Versión del contrato YAML: `2` |
| `types` | Bloques opcionales: `functional`, `technical`, `code`. Un tipo omitido está desactivado |
| `enabled` | `true` activa el tipo; `false` lo desactiva |
| `language` | Idioma: `es`, `en` o `ca`; otros se acuerdan antes |
| `output` | Solo `functional` y `technical`: directorio relativo donde se escriben los Markdown. `code` no lo lleva: siempre escribe en el código fuente |
| `audience` | Público que determina vocabulario y detalle |
| `xml_comments` | Solo `code`. `true` escribe cabeceras `///` de tipos y miembros |
| `inline_comments` | Solo `code`. `true` añade comentarios `//` que explican el porqué de una decisión |
| `scope` | Solo `code`: proyectos incluidos, excluidos y visibilidad |
| `include_projects` / `exclude_projects` | Dentro de `scope`: listas de rutas relativas de `.csproj`; las exclusiones prevalecen |
| `visibility` | Dentro de `scope`: miembros que llevan cabecera XML (`public`, `protected`, `internal` o `private`). Con `xml_comments: true` debe incluir `public` y `protected`. No afecta a los comentarios `//` |

`functional` y `technical` llevan solo **enabled, language, output y audience**. `code` añade `xml_comments`, `inline_comments` y `scope`, y no lleva `output`; no hay que inventar visibilidad para un documento funcional.

Los dos modos de `code` son independientes: con uno en `false`, ese modo no genera, modifica ni borra nada. Una lista de inclusión vacía, un proyecto inexistente o una salida fuera del repo requieren aclaración. Un tipo desactivado u omitido no genera, modifica ni borra documentos.

Si solo necesitas documentación funcional, conserva únicamente ese bloque. El YAML usa espacios de indentación y no traduce nombres de código.

### Migrar desde `version: 1`

El contrato 1 tenía cuatro tipos (`functional`, `technical`, `xml`, `comments`). El 2 junta `xml` y `comments` en `code`, porque los nombres eran poco descriptivos. Si el skill encuentra un fichero con `version: 1`, no lo usa: explica el cambio, muestra esta equivalencia y propone migrarlo. **No migra sin tu acuerdo.**

| Contrato 1 | Contrato 2 |
| --- | --- |
| `version: 1` | `version: 2` |
| Bloque `xml` | `code` con `xml_comments: true` |
| Bloque `comments` | `code` con `inline_comments: true` |
| `output: source` | Desaparece: `code` siempre escribe en el código |
| `scope` de `xml` y de `comments` | Un único `scope` en `code`: se unen los proyectos y se conserva la `visibility` de `xml` |
| `functional` y `technical` | Sin cambios |

## Validación y mantenimiento

Ejecuta [los casos fijos](v2.0.0/pruebas.md) y uno propio en Claude Code y VS Code Local. Contrasta textos con sus fuentes y revisa idioma y salida. Para las cabeceras XML, compara CS1591 y CS1574 antes y después.

Publica mejoras en esta fuente con nueva versión y CHANGELOG. Instalar esa versión y actualizar el registro son pasos posteriores.
