namespace CommerceAIAgents.Services;

public class MockAuthService
    : IAuthService
{
    public async Task<string>
        GetAccessTokenAsync()
    {
        await Task.Delay(50);

        return
            "mock-commerce-token";
    }
}