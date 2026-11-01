# Changelog

## 2.0.0

- **MAJOR: cambia el contrato de configuración.** Un `docs/documentacion.config.yml` con `version: 1` ya no se interpreta con este skill: hay que migrarlo. Por eso es un cambio incompatible y no MINOR.
- Los bloques `xml` y `comments`, poco descriptivos, se unen en un único bloque `code`, con `xml_comments` (cabeceras `///`) e `inline_comments` (comentarios `//` del porqué). `code` no lleva `output`: siempre escribe en el código. El contrato pasa a `version: 2` y a tres tipos: `functional`, `technical` y `code`.
- Un único `scope` para `code`. `visibility` solo limita las cabeceras XML; con `xml_comments: true` debe incluir `public` y `protected`.
- Si encuentra `version: 1`, el skill explica el cambio, muestra la equivalencia (`xml` + `comments` → `code`) y propone migrar; no migra sin acuerdo.
- Se mantienen las reglas de calidad de las cabeceras XML y de los comentarios del porqué de la v1.0.0.
- Ejemplos reescritos con un comentario por campo que se entiende sin leer el skill. Nuevos casos D16 (`version: 1`) y D17 (modos independientes y visibilidad). Estado `draft`; pruebas de ejecución pendientes.

## 1.0.0

- Primera referencia configurable para cuatro tipos de documentación: funcional, técnica, XML y comentarios.
- Contrato YAML comentado en `docs/documentacion.config.yml`, con ejemplos independientes del artefacto para CourtConnect y una entrega ficticia en catalán.
- Tipos omitidos desactivados; alcance de proyectos y visibilidad solo para XML y comentarios.
- Reglas semánticas de XML, límites de `inheritdoc`, fuentes comprobables y revisión de CS1591/CS1574.
- Un skill manual compartido por Claude Code y VS Code Local, sin variantes duplicadas; copia adicional solo si se usa el motor Copilot. Estado `draft`; pruebas de ejecución e instalación pendientes.
