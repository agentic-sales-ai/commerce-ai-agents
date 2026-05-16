using CommerceAIAgents.Contracts;

namespace CommerceAIAgents.Services;

public class RecommendationService
{
    public AssistantResponse GetRecommendations(
        AssistantRequest request)
    {
        return new AssistantResponse
        {
            Message =
                $"Recommendations for: {request.Query}",

            Products =
            [
                new ProductRecommendation
                {
                    ItemId="P1001",
                    Name="Paneer Tikka Combo",
                    Price=449
                },

                new ProductRecommendation
                {
                    ItemId="P1002",
                    Name="Masala Cola",
                    Price=49
                }
            ]
        };
    }
}