using Xunit;
using CalculadoraPOO;
using System;

public class CalculadoraTests
{
    private readonly Calculadora calc = new Calculadora();

    // Theory + InlineData para casos felices
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    public void Sumar_DevuelveResultadoCorrecto(double a, double b, double esperado)
    {
        Assert.Equal(esperado, calc.Sumar(a, b));
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(0, 1, -1)]
    public void Restar_DevuelveResultadoCorrecto(double a, double b, double esperado)
    {
        Assert.Equal(esperado, calc.Restar(a, b));
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(-1, 1, -1)]
    public void Multiplicar_DevuelveResultadoCorrecto(double a, double b, double esperado)
    {
        Assert.Equal(esperado, calc.Multiplicar(a, b));
    }

    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(5, 2, 2.5)]
    public void Dividir_DevuelveResultadoCorrecto(double a, double b, double esperado)
    {
        Assert.Equal(esperado, calc.Dividir(a, b));
    }

    // Caso límite: división por cero
    [Fact]
    public void Dividir_DivisionPorCero_LanzaExcepcion()
    {
        Assert.Throws<DivideByZeroException>(() => calc.Dividir(5, 0));
    }

    [Theory]
    [InlineData(2, 3, 8)]
    [InlineData(4, 0.5, 2)]
    public void Potencia_DevuelveResultadoCorrecto(double baseNum, double exponente, double esperado)
    {
        Assert.Equal(esperado, calc.Potencia(baseNum, exponente));
    }

    [Theory]
    [InlineData(4, 2)]
    [InlineData(9, 3)]
    public void Raiz_DevuelveResultadoCorrecto(double valor, double esperado)
    {
        Assert.Equal(esperado, calc.Raiz(valor));
    }

    // Caso límite: raíz de número negativo
    [Fact]
    public void Raiz_Negativo_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() => calc.Raiz(-1));
    }
}
