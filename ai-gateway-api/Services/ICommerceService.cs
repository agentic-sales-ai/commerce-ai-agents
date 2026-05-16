using CommerceAIAgents.Contracts;

namespace CommerceAIAgents.Services;

public interface ICommerceService
{
    Task<List<ProductRecommendation>>
        SearchProductsAsync(
            string searchText,
            string channelId);
}