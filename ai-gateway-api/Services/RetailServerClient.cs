using System.Text.Json;
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

    private List<CommerceProduct>
        _cachedCategories = new();

    private DateTimeOffset
        _categoryCacheTime =
            DateTimeOffset.MinValue;

    private List<CommerceChannel>
        _cachedChannels = new();

    private DateTimeOffset
        _channelCacheTime =
            DateTimeOffset.MinValue;

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
        return new List<CommerceProduct>();
    }

    public async Task<
        List<CommerceChannel>>
        GetChannelsAsync()
    {
        try
        {
            if(_cachedChannels.Any()
                &&
               DateTimeOffset.UtcNow
               <
               _channelCacheTime
               .AddMinutes(30))
            {
                Console.WriteLine(
                    "Using cached channels");

                return _cachedChannels;
            }

            var token =
                await _auth
                    .GetAccessTokenAsync();

            Console.WriteLine(
                "Loading channels...");

            var response =
                await _httpClient
                    .GetAsync(
"GetChannels()?$top=20&api-version=7.3",
                    token);

            var options =
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive=true
                };

            var result =
                JsonSerializer.Deserialize<
                    CommerceApiResponse
                    <CommerceChannel>>
                    (
                        response,
                        options
                    );

            _cachedChannels =
                result?.Value
                ??
                new();

            _channelCacheTime =
                DateTimeOffset.UtcNow;

            Console.WriteLine(
$"Channels:{_cachedChannels.Count}");

            return
                _cachedChannels;
        }
        catch(Exception ex)
        {
            Console.WriteLine(
                ex.Message);

            return new();
        }
    }

    public async Task<
        List<CommerceProduct>>
        GetCategoriesAsync()
    {
        try
        {
            if(_cachedCategories.Any()
                &&
               DateTimeOffset.UtcNow
               <
               _categoryCacheTime
               .AddMinutes(30))
            {
                Console.WriteLine(
                    "Using cached categories");

                return
                    _cachedCategories;
            }

            var token =
                await _auth
                    .GetAccessTokenAsync();

            Console.WriteLine(
"Fetching live Commerce categories...");

            var response =
                await _httpClient
                    .GetAsync(
"Categories?$top=20&api-version=7.3",
                    token);

            _cachedCategories =
                DeserializeProducts(
                    response);

            _categoryCacheTime =
                DateTimeOffset.UtcNow;

            return
                _cachedCategories;
        }
        catch(Exception ex)
        {
            Console.WriteLine(
                ex.Message);

            return new();
        }
    }

    public async Task<
        List<CommerceProduct>>
        GetProductsByCategoryAsync(
            long categoryId,
            long channelRecordId)
    {
        try
        {
            var token =
                await _auth
                    .GetAccessTokenAsync();

            Console.WriteLine(
$"Loading products for channel {channelRecordId}");

            var response =
                await _httpClient
                    .GetAsync(
$"Products/SearchByCategory(channelId={channelRecordId},catalogId=0,categoryId={categoryId})?$top=20&api-version=7.3",
                    token);

            return
                DeserializeProducts(
                    response);
        }
        catch(Exception ex)
        {
            Console.WriteLine(
                ex.Message);

            return new();
        }
    }

    private List<CommerceProduct>
        DeserializeProducts(
            string response)
    {
        var options =
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive=true
            };

        var result =
            JsonSerializer.Deserialize<
                CommerceApiResponse
                <CommerceProduct>>
                (
                    response,
                    options
                );

        return
            result?.Value
            ??
            new();
    }
}