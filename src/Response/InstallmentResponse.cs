namespace Sa.Payment.Api.Response;

public class InstallmentResponse 
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Value { get; set; }
    public decimal Total { get; set; }
    public required int Quantity { get; set; }
    public int CurrentParcel { get; set; }
    public DateTime? CreatedDate { get; set; }
}