using CommerceAIAgents.Models;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace CommerceAIAgents.Services;

public class MockAuthService
    : IAuthService
{
    private readonly AuthSettings
        _settings;

    public MockAuthService(
        IOptions<AuthSettings> options)
    {
        _settings =
            options.Value;
    }

    public async Task<string>
        GetAccessTokenAsync()
    {
        try
        {
            var app =
                ConfidentialClientApplicationBuilder
                .Create(
                    _settings.ClientId)
                .WithClientSecret(
                    _settings.ClientSecret)
                .WithAuthority(
                    $"https://login.microsoftonline.com/{_settings.TenantId}")
                .Build();

            var result =
                await app
                .AcquireTokenForClient(
                    new[]
                    {
                        "https://erp.dynamics.com/.default"
                    })
                .ExecuteAsync();

            Console.WriteLine(
    $"Token acquired for: {result.Account}");

Console.WriteLine(
    $"Expires: {result.ExpiresOn}");

            return
                result.AccessToken;
        }
        catch(Exception ex)
        {
            Console.WriteLine(
                ex.Message);

            return "";
        }
    }
}