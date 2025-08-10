# Semana 3 - Ejercicio 2: Gestor de Tareas (ToDoList) (OBLIGATORIO)

**Branch sugerida:** `semana3-ej2`

## Objetivo
Diseñar clases `Tarea` y `GestorTareas` que permitan añadir, listar, marcar como completada y eliminar tareas.
Practicar encapsulación, uso de `List<T>` y operaciones con LINQ.

## Requerimientos mínimos
- Clase `Tarea` con properties: `Id`, `Titulo`, `Descripcion`, `FechaCreacion`, `Completada`.
- Clase `GestorTareas` con métodos: `Agregar`, `Eliminar`, `ListarTodas`, `ListarPendientes`, `MarcarCompletada`.
- Tests que validen las operaciones principales (añadir, marcar completada, eliminar).

## Entregables
- Código en `src/GestorTareas` o `Semana3/Ejercicio2`
- Tests en `tests/GestorTareas.Tests`
- PR `Semana3 – Gestor de Tareas` con salida de `dotnet test`

## Verificaciones antes de PR
- `dotnet build` y `dotnet test` pasan
- Revisar **PROBLEMS** y corregir warnings críticos
