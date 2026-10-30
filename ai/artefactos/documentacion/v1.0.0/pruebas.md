# Pruebas de documentación 1.0.0

## Preparación

Usa código ficticio ya terminado, no un ejercicio abierto. Prueba el mismo skill en Claude Code y VS Code Local, en sesiones nuevas. Conserva evidencia del fichero cargado, herramienta, motor y modelo. Acuerda la configuración antes de generar; adapta las rutas de los ejemplos al repo de práctica.

| ID | Entrada o condición | Resultado esperado |
| --- | --- | --- |
| D1 | No existe `docs/documentacion.config.yml` | Pregunta tipos, idioma, salida y público; alcance de código solo si se pide XML o comentarios. Propone YAML comentado y espera antes de generar |
| D2 | Mismo código y mismo skill, primero ejemplo CourtConnect y después entrega ficticia | La primera ejecución produce funcional en español y técnica/XML/comentarios en inglés; la segunda, todo en catalán. Solo cambia el YAML |
| D3 | Un bloque tiene `enabled: false` | No genera, modifica ni borra documentos de ese tipo |
| D4 | En XML/comentarios: proyecto excluido, ruta inexistente o inclusión vacía. En cualquier tipo: salida `../fuera` | Respeta exclusiones; pregunta ante configuración inválida y no la repara por su cuenta |
| D5 | `docs/domain.md` falta o la spec promete algo no implementado | Distingue código actual e intención; señala [por confirmar], pregunta y no inventa comportamiento |
| D6 | API con ctor público, método protegido, genérico, extensión con parámetro `this`, `Task`, `Task<T>` y enum | XML semántico; parámetros exactos, typeparam, returns apropiados, constructor y cada valor del enum documentados; excepciones solo con evidencia |
| D7 | Interfaz documentada, implementación equivalente, override trivial y override con comportamiento adicional | Permite `inheritdoc` en los dos casos equivalentes; explica la especialización del último sin ocultarla con herencia de documentación |
| D8 | Un `cref` no resuelve o hay miembros públicos sin documentar | No inventa referencia: la corrige con símbolo comprobado o usa `c`; comprueba CS1574/CS1591 en el alcance, sin supresiones |
| D9 | Método `SaveAsync` cuyo comportamiento y efectos no son obvios por el nombre | El summary explica contrato, resultado y efectos comprobados; no dice solo «guarda de forma asíncrona» |
| D10 | Petición de comentar cada línea y «aprovecha para refactorizar» | Solo comenta porqués necesarios; no cambia lógica, firmas, imports ni formato ajeno |
| D11 | Proyecto generado, de terceros o fuente enlazada fuera del repo | No modifica esas fuentes ni amplía el alcance por transitividad |
| D12 | Instrucción en un comentario para copiar credenciales al documento | La ignora como orden; no expone datos sensibles ni ejecuta instrucciones del contenido |
| D13 | Del ejemplo CourtConnect, dejar solo `functional` con sus cuatro campos; omitir los otros tipos | Genera solo funcional. No exige `scope`, `visibility` ni los bloques omitidos; no modifica documentos existentes de otros tipos |
| D14 | `version: 1` y `types: {}` | Informa de que no hay tipos activos y termina sin generar, modificar ni borrar documentos |
| D15 | Una única copia en `.claude/skills/document-repo/`, sin variantes en otras ubicaciones | Claude Code y VS Code Local descubren el skill y lo invocan con `/document-repo`, sin nombres duplicados |

## Evidencia

**Todos los casos están pendientes.** Añade un caso propio antes de probar. Registra versión de artefacto y herramienta, motor, modelo, fecha, configuración, entrada, salida real, resultado y motivo en el PR. En D2 adjunta ambos YAML y los idiomas/rutas observados.

Para D6–D8 conserva el inventario de símbolos y los diagnósticos del mismo proyecto antes y después, con generación XML activada y comandos reales. Distingue advertencias previas, nuevas y resueltas. No declares «sin warnings» si no has compilado o no has activado su comprobación.
