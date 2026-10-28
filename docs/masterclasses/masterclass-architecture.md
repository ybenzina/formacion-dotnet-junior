# Masterclass Arquitectura

**El domingo siguiente al Día 3 del reto**, antes del ejercicio 3 de la Parte I.

## Contenido

- **SOLID**, con ejemplos del propio CourtConnect.
- **Capas** (Clean Architecture) frente a ***slices* verticales**: qué organiza cada una y por qué en Àmbit se combinan (capas, y dentro de Application, una carpeta por caso de uso).
- **DDD básico:** entidad, objeto de valor, agregado y dónde viven las reglas. Dominio rico solo donde hay reglas de verdad.
- **Inyección de dependencias** y sus ciclos de vida (*transient*, *scoped*, *singleton*). La **dependencia cautiva**: un singleton que guarda algo *scoped*, como el `DbContext`.
- **Patrón Singleton:** qué es y por qué en .NET moderno se resuelve con el contenedor y no con una clase estática.
- **Repositorio y unidad de trabajo:** qué hace ya EF Core (`DbSet` y `DbContext`), cuándo un repositorio específico aporta y por qué no hacemos uno genérico.
- **Mediator** como patrón: qué resuelve y por qué no usamos MediatR (licencia comercial desde la v13, y un *handler* inyectado hace lo mismo sin indirección).
- Otros patrones que aparecerán: Factory, Strategy y Observer.

## Ejercicio

Convertir `RegistrationService` de CourtConnect en *slices* (`Features/Registrations/Register/`, `Features/Registrations/Cancel/`…), **sin mediador**: cada *handler* es una clase que se inyecta en su endpoint. Comparar las dos versiones: qué se gana, qué se repite y qué es más fácil de pedir a una IA.

Es la forma en que se harán las funcionalidades SDD de la Parte III.
