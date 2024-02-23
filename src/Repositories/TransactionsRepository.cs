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

    public async Task<TransactionsResponse> GetLastTransactionsFromCard(int cardId) 
    {
        CardResponse card = await _cardRepository.GetCard(cardId);
        
        YearResponse year = card
            .Months.First(m => m.Name == DateTime.UtcNow.GetMonthAbbreviatedName())
            .Years.First(y => y.Name == DateTime.UtcNow.Year.ToString());

        IEnumerable<InstallmentResponse> installments = year.Installments.Where(installment => TransactionHelper.IsAlmostFinish(installment));

        TransactionsResponse response = new() { LastTransactions = [] };

        foreach(var installment in installments)
        {
            response.LastTransactions.Add(new Transaction() 
            {
                Name = installment.Name,
                LeftQuantity = installment.Quantity - installment.CurrentParcel,
                Description = TransactionHelper.FormatDescription(installment)
            });
        }

        return response;
    }

}