# Documentación · document-repo

**v1.0.0 · draft.** Un skill configurable para documentación funcional, técnica, XML y comentarios. Sin modelo ni versión de .NET fijados. Pruebas de ejecución pendientes.

## Cuándo usarlo

Para documentar comportamiento existente y contrastarlo con especificaciones. No decide requisitos ni resuelve ejercicios abiertos.

Lee código, pruebas, specs y `docs/domain.md`; los huecos quedan como **[por confirmar]**. Las reglas detalladas de XML y revisión están en el skill.

## Instalación

Copia el [skill](v1.0.0/claude/.claude/skills/document-repo/SKILL.md) con su cabecera mediante PR:

| Motores | Ruta destino | Invocación |
| --- | --- | --- |
| Claude Code y VS Code Local | `.claude/skills/document-repo/SKILL.md` | `/document-repo` |

Solo para el motor **Copilot**, añade el mismo fichero a `.github/skills/document-repo/SKILL.md`. Local lee ambas carpetas. Una copia compartida evita nombres duplicados y reduce la deriva.

Comprueba [SHA-256](../../README.md#deriva-y-sha-256) y actualiza [REGISTRO.md](../../REGISTRO.md). Para retirar variantes antiguas, sigue [la guía de instalación](../../README.md#instalación-manual).

## Configuración YAML

La configuración vive en **`docs/documentacion.config.yml`**. Si falta, el skill pregunta y propone crearla antes de documentar. Los ejemplos no se activan automáticamente:

- [CourtConnect](v1.0.0/ejemplos/court-connect.yml): funcional en español en `docs/`, técnica en inglés en `docs/technical-doc/`, XML y comentarios en inglés.
- [Entrega ficticia](v1.0.0/ejemplos/client-delivery.yml): los cuatro tipos en catalán.

**Solo cambia el YAML, no el skill.** Cada campo lleva un comentario. Adapta las rutas de ejemplo a proyectos que existan en el destino.

### Contrato de configuración

| Campo | Significado |
| --- | --- |
| `version` | Versión del contrato YAML: `1` |
| `types` | Bloques opcionales: `functional`, `technical`, `xml`, `comments`. Un tipo omitido está desactivado |
| `enabled` | `true` activa el tipo; `false` lo desactiva |
| `language` | Idioma: `es`, `en` o `ca`; otros se acuerdan antes |
| `output` | Directorio relativo para funcional/técnica; literal `source` para XML/comentarios |
| `audience` | Público que determina vocabulario y detalle |
| `scope` | Solo XML/comentarios: proyectos incluidos, excluidos y visibilidad |
| `include_projects` / `exclude_projects` | Dentro de `scope`: listas de rutas relativas de `.csproj`; las exclusiones prevalecen |
| `visibility` | Dentro de `scope`, solo XML/comentarios: `public`, `protected`, `internal` o `private` |

`functional` y `technical` llevan solo **enabled, language, output y audience**. XML y comentarios añaden `scope`; no hay que inventar visibilidad para un documento funcional.

Para XML, incluye `public` y `protected`. Una lista de inclusión vacía, un proyecto inexistente o una salida fuera del repo requieren aclaración. Un tipo desactivado u omitido no genera, modifica ni borra documentos.

Si solo necesitas documentación funcional, conserva únicamente ese bloque. El YAML usa espacios de indentación y no traduce nombres de código.

## Validación y mantenimiento

Ejecuta [los casos fijos](v1.0.0/pruebas.md) y uno propio en Claude Code y VS Code Local. Contrasta textos con sus fuentes y revisa idioma y salida. Para XML, compara CS1591 y CS1574 antes y después.

Publica mejoras en esta fuente con nueva versión y CHANGELOG. Instalar esa versión y actualizar el registro son pasos posteriores.
