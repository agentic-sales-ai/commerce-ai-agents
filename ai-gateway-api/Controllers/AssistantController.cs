using CommerceAIAgents.Contracts;
using CommerceAIAgents.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommerceAIAgents.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssistantController : ControllerBase
{
    private readonly RecommendationService _service;

    public AssistantController(
        RecommendationService service)
    {
        _service = service;
    }

    [HttpPost("recommend")]
    public ActionResult<AssistantResponse> Recommend(
        AssistantRequest request)
    {
        return Ok(
            _service.GetRecommendations(request)
        );
    }
}