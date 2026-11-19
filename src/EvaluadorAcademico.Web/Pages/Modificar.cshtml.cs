using EvaluadorAcademico.Web.Models;
using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluadorAcademico.Web.Pages;

public class ModificarModel : PageModel
{
    [BindProperty]
    public string Matricula { get; set; } = "";

    [BindProperty]
    public Evaluacion Evaluacion { get; set; } = new();

    public void OnGet()
    {
    }

    public void OnPostBuscar()
    {
        var excel = new ExcelService();

        var evaluacion =
            excel.ObtenerEvaluacion(Matricula);

        if (evaluacion != null)
        {
            Evaluacion = evaluacion;
        }
    }

    public void OnPostGuardar()
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

        Evaluacion =
            calculo.Calcular(Evaluacion, parametros);

        var excel = new ExcelService();

        excel.ActualizarEvaluacion(Evaluacion);
    }
}