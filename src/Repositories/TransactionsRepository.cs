namespace Sa.Payment.Api.Repositories;

public class TransactionsRepository : ITransactionsRepository
{
    private readonly IMapper _mapper;
    private readonly ICardRepository _cardRepository;

    public TransactionsRepository(IMapper mapper, ICardRepository cardRepository)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
    }

    public async Task<TransactionsResponse> GetExpiringTransactionsFromCard(int cardId) 
    {
        CardResponse card = await _cardRepository.GetCard(cardId);
        
        IEnumerable<InstallmentResponse> installments = InstallmentHelper.GetInstallmentsFromTheCurrentMonthInCard(card);

        TransactionsResponse response = new() { Expiring = [] };

        foreach(var installment in installments)
        {
            if (installment.Quantity == 1) continue;

            response.Expiring.Add(new Transaction() 
            {
                Name = installment.Name,
                LeftQuantity = installment.Quantity - installment.CurrentParcel,
                Description = TransactionHelper.FormatDescription(installment)
            });
        }

        return response;
    }

    public async Task<IEnumerable<InstallmentResponse>> GetLastTransactionsFromCard(int cardId)
    {
        CardResponse card = await _cardRepository.GetCard(cardId);

        DateTime today = DateTime.Today;
        DayOfWeek currentDayOfWeek = today.DayOfWeek;
        int daysToSubtract = (int)currentDayOfWeek - 1;
        DateTime startOfWeek = today.AddDays(-daysToSubtract);
        DateTime endOfWeek = startOfWeek.AddDays(7);
        
        IEnumerable<InstallmentResponse> installments = InstallmentHelper
            .GetInstallmentsFromTheCurrentMonthInCard(card)
            .Where(i => i.CreatedDate >= startOfWeek && i.CreatedDate < endOfWeek);

        ICollection<InstallmentResponse> response = [];
        
        int length = installments.ToList().Count > 5 ? 4 : installments.ToList().Count;

        if (length == 0) return []; 

        for (int index = 0; index <= length; index++)
        {   
            response.Add(installments.ToList()[index]);
        }

        return response;
    }

}