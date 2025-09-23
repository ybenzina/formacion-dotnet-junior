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

## Mejoras

### Renombrar `Tareas` → `Tarea`

- Renombra el archivo `Tareas.cs` a `Tarea.cs`.
- Dentro del archivo, cambia `public class Tareas` por `public class Tarea`.
- Actualiza todas las referencias en el código (usos de `Tareas` → `Tarea`).
- Ejecuta `dotnet build` y `dotnet test` para verificar.

### Sugerencias de cambio en `GestorTarea`

> Edita tu `GestorTarea.cs` existente (no reemplaces a ciegas si tu implementación difiere).
> Asegúrate de que tu clase de entidad se llame `Tarea` (singular) y el archivo sea `Tarea.cs`.

#### 1) No exponer la lista interna

```csharp
// Campo interno
private readonly List<Tarea> tareas = new();

// Exponer colección inmutable
public IReadOnlyList<Tarea> ListarTodas() => tareas.AsReadOnly();
```

#### 2) Validaciones en altas

```csharp
public void Agregar(string titulo, string? descripcion = null)
{
    if (string.IsNullOrWhiteSpace(titulo))
        throw new ArgumentException("El título no puede estar vacío.", nameof(titulo));

    tareas.Add(new Tarea(titulo, descripcion));
}
```
