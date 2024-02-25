namespace Sa.Payment.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class TransactionController : ControllerBase
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly ICardRepository _cardRepository;
    
    public TransactionController(ITransactionsRepository transactionsRepository, ICardRepository cardRepository)
    {
        _transactionsRepository = transactionsRepository;
        _cardRepository = cardRepository;
    }

    [HttpGet("{id}/expiring/transactions")]
    public async Task<ActionResult<TransactionsResponse>> GetExpiringTransactions([FromRoute] int id)
    {
        TransactionsResponse response = await _transactionsRepository.GetExpiringTransactionsFromCard(id);

        return Ok(response);
    }

    [HttpGet("/{id}/last/installments")]
    public async Task<ActionResult<IEnumerable<InstallmentResponse>>> GetLastTransactions([FromRoute] int id)
    {
        IEnumerable<InstallmentResponse> installments = await _transactionsRepository.GetLastTransactionsFromCard(id);

        return Ok(installments);
    }

}