namespace CommerceAIAgents.Models.Commerce;

public class CommerceProduct
{
    public long RecordId { get; set; }

    public string ItemId { get; set; }
        = "";

    public string Name { get; set; }
        = "";

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public string Category { get; set; }
        = "";
}