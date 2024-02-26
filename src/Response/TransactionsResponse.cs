namespace Sa.Payment.Api.Response;

public class TransactionsResponse
{
    public ICollection<InstallmentResponse>? LastTransaction { get; set; }
    public ICollection<Transaction>? Expiring { get; set; }
}