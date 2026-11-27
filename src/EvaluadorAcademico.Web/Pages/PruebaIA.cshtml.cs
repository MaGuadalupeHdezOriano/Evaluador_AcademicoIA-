using EvaluadorAcademico.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluadorAcademico.Web.Pages;

public class PruebaIAModel : PageModel
{
    private readonly FoundryService _foundry;

    public PruebaIAModel(
        FoundryService foundry)
    {
        _foundry = foundry;
    }

    [BindProperty]
    public string Texto { get; set; } = "";

    public string Respuesta { get; set; } = "";

    public async Task OnPost()
    {
        Respuesta =
            await _foundry
                .InterpretarEvaluacionAsync(
                    Texto);
    }
}