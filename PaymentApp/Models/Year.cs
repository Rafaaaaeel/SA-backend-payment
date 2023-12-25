namespace PaymentApp.Models
{
    public class Year
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? Total { get; set; }
        public int? Quantity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public required Month Month { get; set; }
        public ICollection<Installment> Installments { get; set; } = new HashSet<Installment>();
    }
}