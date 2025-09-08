using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace ParallelProcessing
{
    public class ParallelProcessor
    {
        private long Process(int item)
        {
            long result = 0;
            for (int i = 0; i < 100_000; i++)
            {
                result += (item * 31 + i) % 97;
            }
            return result;
        }

        // Procesa los elementos usando un bucle foreach
        public long ProcessSequential(int[] items)
        {
            long total = 0;
            foreach (var item in items)
            {
                total += Process(item);
            }
            return total;
        }

        // Procesa los elementos usando Parallel.ForEach con localInit/localFinally
        public long ProcessParallelForEach(int[] items)
        {
            long total = 0;
            Parallel.ForEach(
                items,
                () => 0L, // Inicializacion del acumulador local para cada tarea
                (item, loopState, localTotal) => localTotal + Process(item), // Funcion que procesa cada elemento y actualiza el acumulador local
                localTotal => Interlocked.Add(ref total, localTotal) // Funcion que combina el resultado local con el total global
            );
            return total;
        }

        // Procesa los elementos usando Parallel.For
        public long ProcessParallelFor(int[] items)
        {
            long total = 0;
            Parallel.For(
                0, // fromInclusive
                items.Length, // toExclusive
                () => 0L, // Inicializacion del acumulador local
                (i, loopState, localTotal) => localTotal + Process(items[i]), // Funcion que procesa cada elemento y actualiza el acumulador local
                localTotal => Interlocked.Add(ref total, localTotal) // Funcion que combina el resultado local con el total global
            );
            return total;
        }

        // Procesa los elementos usando PLINQ
        public long ProcessPLINQ(int[] items)
        {
            return items.AsParallel()
                       .Select(Process)
                       .Sum();
        }

        // Metodo para medir el tiempo de ejecucion
        public TimeSpan MeasureTime(Action action)
        {
            var sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
