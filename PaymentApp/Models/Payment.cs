namespace PaymentApp.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Installment> installments { get; set; }
    }
}