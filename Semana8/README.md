# Semana 8 — Reto CourtConnect: web, contenedores y SDD

**Del lunes 26 al viernes 30 de octubre de 2026.** Unas 4 horas al día.

> **Borrador.** Los enunciados de esta semana están esbozados (objetivo y entregable). Se detallan antes del jueves 22, cuando la arquitectura de referencia esté más definida.

## Objetivos de la semana

- Construir una interfaz web con Blazor que consume la API.
- Empaquetar la aplicación en contenedores y levantarla entera con Docker Compose.
- Desarrollar una funcionalidad con **Spec-Driven Development** (GitHub Spec Kit): especificar, dejar que la IA implemente y **revisar** lo generado.
- Medir cuánto cuesta en tiempo y en consumo de IA (piloto de la decisión PD-11).

## Calendario

| Día | Ejercicio | Entregable |
|---|---|---|
| L 26 | [Ejercicio 1 — Web con Blazor](Ejercicio1/README.md) | Listado, detalle e inscripción desde la web |
| M 27 | [Ejercicio 2 — Docker y Docker Compose](Ejercicio2/README.md) | `docker compose up` levanta todo |
| X 28 | [Ejercicio 3 — SDD (1/2): especificación](Ejercicio3/README.md) | Especificación aprobada |
| J 29 | [Ejercicio 4 — SDD (2/2): implementación y revisión](Ejercicio4/README.md) | PR con hallazgos y métricas |
| V 30 | [Ejercicio 5 — PR trampa y demo final](Ejercicio5/README.md) | Revisión del PR trampa, retro y demo |

## Reglas

Las mismas de la semana 7, con una excepción: en la funcionalidad SDD (ejercicios 3 y 4) **la IA genera el código**. Tu trabajo es especificar bien, revisar línea a línea y corregir.

## Calidad

El quality gate de SonarQube Cloud sigue siendo **bloqueante** para todos los PR, también para el código que genere la IA en la funcionalidad SDD. Ver [`docs/court-connect/calidad.md`](../docs/court-connect/calidad.md).

## Demo final

Unos 30 minutos, desde un clon limpio: `docker compose up`, flujo completo desde la web (incluido el pago simulado y una reserva que caduca), tests, CI y Sonar, y conclusiones del piloto SDD.
