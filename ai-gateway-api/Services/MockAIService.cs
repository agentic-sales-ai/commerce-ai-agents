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

            Keywords=
            [
                "family",
                "dinner"
            ]
        };
    }
}