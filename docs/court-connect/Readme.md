# CourtConnect — dominio de las prácticas de la fase 2

**CourtConnect** es una aplicación para **organizar quedadas y torneos de baloncesto**: creación de eventos, inscripciones (RSVP), gestión de ubicaciones y participantes.

No es un proyecto de entrega: es el **dominio común** sobre el que se construyen los ejercicios de las semanas 7 a 14. En lugar de inventar un caso de uso distinto cada semana, se trabaja siempre sobre el mismo modelo, lo que permite practicar cosas que los ejercicios sueltos no dan: refactorizar en la semana 11 el repositorio escrito en la semana 7, hacer migraciones sobre el propio modelo, o consumir la misma API desde MVC, Blazor y MAUI y comparar.

## Qué hay aquí

- `architecture/` — capas, patrones a aplicar y el refactor de `GetEvent` con Redis.
- `data-model/` — modelo de datos y `init.sql` con el DDL de partida.
- `snippets/` — fragmentos de apoyo.
- `scaffold/` — script para generar la solución base. Ver su [README](scaffold/README.md).

## Cómo empezar

1. Genera la solución con el script de `scaffold/` en una carpeta vacía.
2. `dotnet build CourtConnect.slnx` y `dotnet test`.
3. Ve resolviendo los ejercicios de `Semana7/` en adelante sobre esa solución.

Los proyectos que genera el scaffold son esqueletos: tienen la estructura, las referencias entre capas y los paquetes de partida, pero el código lo escribes tú en cada ejercicio.

## Ramas de trabajo

Se sigue el mismo flujo de ramas que en la fase 1:

- Una rama por ejercicio: `<git-user>/semana7-ej1`, o por área: `feature/dataaccess`, `feature/webui`, `feature/blazorui`.
- Los ejercicios se integran por PR en `<git-user>/integration`.
- `main` mantiene solo los enunciados y el material, nunca las soluciones.
