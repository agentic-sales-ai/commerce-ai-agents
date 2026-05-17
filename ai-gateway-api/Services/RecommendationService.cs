using CommerceAIAgents.Contracts;

namespace CommerceAIAgents.Services;

public class RecommendationService
{
    private readonly IAIService _ai;

    private readonly CatalogService
        _catalog;

    public RecommendationService(
        IAIService ai,
        CatalogService catalog)
    {
        _ai = ai;

        _catalog = catalog;
    }

    public AssistantResponse
        GetRecommendations(
            AssistantRequest request)
    {
        var intent =
            _ai.ParseIntent(
                request.Query);

        var products =
            _catalog
.GetRecommendations(
    intent.Keywords
        .FirstOrDefault()
        ?? intent.Intent,
    intent.Budget,
    request.ChannelId);

        var message =
            products.Any()
            ? "Recommendation generated"
            : "No matching meal found within budget";

        return new AssistantResponse
        {
            Intent = intent,

            Message = message,

            Products = products
        };
    }
}