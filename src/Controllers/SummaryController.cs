namespace Sa.Payment.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class SummaryController : ControllerBase
{
    private readonly ISummaryRepository _summaryRepository;
    
    public SummaryController(ISummaryRepository summaryRepository)
    {
        _summaryRepository = summaryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<SummaryResponse>> GetSummary()
    {
        SummaryResponse response = await _summaryRepository.GetSummary(User.GetEmail());

        return Ok(response);
    }

}