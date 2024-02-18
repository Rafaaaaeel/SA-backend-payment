namespace Sa.Payment.Api.Repositories;

public class CardRepository : ICardRepository
{
    private readonly CardContext _context;
    private readonly IMapper _mapper;

    public CardRepository(CardContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Card> GetAllCards(string email)
    {
        IEnumerable<Card> cards = _context.QueryAllCardsForUser(email);
            
        return cards;
    }
    
    public async Task<CardResponse> GetCard(int id) 
    {
        Card card = await GetCardById(id);
        
        CardResponse response = _mapper.Map<CardResponse>(card);

        return response;
    } 

    public async Task CreateCard(CardRequest request)
    {   
        Card card = _mapper.Map<Card>(request);

        await _context.Card.AddAsync(card);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCard(int id)
    {
        Card card = await GetCardById(id);
        
        _context.Remove(card);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAllInstallmentsFromCard(int id)
    {
        Card card = await GetCardById(id);
        
        card.Months.ToList().ForEach(m => _context.Month.Remove(m));

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCard(CardRequest request)
    {
        Card card = _mapper.Map<Card>(request);

        _context.Update(card);

        await _context.SaveChangesAsync();
    }
    
    private async Task<Card> GetCardById(int id)
    {
        Card? card = await _context.QueryCardById(id);

        if(card is null) throw new NotFoundException();

        return card;
    }
}