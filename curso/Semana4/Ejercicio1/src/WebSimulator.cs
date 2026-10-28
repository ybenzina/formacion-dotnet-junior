using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semana4.Ejercicio1
{
    public class WebSimulator
    {
        public async Task<string> DescargarPaginaAsync(string url)
        {
            await Task.Delay(200); // Simula tiempo de descarga/delay
            return $"Contenido simulado de {url}";
        }

        public async Task<int> ContarPalabrasAsync(string contenido)
        {
            await Task.Delay(50);
            if (string.IsNullOrWhiteSpace(contenido)) return 0; // Manejo de caso vacio o solo espacios
            var palabras = contenido.Split((char[])null, System.StringSplitOptions.RemoveEmptyEntries); // Divide por espacios y elimina nulls (Stack Oberflow, tube que buscarlo pq tenia problemas y no se me pasaba por la cabeza)
            return palabras.Length;
        }

        public async Task<int> ContarPalabrasMultiplesAsync(IEnumerable<string> urls)
        {
            var tareasDescarga = urls.Select(DescargarPaginaAsync).ToArray();
            var contenidos = await Task.WhenAll(tareasDescarga); // Espera a que todas las descargas terminen
            var tareasConteo = contenidos.Select(ContarPalabrasAsync).ToArray();
            var conteos = await Task.WhenAll(tareasConteo);
            return conteos.Sum(); // Una vez obtenidos los conteos, se suman y devuelven la suma de estos
        }
    }
}
