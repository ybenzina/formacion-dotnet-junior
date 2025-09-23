using Xunit;
using CalculadoraLib; // Ajusta el namespace según tu solución

namespace CalculadoraLib.Tests
{
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
}
