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
        IEnumerable<Card> cards = _context.Card.Include(c => c.Months)
                                                    .ThenInclude(m => m.Year)
                                                    .ThenInclude(y => y.Installments)
                                                    .ToList()
                                                    .FindAll(c => c.EmailOwner == email);
            
        return cards;
    }
    
    public async Task<Card> GetCard(int id) 
    {
        Card? card = await _context.Card.Include(c => c.Months)
                                        .ThenInclude(m => m.Year)
                                        .ThenInclude(y => y.Installments)
                                        .FirstOrDefaultAsync(c => c.Id == id);

        if (card == null) throw new NullReferenceException();

        return card;
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
        Card? card = await FetchCardById(id);

        if(card == null) throw new NullReferenceException();
        
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

    private async Task<Card?> FetchCardById(int id) => await _context.Card.Include(c => c.Months).FirstOrDefaultAsync(c => c.Id == id);
}