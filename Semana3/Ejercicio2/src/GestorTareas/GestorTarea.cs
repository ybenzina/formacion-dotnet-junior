using System.Collections.Generic;
using System.Linq;

namespace GestorTareas;

public class GestorTarea
{
    private readonly List<Tareas> tareas = new();
    private int ultimoId = 0;

    public Tareas Agregar(string titulo, string descripcion)
    {
        var tarea = new Tareas(++ultimoId, titulo, descripcion);
        tareas.Add(tarea);
        return tarea;
    }

    public bool Eliminar(int id)
    {
        var tarea = tareas.FirstOrDefault(t => t.Id == id);
        if (tarea == null) return false;
        tareas.Remove(tarea);
        return true;
    }

    public List<Tareas> ListarTodas()
    {
        return tareas.ToList();
    }

    public List<Tareas> ListarPendientes()
    {
        return tareas.Where(t => !t.Completada).ToList();
    }

    public bool MarcarCompletada(int id)
    {
        var tarea = tareas.FirstOrDefault(t => t.Id == id);
        if (tarea == null) return false;
        tarea.MarcarComoCompletada();
        return true;
    }
}
