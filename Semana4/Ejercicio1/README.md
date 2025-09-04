# Semana4 – Ejercicio 1: Métodos async y Task (OBLIGATORIO)

**Branch sugerida:** `<git-user>`/semana4-ej1 (por ejemplo: drissbego/semana4-ej1)

## Objetivo

Practicar `async`/`await` y `Task` implementando un `WebSimulator` que simula descargas y procesamiento de contenido.

## Tareas

1. Implementar `Task<string> DescargarPaginaAsync(string url)` que simule I/O con `Task.Delay` y devuelva un string.
2. Implementar `Task<int> ContarPalabrasAsync(string contenido)` que cuente palabras (operación asíncrona).
3. Implementar `Task<int> ContarPalabrasMultiplesAsync(IEnumerable<string> urls)` que descargue en paralelo y sume palabras usando `Task.WhenAll`.
4. Escribir tests xUnit asíncronos (`async Task`) que validen los métodos, usando `Assert.Equal(await ..., expected)` y `Theory/InlineData` para varios casos.

## Comprobaciones antes de PR

- `dotnet build` y `dotnet test` deben pasar localmente.
- Incluir la salida de `dotnet test` en la descripción del PR.

## Entregable

- Código bajo `Semana4/Ejercicio1/` (o `src/` y `tests/` según aplique).
- PR: `<git-user>/semana4-ej1` -> `<git-user>/integration`
