namespace CommerceAIAgents.Models;

public class IntentResult
{
    public string Intent { get; set; } = "";

    public decimal? Budget { get; set; }

    public int? PartySize { get; set; }

    public List<string> Keywords { get; set; }
        = new();

    public string Category { get; set; } = "";

    public string Sentiment { get; set; } = "";

    public decimal Confidence { get; set; }
}