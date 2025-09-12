using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace ThreadVsTask
{
    public class ThreadRunners
    {
        
        private long DoWork(int i)
        {
            long acc = 0;
            for (int k = 0; k < 100_000; k++)
                acc += (i * 31 + k) % 97;
            return acc;
        }

        public long RunnerThreads(int n)
        {
            var results = new long[n];  // Array para almacenar resultados
            var threads = new Thread[n]; // Array para mantener referencia a los threads

            // Crear y arrancar todos los threads
            for (int i = 0; i < n; i++)
            {
                int local = i; // Variable local para evitar closure sobre la variable del loop
                threads[i] = new Thread(() => results[local] = DoWork(local));
                threads[i].Start();
            }

            // Esperar a que todos los threads terminen
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return results.Sum(); // Sumar todos los resultados
        }

        public long RunnerBackgroundThreads(int n)
        {
            var results = new long[n];
            var threads = new Thread[n];

            for (int i = 0; i < n; i++)
            {
                int local = i;
                threads[i] = new Thread(() => results[local] = DoWork(local));
                threads[i].IsBackground = true; // La única diferencia con RunnerThreads
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return results.Sum();
        }

        public long RunnerThreadPool(int n)
        {
            var results = new long[n];
            // CountdownEvent nos permite esperar a que todas las operaciones terminen
            var countdown = new CountdownEvent(n);

            for (int i = 0; i < n; i++)
            {
                int local = i;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        results[local] = DoWork(local);
                    }
                    finally
                    {
                        countdown.Signal(); // Señalizar que una operacion ha terminado
                    }
                });
            }

            countdown.Wait(); // Esperar a que todas las operaciones terminen
            return results.Sum();
        }

        public async Task<long> RunnerTasks(int n, CancellationToken ct)
        {
            // Crear y ejecutar todas las tareas en paralelo
            var tasks = Enumerable.Range(0, n).Select(i => Task.Run(() => DoWork(i), ct));
            // Esperar a que todas las tareas terminen y obtener sus resultados
            var results = await Task.WhenAll(tasks);
            return results.Sum();
        }

        /// Metodo para medir el tiempo de ejecucion de una accion sincrona
        public TimeSpan MeasureTime(Action action)
        {
            var sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.Elapsed;
        }

        /// Metodo para medir el tiempo de ejecucion de una accion asincrona
        public async Task<TimeSpan> MeasureTimeAsync(Func<Task> action)
        {
            var sw = Stopwatch.StartNew();
            await action();
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
