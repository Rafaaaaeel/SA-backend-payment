namespace Sa.Payment.Api.Response;

public class SummaryResponse
{
    public decimal? Total { get; set; }
    public required IEnumerable<Card> Cards { get; set; }
    public IEnumerable<InstallmentResponse>? LastTrasactions { get; set; }
    public TransactionsResponse? ExpiringInstallments { get; set; }
}