namespace PaymentApp.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Installment>? installments { get; set; }
        public DateTime CreationDate { get; set; }
    }
}