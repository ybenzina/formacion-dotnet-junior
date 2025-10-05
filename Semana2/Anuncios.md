# 📢 **Semana 2 – Git avanzado y Solución .NET multi-proyecto**

🎯 **Objetivos de la semana**
1. Dominar el flujo Git: rebase interactivo y Pull Requests.
2. Crear soluciones .NET con varios proyectos (Core + Console).
3. Introducir testing básico con xUnit (clases de lógica).

🛠️ **Tareas prácticas**

1. **Ejercicio 1 – Git Avanzado**
   - Crea la rama `semana2-ej1` desde `main`.
   - Modifica `README.md` (añade fecha y “Hola Mundo .NET”).
   - Realiza un rebase interactivo para combinar commits triviales (`git rebase -i main`).
   - Abre un **Pull Request** “Semana 2 – Git Avanzado” solicitando revisión de tu rebase.

2. **Ejercicio 2 – Solución .NET multi‑proyecto**
   - Desde CLI o Visual Studio crea la solución `MyApp` con:
     - `src/MyApp.Core/MyApp.Core.csproj` (librería de clases)
     - `src/MyApp.Console/MyApp.Console.csproj` (con referencia a Core)
   - En `MyApp.Core` implementa `ServicioSaludo.Saludar(string nombre)` que devuelva `"¡Hola, {nombre}!"`.
   - En `MyApp.Console`, pide el nombre al usuario y muestra el saludo.
   - Estructura de carpetas:
     ```
     /src
       /MyApp.Core
       /MyApp.Console
     /tests
     ```
   - Haz commits coherentes y abre PR “Semana 2 – Solución .NET”.

3. **Ejercicio 3 – Test básico con xUnit**
   - Crea el proyecto de pruebas en `/tests`:
     ```bash
     dotnet new xunit -n MyApp.Core.Tests
     dotnet add MyApp.Core.Tests/MyApp.Core.Tests.csproj reference src/MyApp.Core/MyApp.Core.csproj
     ```
   - Añade `SaludoTests.cs`:
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
   - Ejecuta `dotnet test` y sube los resultados.
   - Abre PR “Semana 2 – Test unitario básico”.

   📚 **Recursos**
- Git avanzado: https://git-scm.com/book/es/v2/Ramificaciones-en-Git-Reorganizar-el-Trabajo-Realizado
- .NET multi‑proyecto: https://learn.microsoft.com/es-es/dotnet/core/tutorials/with-visual-studio-code
- xUnit Quickstart: https://learn.microsoft.com/es-es/dotnet/core/testing/unit-testing-with-dotnet-test
- Get started with C# – Parte 2: https://learn.microsoft.com/es-es/training/paths/get-started-c-sharp-part-2/  (recomendado como complemento)

📌 **Entregables**
- PR “Semana 2 – Git Avanzado”
- PR “Semana 2 – Solución .NET”
- PR “Semana 2 – Test unitario básico”

👨‍🏫 **Autoevaluación**
- ¿Puedo explicar qué hace `rebase -i` y por qué lo usamos?
- ¿Entiendo la estructura de una solución .NET multi‑proyecto?
- ¿Soy capaz de ejecutar y entender un test con xUnit?
