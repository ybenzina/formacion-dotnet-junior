using Xunit;

namespace AsyncLib.Tests;

public class OperacionesAsyncTests
{
    [Fact]
    public async Task RealizarOperacionLarga_SinCancelacion_CompletaCorrectamente()
    {
        var operaciones = new OperacionesAsync();
        
        await operaciones.RealizarOperacionLargaAsync(500);
        
        Assert.Contains("Operación completada con éxito", operaciones.LogOperaciones);
        Assert.Contains("Limpiando recursos", operaciones.LogOperaciones);
    }

    [Fact]
    public async Task RealizarOperacionLarga_ConCancelacion_LanzaTaskCanceledException()
    {
        var operaciones = new OperacionesAsync();
        using var cts = new CancellationTokenSource();
        
        var operacionTask = operaciones.RealizarOperacionLargaAsync(2000, cts.Token);
        await Task.Delay(200);
        cts.Cancel();

        await Assert.ThrowsAsync<TaskCanceledException>(() => operacionTask);
        Assert.Contains("Operación cancelada por el usuario", operaciones.LogOperaciones);
        Assert.Contains("Limpiando recursos", operaciones.LogOperaciones);
    }

    [Fact]
    public async Task ProcesarConRecursos_SinCancelacion_DevuelveResultado()
    {
        var operaciones = new OperacionesAsync();

        var resultado = await operaciones.ProcesarConRecursosAsync();

        Assert.Equal(42, resultado);
        Assert.Contains("Iniciando procesamiento con recursos", operaciones.LogOperaciones);
        Assert.Contains("Liberando recursos", operaciones.LogOperaciones);
    }

    [Fact]
    public async Task ProcesarConRecursos_ConCancelacion_LiberaRecursos()
    {
        var operaciones = new OperacionesAsync();
        using var cts = new CancellationTokenSource();

        var operacionTask = operaciones.ProcesarConRecursosAsync(cts.Token);
        await Task.Delay(100);
        cts.Cancel();

        await Assert.ThrowsAsync<TaskCanceledException>(() => operacionTask);
        Assert.Contains("Liberando recursos", operaciones.LogOperaciones);
    }

    [Fact]
    public async Task ProcesarConRecursos_DespuesDeDispose_LanzaObjectDisposedException()
    {
        var operaciones = new OperacionesAsync();
        operaciones.Dispose();

        await Assert.ThrowsAsync<ObjectDisposedException>(() => 
            operaciones.ProcesarConRecursosAsync());
    }
}
