# CourtConnect — material del reto (fase 2)

**CourtConnect** es una aplicación para gestionar **campus y torneos de baloncesto**: actividades con plazas limitadas, jugadores, inscripciones y pagos simulados.

No es un producto real: es el dominio sobre el que Driss practica en el reto de las semanas 7 y 8. El código se desarrolla en el repositorio **`DeemSoft/court-connect`**. Aquí está solo el material de partida.

## Qué hay aquí

| Ruta | Para qué |
|---|---|
| [`enunciado-dominio.md`](enunciado-dominio.md) | Requisitos del dominio. Punto de partida para redactar `docs/domain.md` en el repo del reto |
| [`architecture/`](architecture/README.md) | Arquitectura propuesta para el reto |
| [`data-model/`](data-model/README.md) | Modelo de datos de la versión anterior (quedadas y RSVP) e `init.sql`. Solo como referencia |
| [`snippets/`](snippets/snippets.md) | Fragmentos de apoyo de la versión anterior |
| [`scaffold/`](scaffold/README.md) | Script que genera una solución de referencia. Driss crea la suya a mano y lo usa para comparar |
| [`plantilla-repo/`](plantilla-repo/README.md) | Ficheros para copiar al repo nuevo y checklist de creación |
| [`calidad.md`](calidad.md) | Quality gate de SonarQube Cloud: umbrales y cómo cumplirlos |
| [`evaluacion.md`](evaluacion.md) | Criterios de evaluación del reto |
| [`sdd-piloto.md`](sdd-piloto.md) | Plantilla de métricas del piloto de Spec-Driven Development |
| [`issues-reto.md`](issues-reto.md) | Issues del reto, listas para crear en `court-connect` |

## Reglas del reto

- **Primero lo intentas tú, después comparas con la IA.** Cada enunciado termina con una sección «Comparación con IA», y cada PR tiene una sección con ese nombre.
- **La excepción es la funcionalidad SDD** (semana 8): ahí la IA genera el código y tu trabajo es especificar y revisar.
- **Datos siempre ficticios.** Ningún dato real ni de clientes.
- **Lo que construyas no tiene que ser bonito:** tiene que funcionar y tienes que saber explicar cada pieza.
