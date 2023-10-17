namespace PaymentApp.Models
{
    public class Installment 
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int? Total { get; set; }
        public DateTime? Initial { get; set; }
        public DateTime? Final { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public required Payment Payment { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}