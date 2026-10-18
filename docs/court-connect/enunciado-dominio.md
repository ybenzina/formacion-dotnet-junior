# Enunciado del dominio — CourtConnect

> Este documento es el **enunciado**. Tu tarea del día 1 es convertirlo en `docs/domain.md` en el repo `court-connect`: con tus palabras, con un diagrama entidad-relación en Mermaid y con las decisiones que tomes donde el enunciado no dice nada.

## Contexto

Un club organiza **campus de baloncesto** (por ejemplo, un campus de verano de una semana) y **torneos**. Las familias inscriben a los jugadores en los campus, que tienen **plazas limitadas** y un **precio**. Más adelante el pago se hará en línea (simulado).

## Glosario

El código se escribe en inglés y la documentación en español. Usa estos nombres:

| Concepto | Nombre en código |
|---|---|
| Campus | `Camp` |
| Torneo | `Tournament` |
| Jugador | `Player` |
| Equipo | `Team` |
| Inscripción | `Registration` |
| Pago | `Payment` |

## Requisitos

### Núcleo del reto (obligatorio)

**Campus**
- Tiene nombre, descripción, lugar (texto libre), fecha de inicio y de fin, número de plazas, precio y una edad mínima y máxima.
- Estados: **borrador**, **abierto** (admite inscripciones) y **cerrado**.

**Jugador**
- Tiene nombre, apellidos, fecha de nacimiento y un correo de contacto.
- Guarda **solo los datos necesarios**. No guardes datos de salud, alergias ni documentos de identidad: no hacen falta para el reto. Los jugadores pueden ser menores, así que la minimización de datos importa.

**Inscripción**
- Relaciona un jugador con un campus. Guarda la fecha de creación, el importe y el estado.
- En la semana 7, una inscripción nueva queda **confirmada** directamente. El pago llega en la semana 8.
- Estados en la semana 7: **confirmada** y **cancelada**.

### Reglas de negocio (semana 7)

| Id | Regla |
|---|---|
| R1 | Un campus no puede tener más inscripciones activas (no canceladas) que plazas |
| R2 | Un jugador no puede tener dos inscripciones activas en el mismo campus |
| R3 | La edad del jugador **en la fecha de inicio del campus** debe estar entre la mínima y la máxima |
| R4 | Solo se admiten inscripciones en campus **abiertos** y antes de su fecha de inicio |
| R5 | Cancelar una inscripción libera la plaza |
| R6 | El importe de la inscripción es el precio del campus en el momento de inscribirse |

### Funcionalidad SDD (semana 8): pago simulado con caducidad

Se especifica con Spec Kit en la semana 8. Idea de partida, que tendrás que concretar en la especificación:

- Una inscripción nueva queda **pendiente de pago** y **retiene la plaza** durante un tiempo configurable.
- El pago se hace contra una **pasarela simulada** que acepta o rechaza.
- Si se acepta, la inscripción pasa a **confirmada**. Confirmar dos veces el mismo pago no debe tener efectos (idempotencia).
- Si vence el plazo sin pago, la inscripción **caduca** y la plaza queda libre.
- Fuera de alcance: reembolsos y pasarelas reales.

### Ampliación (solo si sobra tiempo)

- **Torneo** con inscripción de **equipos** (un equipo tiene jugadores y un nombre; el torneo tiene un número máximo de equipos).
- Lista de espera cuando no quedan plazas.

## Preguntas que tu `domain.md` debe responder

1. ¿Qué entidad es responsable de comprobar cada regla (R1 a R6)? ¿Por qué ahí?
2. ¿Qué pasa si dos personas se inscriben a la vez en la última plaza? (No hace falta resolverlo el día 1, pero apúntalo.)
3. ¿Qué datos del jugador guardas y por qué no guardas más?
4. ¿Qué decisiones has tomado donde el enunciado no decía nada?
