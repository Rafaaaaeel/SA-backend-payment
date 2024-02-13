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
        string email = GetUserEmail();

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
    public async Task<ActionResult> CreateCard([FromBody] CardRequest request)
    {   
        await _repository.CreateCard(request);

        return NoContent();
    }

    [HttpDelete("{id}/card")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCard([FromRoute] int id)
    {
        // await _repository.DeleteCard(card);

        return NoContent(); 
    }

    [HttpPut("{id}/card")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateCard([FromBody] CardRequest request)
    {
        await _repository.UpdateCard(request);

        return NoContent();
    }

    private string GetUserEmail() => HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
}
