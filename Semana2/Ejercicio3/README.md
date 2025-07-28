# Semana 2 - Ejercicio 3: Test básico con xUnit

## Objetivo
Introducir pruebas unitarias básicas con xUnit para clases de lógica.

## Tareas
- Crear proyecto de test en `/tests`:
  ```bash
  dotnet new xunit -n MyApp.Core.Tests
  dotnet add MyApp.Core.Tests/MyApp.Core.Tests.csproj reference src/MyApp.Core/MyApp.Core.csproj
  ```
- Añadir `SaludoTests.cs`:
  ```csharp
  public class SaludoTests
  {
      [Fact]
      public void Saludar_DeberiaRetornarHolaNombre()
      {
          var svc = new ServicioSaludo();
          Assert.Equal("¡Hola, Maria!", svc.Saludar("Maria"));
      }
  }
  ```
- Ejecutar `dotnet test` y verificar que pasa.

## Recursos
- [xUnit Quickstart](https://learn.microsoft.com/es-es/dotnet/core/testing/unit-testing-with-dotnet-test)
- [Get started with C# – Parte 2](https://learn.microsoft.com/es-es/training/paths/get-started-c-sharp-part-2/) (complemento)

## Entregables
- Pull Request “Semana 2 – Test unitario básico”.
