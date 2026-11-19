using EvaluadorAcademico.Web.Models;
using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluadorAcademico.Web.Pages;

public class ConsultarModel : PageModel
{
    [BindProperty]
    public string Matricula { get; set; } = string.Empty;

    public Alumno? Alumno { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        var excel = new ExcelService();

        Alumno = excel.BuscarAlumno(Matricula);
    }
}