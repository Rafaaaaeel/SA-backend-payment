namespace Sa.Payment.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class InstallmentsController : ControllerBase
{
    private readonly IInstallmentsRepository _repository;
    
    public InstallmentsController(IInstallmentsRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("{id}")]
    public async Task<ActionResult> CreateInstallment([FromBody] InstallmentRequest request, [FromRoute] int id)
    {
        await _repository.CreateInstallmentForCard(request, id);

        return NoContent();
    }

}