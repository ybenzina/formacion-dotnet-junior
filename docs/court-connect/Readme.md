# CourtConnect — material del reto

**CourtConnect** es una aplicación para quedar a jugar a **baloncesto callejero**: canchas, partidos con plazas limitadas, jugadores que se apuntan, cuentas y roles, y torneos por equipos con pago simulado.

No es un producto real: es el dominio sobre el que Driss practica en el reto de formación, en tres partes y 23 días de trabajo (ver el [calendario](calendario.md)). El código se desarrolla en el repositorio **`DeemSoft/court-connect`**. Aquí está solo el material de partida.

## Qué hay aquí

| Ruta | Para qué |
| --- | --- |
| [`enunciado-dominio.md`](enunciado-dominio.md) | Requisitos del dominio. Punto de partida para redactar `docs/domain.md` en el repo del reto |
| [`architecture/`](architecture/README.md) | Arquitectura propuesta para el reto |
| [`data-model/`](data-model/README.md) | Modelo de datos de la primera versión (quedadas y RSVP), muy parecida al dominio actual, e `init.sql`. Solo como referencia: el esquema se crea con migraciones |
| [`snippets/`](snippets/snippets.md) | Fragmentos de apoyo de la versión anterior |
| [`scaffold/`](scaffold/README.md) | Script que genera una solución de referencia. Driss crea la suya a mano y lo usa para comparar |
| [`plantilla-repo/`](plantilla-repo/README.md) | Ficheros para copiar al repo nuevo y checklist de creación |
| [`glosario.md`](glosario.md) | Glosario técnico base. Driss lo copia a su repo y lo amplía con sus palabras |
| [`calidad.md`](calidad.md) | Quality gate de SonarQube Cloud: umbrales y cómo cumplirlos |
| [`evaluacion.md`](evaluacion.md) | Criterios de evaluación del reto |
| [`sdd-piloto.md`](sdd-piloto.md) | Plantilla de métricas del piloto de Spec-Driven Development |
| [`issues-reto.md`](issues-reto.md) | Issues del reto, listas para crear en `court-connect` |
| [Agentes y prompts de referencia](../../ai/README.md) | Tutor, calidad, documentación configurable, plantillas y registro de copias instaladas |

## Reglas del reto

- **Primero lo intentas tú, después comparas con la IA.** Cada enunciado termina con una sección «Comparación con IA», y cada PR tiene una sección con ese nombre.
- **La excepción son las funcionalidades SDD** (Parte III): ahí la IA genera el código y tu trabajo es especificar y revisar.
- **Datos siempre ficticios.** Ningún dato real ni de clientes.
- **Lo que construyas no tiene que ser bonito:** tiene que funcionar y tienes que saber explicar cada pieza.
