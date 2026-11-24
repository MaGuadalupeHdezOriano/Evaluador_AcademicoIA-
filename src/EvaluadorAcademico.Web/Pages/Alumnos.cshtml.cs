using EvaluadorAcademico.Web.Models;
using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluadorAcademico.Web.Pages;

public class AlumnosModel : PageModel
{
    [BindProperty]
    public Alumno Alumno { get; set; } = new();

    public List<Alumno> ListaAlumnos { get; set; } = new();
    
    public string Mensaje { get; set; } = "";

   public void OnGet()
{
    var excel = new ExcelService();

    ListaAlumnos = excel.ObtenerAlumnos();
}

public void OnPost()
{
    var excel = new ExcelService();

    if (excel.ExisteAlumno(Alumno.Matricula))
    {
        Mensaje = "⚠️ La matrícula ya existe.";
        
        ListaAlumnos = excel.ObtenerAlumnos();
        return;
    }

    excel.GuardarAlumno(Alumno);

    Mensaje = "✅ Alumno registrado correctamente.";

    ModelState.Clear();
    
    Alumno = new Alumno();
  
    ListaAlumnos = excel.ObtenerAlumnos();
}
}