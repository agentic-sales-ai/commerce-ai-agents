namespace CommerceAIAgents.Services;

public interface IAuthService
{
    Task<string>
        GetAccessTokenAsync();
}