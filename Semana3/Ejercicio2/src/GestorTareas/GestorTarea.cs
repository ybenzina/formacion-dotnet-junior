using System.Collections.Generic;
using System.Linq;

namespace GestorTareas;

public class GestorTareas
{
    private readonly List<Tarea> _tareas = [];
    private int _ultimoId = 0;

    public Tarea Agregar(string titulo, string descripcion)
	{
		if (string.IsNullOrWhiteSpace(titulo))
			throw new ArgumentException("El título no puede estar vacío.", nameof(titulo));

		var tarea = new Tarea(++_ultimoId, titulo, descripcion);
		_tareas.Add(tarea);
		return tarea;
	}

    public bool Eliminar(int id)
    {
		Tarea? tarea = _tareas.FirstOrDefault(t => t.Id == id);
        if (tarea == null) return false;
        _tareas.Remove(tarea);
        return true;
    }

    public IReadOnlyList<Tarea> ListarTodas()
    {
		// Exponer colección inmutable
        return _tareas.AsReadOnly();
    }

	public IReadOnlyList<Tarea> ListarPendientes()
    {
        // Exponer colección inmutable
        return _tareas.Where(t => !t.Completada).ToList().AsReadOnly();
    }

    public bool MarcarCompletada(int id)
    {
		Tarea? tarea = _tareas.FirstOrDefault(t => t.Id == id);
        if (tarea == null) return false;
        tarea.MarcarComoCompletada();
        return true;
    }
}
