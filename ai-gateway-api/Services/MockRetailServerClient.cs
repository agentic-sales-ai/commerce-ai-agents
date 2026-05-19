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
                RecordId=22565426205,
                Name="Tops"
            }
        ];
    }

    public async Task<
        List<CommerceProduct>>
        GetProductsByCategoryAsync(
            long categoryId,
            long channelRecordId)
    {
        await Task.Delay(100);

        Console.WriteLine(
            $"Mock channel:{channelRecordId}");

        return
        [
            new CommerceProduct
            {
                RecordId=1001,
                ItemId="81121",
                Name="Trim Fit Shirt",
                Price=53.99m
            }
        ];
    }

    public async Task<
        List<CommerceChannel>>
        GetChannelsAsync()
    {
        await Task.Delay(100);

        return
        [
            new CommerceChannel
            {
                Name="Houston",
                OperatingUnitNumber="052",
                RecordId=5637144592,
                InventoryLocationId="HOUSTON"
            }
        ];
    }
}