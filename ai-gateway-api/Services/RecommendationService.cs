using CommerceAIAgents.Contracts;

namespace CommerceAIAgents.Services;

public class RecommendationService
{
    private readonly IAIService _ai;

    public RecommendationService(
        IAIService ai)
    {
        _ai = ai;
    }

    public AssistantResponse GetRecommendations(
        AssistantRequest request)
    {
        var intent =
            _ai.ParseIntent(request.Query);

        return new AssistantResponse
        {
            Message =
                $"Intent:{intent.Intent}\n" +
                $"Budget:{intent.Budget}\n" +
                $"Confidence:{intent.Confidence}\n" +
                $"Category:{intent.Category}",

            Products = new List<ProductRecommendation>
            {
                new ProductRecommendation
                {
                    ItemId = "P1001",
                    Name = "Family Combo Meal",
                    Price = 1299
                }
            }
        };
    }
}