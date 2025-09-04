namespace GestorTareas;

public class Tareas
{
    public int Id { get; }
    public string Titulo { get; }
    public string Descripcion { get; }
    public DateTime FechaCreacion { get; }
    public bool Completada { get; private set; }

    public Tareas(int Id, string Titulo, string Descripcion)
    {
        this.Id = Id;
        this.Titulo = Titulo;
        this.Descripcion = Descripcion;
        FechaCreacion = DateTime.Now;
        Completada = false;
    }

    public void MarcarComoCompletada()
    {
        Completada = true;
    }
}
