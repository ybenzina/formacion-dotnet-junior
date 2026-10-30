# Ejercicio 2 — SDD (2/2): implementación y revisión

**Días 19 y 20 · estimación: 7 h** · Issue: «P3 · Ej2 · SDD (2/2): implementación y revisión»

## Objetivo

Dejar que la IA planifique e implemente la funcionalidad a partir de la especificación, y **revisar** el resultado como lo harías con el PR de otra persona.

## Pasos

Rama `feature/sdd-torneos` (la misma del ejercicio 1). El PR va hacia `develop`, con *squash merge*.

1. **Plan técnico y tareas** generados con Spec Kit. Revísalos antes de implementar: ¿respetan la constitución (slices, sin mediador, reglas en el dominio)?
2. **Implementación** generada por la IA, tarea a tarea.
3. **Revisión línea a línea.** Busca, como mínimo:
   - reglas de la especificación que falten o estén mal;
   - el `BackgroundService`: ¿usa `TimeProvider`?, ¿cómo obtiene el `DbContext`? (un `BackgroundService` vive toda la aplicación y el `DbContext` es *scoped*: ¿qué problema hay?);
   - idempotencia del pago de verdad, no solo en el nombre;
   - comprobación del capitán (R8) en todos los caminos;
   - tests que no comprueban nada o que solo inflan la cobertura.
4. **PR** con una sección **Hallazgos de la revisión**: qué estaba mal o era mejorable, qué corregiste tú y qué pediste corregir a la IA.
5. **Web:** páginas de torneos y el **asistente de inscripción del equipo en varios pasos**, en Static SSR (las puede generar la IA, con la misma revisión). El estado entre pasos, con `[SupplyParameterFromSession]`; el mensaje final, con `[SupplyParameterFromTempData]`, siguiendo PRG. Revisa:
   - ¿qué hay en la sesión y es lo mínimo?;
   - ¿se borra al terminar o al cancelar?;
   - ¿qué pasa si vuelves atrás o abres dos pestañas?;
   - ¿comprueba el servidor en cada paso que quien envía es el capitán (R8)?

   **Antes de .NET 11** esto se resolvía a mano: campos ocultos en cada paso, parámetros en la URL o un borrador guardado en el servidor. Anota en el PR qué te ahorra la novedad y qué riesgos sigue teniendo.

Si el código generado no supera el quality gate, puedes usar [la referencia de calidad](../../../ai/artefactos/calidad-sonarqube/README.md). Respeta sus paradas de alcance, plan y revisión por módulo; la ayuda no sustituye tu revisión ni la comprobación del gate del PR.

### Extra: agentes de UI y backend

Crea un agente de UI y otro de backend y úsalos para las páginas de torneos y el asistente de inscripción del equipo. Diséñalos primero con [la plantilla de UI](../../../ai/plantillas/esqueleto-agente-ui.md) y [el contrato de coordinación](../../../ai/plantillas/contrato-coordinacion.md), con la especificación aprobada como límite.

- Define qué pide la UI, qué responde la API y cuándo ambos deben parar para preguntarte. No inventes endpoints ni DTO para encajar una pantalla.
- Mantén la separación: **UI → API mediante `HttpClient` tipado; nunca UI → base de datos**. La API sigue siendo la autoridad de autorización y reglas.
- Justifica render modes, estado, formularios y pruebas con bUnit; prueba también una petición que el otro agente deba rechazar por estar fuera de su responsabilidad.
- Conserva el diseño y los intercambios en el PR. Tú coordinas y revisas; no hace falta automatizar una conversación entre agentes. No uses el tutor instalable en esta rama SDD.

## Criterios de aceptación

- [ ] Plan y tareas revisados antes de implementar.
- [ ] Funcionalidad completa según la especificación, con caducidad automática.
- [ ] Asistente de inscripción en varios pasos, con el estado en sesión, revisado.
- [ ] PR con «Hallazgos de la revisión».
- [ ] Quality gate superado por el código generado.
- [ ] Métricas completas en `docs/sdd/sdd-piloto.md`.

## Preguntas para la demo

- Enseña el hallazgo más grave que encontraste en el código de la IA. ¿Qué habría pasado en producción?
- ¿Cómo obtiene el `BackgroundService` acceso a la base de datos y por qué así?
- ¿Dónde vive el estado del asistente entre pasos? ¿Qué pasaría con dos réplicas de la web?
- Si mañana te piden cambiar el tiempo de retención, ¿qué tocas?
