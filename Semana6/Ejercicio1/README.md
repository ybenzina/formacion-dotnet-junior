# Semana6 — Ejercicio 1: Colecciones concurrentes y productor/consumidor

## Objetivo
Implementar productor/consumidor con `BlockingCollection<T>` y practicar `ConcurrentDictionary` en escenarios concurrentes.

## Pasos
1. Implementa productores (10) que generen 100 items cada uno.  
2. Implementa consumidores (5) que leen `GetConsumingEnumerable()` y procesan.  
3. Verifica que total producido == total consumido.  
4. Implementa `ConcurrentDictionary<string,int>` con `AddOrUpdate` para conteos por clave bajo alta concurrencia.

## Tests recomendados
- Productores múltiples + consumidores múltiples → verificar contador total.  
- ConcurrentDictionary: 1000 tareas incrementando misma clave → comprobar valor final.

## Entregable
Código en `src/` y tests en `tests/`.
