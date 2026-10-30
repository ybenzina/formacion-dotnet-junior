# Parte III · MVP con SDD — Reto CourtConnect

**Días 17 a 23** del reto ([calendario](../../docs/court-connect/calendario.md)). Unas 4 horas al día. El proyecto real tiene prioridad: si empieza la iteración 0 de Àmbit, aplica el orden de recorte (más abajo).

## Objetivos de la Parte III

- **Migrar** el MVP de .NET 10 a **.NET 11** antes de añadir nada, como se hace en un proyecto real cuando sale una versión nueva.
- Desarrollar funcionalidades con **Spec-Driven Development** (GitHub Spec Kit): especificar, dejar que la IA planifique e implemente, y **revisar** lo generado como el PR de otra persona.
- Organizar el código nuevo en ***slices* verticales** (una carpeta por caso de uso) y añadir un proceso en segundo plano (`BackgroundService`).
- **Desplegar** el MVP en Azure, con una URL que puedas enseñar.
- Medir cuánto cuesta en tiempo y en consumo de IA: es el piloto de la decisión **PD-11** de Àmbit.

## Calendario

| Días | Ejercicio | Entregable |
|---|---|---|
| 17 – 18 | [Ejercicio 1 — .NET 11 y SDD (1/2): especificar torneos y pago](Ejercicio1/README.md) | `develop` en .NET 11, constitución y especificación aprobadas |
| 19 – 20 | [Ejercicio 2 — SDD (2/2): implementación y revisión](Ejercicio2/README.md) | PR con hallazgos de la revisión y métricas |
| 21 | [Ejercicio 3 — Segunda funcionalidad SDD](Ejercicio3/README.md) | Ciclo completo en un día, con métricas |
| 22 | [Ejercicio 4 — Despliegue en Azure](Ejercicio4/README.md) | El MVP funcionando en una URL pública |
| 23 | [Ejercicio 5 — PR trampa y demo final](Ejercicio5/README.md) | Revisión del PR trampa, retro y demo |

Los viernes, reunión semanal de seguimiento.

## Reglas

Las mismas de la Parte I, con una excepción: en las funcionalidades SDD **la IA genera el código**. Tu trabajo es especificar bien, revisar línea a línea y corregir. Si no entiendes una línea, no se fusiona.

## .NET 11 desde la Parte III

Las partes I y II se hacen en **.NET 10** (LTS). La Parte III empieza migrando a **.NET 11**, que sale en noviembre de 2026 (STS). Motivos:

- **Migrar de versión** es una tarea real que se repite cada año: SDK, framework de destino, paquetes, imágenes de Docker y cambios incompatibles.
- Las STS tienen ahora **24 meses** de soporte, así que .NET 11 termina en fechas parecidas a .NET 10.
- ASP.NET Core 11 trae **TempData y sesión en Static SSR** (`[SupplyParameterFromTempData]` y `[SupplyParameterFromSession]`). Con eso se hace el **asistente de inscripción del equipo en varios pasos** de la funcionalidad de torneos, sin montar a mano lo que antes había que resolver con campos ocultos o borradores en el servidor.

La migración va en el [ejercicio 1](Ejercicio1/README.md#1-migración-a-net-11-1-h-30-min), justo después de etiquetar `v0.1.0` (el MVP en .NET 10).

## Flujo de ramas desde la Parte III

Al terminar la Parte II ya hay un MVP que funciona. Desde aquí se trabaja como en un proyecto con código en producción, a pequeña escala:

- **`main`** es lo que está en producción (lo desplegado en Azure). Cada versión se etiqueta: `v0.1.0`, `v0.2.0`…
- **`develop`** es la rama de integración de la iteración. Las ramas nuevas salen de `develop` y vuelven a `develop`.
- **`feature/*` → `develop`:** PR con *squash merge* (un commit limpio por funcionalidad) y borrado de la rama.
- **`develop` → `main`:** PR con *merge commit* cuando la iteración está validada (una *release*).
- **`hotfix/*`:** sale de `main` y se fusiona en `main` y en `develop`.

**SonarQube Cloud (plan gratuito):** analiza `main` y los PR, pero no los push a otras ramas. Los PR hacia `develop` pasan el quality gate; la propia `develop` no se analiza hasta la *release* a `main`. Compruébalo con el primer PR.

## Calidad

El quality gate de SonarQube Cloud sigue siendo **bloqueante**, también para el código que genere la IA. Si el código generado no lo supera, eso también es un hallazgo de la revisión.

## Orden de recorte

Si falta tiempo, o empieza la iteración 0 de Àmbit:

1. Los apartados **Extra**.
2. El ejercicio 3 (segunda funcionalidad SDD).
3. El ejercicio 4 (el despliegue pasa a la iteración 0 de Àmbit, donde se hará igualmente).

Lo que **no** se recorta: la primera funcionalidad SDD con sus métricas. La decisión PD-11 tiene que estar tomada antes de escribir código de Àmbit.

## Demo final

**Al terminar el Día 23**, unos 45 minutos:

1. La *release* de `develop` a `main` y la aplicación en Azure: crear un torneo, inscribir un equipo con el asistente de varios pasos, pagar (y dejar caducar otra inscripción).
2. La segunda funcionalidad, si se hizo.
3. Conclusiones del piloto SDD con números: horas, consumo de IA y defectos encontrados en la revisión.
4. Tests, CI y Sonar.
5. Preguntas de «explícame esta pieza», también sobre el código que escribió la IA.

Criterios: [`docs/court-connect/evaluacion.md`](../../docs/court-connect/evaluacion.md).
