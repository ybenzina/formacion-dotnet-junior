# Guía xUnit - Intermedio (Facts, Theory, InlineData)

## Ejemplo Fact
```csharp
using Xunit;

public class CalculadoraTests
{
    [Fact]
    public void Sumar_DosNumeros_RetornaResultado()
    {
        var calc = new Calculadora();
        Assert.Equal(5, calc.Sumar(2,3));
    }
}
```

## Ejemplo Theory + InlineData
```csharp
using Xunit;

public class CalculadoraTheoryTests
{
    [Theory]
    [InlineData(5, 2, 3)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, -3, 2)]
    public void Sumar_VariosCasos(int expected, int a, int b)
    {
        var calc = new Calculadora();
        Assert.Equal(expected, calc.Sumar(a,b));
    }
}
```

## Comprobaciones y buenas prácticas
- Mantener tests independientes entre sí.
- Nombres descriptivos: `Metodo_Escenario_ResultadoEsperado`.
- Ejecuta `dotnet test --verbosity normal` para obtener salida clara.
