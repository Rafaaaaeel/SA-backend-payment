using Microsoft.IdentityModel.Tokens;

namespace Sa.Payment.Api.Repositories;

public class SummaryRepository : ISummaryRepository
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly ICardRepository _cardRepository;

    public SummaryRepository(ITransactionsRepository transactionsRepository, ICardRepository cardRepository)
    {
        _transactionsRepository = transactionsRepository;
        _cardRepository = cardRepository;
    }

    public async Task<SummaryResponse> GetSummary(string email)
    {
        IEnumerable<Card> cards = _cardRepository.GetAllCards(email);
        
        if (cards.ToList().IsNullOrEmpty()) return new SummaryResponse() { Cards = cards };

        decimal currentMonthTotal = 0;

        foreach (var card in cards)
        {
            Month? month = card.Months.FirstOrDefault(m => m.Name == DateTime.UtcNow.GetMonthAbbreviatedName());

            if (month is null) continue;

            Year? year = month.Year.FirstOrDefault(y => y.Name == DateTime.UtcNow.Year.ToString());

            if (year is null) continue;

            currentMonthTotal += year.Total;
        }

        Card firstCard = cards.ToList()[0];
        
        if (firstCard.Months.ToList().IsNullOrEmpty()) return new SummaryResponse() { Cards = cards }; 

        IEnumerable<InstallmentResponse> lastTransactions = await _transactionsRepository.GetLastTransactionsFromCard(firstCard.Id);

        TransactionsResponse expiring = await _transactionsRepository.GetExpiringTransactionsFromCard(firstCard.Id);

        return new SummaryResponse() { Total = currentMonthTotal, Cards = cards, ExpiringInstallments = expiring, LastTrasactions = lastTransactions};
    }
}