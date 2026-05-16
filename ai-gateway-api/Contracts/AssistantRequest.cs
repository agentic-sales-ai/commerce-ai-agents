namespace CommerceAIAgents.Contracts;

public class AssistantRequest
{
    public string Query { get; set; } = "";
    public string StoreId { get; set; } = "";
    public string ChannelId { get; set; } = "";
}