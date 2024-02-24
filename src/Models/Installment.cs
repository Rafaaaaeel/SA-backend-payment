namespace Sa.Payment.Api.Models;

public class Installment 
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Value { get; set; }
    public decimal Total { get; set; }
    public decimal MaxExpanse { get; set; } = 0;
    public required int Quantity { get; set; }
    public int CurrentParcel { get; set; } = 0;
    public DateTime? Date { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public required Year Year { get; set; }
}