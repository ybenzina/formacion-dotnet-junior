using System.Text;

namespace AsyncLib;

public class OperacionesAsync
{
    private readonly StringBuilder logOperaciones = new();
    private bool disposed;

    public string LogOperaciones => logOperaciones.ToString();

    public async Task RealizarOperacionLargaAsync(int duracionMs, CancellationToken cancellationToken = default)
    {
        try
        {
            logOperaciones.AppendLine("Iniciando operación larga...");
            
            const int intervalo = 100;
            var tiempoRestante = duracionMs;
            
            while (tiempoRestante > 0)
            {
                cancellationToken.ThrowIfCancellationRequested();
                
                await Task.Delay(Math.Min(intervalo, tiempoRestante), cancellationToken);
                tiempoRestante -= intervalo;
                
                logOperaciones.AppendLine($"Progreso: {Math.Min(100, (duracionMs - tiempoRestante) * 100 / duracionMs)}%");
            }

            logOperaciones.AppendLine("Operación completada con éxito.");
        }
        catch (OperationCanceledException)
        {
            logOperaciones.AppendLine("Operación cancelada por el usuario.");
            throw;
        }
        finally
        {
            logOperaciones.AppendLine("Limpiando recursos...");
        }
    }

    public async Task<int> ProcesarConRecursosAsync(CancellationToken cancellationToken = default)
    {
        if (disposed)
        {
            throw new ObjectDisposedException(nameof(OperacionesAsync));
        }

        try
        {
            logOperaciones.AppendLine("Iniciando procesamiento con recursos...");
            
            for (int i = 0; i < 5; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(200, cancellationToken);
                logOperaciones.AppendLine($"Procesando parte {i + 1} de 5...");
            }

            return 42; // Valor de ejemplo
        }
        finally
        {
            logOperaciones.AppendLine("Liberando recursos...");
        }
    }

    public void Dispose()
    {
        if (!disposed)
        {
            logOperaciones.Clear();
            disposed = true;
        }
    }
}
