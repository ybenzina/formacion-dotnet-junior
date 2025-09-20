using System;
using System.Collections.Generic;
using System.Linq;

public class Alumno
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public double Grade { get; set; }

    // Lista de ejemplo (hay un empate de nota para probar GroupBy)
    public static List<Alumno> ListaEjemplo() => new()
    {
        new Alumno { Id = 1, Nombre = "Ana", Grade = 8.5 },
        new Alumno { Id = 2, Nombre = "Luis", Grade = 6.0 },
        new Alumno { Id = 3, Nombre = "Marta", Grade = 9.0 },
        new Alumno { Id = 4, Nombre = "Pedro", Grade = 4.5 },
        new Alumno { Id = 5, Nombre = "Lucia", Grade = 6.0 }, // empate con Luis
    };
}

public static class AlumnoQueries
{
    // Approved. Alumnos con Grade >= 5
    public static IEnumerable<Alumno> Approved(IEnumerable<Alumno> alumnos) =>
        alumnos.Where(a => a.Grade >= 5.0);

    // Average. Si la coleccion esta vacia, devolvemos 0
    public static double Average(IEnumerable<Alumno> alumnos) =>
        alumnos.Any() ? alumnos.Average(a => a.Grade) : 0.0;

    // Descendente por Grade
    public static IEnumerable<Alumno> OrderedByGrade(IEnumerable<Alumno> alumnos) =>
        alumnos.OrderByDescending(a => a.Grade);

    // Agrupar por Grade
    public static IEnumerable<IGrouping<double, Alumno>> GroupByGrade(IEnumerable<Alumno> alumnos) =>
        alumnos.GroupBy(a => a.Grade);

    // Suma de notas
    public static double SumGrades(IEnumerable<Alumno> alumnos) =>
        alumnos.Sum(a => a.Grade);

    // Se une con una lista
    public static IEnumerable<(string Alumno, string Subject)> JoinSubjects(
        IEnumerable<Alumno> alumnos,
        IEnumerable<(int AlumnoId, string Subject)> subjects)
    {
        return alumnos.Join(subjects,
            a => a.Id,
            s => s.AlumnoId,
            (a, s) => (a.Nombre, s.Subject));
    }

    // Implementacion propia de "Where"
    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Func<T, bool> predicate)
    {
        foreach (var item in items)
        {
            if (predicate(item))
                yield return item;
        }
    }
}
