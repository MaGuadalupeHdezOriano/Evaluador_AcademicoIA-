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
        var excel = new ExcelService();

        var parametros =
            excel.ObtenerParametros();

        var calculo = new CalculoService();

        Evaluacion =
            calculo.Calcular(Evaluacion, parametros);

        excel.ActualizarEvaluacion(Evaluacion);

        ModelState.Clear();

        Matricula = "";

        Evaluacion = new Evaluacion();
    }
}