using System.Net.Http.Headers;
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
        GetAsync(
            string relativeUrl,
            string token)
    {
        _httpClient.DefaultRequestHeaders.Clear();

        _httpClient
            .DefaultRequestHeaders
            .Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);

        var url =
            $"{_settings.BaseUrl}/{relativeUrl}";

        Console.WriteLine(
            $"GET {url}");

        try
        {
            var response =
                await _httpClient
                    .GetAsync(url);

            var content =
    await response
        .Content
        .ReadAsStringAsync();

Console.WriteLine(
    $"Status:{response.StatusCode}");

Console.WriteLine(
    content);

return content;
        }
        catch(Exception ex)
        {
            return
                $"ERROR:{ex.Message}";
        }
    }
}