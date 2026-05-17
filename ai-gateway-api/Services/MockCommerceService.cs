using CommerceAIAgents.Contracts;

namespace CommerceAIAgents.Services;

public class MockCommerceService
    : ICommerceService
{
    private readonly CommerceHttpClient
        _client;

    private readonly IRetailServerClient
        _retail;

    public MockCommerceService(
        CommerceHttpClient client,
        IRetailServerClient retail)
    {
        _client = client;

        _retail = retail;
    }

    public async Task<List<ProductRecommendation>>
        SearchProductsAsync(
            string searchText,
            string channelId)
    {
        await Task.Delay(100);

        var retailProducts =
            await _retail
                .GetCategoriesAsync();

        var filteredProducts =
            retailProducts
            .Where(x =>
                x.Name.Contains(
                    searchText,
                    StringComparison
                        .OrdinalIgnoreCase))
            .ToList();

        Console.WriteLine(
            $"Matched items: {filteredProducts.Count}");

        var mappedProducts =
            filteredProducts
            .Select(x =>
                new ProductRecommendation
                {
                    ItemId =
                        x.RecordId
                        .ToString(),

                    Name =
                        x.Name,

                    Price = 0,

                    Category =
                        "Commerce"
                })
            .ToList();

        return mappedProducts;
    }
}