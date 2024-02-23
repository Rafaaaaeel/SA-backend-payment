namespace Sa.Payment.Api.Interface;

public interface ITransactionsRepository
{
    Task<IEnumerable<InstallmentResponse>> GetLastTransactionsFromCard(int cardId);
}