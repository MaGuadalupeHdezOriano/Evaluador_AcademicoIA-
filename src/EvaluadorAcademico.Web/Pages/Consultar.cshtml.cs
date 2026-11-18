using EvaluadorAcademico.Web.Models;
using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluadorAcademico.Web.Pages;

public class ConsultarModel : PageModel
{
    public List<Alumno> Alumnos { get; set; } = new();

    public void OnGet()
    {
        var excel = new ExcelService();

        Alumnos = excel.ObtenerAlumnos();
    }
}
