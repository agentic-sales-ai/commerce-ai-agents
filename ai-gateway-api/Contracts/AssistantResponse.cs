namespace CommerceAIAgents.Contracts;

public class AssistantResponse
{
    public string Message { get; set; } = "";

    public List<ProductRecommendation> Products { get; set; }
        = new();
}