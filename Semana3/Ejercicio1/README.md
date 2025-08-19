# Semana 3 - Ejercicio 1: Calculadora POO con Tests (OBLIGATORIO)

**Branch sugerida:** `semana3-ej1`

## Objetivo
Implementar una clase `Calculadora` orientada a objetos con operaciones básicas y avanzadas,
respetando encapsulación y buenas prácticas. Añadir tests intermedios con xUnit usando `Theory` + `InlineData`.

## Requerimientos mínimos
- Implementar métodos: `Sumar`, `Restar`, `Multiplicar`, `Dividir` (lanza excepción si divisor 0)
- Implementar al menos 2 operaciones adicionales: `Potencia`, `RaizCuadrada`, o `Modulo`
- (Opcional) Llevar contador interno de operaciones (propiedad read-only)

## Tests (mínimo)
- Tests `Fact` para casos especiales (división por cero -> excepción)
- Tests `Theory` + `InlineData` para múltiples casos de `Sumar` y `Multiplicar`

## Entregables
- Código en `src/CalculadoraLib` o en `Semana3/Ejercicio1`
- Tests en `tests/CalculadoraLib.Tests` o carpeta equivalente
- PR `Semana3 – Calculadora POO` con salida de `dotnet test` en la descripción

## Verificaciones antes de PR
- Ejecutar `dotnet build` y `dotnet test`
- Comprobar la pestaña **PROBLEMS** en Visual Studio y corregir issues relevantes
- Asegurarse de que no hay bin/obj comiteados (.gitignore)
