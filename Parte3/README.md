# Parte III · MVP con SDD — Reto CourtConnect

**Del jueves 12 al viernes 20 de noviembre de 2026.** Unas 4 horas al día. El proyecto real tiene prioridad: si empieza la iteración 0 de Àmbit, aplica el orden de recorte (más abajo).

## Objetivos de la Parte III

- Desarrollar funcionalidades con **Spec-Driven Development** (GitHub Spec Kit): especificar, dejar que la IA planifique e implemente, y **revisar** lo generado como el PR de otra persona.
- Organizar el código nuevo en ***slices* verticales** (una carpeta por caso de uso) y añadir un proceso en segundo plano (`BackgroundService`).
- **Desplegar** el MVP en Azure, con una URL que puedas enseñar.
- Medir cuánto cuesta en tiempo y en consumo de IA: es el piloto de la decisión **PD-11** de Àmbit.

## Calendario

| Días | Ejercicio | Entregable |
|---|---|---|
| J 12 – V 13 | [Ejercicio 1 — SDD (1/2): especificar torneos y pago](Ejercicio1/README.md) | Constitución y especificación aprobadas |
| L 16 – M 17 | [Ejercicio 2 — SDD (2/2): implementación y revisión](Ejercicio2/README.md) | PR con hallazgos de la revisión y métricas |
| X 18 | [Ejercicio 3 — Segunda funcionalidad SDD](Ejercicio3/README.md) | Ciclo completo en un día, con métricas |
| J 19 | [Ejercicio 4 — Despliegue en Azure](Ejercicio4/README.md) | El MVP funcionando en una URL pública |
| V 20 | [Ejercicio 5 — PR trampa y demo final](Ejercicio5/README.md) | Revisión del PR trampa, retro y demo |

Viernes 13: reunión semanal de seguimiento.

## Reglas

Las mismas de la Parte I, con una excepción: en las funcionalidades SDD **la IA genera el código**. Tu trabajo es especificar bien, revisar línea a línea y corregir. Si no entiendes una línea, no se fusiona.

## Calidad

El quality gate de SonarQube Cloud sigue siendo **bloqueante**, también para el código que genere la IA. Si el código generado no lo supera, eso también es un hallazgo de la revisión.

## Orden de recorte

Si falta tiempo, o empieza la iteración 0 de Àmbit:

1. Los apartados **Extra**.
2. El ejercicio 3 (segunda funcionalidad SDD).
3. El ejercicio 4 (el despliegue pasa a la iteración 0 de Àmbit, donde se hará igualmente).

Lo que **no** se recorta: la primera funcionalidad SDD con sus métricas. La decisión PD-11 tiene que estar tomada antes de escribir código de Àmbit.

## Demo final

**Viernes 20 de noviembre**, unos 45 minutos:

1. La aplicación en Azure: crear un torneo, inscribir un equipo, pagar (y dejar caducar otra inscripción).
2. La segunda funcionalidad, si se hizo.
3. Conclusiones del piloto SDD con números: horas, consumo de IA y defectos encontrados en la revisión.
4. Tests, CI y Sonar.
5. Preguntas de «explícame esta pieza», también sobre el código que escribió la IA.

Criterios: [`docs/court-connect/evaluacion.md`](../docs/court-connect/evaluacion.md).
