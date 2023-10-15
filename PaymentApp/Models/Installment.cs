namespace PaymentApp.Models
{
    public class Installment 
    {
        public int Id { get; set; }
        public Decimal Value { get; set; }
        public int? Total { get; set; }
        public DateTime? Initial { get; set; }
        public DateTime? Final { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public IEnumerable<PaymentInstallment>? PaymentInstallments { get; set; }
        public IEnumerable<InstallmentTag>? Tags { get; set; }
    }
}