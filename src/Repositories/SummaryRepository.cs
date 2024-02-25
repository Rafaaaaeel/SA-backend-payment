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
        
        int cardId = cards.ToList()[0].Id;

        IEnumerable<InstallmentResponse> lastTransactions = await _transactionsRepository.GetLastTransactionsFromCard(cardId);
        TransactionsResponse expiring = await _transactionsRepository.GetExpiringTransactionsFromCard(cardId);

        return new SummaryResponse() { Cards = cards, ExpiringInstallments = expiring, LastTrasactions = lastTransactions};
    }
}