# Semana 3 - Referencia rápida (POO y testing intermedio)

## Objetivos principales esta semana
- Consolidar POO en C#: clases, propiedades, encapsulación, excepciones y métodos.
- Escribir y ejecutar tests unitarios intermedios con xUnit (`Fact`, `Theory`, `InlineData`).
- Aplicar estilo con `.editorconfig` y comprobar la pestaña PROBLEMS en Visual Studio.

## Comandos útiles
- Crear solución / proyecto:
  - `dotnet new sln -n NombreSolucion`
  - `dotnet new classlib -n MiLib -o src/MiLib`
  - `dotnet new console -n MiApp -o src/MiApp`
- Añadir proyecto a solución:
  - `dotnet sln add src/MiLib/MiLib.csproj`
  - `dotnet add src/MiApp/MiApp.csproj reference src/MiLib/MiLib.csproj`
- Tests:
  - `dotnet new xunit -n MiLib.Tests -o tests/MiLib.Tests`
  - `dotnet add tests/MiLib.Tests/MiLib.Tests.csproj reference src/MiLib/MiLib.csproj`
  - `dotnet test`

## Recursos Microsoft Learn (complemento)
- Obligatorios esta semana:
  - Get started with C# – Parte 3: https://learn.microsoft.com/es-es/training/paths/get-started-c-sharp-part-3/
  - Get started with C# – Parte 4: https://learn.microsoft.com/es-es/training/paths/get-started-c-sharp-part-4/
- Opcionales:
  - Parte 5: https://learn.microsoft.com/es-es/training/paths/get-started-c-sharp-part-5/
  - Parte 6: https://learn.microsoft.com/es-es/training/paths/get-started-c-sharp-part-6/

## Sobre pruebas (recordatorio)
- Usa `Fact` para casos únicos y `Theory` + `InlineData` para parametrizar entradas.
- Añade tests para casos felices y casos límite (e.g. divisiones por cero, inputs nulos, strings vacíos).
- Incluye la salida de `dotnet test` en la descripción del PR (o una captura) cuando abras el PR.
