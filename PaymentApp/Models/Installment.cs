namespace PaymentApp.Models
{
    public class Installment 
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public int? Total { get; set; }
        public required int Quantity { get; set; }
        public DateTime? Date { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public required Year Year { get; set; }
    }
}