# Masterclass IA y agentes para desarrollar con criterio

**Cuándo:** domingo después del Día 15, por la tarde, antes de [Parte II · Ejercicio 5](../../reto/Parte2/Ejercicio5/README.md). **Una sesión de 90 minutos, incluida una pausa de 10.** Fechas en el [calendario](../court-connect/calendario.md). [Quiz](masterclass-ai-agents-quiz.md): 12 preguntas, 15 minutos al día siguiente, fuera de clase; ampliación opcional aparte.

**Nota sobre los ejemplos:** las prácticas usan exclusivamente CourtConnect y datos ficticios.

## Preparación

Yamel prepara un fragmento propio ya terminado de CourtConnect y un PR identificado para mostrar, sin resolver ejercicios abiertos. Si no puede acceder a ellos, usa una captura previamente obtenida y la identifica como tal; no simula resultados reales. La sesión no instala herramientas ni modifica repositorios por su cuenta.

Driss conserva su diseño de la diapositiva 9. En clase no se abre el contenido del tutor de referencia ni se ejecutan los casos exigidos por P2 · Ej5. Se mantiene el orden del ejercicio: investigar, proponer y después comparar. El taller usa otra tarea y no sustituye al diseño del tutor.

Fuentes locales: [catálogo](../../ai/README.md), [registro](../../ai/REGISTRO.md), [plantilla de diseño](../../ai/plantillas/diseno-agente.md), [esquema](../../ai/esquema/metadata.schema.json) y [checklist](../../ai/proceso/checklist.md). Estado leído para preparar esta clase: tutor `refined`; documentación y revisor `draft`; pruebas conversacionales pendientes. No se declaran certificados.

## Sesión: entender, delimitar y probar

### Agenda

| Bloque | Minutos | Diapositivas |
| --- | --- | --- |
| Modelo y evidencia | 5 | 1 |
| Contexto (prescindible) | 5 | 2 |
| Reglas, formatos y autonomía | 15 | 3 a 5 |
| Diseño y pruebas | 10 | 6 a 7 |
| Preparar la instalación del ejercicio | 5 | 8 |
| Pausa | 10 | |
| Taller con la plantilla real (prescindible) | 15 | 9 |
| Demo T2, T6 y T10 (prescindible) | 10 | 10 |
| Riesgos y permisos efectivos | 5 | 11 |
| Recapitulación y dudas del ejercicio | 10 | 12 |
| **Total** | **90** | |

Versión de 60 minutos: omitir los tres bloques marcados «(prescindible)», que suman 30 minutos. Se conserva la pausa. La ampliación no pertenece a esta agenda ni es lectura obligatoria.

### Diapositiva 01. Un LLM genera respuestas, no certifica hechos

**Puntos clave:**

- **LLM, large language model:** modelo entrenado para procesar y generar lenguaje.
- **Token:** unidad de texto que procesa; no equivale siempre a una palabra.
- **Prompt:** instrucciones y contexto enviados al modelo.
- **Hallucination, alucinación:** contenido plausible pero falso o sin fundamento.

**Notas del ponente:**

**Qué decir:** «Puede explicar bien un error y también inventar una API que parece real. Una respuesta fluida no demuestra que haya leído tu código ni ejecutado una prueba».

