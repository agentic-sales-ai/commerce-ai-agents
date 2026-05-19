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
                RecordId = 22565426205,
                Name = "Tops"
            },

            new CommerceProduct
            {
                RecordId = 22565426203,
                Name = "Womenswear"
            }
        ];
    }

    public async Task<
        List<CommerceProduct>>
        GetProductsByCategoryAsync(
            long categoryId)
    {
        await Task.Delay(100);

        return
        [
            new CommerceProduct
            {
                RecordId = 1001,
                ItemId = "P1001",
                Name = "Mock Shirt",
                Price = 499,
                Category = "Fashion",
                IsAvailable = true
            },

            new CommerceProduct
            {
                RecordId = 1002,
                ItemId = "P1002",
                Name = "Mock Jeans",
                Price = 899,
                Category = "Fashion",
                IsAvailable = true
            }
        ];
    }
}