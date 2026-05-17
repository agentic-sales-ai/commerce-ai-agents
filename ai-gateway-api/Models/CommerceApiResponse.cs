namespace CommerceAIAgents.Models.Commerce;

public class CommerceApiResponse<T>
{
    public List<T> Value { get; set; }
        = new();
}