using ClosedXML.Excel;
using EvaluadorAcademico.Web.Models;

namespace EvaluadorAcademico.Web.Services;

public class ExcelService
{
    private readonly string rutaExcel =
        @"C:\Users\luho9\OneDrive\Documents\Evaluador_Academico\data\Control_Calificaciones.xlsx";

    public List<Alumno> ObtenerAlumnos()
    {
        var alumnos = new List<Alumno>();

        using var workbook = new XLWorkbook(rutaExcel);

        var hoja = workbook.Worksheet("ALUMNOS");

        Console.WriteLine("===== DIAGNOSTICO EXCEL =====");

        foreach (var fila in hoja.RowsUsed())
        {
            Console.WriteLine(
                $"Fila {fila.RowNumber()} | " +
                $"C1=[{fila.Cell(1).GetValue<string>()}] | " +
                $"C2=[{fila.Cell(2).GetValue<string>()}] | " +
                $"C3=[{fila.Cell(3).GetValue<string>()}] | " +
                $"C4=[{fila.Cell(4).GetValue<string>()}] | " +
                $"C5=[{fila.Cell(5).GetValue<string>()}] | " +
                $"C6=[{fila.Cell(6).GetValue<string>()}]");
        }

        var filas = hoja.RowsUsed().Skip(2);

        foreach (var fila in filas)
        {
            alumnos.Add(new Alumno
            {
                Matricula = fila.Cell(2).GetValue<string>().Trim(),
                Nombre = fila.Cell(3).GetValue<string>().Trim(),
                Grupo = fila.Cell(4).GetValue<string>().Trim(),
                Asignatura = fila.Cell(5).GetValue<string>().Trim(),
                Estatus = fila.Cell(7).GetValue<string>().Trim()
            });
        }

        return alumnos;
    }

    public Alumno? BuscarAlumno(string matricula)
    {
        var alumnos = ObtenerAlumnos();

        Console.WriteLine("===== ALUMNOS LEIDOS =====");

        foreach (var alumno in alumnos)
        {
            Console.WriteLine(
                $"[{alumno.Matricula}] - {alumno.Nombre}");
        }

        Console.WriteLine($"BUSCANDO: [{matricula}]");

        return alumnos.FirstOrDefault(
            a => a.Matricula.Trim()
                .Equals(
                    matricula.Trim(),
                    StringComparison.OrdinalIgnoreCase));
    }
}