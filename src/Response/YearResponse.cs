namespace Sa.Payment.Api.Response;

public class YearResponse
{
    public required string Name { get; set; }
    public decimal Total { get; set; } = 0.0m;
    public int? Quantity { get; set; }
    public IEnumerable<InstallmentResponse> Installments { get; set; } = new HashSet<InstallmentResponse>();
}