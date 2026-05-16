using CommerceAIAgents.Models;

namespace CommerceAIAgents.Services;

public class MockAIService : IAIService
{
    public IntentResult ParseIntent(
        string query)
    {
        return new IntentResult
        {
            Intent="FoodRecommendation",

            Budget=1500,

            PartySize=4,

            Category="Restaurant",

            Sentiment="Positive",

            Confidence=0.94m,

            Keywords=
            [
                "family",
                "dinner"
            ]
        };
    }
}