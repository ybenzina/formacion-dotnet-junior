using Xunit;
using CalculadoraLib; // Ajusta el namespace según tu solución

namespace CalculadoraLib.Tests
{
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
}
