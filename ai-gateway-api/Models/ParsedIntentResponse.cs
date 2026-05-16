namespace CommerceAIAgents.Models;

public class ParsedIntentResponse
{
    public string Intent { get; set; } = "";

    public decimal Budget { get; set; }

    public int PartySize { get; set; }

    public List<string> Keywords { get; set; }
        = new();
}