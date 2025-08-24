# Semana4 – Ejercicio 2: Concurrencia y sincronización (OBLIGATORIO)

**Branch sugerida:** <githubuser>/semana4-ej2

## Objetivo

Entender race conditions y aplicar sincronización con `lock`, `SemaphoreSlim` e `Interlocked`.

## Tareas

1. Implementar `ContadorConcurrente` con:
   - Versión sin sincronización (para demostrar race condition).
   - Versión con `lock`.
   - Versión con `Interlocked.Increment`.
2. Implementar `AccesoLimitado` que use `SemaphoreSlim` para limitar N operaciones concurrentes.
3. Escribir tests que:
   - Llamen a 1000 tareas en paralelo incrementando el contador y verifiquen el resultado.
   - Muestren diferencia entre versión no sincronizada y sincronizada.
   - Verifiquen el comportamiento de `SemaphoreSlim` (máximo N concurrentes).

## Comprobaciones antes de PR

- `dotnet test` pasa y muestra casos de race condition/diferencia entre versiones.

## Entregable

- Código bajo `Semana4/Ejercicio2/` y tests en `tests/`.
- PR: `<tuusuario>/semana4-ej2` -> `drissbego/integration`
