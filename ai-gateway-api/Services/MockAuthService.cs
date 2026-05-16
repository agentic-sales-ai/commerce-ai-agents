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
   "https://commerce.dynamics.com/.default"
})
                .ExecuteAsync();

            Console.WriteLine(
    $"Token acquired for: {result.Account}");

Console.WriteLine(
    $"Expires: {result.ExpiresOn}");

            var jwt =
    result.AccessToken
    .Split('.');

if(jwt.Length > 1)
{
    var payload =
        jwt[1];

    payload +=
        new string(
            '=',
            (4 - payload.Length % 4) % 4);

    var json =
        System.Text.Encoding.UTF8
        .GetString(
            Convert.FromBase64String(
                payload
                .Replace('-','+')
                .Replace('_','/')));

    Console.WriteLine(
        $"TOKEN PAYLOAD:\n{json}");
}

return result.AccessToken;

        }
        catch(Exception ex)
        {
            Console.WriteLine(
                ex.Message);

            return "";
        }
    }
}