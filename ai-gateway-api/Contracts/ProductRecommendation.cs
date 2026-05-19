namespace CommerceAIAgents.Contracts;

public class ProductRecommendation
{
    public string ItemId { get; set; } = "";

    public string Name { get; set; } = "";

    public decimal Price { get; set; }

    public string Category { get; set; } = "";

    public string ImageUrl { get; set; } = "";

    public double Rating { get; set; }

    public int TotalRatings { get; set; }

    public string Description { get; set; } = "";

    public decimal BasePrice { get; set; }

    public string ProductNumber { get; set; } = "";
}