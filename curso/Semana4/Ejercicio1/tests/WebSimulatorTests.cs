using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Semana4.Ejercicio1;

namespace Semana4.Ejercicio1.Tests
{
    public class WebSimulatorTests
    {
        private readonly WebSimulator simulator = new WebSimulator();

        [Theory]
        [InlineData("http://test1.com", "Contenido simulado de http://test1.com")]
        [InlineData("https://test2.com", "Contenido simulado de https://test2.com")]
        public async Task DescargarPaginaAsync_DevuelveContenidoSimulado(string url, string expected)
        {
            var result = await simulator.DescargarPaginaAsync(url);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("uno dos tres", 3)]
        [InlineData("", 0)]
        [InlineData("palabra", 1)]
        [InlineData("muchas palabras en una frase", 5)]
        public async Task ContarPalabrasAsync_DeberiaContarPalabras(string contenido, int expected)
        {
            var result = await simulator.ContarPalabrasAsync(contenido);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new[] { "url1", "url2" }, 8)]
        [InlineData(new[] { "url3" }, 4)]
        public async Task ContarPalabrasMultiplesAsync_DeberiaSumarPalabrasDeMultiplesUrls(string[] urls, int esperado)
        {
            var total = await simulator.ContarPalabrasMultiplesAsync(urls);
            Assert.Equal(esperado, total);
        }
    }
}
