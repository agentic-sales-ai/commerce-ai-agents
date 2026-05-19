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
        _cachedCategories =
            new();

    private DateTimeOffset
        _categoryCacheTime =
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
        Console.WriteLine(
            $"Product search requested: {searchText}");

        return new List<CommerceProduct>();
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
               < _categoryCacheTime
                    .AddMinutes(30))
            {
                Console.WriteLine(
                    "Using cached categories");

                return _cachedCategories;
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

            var categories =
                DeserializeProducts(
                    response);

            _cachedCategories =
                categories;

            _categoryCacheTime =
                DateTimeOffset.UtcNow;

            return categories;
        }
        catch(Exception ex)
        {
            Console.WriteLine(
                ex.Message);

            return new List<CommerceProduct>();
        }
    }

    public async Task<
        List<CommerceProduct>>
        GetProductsByCategoryAsync(
            long categoryId)
    {
        try
        {
            var token =
                await _auth
                    .GetAccessTokenAsync();

            Console.WriteLine(
$"Loading products for category {categoryId}");

            var response =
                await _httpClient
                    .GetAsync(
$"Products/SearchByCategory(channelId=5637144592,catalogId=0,categoryId={categoryId})?$top=20&api-version=7.3",
                    token);

            return DeserializeProducts(
                response);
        }
        catch(Exception ex)
        {
            Console.WriteLine(
                ex.Message);

            return new List<CommerceProduct>();
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
                CommerceApiResponse<CommerceProduct>>
                (
                    response,
                    options
                );

        var products =
            result?.Value
            ??
            new List<CommerceProduct>();

        Console.WriteLine(
            $"Items returned: {products.Count}");

        if(products.Any())
        {
            Console.WriteLine(
                $"First item: {products[0].Name}");
        }

        return products;
    }
}