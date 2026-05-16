using CommerceAIAgents.Contracts;

namespace CommerceAIAgents.Services;

public class MockCommerceService
    : ICommerceService
{
    public async Task<List<ProductRecommendation>>
        SearchProductsAsync(
            string searchText,
            string channelId)
    {
        await Task.Delay(100);

        if(channelId=="101")
        {
            return new List<ProductRecommendation>
            {
                new ProductRecommendation
                {
                    ItemId="MC1001",
                    Name="Vegetarian Rice Bowl",
                    Price=399,
                    Category="Meal"
                },

                new ProductRecommendation
                {
                    ItemId="MC1003",
                    Name="Fresh Orange Juice",
                    Price=89,
                    Category="Drink"
                }
            };
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