namespace PaymentApp.Models
{
    public class Installment 
    {
        public int Id { get; set; }
        public Decimal Value { get; set; }
        public DateTime? initial { get; set; }
        public DateTime? final { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public IEnumerable<PaymentInstallment>? PaymentInstallments { get; set; }
        public IEnumerable<InstallmentTag>? Tags { get; set; }
    }
}