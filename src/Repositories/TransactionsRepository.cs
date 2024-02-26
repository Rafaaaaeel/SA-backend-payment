using Microsoft.IdentityModel.Tokens;

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
        
        IEnumerable<InstallmentResponse> installments = InstallmentHelper.GetInstallmentsFromTheCurrentMonthExpiringInCard(card);

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

    public async Task<TransactionsResponse> GetLastTransactionsFromCard(int cardId)
    {
        CardResponse card = await _cardRepository.GetCard(cardId);

        DateTime today = DateTime.Today;
        DayOfWeek currentDayOfWeek = today.DayOfWeek;
        int daysToSubtract = (int)currentDayOfWeek - 1;
        DateTime startOfWeek = today.AddDays(-daysToSubtract);
        DateTime endOfWeek = startOfWeek.AddDays(7);

        if (card.Months.ToList().IsNullOrEmpty()) return new TransactionsResponse();
        
        IEnumerable<InstallmentResponse> installments = InstallmentHelper
            .GetLastInstallmentsFromTheCurrentMonthInCard(card)
            .Where(i => i.CreatedDate >= startOfWeek && i.CreatedDate < endOfWeek);

        ICollection<InstallmentResponse> response = [];
        
        int length = installments.ToList().Count > 5 ? 4 : installments.ToList().Count;

        if (length == 0) return new TransactionsResponse();

        for (int index = 0; index < length; index++)
        {   
            response.Add(installments.ToList()[index]);
        }
        
        return new TransactionsResponse() { LastTransaction = response };
    }

}