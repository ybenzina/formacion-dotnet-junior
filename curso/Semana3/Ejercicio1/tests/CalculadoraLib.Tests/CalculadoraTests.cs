using Xunit;
using CalculadoraLib;

namespace CalculadoraLib.Tests;

public class CalculadoraTests
{
    private readonly Calculadora _calc = new Calculadora();

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 4, 3)]
    [InlineData(0, 0, 0)]
    public void Sumar_VariosCasos(double a, double b, double esperado)
    {
        var resultado = _calc.Sumar(a, b);
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(-2, 3, -6)]
    [InlineData(0, 5, 0)]
    public void Multiplicar_VariosCasos(double a, double b, double esperado)
    {
        var resultado = _calc.Multiplicar(a, b);
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void Dividir_DivisorCero_LanzaExcepcion()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(5, 0));
    }

    [Fact]
    public void RaizCuadrada_NumeroNegativo_LanzaExcepcion()
    {
        Assert.Throws<ArgumentException>(() => _calc.RaizCuadrada(-9));
    }

    [Fact]
    public void Potencia_Base2Exp3_Devuelve8()
    {
        var resultado = _calc.Potencia(2, 3);
        Assert.Equal(8, resultado);
    }
}
