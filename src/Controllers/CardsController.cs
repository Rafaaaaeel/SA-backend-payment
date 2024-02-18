namespace Sa.Payment.Controllers;

[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ApiController]
[Authorize]
public class CardsController : ControllerBase 
{
    private readonly ICardRepository _repository;

    public CardsController(ICardRepository repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    /// It'll get all user cards
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Card>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Card>> GetAllCards()
    {
        string email = User.GetEmail();

        IEnumerable<Card> cards = _repository.GetAllCards(email);

        return Ok(cards);
    }

    /// <summary>
    /// It'll gets only a card
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/card")]
    [ProducesResponseType(typeof(Card), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CardResponse>> GetCard(int id)
    {
        CardResponse card  = await _repository.GetCard(id);

        return Ok(card);
    }
    
    /// <summary>
    /// Creates 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateCard([FromBody] CardRequest request)
    {   
        await _repository.CreateCard(request);

        return NoContent();
    }

    /// <summary>
    /// Delete an existed user card.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}/card")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCard([FromRoute] int id)
    {
        await _repository.DeleteCard(id);

        return NoContent(); 
    }

    /// <summary>
    /// Update user card details.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}/card")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateCard([FromBody] CardRequest request)
    {
        await _repository.UpdateCard(request);

        return NoContent();
    }

    /// <summary>
    /// It deletes all list of Months inside the Card object, 
    /// by doing ths we reset all installmnets
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}/installments")]
    public async Task<ActionResult> DeleteInstallmentsFromCardId([FromRoute] int id)
    {
        await _repository.DeleteAllInstallmentsFromCard(id);

        return NoContent();
    }

}
