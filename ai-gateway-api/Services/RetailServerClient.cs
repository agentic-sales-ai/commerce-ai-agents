using CommerceAIAgents.Models;
using CommerceAIAgents.Models.Commerce;
using Microsoft.Extensions.Options;

namespace CommerceAIAgents.Services;

public class RetailServerClient
    : IRetailServerClient
{
    private readonly CommerceHttpClient
        _httpClient;

    private readonly CommerceSettings
        _settings;

    public RetailServerClient(
        CommerceHttpClient httpClient,
        IOptions<CommerceSettings> options)
    {
        _httpClient = httpClient;

        _settings = options.Value;
    }

    public async Task<
    List<CommerceProduct>>
    SearchProductsAsync(
        string searchText,
        string channelId)
{
    try
    {
        var endpoint =
            $"{_settings.BaseUrl}" +
            "/Commerce";

        Console.WriteLine(
            $"Retail endpoint: {endpoint}");

        await Task.Delay(100);

        return new List<CommerceProduct>();
    }
    catch(Exception ex)
    {
        Console.WriteLine(
            ex.Message);

        return new List<CommerceProduct>();
    }
}
}