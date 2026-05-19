namespace CommerceAIAgents.Models.Commerce;

public class CommerceProduct
{
    public string ItemId { get; set; } = "";

    public string Name { get; set; } = "";

    public decimal Price { get; set; }

    public string Category { get; set; } = "";

    public bool IsAvailable { get; set; }

    public long RecordId { get; set; }

    public string LocalizedDescription
    {
        get;
        set;
    } = "";

    public string PrimaryImageUrl
    {
        get;
        set;
    } = "";

    public string ProductNumber
    {
        get;
        set;
    } = "";

    public double AverageRating
    {
        get;
        set;
    }

    public int TotalRatings
    {
        get;
        set;
    }

    public string Description
    {
        get;
        set;
    } = "";

    public decimal BasePrice
    {
        get;
        set;
    }

    public bool IsMasterProduct
    {
        get;
        set;
    }

    public long MasterProductId
    {
        get;
        set;
    }

    public string DefaultUnitOfMeasure
    {
        get;
        set;
    } = "";
}