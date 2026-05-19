using CommerceAIAgents.Models;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace CommerceAIAgents.Services;

public class MockAuthService
    : IAuthService
{
    private readonly AuthSettings
        _settings;

    private string
        _cachedToken = "";

    private DateTimeOffset
        _expiresOn =
            DateTimeOffset.MinValue;

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
            if(!string.IsNullOrEmpty(
                _cachedToken)
               &&
               DateTimeOffset.UtcNow
               < _expiresOn.AddMinutes(-5))
            {
                Console.WriteLine(
                    "Using cached token");

                return _cachedToken;
            }

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
                        $"{_settings.Resource}/.default"
                    })
                    .ExecuteAsync();

            _cachedToken =
                result.AccessToken;

            _expiresOn =
                result.ExpiresOn;

            Console.WriteLine(
                $"Token acquired");

            Console.WriteLine(
                $"Expires: {_expiresOn}");

            return
                _cachedToken;
        }
        catch(Exception ex)
        {
            Console.WriteLine(
                ex.Message);

            return "";
        }
    }
}