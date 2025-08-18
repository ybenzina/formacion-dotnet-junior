using Xunit;
using GestorTareas;

namespace GestorTareas.Tests;

public class GestorTareasTests
{
    private readonly GestorTareas gestor = new();

    [Fact]
    public void Agregar_DeberiaIncrementarCantidad()
    {
        gestor.Agregar("Test 1", "Descripcion 1");
        var tareas = gestor.ListarTodas();
        Assert.Single(tareas);
    }

    [Fact]
    public void Eliminar_DeberiaQuitarTarea()
    {
        var tarea = gestor.Agregar("Test 2", "Descripcion 2");
        bool eliminado = gestor.Eliminar(tarea.Id);
        Assert.True(eliminado);
        Assert.Empty(gestor.ListarTodas());
    }

    [Fact]
    public void MarcarCompletada_DeberiaCambiarEstado()
    {
        var tarea = gestor.Agregar("Test 3", "Descripcion 3");
        bool ok = gestor.MarcarCompletada(tarea.Id);
        Assert.True(ok);
        Assert.True(gestor.ListarTodas().First().Completada);
    }

    [Fact]
    public void ListarPendientes_DeberiaExcluirCompletadas()
    {
        var t1 = gestor.Agregar("Pendiente", "Tarea pendiente");
        var t2 = gestor.Agregar("Completa", "Tarea completa");
        gestor.MarcarCompletada(t2.Id);

        var pendientes = gestor.ListarPendientes();

        Assert.Contains(pendientes, t => t.Id == t1.Id);
        Assert.DoesNotContain(pendientes, t => t.Id == t2.Id);
    }
}
