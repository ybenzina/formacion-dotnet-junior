using Xunit;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ConcurrencyLib.Tests;

public class ConcurrencyTests
{
    [Fact]
    public async Task ContadorNoSincronizado_MuestraRaceCondition()
    {
        // Arrange
        var contador = new ContadorConcurrente();
        var tareas = new List<Task>();

        // Act
        for (int i = 0; i < 1000; i++)
        {
            tareas.Add(Task.Run(() => contador.IncrementarNoSincronizado()));
        }
        await Task.WhenAll(tareas);

        // Assert
        // Es probable que el valor sea menor que 1000 debido a race conditions
        Assert.NotEqual(1000, contador.ValorNoSincronizado);
    }

    [Fact]
    public async Task ContadorConLock_NoMuestraRaceCondition()
    {
        // Arrange
        var contador = new ContadorConcurrente();
        var tareas = new List<Task>();

        // Act
        for (int i = 0; i < 1000; i++)
        {
            tareas.Add(Task.Run(() => contador.IncrementarConLock()));
        }
        await Task.WhenAll(tareas);

        // Assert
        Assert.Equal(1000, contador.ValorLock);
    }

    [Fact]
    public async Task ContadorConInterlocked_NoMuestraRaceCondition()
    {
        // Arrange
        var contador = new ContadorConcurrente();
        var tareas = new List<Task>();

        // Act
        for (int i = 0; i < 1000; i++)
        {
            tareas.Add(Task.Run(() => contador.IncrementarConInterlocked()));
        }
        await Task.WhenAll(tareas);

        // Assert
        Assert.Equal(1000, contador.ValorInterlocked);
    }

    [Fact]
    public async Task AccesoLimitado_RespetaLimiteDeOperacionesConcurrentes()
    {
        // Arrange
        const int maxConcurrencia = 3;
        var accesoLimitado = new AccesoLimitado(maxConcurrencia);
        var operacionesMaximas = new ConcurrentBag<int>();
        var tareas = new List<Task>();

        // Act
        for (int i = 0; i < 100; i++)
        {
            tareas.Add(accesoLimitado.EjecutarOperacionAsync(async () =>
            {
                operacionesMaximas.Add(accesoLimitado.OperacionesConcurrentes);
                await Task.Delay(10);
            }));
        }
        await Task.WhenAll(tareas);

        // Assert
        Assert.True(operacionesMaximas.Max() <= maxConcurrencia);
    }
}
