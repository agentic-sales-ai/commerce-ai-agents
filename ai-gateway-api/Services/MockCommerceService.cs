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
                .SearchProductsAsync(
                    searchText,
                    channelId);

        var mappedProducts =
            retailProducts
            .Select(x =>
                new ProductRecommendation
                {
                    ItemId = x.ItemId,
                    Name = x.Name,
                    Price = x.Price,
                    Category = x.Category
                })
            .ToList();

        return mappedProducts;
    }
}