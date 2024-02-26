using Microsoft.IdentityModel.Tokens;

namespace Sa.Payment.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class TransactionController : ControllerBase
{
    private readonly ITransactionsRepository _transactionsRepository;
    
    public TransactionController(ITransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }

    [HttpGet("{id}/expiring/transactions")]
    public async Task<ActionResult<TransactionsResponse>> GetExpiringTransactions([FromRoute] int id)
    {
        TransactionsResponse response = await _transactionsRepository.GetExpiringTransactionsFromCard(id);

        if (response.Expiring.IsNullOrEmpty()) NoContent();

        return Ok(response);
    }

    [HttpGet("{id}/last/installments")]
    public async Task<ActionResult<TransactionsResponse>> GetLastTransactions([FromRoute] int id)
    {
        TransactionsResponse response = await _transactionsRepository.GetLastTransactionsFromCard(id);
        
        if (response.LastTransaction.IsNullOrEmpty()) NoContent();

        return Ok(response);
    }

}