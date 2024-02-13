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
        Card? card = await _context.QueryCardById(id);

        if (card == null) throw new NotFoundException();
        
        CardResponse response = _mapper.Map<CardResponse>(card);

        return response;
    } 

    public async Task CreateCard(CardRequest request)
    {   
        Card card = _mapper.Map<Card>(request);

        await _context.Card.AddAsync(card);

        await Save();
    }

    public async Task DeleteCard(Card card)
    {
        _context.Remove(card);

        await Save();
    }

    public async Task DeleteAllInstallmentsFromCard(int id)
    {
        Card? card = await _context.QueryCardById(id);

        if(card == null) throw new NotFoundException();
        
        card.Months.ToList().ForEach(m => _context.Month.Remove(m));

        await Save();
    }

    public async Task UpdateCard(CardRequest request)
    {
        Card card = _mapper.Map<Card>(request);

        _context.Update(card);

        await Save();
    }

    private async Task<bool> Save()
    {
        int state = await _context.SaveChangesAsync();
        
        return state >= 0;
    }
    
}