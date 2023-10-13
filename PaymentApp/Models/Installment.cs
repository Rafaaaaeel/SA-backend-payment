namespace PaymentApp.Models
{
    public class Installment 
    {
        public int Id { get; set; }
        public string Colour { get; set; } = string.Empty;
        public Decimal Value { get; set; }
        public DateTime? initial { get; set; }
        public DateTime? final { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<PaymentInstallment>? PaymentInstallments { get; set; }
        public ICollection<InstallmentTag>? Tags { get; set; }
    }
}