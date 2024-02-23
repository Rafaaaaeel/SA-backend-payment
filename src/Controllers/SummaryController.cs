namespace Sa.Payment.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class SummaryController : ControllerBase
{
    private readonly ITransactionsRepository _repository;
    
    public SummaryController(ITransactionsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TransactionsResponse>> GetLastTransactions([FromRoute] int id)
    {
        TransactionsResponse response = await _repository.GetLastTransactionsFromCard(id);

        return Ok(response);
    }

}