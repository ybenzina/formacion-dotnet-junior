# Semana 2 - Ejercicio 2: Solución .NET multi-proyecto

## Objetivo
Crear una solución .NET con varios proyectos (Core + Console).

## Tareas
- Crear solución `MyApp` con:
  - `src/MyApp.Core/MyApp.Core.csproj` (librería de clases)
  - `src/MyApp.Console/MyApp.Console.csproj` (aplicación de consola referenciando Core)
- En `MyApp.Core`, implementar `ServicioSaludo.Saludar(string nombre)` que devuelva `"¡Hola, {nombre}!"`.
- En `MyApp.Console`, solicitar el nombre del usuario y mostrar el saludo en consola.
- Mantener la siguiente estructura de carpetas:
  ```
  /src
    /MyApp.Core
    /MyApp.Console
  /tests
  ```

## Recursos
- [Tutorial .NET multi-proyecto (VS Code)](https://learn.microsoft.com/es-es/dotnet/core/tutorials/with-visual-studio-code)

## Entregables
- Pull Request “Semana 2 – Solución .NET”.
