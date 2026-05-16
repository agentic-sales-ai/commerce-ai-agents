using CommerceAIAgents.Models;

namespace CommerceAIAgents.Services;

public class OpenAIService : IAIService
{
    public IntentResult ParseIntent(string query)
    {
        return new IntentResult
        {
            Intent = "PendingOpenAI",
            Confidence = 0.99m,
            Category = "AI"
        };
    }
}