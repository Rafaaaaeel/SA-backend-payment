namespace Sa.Payment.Api.Models;

public class Year
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Total { get; set; } = 0.0m;
    public int? Quantity { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public required Month Month { get; set; }
    public ICollection<Installment> Installments { get; set; } = new HashSet<Installment>();
}