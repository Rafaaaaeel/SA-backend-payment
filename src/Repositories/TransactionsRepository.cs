namespace Sa.Payment.Api.Repositories;

public class TransactionsRepository : ITransactionsRepository
{
    private readonly CardContext _context;
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;

    public TransactionsRepository(CardContext context, IMapper mapper, ICardRepository cardRepository)
    {
        _context = context;
        _mapper = mapper;
        _cardRepository = cardRepository;
    }

    public async Task<IEnumerable<InstallmentResponse>> GetLastTransactionsFromCard(int cardId) 
    {
        throw new NotImplementedException();
    }
}