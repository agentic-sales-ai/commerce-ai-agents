using CommerceAIAgents.Models.Commerce;

namespace CommerceAIAgents.Services;

public class MockRetailServerClient
    : IRetailServerClient
{
    public async Task<
        List<CommerceProduct>>
        SearchProductsAsync(
            string searchText,
            string channelId)
    {
        await Task.Delay(100);

        return
        [
            new CommerceProduct
            {
                RecordId = 1,
                ItemId = "RS1001",
                Name = "Retail Veg Combo",
                Price = 399,
                Category = "Meal",
                IsAvailable = true
            },

            new CommerceProduct
            {
                RecordId = 2,
                ItemId = "RS1002",
                Name = "Retail Orange Juice",
                Price = 89,
                Category = "Drink",
                IsAvailable = true
            }
        ];
    }

    public async Task<
        List<CommerceProduct>>
        GetCategoriesAsync()
    {
        await Task.Delay(100);

        return
        [
            new CommerceProduct
            {
                RecordId = 22565426194,
                Name = "Fashion"
            },

            new CommerceProduct
            {
                RecordId = 22565426195,
                Name = "Menswear"
            },

            new CommerceProduct
            {
                RecordId = 22565426203,
                Name = "Womenswear"
            }
        ];
    }
}