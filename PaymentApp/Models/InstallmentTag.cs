namespace PaymentApp.Models
{
    public class InstallmentTag
    {
        public int InstallementId { get; set; }
        public int TagId { get; set; }
        public Installment? Installment { get; set; }
        public Tag? Tag { get; set; }
    }
}