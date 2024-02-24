namespace Sa.Payment.Api.Interface;

public interface ITransactionsRepository
{
    Task<TransactionsResponse> GetExpiringTransactionsFromCard(int cardId);
    Task<IEnumerable<InstallmentResponse>> GetLastTransactionsFromCard(int cardId);
}