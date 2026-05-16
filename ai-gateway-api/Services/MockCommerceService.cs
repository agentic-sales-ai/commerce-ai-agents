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

        var endpoint =
    await _client
        .HealthCheckAsync();

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

Console.WriteLine(
    endpoint);

        if(channelId=="101")
{
    return mappedProducts;
}

        if(channelId=="999")
        {
            return new List<ProductRecommendation>
            {
                new ProductRecommendation
                {
                    ItemId="MC2001",
                    Name="Premium Veg Platter",
                    Price=549,
                    Category="Meal"
                },

                new ProductRecommendation
                {
                    ItemId="MC2002",
                    Name="Mango Smoothie",
                    Price=99,
                    Category="Drink"
                }
            };
        }

        return new List<ProductRecommendation>();
    }
}