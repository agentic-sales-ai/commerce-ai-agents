using CommerceAIAgents.Models.Commerce;

namespace CommerceAIAgents.Services;

public interface IRetailServerClient
{
    Task<List<CommerceProduct>>
        SearchProductsAsync(
            string searchText,
            string channelId);

    Task<List<CommerceProduct>>
        GetCategoriesAsync();

    Task<List<CommerceProduct>>
        GetProductsByCategoryAsync(
            long categoryId,
            long channelRecordId);

    Task<List<CommerceChannel>>
        GetChannelsAsync();
}