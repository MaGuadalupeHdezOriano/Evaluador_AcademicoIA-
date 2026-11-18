using EvaluadorAcademico.Web.Models;
using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluadorAcademico.Web.Pages;

public class AlumnosModel : PageModel
{
    [BindProperty]
    public Alumno Alumno { get; set; } = new();

    public List<Alumno> ListaAlumnos =>
        AlumnoService.Alumnos;

    public void OnGet()
    {
    }

    public void OnPost()
    {
        AlumnoService.Alumnos.Add(new Alumno
        {
            Matricula = Alumno.Matricula,
            Nombre = Alumno.Nombre,
            Grupo = Alumno.Grupo,
            Asignatura = Alumno.Asignatura,
            Estatus = "Activo"
        });
    }
}