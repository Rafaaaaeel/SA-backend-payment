namespace PaymentApp.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Colour { get; set; }
        public required string Image { get; set; }
        public string? Description { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<Installment>? Installments { get; set; }
        public IEnumerable<PaymentInstallment>? PaymentInstallment { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public required string EmailOwner { get; set; }
    }
}