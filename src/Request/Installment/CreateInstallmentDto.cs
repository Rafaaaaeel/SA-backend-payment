namespace Sa.Payment.Api.Request;
public class InstallmentRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Value { get; set; }
    public required decimal Total { get; set; }
    public required int Quantity { get; set; }
    public DateTime? Date { get; set; }
}