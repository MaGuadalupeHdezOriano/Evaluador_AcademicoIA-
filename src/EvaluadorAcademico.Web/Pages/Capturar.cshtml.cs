using EvaluadorAcademico.Web.Models;
using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluadorAcademico.Web.Pages;

public class CapturarModel : PageModel
{
    [BindProperty]
    public Evaluacion Evaluacion { get; set; } = new();

    public Alumno? AlumnoEncontrado { get; set; }

    public decimal Calificacion100 { get; set; }

    public decimal Calificacion10 { get; set; }

    public string Mensaje { get; set; } = "";

    public void OnGet()
    {
    }

    public void OnPost()
    {
        var excel = new ExcelService();

        AlumnoEncontrado =
            excel.BuscarAlumno(Evaluacion.Matricula);

        var parametros =
            excel.ObtenerParametros();

        var calculo = new CalculoService();

        Evaluacion =
            calculo.Calcular(Evaluacion, parametros);

        Calificacion100 =
            Evaluacion.Calificacion100;

        Calificacion10 =
            Evaluacion.Calificacion10;

        if (AlumnoEncontrado != null)
        {
            excel.GuardarEvaluacion(
                Evaluacion,
                AlumnoEncontrado.Nombre);

            Mensaje =
                "✅ Evaluación guardada correctamente.";
        }
    }
}
