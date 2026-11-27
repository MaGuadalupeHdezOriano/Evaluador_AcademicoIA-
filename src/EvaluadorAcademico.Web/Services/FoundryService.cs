using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

namespace EvaluadorAcademico.Web.Services;

public class FoundryService
{
    private readonly IConfiguration _configuration;

    public FoundryService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> InterpretarEvaluacionAsync(
        string texto)
    {
        var endpoint =
            _configuration["AzureOpenAI:Endpoint"];

        var apiKey =
            _configuration["AzureOpenAI:ApiKey"];

        var deploymentName =
            _configuration["AzureOpenAI:DeploymentName"];

        Console.WriteLine("ENDPOINT:");
        Console.WriteLine(endpoint);

        Console.WriteLine("DEPLOYMENT:");
        Console.WriteLine(deploymentName);

        AzureOpenAIClient azureClient =
            new(
                new Uri(endpoint!),
                new AzureKeyCredential(apiKey!)
            );

        ChatClient chatClient =
            azureClient.GetChatClient(
                deploymentName!);

        var mensajes =
            new List<ChatMessage>()
            {
                new SystemChatMessage(
                    """
                    Eres un asistente especializado
                    en evaluación académica.

                    Extrae únicamente:

                    Matrícula
                    Asistencia
                    Actividades
                    Prácticas
                    Examen
                    """
                ),

                new UserChatMessage(texto)
            };

        ChatCompletion resultado =
            await chatClient.CompleteChatAsync(
                mensajes);

        return resultado.Content[0].Text;
    }
}