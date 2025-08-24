# 📈  Feedback técnico — Semana 3

## ✅ Puntos fuertes

- Ha completado correctamente todos los ejercicios obligatorios de la semana 3.
- Los PRs fueron creados, revisados, aprobados y mergeados correctamente en la rama `drissbego/integration`.
- El flujo de trabajo con ramas y PRs se aplicó bien, siguiendo buenas prácticas de commits y ramas temáticas.
- El código es legible, estructurado y con buena separación entre capas.
- Implementaciones limpias y con buena separación: `Calculadora` y `GestorTarea` muestran un diseño orientado a objetos claro.
- Los tests con xUnit utilizan `Theory` + `InlineData` donde toca — cubren casos felices y casos límite (ej.: división/raíz).
- Buen uso de propiedades y encapsulación básica (`OperacionesRealizadas` readonly, `Tareas.Completada` private set).

## 🔎 Observaciones de mejora

1. **Reglas de estilo y naming (.editorconfig)**
   - Algunos avisos de estilo (naming) definidos en `.editorconfig` no se han aplicado en todos los casos.
   - Estos no aparecen en el panel *Problems* de VS Code (limitación de la herramienta), pero sí se muestran como sugerencias en las "bombillas".
   - ⚠️ Recordar revisarlos manualmente en futuros ejercicios.

2. **Actualización de ramas**
   - Al crear ramas de ejercicios desde una `main` desactualizada, la documentación no estaba alineada.
   - Esto ya se corrigió, pero conviene **hacer siempre `git pull origin main` antes de crear nuevas ramas**.

3. **Cierre de issues y checklists**
   - Varias tareas marcadas en issues o checklists quedaron sin actualizar en GitHub aunque sí se completaron.
   - Se recomienda **marcar los checks y cerrar los issues** cuando termines, para dejar trazabilidad clara del progreso.

4. **Naming en singular para clases**
   - Has definido la clase `Tareas` en plural. Recomendación: **usar singular** (`Tarea`) salvo que sea una colección.

## 📌 Recomendaciones

- Reforzar atención a las sugerencias de estilo de código.
- Mantener issues y checklists al día para reflejar el estado real.
- Asegurarse de crear ramas desde una base actualizada.
- Continuar con la misma constancia, la base de código está sólida.

## 🛠️ Sugerencias de mejora de código (opcional, formativo)

### A) Calculadora — tests adicionales

- **Contador de operaciones** (`OperacionesRealizadas`):

```csharp
using Xunit;
using CalculadoraLib; // Ajusta el namespace según tu solución

public class CalculadoraOperacionesTests
{
    [Fact]
    public void OperacionesRealizadas_Incrementa_Tras_Multiples_Operaciones()
    {
        var calc = new Calculadora();
        calc.Sumar(1, 1);
        calc.Multiplicar(2, 3);
        calc.Dividir(10, 2);

        Assert.Equal(3, calc.OperacionesRealizadas);
    }
}
```

- **Precisión en `double`** (tolerancia en asserts), útil por ejemplo en división:

```csharp
using Xunit;
using CalculadoraLib;

public class CalculadoraPrecisionTests
{
    [Theory]
    [InlineData(1, 3, 0.33333)]
    [InlineData(2, 3, 0.66667)]
    public void Dividir_UsaToleranciaEnDouble(double a, double b, double esperado)
    {
        var calc = new Calculadora();
        var resultado = calc.Dividir(a, b);
        Assert.Equal(esperado, resultado, 5); // 5 decimales de precisión
    }
}
```

### B) GestorTarea — encapsulación y validaciones

- **Devolver colección de solo lectura** para no exponer la lista interna:

```csharp
// En GestorTarea.cs
private readonly List<Tarea> tareas = new();

public IReadOnlyList<Tarea> ListarTodas() => tareas.AsReadOnly();
```

- **Validar entradas** al agregar:

```csharp
public void Agregar(string titulo, string? descripcion = null)
{
    if (string.IsNullOrWhiteSpace(titulo))
        throw new ArgumentException("El título no puede estar vacío.", nameof(titulo));

    tareas.Add(new Tarea(titulo, descripcion));
}
```

- **Tests para entradas inválidas:**

```csharp
using Xunit;
using GestorTareas; // Ajusta el namespace según tu solución

public class GestorTareasValidationTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Agregar_TituloInvalido_LanzaArgumentException(string tituloInvalido)
    {
        var gestor = new GestorTarea();
        Assert.Throws<ArgumentException>(() => gestor.Agregar(tituloInvalido));
    }
}
```

- **Renombrar clase `Tareas` → `Tarea`** (singular) y su archivo `Tareas.cs` → `Tarea.cs`.

---
