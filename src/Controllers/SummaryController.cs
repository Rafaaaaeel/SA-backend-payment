namespace Sa.Payment.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class SummaryController : ControllerBase
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly ICardRepository _cardRepository;
    
    public SummaryController(ITransactionsRepository transactionsRepository, ICardRepository cardRepository)
    {
        _transactionsRepository = transactionsRepository;
        _cardRepository = cardRepository;
    }

    [HttpGet("{id}/transactions")]
    public async Task<ActionResult<TransactionsResponse>> GetExpiringTransactions([FromRoute] int id)
    {
        TransactionsResponse response = await _transactionsRepository.GetExpiringTransactionsFromCard(id);

        return Ok(response);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Card>> GetUserCards()
    {
        IEnumerable<Card> cards = _cardRepository.GetAllCards(User.GetEmail());

        return Ok(cards);
    }

    [HttpGet("{id}/installments")]
    public async Task<ActionResult<IEnumerable<InstallmentResponse>>> GetLastTransactions([FromRoute] int id)
    {
        IEnumerable<InstallmentResponse> installments = await _transactionsRepository.GetLastTransactionsFromCard(id);

        return Ok(installments);
    }

}