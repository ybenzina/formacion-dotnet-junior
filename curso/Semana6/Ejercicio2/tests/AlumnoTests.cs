using System.Collections.Generic;
using System.Linq;
using Xunit;

public class AlumnoTests
{
    [Fact]
    public void Approved_DeberiaFilterCorrectamente()
    {
        var students = Alumno.ListaEjemplo();
        var approved = AlumnoQueries.Approved(students).ToList();

        Assert.All(approved, a => Assert.True(a.Grade >= 5));
    }

    [Fact]
    public void Average_ConListaVacia_DeberiaSerCero()
    {
        var average = AlumnoQueries.Average(new List<Alumno>());
        Assert.Equal(0, average);
    }

    [Fact]
    public void OrderedByGrade_DeberiaEstarDescendente()
    {
        var students = Alumno.ListaEjemplo();
        var ordered = AlumnoQueries.OrderedByGrade(students).ToList();

        var grades = ordered.Select(a => a.Grade).ToList();
        var ordenadas = grades.OrderByDescending(x => x).ToList();

        Assert.Equal(ordenadas, grades);
    }

    [Fact]
    public void GroupByGrade_DeberiaDetectarEmpates()
    {
        var students = Alumno.ListaEjemplo();
        var grupos = AlumnoQueries.GroupByGrade(students);

        Assert.Contains(grupos, g => g.Count() > 1);
    }

    [Fact]
    public void Filter_DeberiaComportarseIgualQueWhere()
    {
        var students = Alumno.ListaEjemplo();

        var f1 = AlumnoQueries.Filter(students, a => a.Grade >= 7).ToList();
        var f2 = students.Where(a => a.Grade >= 7).ToList();

        Assert.Equal(f2.Count, f1.Count);
        Assert.Equal(f2.Select(a => a.Id), f1.Select(a => a.Id));
    }

    [Fact]
    public void JoinSubjects_DeberiaUnirCorrectamente()
    {
        var students = Alumno.ListaEjemplo();
        var subjects = new List<(int AlumnoId, string Subject)>
        {
            (1, "Matemáticas"),
            (2, "Historia"),
            (3, "Física"),
        };

        var result = AlumnoQueries.JoinSubjects(students, subjects).ToList();

        Assert.Contains(result, r => r.Alumno == "Ana" && r.Subject == "Matemáticas");
        Assert.Equal(3, result.Count);
    }
}
