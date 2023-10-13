namespace PaymentApp.Models
{
    public class PaymentInstallment 
    {
        public int PaymentId { get; set; }
        public int InstallementId { get; set; }
        public Payment? Payment { get; set; }
        public ICollection<Installment>? Installments { get; set; }
    }
}