using System;
using System.Threading.Tasks;

namespace ParallelProcessing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var processor = new ParallelProcessor();

            // Tamaños de prueba
            int[] sizes = { 10_000, 100_000, 300_000 };

            foreach (var n in sizes)
            {
                Console.WriteLine($"\nPruebas con {n:N0} elementos:");
                Console.WriteLine("----------------------------------------");

                var items = new int[n];
                for (int i = 0; i < n; i++) items[i] = i;

                // Medir y mostrar tiempos para cada implementación
                var sequentialTime = processor.MeasureTime(() =>
                {
                    var result = processor.ProcessSequential(items);
                    Console.WriteLine($"Sequential: {result:N0}");
                });

                var parallelForEachTime = processor.MeasureTime(() =>
                {
                    var result = processor.ProcessParallelForEach(items);
                    Console.WriteLine($"Parallel.ForEach: {result:N0}");
                });

                var parallelForTime = processor.MeasureTime(() =>
                {
                    var result = processor.ProcessParallelFor(items);
                    Console.WriteLine($"Parallel.For: {result:N0}");
                });

                var plinqTime = processor.MeasureTime(() =>
                {
                    var result = processor.ProcessPLINQ(items);
                    Console.WriteLine($"PLINQ: {result:N0}");
                });

                // Mostrar comparativa de tiempos
                Console.WriteLine("\nComparativa de tiempos:");
                Console.WriteLine($"Sequential:       {sequentialTime.TotalMilliseconds:N2}ms");
                Console.WriteLine($"Parallel.ForEach: {parallelForEachTime.TotalMilliseconds:N2}ms");
                Console.WriteLine($"Parallel.For:     {parallelForTime.TotalMilliseconds:N2}ms");
                Console.WriteLine($"PLINQ:           {plinqTime.TotalMilliseconds:N2}ms");

                // Calcular y mostrar speedup
                var baseTime = sequentialTime.TotalMilliseconds;
                Console.WriteLine("\nSpeedups:");
                Console.WriteLine("Sequential:");
                Console.WriteLine($"Parallel.ForEach: {baseTime / parallelForEachTime.TotalMilliseconds:N2}x");
                Console.WriteLine($"Parallel.For:     {baseTime / parallelForTime.TotalMilliseconds:N2}x");
                Console.WriteLine($"PLINQ:           {baseTime / plinqTime.TotalMilliseconds:N2}x");
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
