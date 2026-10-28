# Semana6 — Ejercicio 2: LINQ y delegados (vitaminado)

## Objetivo
Dominar consultas LINQ básicas y el uso de delegados (`Func`, `Action`) para crear APIs flexibles.

## Pasos
1. Crear `Alumno` y lista de ejemplo.  
2. Implementar consultas: `Where`, `Select`, `OrderBy`, `GroupBy`, `Join`, `Average`, `Sum`.  
3. Implementar `Filtrar<T>(IEnumerable<T>, Func<T,bool>)` y comparar con `Where`.  
4. Tests: casos vacíos, todos aprobados, empates y comparación `Filtrar` vs `Where`.

## Extras (opcionales)
- PLINQ (`AsParallel()`) y `WithDegreeOfParallelism`.  
- Breve demo de `Expression<Func<T,bool>>` si hay tiempo.

## Entregable
Código, tests y README con ejemplos y notas sobre deferred execution.
