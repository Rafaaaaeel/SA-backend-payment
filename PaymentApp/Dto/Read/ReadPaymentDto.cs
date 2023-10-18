using PaymentApp.Models;

namespace PaymentApp.Dto.Read
{
    public class ReadPaymentDto
    {
        public required string Name { get; set; }
        public required string Colour { get; set; }
        public required string Image { get; set; }
        public string? Description { get; set; }
        public decimal Total { get; set; } = 0;
        public ICollection<Installment> Installments { get; set; } = new HashSet<Installment>();
    }
}