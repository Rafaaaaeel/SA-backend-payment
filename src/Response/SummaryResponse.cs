namespace Sa.Payment.Api.Response;

public class SummaryResponse
{
    public required IEnumerable<Card> Cards { get; set; }
    public IEnumerable<InstallmentResponse>? LastTrasactions { get; set; }
    public TransactionsResponse? ExpiringInstallments { get; set; }
}