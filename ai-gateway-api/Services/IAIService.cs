using CommerceAIAgents.Models;

namespace CommerceAIAgents.Services;

public interface IAIService
{
    IntentResult ParseIntent(
        string query);
}