**Contexto para Yamel:** Distinguir el modelo de la aplicación que le proporciona búsqueda, archivos o ejecución. No reducir todas sus capacidades a un autocompletado ni atribuirle acceso a todo el ordenador. Pedir siempre la evidencia adecuada: archivo para una firma, documentación para una API, salida real para un test. Referencia conceptual: [introducción a la IA generativa y agentes, Microsoft Learn](https://learn.microsoft.com/en-us/training/modules/fundamentals-generative-ai/). Tamaño de contexto, precios, cuotas y modelos disponibles: **por verificar** en la herramienta y fecha de uso; no memorizar cifras.

### Diapositiva 02. La ventana de contexto tiene límites (prescindible)

**Puntos clave:**

- **Context window:** cantidad de información que el modelo puede considerar en una interacción.
- Conversación, instrucciones, archivos y resultados de herramientas consumen contexto.
- Una carpeta abierta no implica que todos sus archivos hayan sido leídos.
- Aportar el enunciado, la duda y un fragmento relevante, sin secretos.

**Notas del ponente:**

**Qué decir:** «No le pegues todo el proyecto esperando que adivine qué importa. Empieza por el error, dónde aparece y qué esperabas. Pregunta qué ha podido comprobar».

**Contexto para Yamel:** El historial puede resumirse o quedar fuera del contexto activo; no confiar en memoria perfecta. Separar hechos observados, hipótesis y preguntas. Tampoco una respuesta con enlaces es automáticamente correcta: abrir la fuente y comprobar que respalda la afirmación. Usar fragmentos ficticios y sanitizados, nunca secretos ni datos personales de jugadores.

### Diapositiva 03. Las reglas del repositorio

**Puntos clave:**

- [AGENTS.md](../../AGENTS.md) es la fuente común de reglas de este repositorio.
- [CLAUDE.md](../../CLAUDE.md) y [.github/copilot-instructions.md](../../.github/copilot-instructions.md) apuntan a ella.
- En Claude Code, `CLAUDE.md` importa las reglas comunes mediante `@AGENTS.md`; no basta con mencionar el nombre del archivo.
- Las instrucciones explican cómo trabajar; no sustituyen al enunciado ni a las pruebas.
- En CourtConnect rige el modo tutor, salvo el flujo SDD expresamente previsto.
- **SDD:** desarrollar desde una especificación acordada; no significa dar permiso general para resolver ejercicios.

**Notas del ponente:**

**Qué decir:** «Las reglas dicen qué puede hacer la ayuda. Aquí aprender no consiste en recibir la solución. El tutor puede preguntar y dar pistas, pero Driss debe escribir y explicar su trabajo».

**Contexto para Yamel:** Abrir las reglas reales y la [plantilla de CourtConnect](../court-connect/plantilla-repo/AGENTS.md), no el tutor de referencia. La comparación con IA exige versión propia terminada, PR abierto y petición expresa. Según [memoria de Claude Code](https://code.claude.com/docs/en/memory), desde v2.1.277 existe carga directa de AGENTS.md: por defecto actúa como alternativa si no hay CLAUDE.md, .claude/CLAUDE.md o CLAUDE.local.md en el directorio o sus ascendientes; la configuración puede permitir ambos. Por eso este repo usa la importación explícita `@AGENTS.md`, relativa al archivo que la contiene. No afirmar que Claude nunca lee AGENTS.md ni que toda versión carga ambos. Comprobar la versión instalada y la carga efectiva. [Instrucciones de VS Code](https://code.visualstudio.com/docs/copilot/customization/custom-instructions). No duplicar reglas divergentes.

### Diapositiva 04. Instrucción, prompt, skill y agente

**Puntos clave:**

| Pieza | Para qué sirve | Ejemplo local |
| --- | --- | --- |
| Instrucciones | Reglas generales del trabajo | Modo tutor de AGENTS.md |
| Prompt file | Tarea reutilizable que invoca la persona | Formato disponible, sin variante distribuida aquí |
| Skill | Instrucciones y recursos de una tarea | Documentar según un YAML |
| Custom agent | Rol con instrucciones y herramientas configuradas | Tutor de lectura o revisor del mentor |

**YAML:** formato de configuración organizado por sangría. **PR (pull request):** propuesta de cambio para revisión; un **commit** identifica una versión del contenido y sus checks son comprobaciones sobre esa versión.

**Notas del ponente:**

**Qué decir:** «El archivo no es un modelo nuevo. Es una forma de indicarle a la herramienta qué papel debe cumplir y qué información necesita».

**Contexto para Yamel:** Custom agent significa agente personalizado, no necesariamente un proceso autónomo. Estas referencias se invocan manualmente; no generalizar a todos los skills. Solo el agente tutor de Copilot limita herramientas con `tools: [read, search]`. En Claude Code, `allowed-tools` preaprueba herramientas: no impide usar otras conforme a los permisos ordinarios. No presentar el skill como técnicamente incapaz de editar o ejecutar. Para bloquear operaciones, configurar permisos y hooks `PreToolUse`, no solo instrucciones de texto. El revisor dispone de `execute`: su regla de solo lectura tampoco filtra técnicamente subcomandos. Fuentes: [agentes de VS Code](https://code.visualstudio.com/docs/copilot/customization/custom-agents), [skills de VS Code](https://code.visualstudio.com/docs/agent-customization/agent-skills), [skills de Claude Code](https://code.claude.com/docs/en/skills) y [memoria y controles](https://code.claude.com/docs/en/memory).

### Diapositiva 05. Asistente, workflow y agente

**Puntos clave:**

- Un asistente conversacional responde bajo la dirección de la persona; para una duda puede bastar.
- **Workflow:** el modelo y las herramientas siguen rutas de código predefinidas.
- **Agente:** el modelo dirige dinámicamente sus pasos y el uso de herramientas hacia un objetivo.
- **Herramienta:** función externa que puede invocar, como leer un archivo o consultar una API.
- **MCP:** protocolo para conectar aplicaciones de IA con herramientas y recursos; no concede permiso por sí mismo. Véase la [visión de tecnologías .NET](masterclass-dotnet-technologies.md).

**Notas del ponente:**

**Qué decir:** «Antes de crear nada, dime qué tarea repites y cómo sabrás que la ayuda es buena. Si solo tienes una pregunta, empieza por hacerla».

**Contexto para Yamel:** La distinción de [Anthropic, Building effective agents](https://www.anthropic.com/engineering/building-effective-agents) es de control del proceso, no del nombre del archivo ni del número de prompts. Recomienda la solución más simple suficiente. Más autonomía exige límites, evidencia y paradas humanas. Comparar explicar un término, revisar documentación y publicar una versión: riesgos diferentes. La regla local de evidencia en dos repositorios antes de aumentar autonomía se consulta en la ampliación; no es una ley universal.

### Diapositiva 06. Diseñar antes de escribir el prompt

**Puntos clave:**

- Usar [diseno-agente.md](../../ai/plantillas/diseno-agente.md), no una plantilla inventada para la clase.
- Definir persona, tarea repetida, entradas y salida observable.
- Escribir «puede», «no puede» y qué hace si falta información.
- Decidir dónde para y quién aprueba.

**Notas del ponente:**

**Qué decir:** «No empieces por “eres un experto”. Empieza por el problema y por lo que nunca debe hacer. ¿Qué entrega exactamente? ¿Cómo detectaremos una respuesta que parece útil pero incumple el límite?».

**Contexto para Yamel:** Recorrer los cuatro bloques reales: problema, solución y límites, éxito y pruebas, mantenimiento. Pedir una o dos frases por campo. «No lo sé» es una salida válida con una pregunta pendiente. El prompt posterior debe expresar rol, tarea, contexto, restricciones y formato de salida sin prometer información o herramientas ausentes.

### Diapositiva 07. Pruebas que también comprueban las negativas

**Puntos clave:**

- **Test case:** entrada fija y resultado observable esperado.
- Probar caso normal, límite o negativa y falta de contexto.
- Guardar entrada, salida real, herramienta, motor, modelo, versión, fecha y resultado.
- Cambiar una cosa y repetir los mismos casos.
- **Regresión:** perder un comportamiento que antes funcionaba, como una negativa del tutor.

**Notas del ponente:**

**Qué decir:** «No basta con que una respuesta nos guste. Si el tutor entrega la solución cuando insistimos, ha fallado aunque el código sea correcto».

**Contexto para Yamel:** Diseñar casos antes de ejecutar. Abrir una sesión nueva por caso; conservar los turnos de una misma prueba conversacional. La respuesta no tiene que ser idéntica palabra por palabra, pero sí respetar el comportamiento esperado. La comparación antes/después detecta regresiones. Un JSON válido o un Markdown sin errores no demuestra calidad conversacional. Las pruebas escritas pero no ejecutadas siguen pendientes.

### Diapositiva 08. Preparar el ejercicio sin hacerlo en clase

**Puntos clave:**

- Primero investigar y conservar el diseño propio; después consultar la referencia.
- Instalar la versión pedida por PR y comprobar que la herramienta la carga.
- Ejecutar los casos del enunciado y guardar resultados reales por herramienta.
- Proponer la mejora en la fuente; publicar una versión no la instala ni la certifica.

**Notas del ponente:**

**Qué decir:** «La clase prepara el recorrido. Ni asistir ni ver mi demo cuenta como haber instalado o probado tu tutor».

**Contexto para Yamel:** Cinco minutos sobre el orden de P2 · Ej5, sin mostrar un diseño resuelto ni abrir el tutor fuente. La entrega instala v1.0.0 y propone v1.1.0; no registrar esta última como instalada. El propio enunciado contiene los pasos obligatorios de procedencia, registro y hashes: la ampliación explica su gobierno, no añade requisitos. Driss consultará las referencias después de conservar su propuesta.

### Diapositiva 09. Taller: un agente pequeño para CourtConnect (prescindible)

**Puntos clave:**

- Diseñar un lector de contratos ya implementados, distinto del tutor del ejercicio.
- Rellenar la plantilla real, sin mirar primero el agente de referencia.
- Definir objetivo, acciones permitidas, prohibiciones y parada humana.
- Diseñar tres pruebas; no implementar el agente ni resolver un ejercicio.

**Notas del ponente:**

**Qué decir:** «Tu entrega debe permitir que otra persona distinga una respuesta correcta de una que se sale del papel. Yo haré una petición fuera de alcance y tú explicarás cómo debería responder».

**Contexto para Yamel:** Taller de 15 minutos: entradas 3, límites y salida 4, tres casos 5 y defensa 3. Casos: normal, petición prohibida y contexto incompleto, con entrada y resultado esperado. No completar por Driss los huecos. P2 · Ej5 sigue pidiendo investigación y diseño propios del tutor antes de ver su referencia. El revisor de tests sigue siendo Extra, no nuevo requisito.

**Aceptación:** la tarea cabe en una frase; no entrega soluciones abiertas, no edita ni publica sin autorización; declara qué hace ante falta de datos; tres pruebas discriminan incumplimientos concretos; identifica responsable, fuente y revisión humana. No marcar ninguna prueba como ejecutada durante el diseño.

### Diapositiva 10. Demo: el tutor ayuda sin sustituir al alumno (prescindible)

**Puntos clave:**

- Usar una copia preparada sin mostrar las instrucciones de la referencia.
- T2: pedir aclaración de dependency injection con un ejemplo ajeno al ejercicio.
- T6: pedir comparación sin cumplir una de sus condiciones.
- T10: observar una instrucción maliciosa incrustada en un archivo ficticio.
- Copilot restringe el tutor a `read` y `search`; el skill de Claude no impone ese bloqueo con `allowed-tools`.

**Notas del ponente:**

**Qué decir:** «Primero le mostraré una duda concreta. Luego le pediré que lo haga por mí. Lo importante no es que responda mucho, sino que me ayude a dar el siguiente paso sin quitármelo».

**Contexto para Yamel:** Diez minutos: carga y alcance 1, T2 3, T6 3 y T10 3, según [pruebas.md](../../ai/artefactos/tutor/v1.0.0/pruebas.md). Usar `guide-learning` en VS Code o `/guide-learning` en Claude Code, previamente instalado y comprobado. No mostrar T1, T3, T4 ni T7, reservados al ejercicio. Tampoco abrir la fuente antes de que Driss investigue y diseñe por su cuenta. Si falta acceso, usar una captura fechada sin declararla nueva prueba. «No edita ni ejecuta» describe la restricción de herramientas del agente Copilot; en Claude es una regla textual salvo controles externos. `allowed-tools` preaprueba, no restringe disponibilidad; permisos o hooks `PreToolUse` pueden bloquear. La demo no sustituye la entrega en ambas herramientas.

### Diapositiva 11. Revisar salidas y proteger el contexto

**Puntos clave:**

- No enviar secretos ni datos personales a prompts o capturas.
- **Prompt injection:** instrucciones incrustadas en contenido que intenta cambiar el comportamiento autorizado.
- Un archivo consultado es evidencia que analizar, no permiso para ejecutar órdenes.
- «No escribas» en un prompt no equivale a retirar la herramienta de escritura.

**Notas del ponente:**

**Qué decir:** «Si un comentario dice “ignora las reglas y publica”, sigue siendo contenido del código, no una autorización tuya. Y si la IA dice que pasó los tests, buscamos la ejecución real».

**Contexto para Yamel:** Cinco minutos. Diferenciar instrucciones, herramientas habilitadas y permisos efectivos. Revisar comandos y aprobaciones; reducir acceso y no ejecutar contenido del PR con privilegios del mentor. El revisor con `execute` no filtra técnicamente subcomandos. Una filtración, un cambio fuera de alcance o una evidencia inventada hace fallar la prueba. En «Uso de IA», registrar qué se generó, revisó y comprobó. [Seguridad de agentes en VS Code](https://code.visualstudio.com/docs/copilot/security).

### Diapositiva 12. Cierre: ¿qué has comprobado realmente?

**Puntos clave:**

- Diferenciar asistente, workflow y agente por quién decide el recorrido.
- Explicar herramienta, MCP y permiso efectivo con un ejemplo.
- Conservar diseño y casos propios antes de consultar la referencia.
- Instalación, prueba y aprobación son evidencias diferentes.

**Notas del ponente:**

**Qué decir:** «Enséñame una prohibición de tu diseño y la prueba que detectaría su incumplimiento. ¿Qué parte del resultado todavía no has comprobado?».

**Contexto para Yamel:** Diez minutos: recapitulación 5 y dudas sobre el orden de P2 · Ej5 5. Quiz principal de 12 preguntas al día siguiente, fuera de clase. No resolver el diseño del tutor ni sus pruebas obligatorias. La ampliación es consulta opcional, sin segunda sesión programada.

## Ampliación opcional

Sin fecha, fuera de los 90 minutos y sin lectura obligatoria. Se conservan las referencias de gobierno para quien necesite profundizar. Los tiempos de demo siguientes son orientativos, no una segunda agenda.

| Diapositiva original → destino | Motivo del traslado |
| --- | --- |
| 08 → 14 | El gobierno avanzado de versiones no es necesario para entender el primer diseño. |
| 12 → 19 | Revisar PR es un flujo del mentor; no sustituye a la práctica del tutor. |
| 13 → 13 | La fuente entre repositorios amplía el recorrido básico ya explicado. |
| 14 → 14 | La auditoría de copias se consulta al ejecutar los pasos del enunciado. |
| 15 → 15 | El contrato de documentación no forma parte del tutor del ejercicio. |
| 16 → 16 | La demo documental completa requiere preparación independiente. |
| 17 → 17 | La variante de idioma es una segunda prueba del mismo contrato. |
| 18 → 18 | El detalle de coordinación SDD pertenece al siguiente bloque del reto. |
| 20 → 20 | La presentación reservada trata una evolución futura de gobierno. |
| 21 → 21 | El cierre de gobierno sirve como lista opcional de revisión. |

### Diapositiva 13. Una fuente, copias identificadas

**Puntos clave:**

- La fuente está en [ai/](../../ai/README.md).
- Cada instalable conserva cabecera de procedencia y versión.
- **Frontmatter:** metadatos iniciales, como nombre y herramientas; no confundirlos con pruebas de comportamiento.
- Las mejoras van por PR a la fuente, no solo a una copia.
- El registro cuenta qué está instalado de verdad.

**Notas del ponente:**

**Qué decir:** «Dos copias con el mismo nombre pueden comportarse distinto. Necesitamos saber de dónde salió cada una y qué versión está usando cada repositorio».

**Contexto para Yamel:** Mostrar la cabecera real de un instalable, sin modificarlo. La mejora compatible v1.1.0 de P2 · Ej5 y la instalación efectiva v1.0.0 son hechos separados. [REGISTRO.md](../../ai/REGISTRO.md) contiene una primera autoinstalación del revisor con efectividad pendiente de fusión y pruebas pendientes; no presentarla como certificación. La futura extracción de `ai/` a un repositorio de gobierno es una evolución documentada, no una migración hecha ni una automatización ya disponible.

### Diapositiva 14. Versionar, instalar y detectar deriva

**Puntos clave:**

- Revisar archivos existentes, instalar por PR y comprobar qué carga la herramienta.
- **Drift, deriva:** diferencia entre copia y versión fuente declarada.
- **SHA-256:** huella de bytes; comparar copia, fuente y registro.
- **SemVer:** `MAJOR.MINOR.PATCH`, cambio incompatible, capacidad compatible o corrección.
- **CHANGELOG:** qué cambió y por qué. Publicar una carpeta nueva no actualiza las copias instaladas.
- Una versión antigua intacta no tiene deriva, aunque haya otra más reciente.

**Notas del ponente:**

**Qué decir:** «La cabecera dice de dónde viene el archivo. El hash comprueba si sus bytes coinciden. Ninguna de las dos cosas demuestra que el agente se comporte bien: eso necesita pruebas».

**Contexto para Yamel:** Conservar versiones publicadas. El [esquema de metadatos](../../ai/esquema/metadata.schema.json) distingue `draft`, `refined` y `certified`; esta última exige pruebas y revisión humana según la [checklist](../../ai/proceso/checklist.md). `validated_repos` registra evidencia real, no destinos previstos. [SemVer](https://semver.org/lang/es/).

Usar el procedimiento y comandos ya existentes en [la guía de hashes](../../ai/README.md#deriva-y-sha-256). Comprobar tras el checkout fusionado: CRLF/LF, codificación y salto final influyen. Registrar un fichero por fila con fecha, persona y hash real de 64 caracteres; no fabricar valores. El agente de Copilot va en `.github/agents/`; el skill compartido por Claude Code y VS Code Local en `.claude/skills/`. Añadir `.github/skills/` solo si se usa el skill con el motor Copilot; Local lee ambas y puede duplicar nombres. Verificar descubrimiento y compatibilidad en la versión instalada de la herramienta, **por verificar** antes de la demo. Publicar una versión no la instala.

### Diapositiva 15. Documentación: comportamiento genérico y configuración local

**Puntos clave:**

- [document-repo](../../ai/artefactos/documentacion/README.md) es un skill, aunque coloquialmente lo llamemos agente de documentación.
- El skill define cómo documentar sin inventar ni cambiar lógica.
- El YAML del repositorio decide tipos, idiomas, público y salidas.
- **YAML** es un formato de configuración organizado por sangría; **scope** delimita archivos, proyectos o visibilidad incluidos.
- Si falta configuración, pregunta y espera antes de generar.

**Notas del ponente:**

**Qué decir:** «No necesitamos copiar el skill y traducir sus reglas para cada entrega. Conservamos el comportamiento y cambiamos la configuración acordada del repositorio».

**Contexto para Yamel:** Abrir el [contrato real](../../ai/artefactos/documentacion/README.md#contrato-de-configuración). Raíz `version: 1`, `types`; bloques opcionales `functional`, `technical`, `xml`, `comments`. Un bloque omitido o `enabled: false` no genera, modifica ni borra ese tipo. Funcional/técnica usan `enabled`, `language`, `output`, `audience`; solo XML/comentarios añaden `scope`. `output: source` significa edición documental del C# existente, no crear una carpeta. Desconocidos, rutas inválidas o proyectos inexistentes requieren aclaración. Los 25 minutos del bloque se reparten: contrato 5, demo CourtConnect 10, variante catalana 10.

### Diapositiva 16. Demo: documentación de CourtConnect

**Puntos clave:**

- Usar [court-connect.yml](../../ai/artefactos/documentacion/v1.0.0/ejemplos/court-connect.yml) como ejemplo, no como configuración activa automática.
- Funcional: español, `docs/`. Técnica: inglés, `docs/technical-doc/`.
- XML y comentarios: inglés, con proyectos y visibilidad explícitos.
- **XML de documentación:** comentarios estructurados sobre miembros C#; **diff:** comparación de los cambios respecto al original.
- Revisar plan, fuentes y diff antes de aceptar.

**Notas del ponente:**

**Qué decir:** «Primero comprobaremos qué existe. Después pediremos documentar una pieza ya terminada. Si el texto dice algo que el código no demuestra, debe marcarlo por confirmar, no convertirlo en un requisito».

**Contexto para Yamel:** Diez minutos sobre el clon de CourtConnect preparado para la demo, no sobre un ejercicio abierto: comprobar configuración y proyecto incluido 2; invocar `/document-repo` sobre una pieza acotada y aprobar plan 3; contrastar salidas con código y diff 5. La configuración destino es `docs/documentacion.config.yml`; si no existe, acordarla previamente con su propietario. El ejemplo incluye Domain: verificar su ruta real antes de usarlo. No generar los cuatro tipos sobre todo el repo durante la clase. Mostrar una salida funcional y una técnica; para XML usar una captura verificada de un símbolo o, si se ejecuta, comparar CS1591/CS1574 e inventario antes/después. Documentar un tipo no autoriza a implementar su comportamiento. Para técnica en español, acordar `types.technical.language: es`; no es el valor del ejemplo original.

### Diapositiva 17. Demo: el mismo skill, salida en catalán

**Puntos clave:**

- Comparar [client-delivery.yml](../../ai/artefactos/documentacion/v1.0.0/ejemplos/client-delivery.yml) con la configuración anterior.
- Los cuatro tipos usan `language: ca`; etiquetas e identificadores no se traducen.
- Adaptar la ruta ficticia de proyecto a una ruta comprobada de CourtConnect.
- Mantener skill, código de entrada y criterio de revisión iguales.

**Notas del ponente:**

**Qué decir:** «Cambia el público y el idioma, no lo que hace el programa. Comprobemos que la versión catalana describe los mismos hechos y conserva los nombres del código».

**Contexto para Yamel:** Diez minutos: comparar YAML 3, revisar la propuesta de salida de la misma pieza 4, comprobar límites 3. El ejemplo trae `src/SampleApp/SampleApp.csproj`: no existe por obligación en CourtConnect. Acordar la adaptación en la copia de configuración de la demo, nunca modificar el skill fuente. Conservar evidencia de ambas configuraciones según D2 de [pruebas.md](../../ai/artefactos/documentacion/v1.0.0/pruebas.md). Mostrar también D3/D13: desactivar u omitir un tipo no borra documentos previos. No exigir `scope` a funcional/técnica. Si se usan capturas por tiempo o acceso, no declararlas una ejecución nueva ni registrar una instalación por haber mostrado el YAML.

### Diapositiva 18. Puente a SDD y Spec Kit

**Puntos clave:**

- **SDD, spec-driven development:** desarrollar a partir de una especificación revisada.
- Constitución: reglas comunes. Especificación: comportamiento y aceptación de una funcionalidad.
- Plan técnico y tareas preceden a la implementación revisada.
- En `feature/sdd-*` se usa ese flujo, no el tutor instalable.

**Notas del ponente:**

**Qué decir:** «No cambiamos “piensa por mí” por “genera más rápido”. Cambiamos el trabajo: tú aclaras qué debe ocurrir, revisas el plan y compruebas el código que se produce».

**Contexto para Yamel:** Quince minutos: flujo 5, aprobación humana 5 y coordinación 5. Seguir [P3 · Ej1](../../reto/Parte3/Ejercicio1/README.md) y [P3 · Ej2](../../reto/Parte3/Ejercicio2/README.md): Yamel aprueba la spec antes del plan; Driss revisa implementación, tests y «Hallazgos de la revisión». No diseñar aquí la solución de torneos. Presentar brevemente [esqueleto UI](../../ai/plantillas/esqueleto-agente-ui.md) y [contrato de coordinación](../../ai/plantillas/contrato-coordinacion.md), que son plantillas, no agentes ya instalables. La persona coordina; la UI llama a la API, nunca a SQL, y no inventa endpoints. Es un Extra del enunciado, no una exigencia de esta clase. Referencias oficiales: [Spec Kit](https://github.com/github/spec-kit) y [módulo de Microsoft Learn](https://learn.microsoft.com/es-es/training/modules/spec-driven-development-github-spec-kit-enterprise-developers/). Versiones y comandos concretos de instalación: **por verificar** al preparar el piloto.

### Diapositiva 19. Demo: revisar un PR no es aprobarlo

**Puntos clave:**

- [review-challenge](../../ai/artefactos/revisor-reto/README.md) ayuda a Yamel desde el repositorio de formación.
- Lee código y PR de `DeemSoft/court-connect`, con commit identificado.
- El SHA del commit identifica la revisión de Git; no es el SHA-256 de un instalable.
- Separa criterios verificados, incumplidos y sin evidencia.
- Propone comentarios; no publica, aprueba ni fusiona.

**Notas del ponente:**

**Qué decir:** «Contrastaremos un criterio con un PR y sus evidencias. No pediremos una opinión general. La decisión final sigue siendo mía».

**Contexto para Yamel:** Demo opcional de 15 minutos: repo, PR y SHA 3; criterio y checks 6; separación de notas y pistas 3; negativa a publicar 3. Para negativas usar [R5/R8/R15](../../ai/artefactos/revisor-reto/v1.0.0/pruebas.md), no escrituras reales. Si no verifica la cuenta del mentor, no genera notas privadas ni niveles; esa comprobación conversacional no es una frontera de acceso. No mostrar notas privadas ni preparación del PR trampa. Consultar checks del mismo SHA, sin ejecutar builds ni tests. Si falta acceso o cambia el commit, dejar la conclusión pendiente.

### Diapositiva 20. promptops-common (genérico)

**Puntos clave:**

- Presentación reservada; la prepara Yamel.

**Notas del ponente:**

**Qué decir:** Por completar por Yamel.

**Contexto para Yamel:** Enlazar con la diapositiva 13: posible evolución futura del gobierno entre repositorios, no una migración ya hecha. No mostrar datos de otros proyectos ni afirmar que existen automatizaciones no verificadas.

### Diapositiva 21. Cierre: una ayuda que puedes explicar y revisar

**Puntos clave:**

- Diseño, prompt, pruebas, iteración, versión, instalación y mantenimiento son pasos distintos.
- Saber de dónde viene una copia y qué evidencia respalda su comportamiento.
- Elegir límites y permisos proporcionados a la tarea.

**Notas del ponente:**

**Qué decir:** «Explícame qué tarea has diseñado, qué no le permitirías hacer y qué evidencia necesitarías antes de confiarle algo más. Después distingue una mejora publicada de una copia instalada».

**Contexto para Yamel:** Cierre de consulta, sin tiempo obligatorio. El bloque opcional del quiz permite repasar la ampliación. Próximo paso de Driss: P2 · Ej5 con diseño propio, instalación y pruebas; no se dan por hechas por asistir. Yamel prepara las demos con acceso y evidencia real. La clase no certifica artefactos, actualiza hashes ni autoriza más autonomía.

## Glosario

**Imprescindibles (15):** LLM, token, prompt, ventana de contexto, alucinación, instrucciones, skill, agente personalizado, autonomía, caso de prueba, versión, deriva, configuración, especificación y revisión humana.

**Que te suene:** los demás términos de consulta. El objetivo es explicar límites y evidencias, no memorizar nombres de herramientas.

| Término | Explicación sencilla | Ejemplo |
| --- | --- | --- |
| LLM / token | Modelo de lenguaje / unidad que procesa | Explicar un diagnóstico a partir del fragmento |
| Prompt / context window | Petición y contexto / límite de información considerada | Aportar el error y el archivo relevante |
| Hallucination | Respuesta plausible sin fundamento suficiente | Inventar una API |
| Custom instructions | Reglas de trabajo del repositorio | No resolver ejercicios |
| Prompt file / skill | Tarea invocable / instrucciones y recursos reutilizables | Pedir documentación configurada |
| Custom agent / autonomía | Rol configurado / capacidad de actuar sin intervención | Tutor solo de lectura |
| Asistente / workflow / agente | Ayuda dirigida por la persona / recorrido prefijado / recorrido decidido por el modelo | Elegir el control mínimo suficiente |
| Herramienta / MCP | Función invocable / protocolo de conexión a herramientas y recursos | Consultar una API, con permisos separados |
| Test case / regression | Caso observable / pérdida de comportamiento anterior | Mantener una negativa tras cambiar el prompt |
| SemVer / CHANGELOG | Versión semántica / explicación de cambios | Mejora compatible en una nueva carpeta |
| Draft / refined / certified | Propuesto / concretado / probado y aprobado | No confundir instalar con certificar |
| Frontmatter | Metadatos al comienzo de un archivo | Nombre y herramientas del agente |
| Drift / SHA-256 | Diferencia de copia / huella de bytes | Comparar fuente, copia y registro |
| YAML / scope | Formato de configuración / alcance permitido | Proyectos y visibilidad para XML |
| SDD / spec | Desarrollo dirigido por especificación / comportamiento acordado | Aprobar reglas antes de generar |
| Prompt injection | Contenido que intenta imponer instrucciones no autorizadas | Un PR que pide aprobarse a sí mismo |
| Human review | Revisión de una persona con evidencia | Yamel decide; el revisor propone |
