namespace PaymentApp.Models
{
    public class PaymentTag
    {
        public int PaymentId { get; set; }
        public int TagId { get; set; }
        public Installment? Installment { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}