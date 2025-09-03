# Semana4 – Ejercicio 3: Tests async y Cancelación (OBLIGATORIO)

**Branch sugerida:** `<git-user>`/semana4-ej3

## Objetivo

Aprender a testear cancelación y excepciones relacionadas con tareas asíncronas.

## Tareas

1. Implementar métodos que acepten `CancellationToken` y cancelen operaciones largas cooperativamente.
2. Escribir tests que:
   - Validen que al cancelar se lanza `TaskCanceledException` o que la operación termina correctamente.
   - Comprueben que las tareas pueden limpiamente liberar recursos (usar `try/finally` en ejemplo).

## Entregable

- Código bajo `Semana4/Ejercicio3/` /src y /tests según aplique.
- PR: `<git-user>/semana4-ej3` -> `<git-user>/integration`
