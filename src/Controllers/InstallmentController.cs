namespace Sa.Payment.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class InstallmentsController : ControllerBase
{
    private readonly IInstallmentsRepository _repository;
    private readonly IMapper _mapper;

    public InstallmentsController(IInstallmentsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost("{id}/installment")]
    public async Task<ActionResult> CreateInstallment([FromBody] CreateInstallmentDto request, [FromRoute] int id)
    {
        Installment installment = _mapper.Map<Installment>(request);

        await _repository.CreateInstallmentForCard(installment, id);

        return NoContent();
    }

    [HttpDelete("{id}/installment")]
    public async Task<ActionResult> DeleteSingleInstallment([FromRoute] int id)
    {
        await _repository.DeleteOccurenceInstallment(id);

        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<ActionResult> DeleteManyInstallments([FromRoute] int id)
    {
        await _repository.DeleteInstallment(id, id);

        return NoContent();
    }

}