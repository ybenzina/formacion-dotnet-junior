# Ejercicio 5 — Demo 2 y preparación del SDD

**Día 16 · estimación: 4 h** · Issue: «P2 · Ej5 · Demo 2 y preparación del SDD»

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

### 3. Retro y demo (≈ 1 h 15 min)

- Añade a `docs/learning/retro.md` la retro de la Parte II.
- Demo con Yamel: ver [`reto/Parte2/README.md`](../README.md#demo-2).

## Criterios de aceptación

- [ ] La aplicación arranca desde un clon limpio siguiendo el README.
- [ ] Módulo de SDD completado y Spec Kit instalado.
- [ ] Herramienta del piloto y segunda funcionalidad elegidas y justificadas.
- [ ] Retro escrita.

## Preguntas para la demo

- Repasa el camino de una inscripción desde el clic en la web hasta la base de datos: qué componentes atraviesa, dónde se comprueba quién eres y dónde se aplican las reglas.
- ¿Qué parte de la Parte II te costó más y cómo la resolviste?
- ¿Qué esperas del SDD? ¿Qué te preocupa de dejar que la IA escriba el código?
