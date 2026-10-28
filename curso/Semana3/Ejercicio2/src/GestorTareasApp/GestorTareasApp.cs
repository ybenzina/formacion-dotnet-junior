using System;
using GestorTareas;

namespace GestorTareasApp;

class GestorTareasApp
{
    static void Main()
    {
        var gestor = new GestorTareas.GestorTareas();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=== Gestor de Tareas ===");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Listar todas");
            Console.WriteLine("3. Listar pendientes");
            Console.WriteLine("4. Marcar como completada");
            Console.WriteLine("5. Eliminar tarea");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine() ?? "";
                    Console.Write("Descripción: ");
                    string descripcion = Console.ReadLine() ?? "";
					Tarea tarea = gestor.Agregar(titulo, descripcion);
                    Console.WriteLine($"Tarea agregada con Id {tarea.Id}");
                    break;

                case "2":
                    Console.WriteLine("\n--- Todas las tareas ---");
                    foreach (Tarea t in gestor.ListarTodas())
                        Console.WriteLine($"[{t.Id}] {t.Titulo} - {(t.Completada ? "✅" : "⏳")}");
                    break;

                case "3":
                    Console.WriteLine("\n--- Tareas pendientes ---");
                    foreach (Tarea t in gestor.ListarPendientes())
                        Console.WriteLine($"[{t.Id}] {t.Titulo}");
                    break;

                case "4":
                    Console.Write("Id de la tarea a completar: ");
                    if (int.TryParse(Console.ReadLine(), out int idCompletar))
                    {
                        if (gestor.MarcarCompletada(idCompletar))
                            Console.WriteLine("Tarea marcada como completada ✅");
                        else
                            Console.WriteLine("No se encontró esa tarea");
                    }
                    break;

                case "5":
                    Console.Write("Id de la tarea a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        if (gestor.Eliminar(idEliminar))
                            Console.WriteLine("Tarea eliminada 🗑️");
                        else
                            Console.WriteLine("No se encontró esa tarea");
                    }
                    break;

                case "0":
                    salir = true;
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida, intenta de nuevo");
                    break;
            }
        }
    }
}
