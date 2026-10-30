# Checklist de una referencia de IA

Úsala en el PR de la fuente. Marca solo lo comprobado y adjunta la evidencia; lo pendiente queda sin marcar.

## Diseño y límites

- [ ] Problema repetido y usuarios definidos en el README o en la plantilla de diseño.
- [ ] Se ha explicado por qué basta un prompt o skill, o por qué hace falta un agente.
- [ ] Entradas, salida, acciones permitidas, prohibiciones y parada humana claras.
- [ ] Respeta las instrucciones del destino, el modo tutor y los límites de SDD.
- [ ] No contiene secretos, datos reales ni referencias privadas de otros proyectos.

## Formato y versión

- [ ] Ubicación y frontmatter contrastados con documentación oficial, con URL y fecha.
- [ ] Metadatos válidos contra `ai/esquema/metadata.schema.json`; rutas y nombre de canal coherentes.
- [ ] Nueva carpeta de versión, CHANGELOG y cabecera de procedencia en cada instalable.
- [ ] Todos los canales conservan el mismo comportamiento, salvo diferencias documentadas de la herramienta.
- [ ] Enlaces comprobados, YAML con espacios de indentación y sintaxis válida, sin alterar los finales de línea existentes.
- [ ] No se ha cambiado una versión ya publicada ni la configuración del destino sin aprobación.

## Pruebas y revisión

- [ ] Casos fijos: nominal, límite, error y negativa; en tutoría, también varios turnos.
- [ ] Cada canal probado en sesión nueva, con entradas fijas y un caso propio.
- [ ] Resultados reales registrados: versión del artefacto y herramienta, motor, modelo, fecha, entrada, salida y aprobado/fallido.
- [ ] Misma batería antes y después del cambio; las negativas y paradas siguen funcionando.
- [ ] No se ha confundido validez de YAML/JSON con calidad del comportamiento del modelo.
- [ ] Revisión humana aprobada antes de declarar `certified`.
- [ ] Si se aumenta la autonomía: evidencia del flujo previo en dos repos distintos y plan de vuelta atrás.

## Instalación y mantenimiento

- [ ] Copia revisada e instalada por PR, sin comandos duplicados ni sobrescrituras ocultas.
- [ ] Hash de copia, fuente y registro coincidentes tras el checkout del destino.
- [ ] Registro actualizado solo tras la instalación efectiva, con SHA-256, fecha y persona reales.
- [ ] Las mejoras locales se han propuesto primero a la fuente, con nueva versión.
- [ ] PR con «Qué cambia», «Por qué», «Cómo se ha comprobado» y «Uso de IA».
