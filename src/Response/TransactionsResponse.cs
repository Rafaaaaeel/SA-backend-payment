namespace Sa.Payment.Api.Response;

public class TransactionsResponse
{
    public required ICollection<Transaction> Expiring { get; set; }
}