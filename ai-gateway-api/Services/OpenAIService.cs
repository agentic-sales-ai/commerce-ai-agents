using CommerceAIAgents.Models;
using Microsoft.Extensions.Options;
using OpenAI.Chat;
using System.Text.Json;

namespace CommerceAIAgents.Services;

public class OpenAIService : IAIService
{
    private readonly OpenAISettings _settings;

    public OpenAIService(
        IOptions<OpenAISettings> options)
    {
        _settings = options.Value;
    }

    public IntentResult ParseIntent(
        string query)
    {
        try
        {
            var client =
                new ChatClient(
                    model:_settings.Model,
                    apiKey:_settings.ApiKey);

            var prompt =
    "Extract fields and return VALID JSON ONLY.\n" +
    "Schema:\n" +
    "{\n" +
    "\"Intent\":\"\",\n" +
    "\"Budget\":0,\n" +
    "\"PartySize\":0,\n" +
    "\"Keywords\":[]\n" +
    "}\n\n" +
    $"Query:\n{query}\n\n" +
    "No markdown.\n" +
    "No explanation.\n" +
    "JSON only.";

var completion =
    client.CompleteChat(prompt);

            var result =
                completion.Value;

            var text =
                result.Content[0].Text;

            var parsed =
                JsonSerializer.Deserialize
                <ParsedIntentResponse>(text);

            return new IntentResult
{
    Intent =
        parsed?.Intent ?? "",

    Budget =
        parsed?.Budget > 0
            ? parsed.Budget
            : null,

    PartySize =
        parsed?.PartySize > 0
            ? parsed.PartySize.Value
            : 1,

    Keywords =
        parsed?.Keywords
            ?? new List<string>(),

    Confidence =
        !string.IsNullOrWhiteSpace(
            parsed?.Intent)
                ? .95m
                : .30m,

    Category = "OpenAI"
};
        }
        catch(Exception ex)
        {
            return new IntentResult
            {
                Intent=
                    $"ERROR:{ex.Message}"
            };
        }
    }
}