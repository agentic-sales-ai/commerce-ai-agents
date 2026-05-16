using CommerceAIAgents.Models;

namespace CommerceAIAgents.Contracts;

public class AssistantResponse
{
    public IntentResult Intent { get; set; }
        = new();

    public string Message { get; set; } = "";

    public List<ProductRecommendation> Products
        { get; set; }
            = new();
}