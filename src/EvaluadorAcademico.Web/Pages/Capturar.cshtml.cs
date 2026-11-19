using EvaluadorAcademico.Web.Models;
using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluadorAcademico.Web.Pages;

public class CapturarModel : PageModel
{
    [BindProperty]
    public Evaluacion Evaluacion { get; set; } = new();

    public decimal Calificacion100 { get; set; }

    public decimal Calificacion10 { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
{
    var parametros = new ParametrosEvaluacion
    {
        AsistenciaMaxima = 24,
        ActividadesMaximas = 1000,
        PracticasMaximas = 10,
        ExamenMaximo = 125,

        PorcentajeAsistencia = 10,
        PorcentajeActividades = 25,
        PorcentajePracticas = 25,
        PorcentajeExamen = 40
    };

    var calculo = new CalculoService();

    Evaluacion = calculo.Calcular(Evaluacion, parametros);

    Calificacion100 = Evaluacion.Calificacion100;

    Calificacion10 = Evaluacion.Calificacion10;

    var excel = new ExcelService();

    var alumno = excel.BuscarAlumno(Evaluacion.Matricula);

    if (alumno != null)
    {
        excel.GuardarEvaluacion(
            Evaluacion,
            alumno.Nombre);
    }
}
}