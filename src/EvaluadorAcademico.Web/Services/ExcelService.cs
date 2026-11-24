using ClosedXML.Excel;
using EvaluadorAcademico.Web.Models;

namespace EvaluadorAcademico.Web.Services;

public class ExcelService
{
    private readonly string rutaExcel =
        @"C:\Proyectos\Evaluador_Academico\data\Control_Calificaciones.xlsx";

    public List<Alumno> ObtenerAlumnos()
    {
        var alumnos = new List<Alumno>();

        using var workbook = new XLWorkbook(rutaExcel);

        var hoja = workbook.Worksheet("ALUMNOS");

        var filas = hoja.RowsUsed().Skip(2);

        foreach (var fila in filas)
        {
            alumnos.Add(new Alumno
            {
                Matricula = fila.Cell(2).GetValue<string>().Trim(),
                Nombre = fila.Cell(3).GetValue<string>().Trim(),
                Grupo = fila.Cell(4).GetValue<string>().Trim(),
                Asignatura = fila.Cell(5).GetValue<string>().Trim(),
                Cuatrimestre = fila.Cell(6).GetValue<string>().Trim(),
                Estatus = fila.Cell(7).GetValue<string>().Trim()
            });
        }

        return alumnos;
    }

    public bool ExisteAlumno(string matricula)
    {
        var alumnos = ObtenerAlumnos();

        return alumnos.Any(a =>
            a.Matricula.Trim() ==
            matricula.Trim());
    }

    public Alumno? BuscarAlumno(string matricula)
    {
        var alumnos = ObtenerAlumnos();

        return alumnos.FirstOrDefault(a =>
            a.Matricula.Trim() ==
            matricula.Trim());
    }

    public void GuardarAlumno(Alumno alumno)
    {
        using var workbook = new XLWorkbook(rutaExcel);

        var hoja = workbook.Worksheet("ALUMNOS");

        var ultimaFilaUsada = hoja.LastRowUsed();

        int ultimaFila =
            (ultimaFilaUsada?.RowNumber() ?? 1) + 1;

        hoja.Cell(ultimaFila, 2).Value = alumno.Matricula;
        hoja.Cell(ultimaFila, 3).Value = alumno.Nombre;
        hoja.Cell(ultimaFila, 4).Value = alumno.Grupo;
        hoja.Cell(ultimaFila, 5).Value = alumno.Asignatura;
        hoja.Cell(ultimaFila, 6).Value = alumno.Cuatrimestre;
        hoja.Cell(ultimaFila, 7).Value = alumno.Estatus;

        workbook.Save();
    }

    public void GuardarEvaluacion(
        Evaluacion evaluacion,
        string nombre)
    {
        using var workbook = new XLWorkbook(rutaExcel);

        var hoja = workbook.Worksheet("EVALUACIONES");

        var ultimaFilaUsada = hoja.LastRowUsed();

        int ultimaFila =
            (ultimaFilaUsada?.RowNumber() ?? 1) + 1;

        hoja.Cell(ultimaFila, 1).Value = evaluacion.Matricula;
        hoja.Cell(ultimaFila, 2).Value = nombre;
        hoja.Cell(ultimaFila, 3).Value = evaluacion.Asistencia;
        hoja.Cell(ultimaFila, 4).Value = evaluacion.Actividades;
        hoja.Cell(ultimaFila, 5).Value = evaluacion.Practicas;
        hoja.Cell(ultimaFila, 6).Value = evaluacion.Examen;
        hoja.Cell(ultimaFila, 7).Value = evaluacion.Calificacion10;

        workbook.Save();
    }

    public Evaluacion? ObtenerEvaluacion(
        string matricula)
    {
        using var workbook = new XLWorkbook(rutaExcel);

        var hoja = workbook.Worksheet("EVALUACIONES");

        var filas = hoja.RowsUsed().Skip(1);

        foreach (var fila in filas)
        {
            var matriculaExcel =
                fila.Cell(1).GetValue<string>().Trim();

            if (matriculaExcel ==
                matricula.Trim())
            {
                return new Evaluacion
                {
                    Matricula = matriculaExcel,
                    Asistencia =
                        fila.Cell(3).GetValue<decimal>(),
                    Actividades =
                        fila.Cell(4).GetValue<decimal>(),
                    Practicas =
                        fila.Cell(5).GetValue<decimal>(),
                    Examen =
                        fila.Cell(6).GetValue<decimal>(),
                    Calificacion10 =
                        fila.Cell(7).GetValue<decimal>()
                };
            }
        }

        return null;
    }

    public void ActualizarEvaluacion(
        Evaluacion evaluacion)
    {
        using var workbook = new XLWorkbook(rutaExcel);

        var hoja = workbook.Worksheet("EVALUACIONES");

        var filas = hoja.RowsUsed().Skip(1);

        foreach (var fila in filas)
        {
            var matriculaExcel =
                fila.Cell(1).GetValue<string>().Trim();

            if (matriculaExcel ==
                evaluacion.Matricula.Trim())
            {
                fila.Cell(3).Value =
                    evaluacion.Asistencia;

                fila.Cell(4).Value =
                    evaluacion.Actividades;

                fila.Cell(5).Value =
                    evaluacion.Practicas;

                fila.Cell(6).Value =
                    evaluacion.Examen;

                fila.Cell(7).Value =
                    evaluacion.Calificacion10;

                break;
            }
        }

        workbook.Save();
    }
public ParametrosEvaluacion ObtenerParametros()
{
    using var workbook = new XLWorkbook(rutaExcel);

    var hoja = workbook.Worksheet("PARAMETROS");

    return new ParametrosEvaluacion
    {
        AsistenciaMaxima = hoja.Cell("B6").GetValue<decimal>(),
        ActividadesMaximas = hoja.Cell("C6").GetValue<decimal>(),
        PracticasMaximas = hoja.Cell("D6").GetValue<decimal>(),
        ExamenMaximo = hoja.Cell("E6").GetValue<decimal>(),

        PorcentajeAsistencia = hoja.Cell("B7").GetValue<decimal>(),
        PorcentajeActividades = hoja.Cell("C7").GetValue<decimal>(),
        PorcentajePracticas = hoja.Cell("D7").GetValue<decimal>(),
        PorcentajeExamen = hoja.Cell("E7").GetValue<decimal>()
    };
}
public void GuardarParametros(
    ParametrosEvaluacion parametros)
{
    using var workbook = new XLWorkbook(rutaExcel);

    var hoja = workbook.Worksheet("PARAMETROS");

    hoja.Cell("B6").Value = parametros.AsistenciaMaxima;
    hoja.Cell("C6").Value = parametros.ActividadesMaximas;
    hoja.Cell("D6").Value = parametros.PracticasMaximas;
    hoja.Cell("E6").Value = parametros.ExamenMaximo;

    hoja.Cell("B7").Value = parametros.PorcentajeAsistencia;
    hoja.Cell("C7").Value = parametros.PorcentajeActividades;
    hoja.Cell("D7").Value = parametros.PorcentajePracticas;
    hoja.Cell("E7").Value = parametros.PorcentajeExamen;

    workbook.Save();
}
}