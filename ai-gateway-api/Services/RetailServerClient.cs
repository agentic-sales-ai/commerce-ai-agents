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

    private readonly IAuthService
    _auth;

    public RetailServerClient(
        CommerceHttpClient httpClient,
        IOptions<CommerceSettings> options,
        IAuthService auth)
    {
        _httpClient = httpClient;

        _settings = options.Value;

        _auth = auth;
    }

    public async Task<
    List<CommerceProduct>>
    SearchProductsAsync(
        string searchText,
        string channelId)
{
    try
    {
        var token =
    await _auth
        .GetAccessTokenAsync();

var response =
    await _httpClient
        .GetAsync(
    "Categories?$top=20&api-version=7.3",
    token);

Console.WriteLine(
    response);

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