# Ejercicio 3 — Segunda funcionalidad SDD

**Miércoles 18 de noviembre · estimación: 4 h** · Issue: «P3 · Ej3 · Segunda funcionalidad SDD»

## Objetivo

Repetir el ciclo SDD completo (especificación, plan, implementación y revisión) con la funcionalidad que elegiste en la Parte II: **lista de espera** o **equipos aleatorios**. La pregunta que responde este ejercicio, y que necesita PD-11, es: **¿el segundo ciclo va más rápido que el primero?**

## Pasos

Rama `feature/sdd-<funcionalidad>`.

1. Especificación en `specs/`, con las aclaraciones resueltas. Yamel la revisa por Discord (no hace falta esperar a una reunión).
2. Plan, tareas e implementación con la IA.
3. Revisión con la misma sección **Hallazgos de la revisión** en el PR.
4. Métricas en `docs/sdd/sdd-piloto.md`, comparadas con las de la primera funcionalidad.

**Si eliges equipos aleatorios:** el resultado tiene que poder probarse. Igual que con la fecha y `TimeProvider`, el generador de números aleatorios no se crea dentro del dominio: se recibe. ¿Cómo haces que un test siempre obtenga los mismos equipos?

**Si eliges lista de espera:** cuando alguien se borra, ¿quién mueve al primero de la espera, y qué pasa si dos personas se borran a la vez?

## Criterios de aceptación

- [ ] Funcionalidad completa según su especificación.
- [ ] PR con «Hallazgos de la revisión».
- [ ] Quality gate superado.
- [ ] Métricas comparadas con la primera funcionalidad.

## Preguntas para la demo

- ¿Qué hiciste distinto en la segunda especificación después de la primera experiencia?
- ¿El segundo ciclo fue más rápido? ¿Por qué sí o por qué no?
