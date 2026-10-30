# Ejercicio 5 — Demo 2 y preparación del SDD

**Día 16 · estimación: 5 h 30 min** · Issue: «P2 · Ej5 · Demo 2 y preparación del SDD»

## Objetivo

Cerrar la Parte II con una demo desde un clon limpio y dejar preparado el terreno para la Parte III, que se hace con Spec-Driven Development.

## Pasos

### 1. Clon limpio y README (≈ 45 min)

- Clona el repo en una carpeta nueva y arráncalo siguiendo solo tu README. Si algo no funciona, el README está mal: corrígelo.

### 2. Preparar el SDD (≈ 2 h)

- Módulo de Microsoft Learn [Implementación del desarrollo Spec-Driven mediante GitHub Spec Kit](https://learn.microsoft.com/es-es/training/modules/spec-driven-development-github-spec-kit-enterprise-developers/).
- Instala la CLI de Spec Kit (`specify`) y comprueba que funciona. En Windows con consola cp1252, `$env:PYTHONUTF8=1`.
- Con Yamel, **decidid la herramienta de IA del piloto** (Claude Code o Copilot). Anótala en `docs/sdd/sdd-piloto.md` (plantilla en [`docs/court-connect/sdd-piloto.md`](../../../docs/court-connect/sdd-piloto.md)).
- Elige la **segunda funcionalidad SDD** (lista de espera o equipos aleatorios, ver el enunciado del dominio) a partir de lo que te dijo tu grupo, y explica por qué en `docs/discovery.md`.

### 3. Tu agente tutor (≈ 1 h 30 min)

**Antes de empezar:** averigua qué son un agente personalizado y un skill, quién los invoca y dónde los busca cada herramienta (Copilot y Claude Code). Pregunta a la IA o consulta la documentación oficial y explícalo con tus palabras; todavía no mires la referencia.

1. **Diseño breve (≈ 10 min):** rellena [la plantilla](../../../ai/plantillas/diseno-agente.md). Conserva tu propuesta antes de mirar la referencia.
2. **Un PR de instalación (≈ 15 min):** consulta [el tutor](../../../ai/artefactos/tutor/README.md) e instala la **v1.0.0** en `court-connect`, con su cabecera. El mismo PR incluye el agente de Copilot y el skill de Claude Code, que también lee VS Code Local. Comprueba que cargan.
3. **Pruebas (≈ 35 min):** ejecuta **T1, T3, T4, T7 y un caso propio** de [pruebas.md](../../../ai/artefactos/tutor/v1.0.0/pruebas.md), con el agente en VS Code y el skill en Claude Code. Adjunta entradas, salidas y resultados por herramienta al PR de instalación. No se exige aquí la batería completa.
4. **Un PR a la fuente (≈ 30 min):** compara tu diseño con la referencia y propone una mejora compatible en **v1.1.0** en `DeemSoft/formacion-dotnet-junior`. Incluye metadatos, cabeceras, CHANGELOG y el caso que comprobará la mejora. En ese mismo PR, enlaza los resultados anteriores y añade a [REGISTRO.md](../../../ai/REGISTRO.md) una fila por fichero de la **v1.0.0 realmente instalada**, con SHA-256 comprobado tras fusionar la instalación. No registres v1.1.0 como instalada ni abras un PR separado para el registro.

**Extra:** una vez aprobada la mejora, reinstala v1.1.0 por PR en `court-connect`, repite los casos y actualiza el registro con sus hashes reales. También puedes diseñar, con la misma plantilla, un revisor de tests sin aserciones útiles o que solo inflen cobertura.

### 4. Retro y demo (≈ 1 h 15 min)

- Añade a `docs/learning/retro.md` la retro de la Parte II.
- Demo con Yamel: ver [`reto/Parte2/README.md`](../README.md#demo-2).

## Criterios de aceptación

- [ ] La aplicación arranca desde un clon limpio siguiendo el README.
- [ ] Módulo de SDD completado y Spec Kit instalado.
- [ ] Herramienta del piloto y segunda funcionalidad elegidas y justificadas.
- [ ] Diseño propio del tutor conservado antes de consultar la referencia.
- [ ] Un único PR en `court-connect` instala v1.0.0 con procedencia para las dos herramientas.
- [ ] T1, T3, T4, T7 y un caso propio ejecutados en ambas herramientas, con resultados reales en ese PR.
- [ ] Un único PR a la fuente propone v1.1.0 con CHANGELOG y caso de prueba, y registra los ficheros de v1.0.0 efectivamente instalados con SHA-256.
- [ ] La reinstalación de v1.1.0 queda como Extra, fuera de la entrega obligatoria.
- [ ] Retro escrita.

## Preguntas para la demo

- Repasa el camino de una inscripción desde el clic en la web hasta la base de datos: qué componentes atraviesa, dónde se comprueba quién eres y dónde se aplican las reglas.
- ¿Qué parte de la Parte II te costó más y cómo la resolviste?
- ¿Qué esperas del SDD? ¿Qué te preocupa de dejar que la IA escriba el código?
- ¿Qué es un agente y cuándo no crearías uno? ¿Por qué este tutor no se usa en `feature/sdd-*`?
- ¿Qué problema aparece si editas la copia instalada en lugar de proponer el cambio a la fuente? ¿Cómo detectas la deriva?
- ¿Cómo sabes que tu mejora no ha roto otra respuesta o una negativa del tutor?
