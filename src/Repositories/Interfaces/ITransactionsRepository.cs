namespace Sa.Payment.Api.Interface;

public interface ITransactionsRepository
{
    Task<TransactionsResponse> GetLastTransactionsFromCard(int cardId);
}