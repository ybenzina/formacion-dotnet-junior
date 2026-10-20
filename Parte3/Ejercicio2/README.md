# Ejercicio 2 — SDD (2/2): implementación y revisión

**Lunes 16 y martes 17 de noviembre · estimación: 7 h** · Issue: «P3 · Ej2 · SDD (2/2): implementación y revisión»

## Objetivo

Dejar que la IA planifique e implemente la funcionalidad a partir de la especificación, y **revisar** el resultado como lo harías con el PR de otra persona.

## Pasos

Rama `feature/sdd-torneos` (la misma del ejercicio 1).

1. **Plan técnico y tareas** generados con Spec Kit. Revísalos antes de implementar: ¿respetan la constitución (slices, sin mediador, reglas en el dominio)?
2. **Implementación** generada por la IA, tarea a tarea.
3. **Revisión línea a línea.** Busca, como mínimo:
   - reglas de la especificación que falten o estén mal;
   - el `BackgroundService`: ¿usa `TimeProvider`?, ¿cómo obtiene el `DbContext`? (un `BackgroundService` vive toda la aplicación y el `DbContext` es *scoped*: ¿qué problema hay?);
   - idempotencia del pago de verdad, no solo en el nombre;
   - comprobación del capitán (R8) en todos los caminos;
   - tests que no comprueban nada o que solo inflan la cobertura.
4. **PR** con una sección **Hallazgos de la revisión**: qué estaba mal o era mejorable, qué corregiste tú y qué pediste corregir a la IA.
5. **Web:** páginas de torneos e inscripción de equipo (las puede generar la IA, con la misma revisión).

## Criterios de aceptación

- [ ] Plan y tareas revisados antes de implementar.
- [ ] Funcionalidad completa según la especificación, con caducidad automática.
- [ ] PR con «Hallazgos de la revisión».
- [ ] Quality gate superado por el código generado.
- [ ] Métricas completas en `docs/sdd/sdd-piloto.md`.

## Preguntas para la demo

- Enseña el hallazgo más grave que encontraste en el código de la IA. ¿Qué habría pasado en producción?
- ¿Cómo obtiene el `BackgroundService` acceso a la base de datos y por qué así?
- Si mañana te piden cambiar el tiempo de retención, ¿qué tocas?
