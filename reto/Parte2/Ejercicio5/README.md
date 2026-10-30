# Ejercicio 5 — Demo 2 y preparación del SDD

**Día 16 · estimación: 5 h** · Issue: «P2 · Ej5 · Demo 2 y preparación del SDD»

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

### 3. Tu agente tutor (≈ 1 h)

**Antes de empezar:** averigua qué son un agente personalizado y un skill, quién los invoca y dónde los busca cada herramienta (Copilot y Claude Code). Pregunta a la IA o consulta la documentación oficial y explícalo con tus palabras; todavía no mires la referencia.

1. **Diseño propio breve:** usa [la plantilla de diseño](../../../ai/plantillas/diseno-agente.md) para describir un tutor que te ayude sin resolver el ejercicio. Define qué puede hacer, qué no y cómo lo probarías. Conserva este diseño antes de leer la referencia.
2. **Instalación como copia registrada:** consulta [el tutor de referencia](../../../ai/artefactos/tutor/README.md) y cópialo en **ambas herramientas** siguiendo sus formatos oficiales. Conserva la cabecera de procedencia y comprueba que carga. Haz la instalación por PR en `court-connect`; tras fusionarla, calcula y compara los hashes y registra cada fichero, versión y canal en [REGISTRO.md](../../../ai/REGISTRO.md), mediante PR a la fuente. No inventes una instalación mientras siga pendiente.
3. **Pruebas:** ejecuta [los casos fijos](../../../ai/artefactos/tutor/v1.0.0/pruebas.md) y **un caso propio** en Copilot y Claude Code. Guarda entradas, salidas y resultados por herramienta en el PR de mejora, incluida una negativa y una conversación de varios turnos.
4. **Comparación y mejora:** compara tu diseño inicial con la referencia, explica las diferencias y propón una mejora por PR a `DeemSoft/formacion-dotnet-junior`, dentro de `ai/artefactos/tutor/`. Crea una nueva versión según SemVer, actualiza metadatos y CHANGELOG y repite las pruebas. La copia instalada no es la fuente de verdad; una vez aprobada la mejora, otro PR la instala y se actualiza el registro con el hash real.

**Extra:** diseña un revisor que detecte tests sin aserciones útiles o que solo inflen la cobertura. Usa la misma plantilla, define sus límites y prueba falsos positivos antes de proponerlo; no hace falta automatizarlo ni darle más autonomía.

### 4. Retro y demo (≈ 1 h 15 min)

- Añade a `docs/learning/retro.md` la retro de la Parte II.
- Demo con Yamel: ver [`reto/Parte2/README.md`](../README.md#demo-2).

## Criterios de aceptación

- [ ] La aplicación arranca desde un clon limpio siguiendo el README.
- [ ] Módulo de SDD completado y Spec Kit instalado.
- [ ] Herramienta del piloto y segunda funcionalidad elegidas y justificadas.
- [ ] Diseño propio del tutor conservado antes de consultar la referencia.
- [ ] Tutor instalado como copia con procedencia en Copilot y Claude Code; instalaciones efectivas registradas con SHA-256.
- [ ] Casos fijos y caso propio ejecutados en ambas herramientas, con resultados reales en el PR.
- [ ] Diseño comparado y mejora propuesta por PR a la fuente, con nueva versión, CHANGELOG y pruebas repetidas.
- [ ] Retro escrita.

## Preguntas para la demo

- Repasa el camino de una inscripción desde el clic en la web hasta la base de datos: qué componentes atraviesa, dónde se comprueba quién eres y dónde se aplican las reglas.
- ¿Qué parte de la Parte II te costó más y cómo la resolviste?
- ¿Qué esperas del SDD? ¿Qué te preocupa de dejar que la IA escriba el código?
- ¿Qué es un agente y cuándo no crearías uno? ¿Por qué este tutor no se usa en `feature/sdd-*`?
- ¿Qué problema aparece si editas la copia instalada en lugar de proponer el cambio a la fuente? ¿Cómo detectas la deriva?
- ¿Cómo sabes que tu mejora no ha roto otra respuesta o una negativa del tutor?
