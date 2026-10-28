using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadVsTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var runners = new ThreadRunners();
            var cts = new CancellationTokenSource();

            // Numero de operaciones a realizar
            int n = 1000;
            Console.WriteLine($"Ejecutando {n} operaciones con cada método...\n");

			try
			{
				// Medir tiempo con Thread normales
				var threadTime = runners.MeasureTime(() =>
				{
					var result = runners.RunnerThreads(n);
					Console.WriteLine($"Resultado con Threads: {result}");
				});
				Console.WriteLine($"Tiempo con Threads: {threadTime.TotalMilliseconds:F2}ms\n");

				// Medir tiempo con Background Threads
				var bgThreadTime = runners.MeasureTime(() =>
				{
					var result = runners.RunnerBackgroundThreads(n);
					Console.WriteLine($"Resultado con Background Threads: {result}");
				});
				Console.WriteLine($"Tiempo con Background Threads: {bgThreadTime.TotalMilliseconds:F2}ms\n");

				// Medir tiempo con ThreadPool
				var poolTime = runners.MeasureTime(() =>
				{
					var result = runners.RunnerThreadPool(n);
					Console.WriteLine($"Resultado con ThreadPool: {result}");
				});
				Console.WriteLine($"Tiempo con ThreadPool: {poolTime.TotalMilliseconds:F2}ms\n");

				// Medir tiempo con Tasks
				var taskTime = await runners.MeasureTimeAsync(async () =>
				{
					var result = await runners.RunnerTasks(n, cts.Token);
					Console.WriteLine($"Resultado con Tasks: {result}");
				});
				Console.WriteLine($"Tiempo con Tasks: {taskTime.TotalMilliseconds:F2}ms\n");

				// Demostracion de cancelacion con Tasks
#pragma warning disable CA1303 // Do not pass literals as localized parameters
				Console.WriteLine("\nDemostrando cancelacion con Tasks...");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
				var cancellationTask = Task.Run(async () =>
				{
					try
					{
						// Iniciamos una tarea larga
						var result = await runners.RunnerTasks(10000, cts.Token);
						Console.WriteLine($"Resultado (no deberiamos ver esto): {result}");
					}
					catch (OperationCanceledException)
					{
						Console.WriteLine("La operacion fue cancelada exitosamente.");
					}
				});

				// Esperamos un momento y luego cancelamos
				await Task.Delay(100);
				cts.Cancel();
				await cancellationTask;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error inesperado: {ex.Message}");
				Environment.Exit(1);
            }
        }
    }
}
