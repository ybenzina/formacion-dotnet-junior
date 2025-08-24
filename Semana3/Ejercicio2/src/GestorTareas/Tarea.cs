namespace GestorTareas;

public class Tarea
{
    public int Id { get; }
    public string Titulo { get; }
    public string Descripcion { get; }
    public DateTime FechaCreacion { get; }
    public bool Completada { get; private set; }

    public Tarea(int id, string titulo, string descripcion)
    {
        Id = id;
        Titulo = titulo;
        Descripcion = descripcion;
        FechaCreacion = DateTime.Now;
        Completada = false;
    }

    public void MarcarComoCompletada()
    {
        Completada = true;
    }
}
