using EvaluadorAcademico.Web.Models;
using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluadorAcademico.Web.Pages;

public class ParametrosModel : PageModel
{
    [BindProperty]
    public ParametrosEvaluacion Parametros { get; set; } = new();

    public string Mensaje { get; set; } = "";

    public void OnGet()
    {
        var excel = new ExcelService();

        Parametros = excel.ObtenerParametros();
    }

   public void OnPost()
    {
    var excel = new ExcelService();

    var total =
        Parametros.PorcentajeAsistencia +
        Parametros.PorcentajeActividades +
        Parametros.PorcentajePracticas +
        Parametros.PorcentajeExamen;

    if (total != 100)
    {
        Mensaje =
            "⚠️ La suma de los porcentajes debe ser exactamente 100%.";
        return;
    }

    if (Parametros.PorcentajeAsistencia < 0 ||
        Parametros.PorcentajeAsistencia > 100 ||
        Parametros.PorcentajeActividades < 0 ||
        Parametros.PorcentajeActividades > 100 ||
        Parametros.PorcentajePracticas < 0 ||
        Parametros.PorcentajePracticas > 100 ||
        Parametros.PorcentajeExamen < 0 ||
        Parametros.PorcentajeExamen > 100)
    {
        Mensaje =
            "⚠️ Cada porcentaje debe estar entre 0 y 100.";
        return;
    }

    excel.GuardarParametros(Parametros);

    Mensaje =
        "✅ Parámetros actualizados correctamente.";

    Parametros =
        excel.ObtenerParametros();
    }
 }