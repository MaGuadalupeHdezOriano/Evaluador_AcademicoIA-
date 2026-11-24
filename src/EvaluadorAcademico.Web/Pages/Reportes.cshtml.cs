using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluadorAcademico.Web.Models;

namespace EvaluadorAcademico.Web.Pages;

public class ReportesModel : PageModel
{
    public int TotalAlumnos { get; set; }

    public int TotalEvaluaciones { get; set; }

    public decimal PromedioGeneral { get; set; }

    public int Aprobados { get; set; }

    public int Reprobados { get; set; }
    public decimal MejorPromedio { get; set; }

    public decimal MenorPromedio { get; set; }

    public decimal PorcentajeAprobacion { get; set; }

    public List<Evaluacion> UltimasEvaluaciones { get; set; } = new();

    public List<Alumno> AlumnosReporte { get; set; } = new();

    public void OnGet()
    {
        var excel = new ExcelService();

        TotalAlumnos =
            excel.ObtenerAlumnos().Count;

        var evaluaciones =
            excel.ObtenerTodasLasEvaluaciones();

        TotalEvaluaciones =
            evaluaciones.Count;

  if (evaluaciones.Any())
    {
    PromedioGeneral =
        evaluaciones.Average(
            e => e.Calificacion10);

    Aprobados =
        evaluaciones.Count(
            e => e.Calificacion10 >= 7);

    Reprobados =
        evaluaciones.Count(
            e => e.Calificacion10 < 7);

    MejorPromedio =
        Math.Min(
        evaluaciones.Max(
            e => e.Calificacion10),
            10);

    MenorPromedio =
        evaluaciones.Min(
            e => e.Calificacion10);

    PorcentajeAprobacion =
        (decimal)Aprobados /
        evaluaciones.Count * 100;

     var alumnos =
    excel.ObtenerAlumnos();

    AlumnosReporte =
    alumnos
        .OrderBy(a => a.Matricula)
        .ToList();

    }
    }
}