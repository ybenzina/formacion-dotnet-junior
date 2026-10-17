# Semana 7 — Reto CourtConnect: del dominio a la API con CI

**Del lunes 19 al viernes 23 de octubre de 2026.** Unas 4 horas al día. El proyecto real tiene prioridad: si un día te quita horas, aplica el orden de recorte (más abajo) y avisa en Discord.

## Objetivo del reto

Tocar a mano las piezas básicas de una aplicación .NET actual para poder **entender y supervisar** el código que genere una IA. No hace falta dominarlas: hace falta haberlas usado y saber explicar qué hace cada una.

## Objetivos de la semana

- Crear y configurar un repositorio como en un proyecto real.
- Modelar un dominio con reglas de negocio probadas con xUnit.
- Persistir con EF Core en SQL Server ejecutándose en Docker.
- Exponer una API REST con ASP.NET Core.
- Automatizar build, tests y análisis de calidad con GitHub Actions y SonarCloud.

## Calendario

| Día | Ejercicio | Entregable |
|---|---|---|
| L 19 | [Ejercicio 1 — Repositorio y dominio](Ejercicio1/README.md) | Repo creado, `docs/domain.md`, dominio con tests |
| M 20 | [Ejercicio 2 — EF Core y SQL Server en Docker](Ejercicio2/README.md) | Migración aplicada y datos de prueba |
| X 21 | [Ejercicio 3 — API con ASP.NET Core](Ejercicio3/README.md) | Endpoints que se pueden probar con un fichero `.http` |
| J 22 | [Ejercicio 4 — Tests de integración y CI](Ejercicio4/README.md) | CI en verde y obligatoria en `main` |
| V 23 | [Ejercicio 5 — SonarCloud y demo 1](Ejercicio5/README.md) | Quality gate superado, demo y retro |

## Dónde se trabaja

- **Código:** repositorio `DeemSoft/court-connect` (lo creas el lunes).
- **Tareas:** issues de `court-connect`, una por ejercicio, en el milestone **Reto · Semana 7**.
- **Material:** `docs/court-connect/` de este repo.

## Reglas

1. **Primero tú, después la IA.** Resuelve cada ejercicio sin generar código con IA. Puedes preguntarle conceptos y errores: el `AGENTS.md` del repo la configura como tutora. Cuando abras el PR, pídele su versión y anota las diferencias en la sección «Comparación con IA» del PR.
2. **Flujo de trabajo:** el de `ambit-escola` (`docs/methodology/git.md`): rama por tarea desde `main`, PR con «Uso de IA», revisión de Yamel y *merge commit*.
3. **Datos ficticios** siempre. Ningún dato real ni de clientes.
4. **Apunta las horas reales** en cada issue. Al final compararemos con lo estimado.

## Calidad

Desde el viernes, `court-connect` tiene el **quality gate de SonarQube Cloud como requisito para fusionar**: cobertura ≥ 80 %, duplicación ≤ 3 % y fiabilidad, seguridad y mantenibilidad A, **solo sobre el código que añades o cambias**. Los ejercicios de lunes a jueves ya piden los tests necesarios para cumplirlo. Ojo: son **dos checks** en cada PR. Que la Action esté en verde no significa que el ejercicio esté aceptado; también tiene que estar en verde `SonarCloud Code Analysis`. Lee [`docs/court-connect/calidad.md`](../docs/court-connect/calidad.md) antes de empezar.

## Orden de recorte

Si falta tiempo, recorta en este orden y anótalo en el PR:

1. Los apartados marcados como **Extra**.
2. Tests de integración más allá del mínimo.
3. Endpoints de alta de campus (se pueden crear con datos de prueba).

Lo que **no** se recorta: reglas de dominio con tests, migración, API de inscripción, CI en verde y quality gate.

## Demo del viernes

Unos 30 minutos, desde un clon limpio del repo:

1. Arrancar SQL Server en Docker, aplicar migraciones y lanzar la API.
2. Recorrer el flujo: listar campus, inscribir un jugador, intentar una inscripción que incumpla una regla, cancelar.
3. Enseñar los tests, la CI y el análisis de SonarCloud.
4. Responder 3 a 5 preguntas de «explícame esta pieza».

Criterios: [`docs/court-connect/evaluacion.md`](../docs/court-connect/evaluacion.md).
