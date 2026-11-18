using ClosedXML.Excel;
using EvaluadorAcademico.Web.Models;

namespace EvaluadorAcademico.Web.Services;

public class ExcelService
{
    private readonly string _rutaExcel =
        @"C:\Users\luho9\OneDrive\Documents\Evaluador_Academico\data\Control_Calificaciones.xlsx";

    public List<Alumno> ObtenerAlumnos()
    {
        var alumnos = new List<Alumno>();

        using var workbook = new XLWorkbook(_rutaExcel);

        var hoja = workbook.Worksheet("ALUMNOS");

        var filas = hoja.RowsUsed().Skip(2);

        foreach (var fila in filas)
        {
            alumnos.Add(new Alumno
            {
                Matricula = fila.Cell(1).GetValue<string>(),
                Nombre = fila.Cell(2).GetValue<string>(),
                Grupo = fila.Cell(3).GetValue<string>(),
                Asignatura = fila.Cell(4).GetValue<string>(),
                Estatus = fila.Cell(6).GetValue<string>()
            });
        }

        return alumnos;
    }
}