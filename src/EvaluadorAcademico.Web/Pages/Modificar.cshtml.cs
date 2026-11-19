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
}