using CommerceAIAgents.Models;
using Microsoft.Extensions.Options;

namespace CommerceAIAgents.Services;

public class CommerceHttpClient
{
    private readonly CommerceSettings
        _settings;

    private readonly HttpClient
        _httpClient;

    public CommerceHttpClient(
        HttpClient httpClient,
        IOptions<CommerceSettings> options)
    {
        _httpClient = httpClient;

        _settings = options.Value;
    }

    public async Task<string>
        HealthCheckAsync()
    {
        await Task.Delay(50);

        return
            $"Commerce endpoint: {_settings.BaseUrl}";
    }
}