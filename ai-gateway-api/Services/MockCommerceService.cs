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

        var channels =
            await _retail
                .GetChannelsAsync();

        var channel =
            channels
            .FirstOrDefault(
                x =>
                x.OperatingUnitNumber
                ==
                channelId);

        if(channel == null)
        {
            Console.WriteLine(
                $"Channel not found:{channelId}");

            return new List<ProductRecommendation>();
        }

        Console.WriteLine(
            $"Resolved channel:{channel.Name}");

        Console.WriteLine(
            $"Channel RecordId:{channel.RecordId}");

        var categories =
            await _retail
                .GetCategoriesAsync();

        var matchedCategory =
            categories
            .FirstOrDefault(x =>
                x.Name.Contains(
                    searchText,
                    StringComparison
                    .OrdinalIgnoreCase));

        if(matchedCategory == null)
        {
            Console.WriteLine(
                "No category found");

            return new List<ProductRecommendation>();
        }

        Console.WriteLine(
            $"Matched category:{matchedCategory.Name}");

        var products =
    await _retail
        .GetProductsByCategoryAsync(
            matchedCategory.RecordId,
            channel.RecordId);

        Console.WriteLine(
            $"Products found:{products.Count}");

        return products
            .Select(x =>
                new ProductRecommendation
                {
                    ItemId =
                        x.ItemId,

                    Name =
                        x.Name,

                    Price =
                        x.Price,

                    Category =
                        matchedCategory.Name,

                    ImageUrl =
                        x.PrimaryImageUrl,

                    Rating =
                        x.AverageRating,

                    TotalRatings =
                        x.TotalRatings,

                    Description =
                        x.Description,

                    BasePrice =
                        x.BasePrice,

                    ProductNumber =
                        x.ProductNumber
                })
            .ToList();
    }
}