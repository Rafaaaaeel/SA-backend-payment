namespace Sa.Payment.Api.Interface;

public interface ITransactionsRepository
{
    Task<TransactionsResponse> GetExpiringTransactionsFromCard(int cardId);
    Task<TransactionsResponse> GetLastTransactionsFromCard(int cardId);
}